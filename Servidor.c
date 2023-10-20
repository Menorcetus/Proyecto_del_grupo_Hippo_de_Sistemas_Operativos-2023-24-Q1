#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
#include <pthread.h>

pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

int SiguienteID(MYSQL *conn)
{	
	int err;
	// Estructura especial para almacenar resultados de consultas 
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta [512];
	// Comprobamos cual es la ultima ID, el numero de filas existentes sera la proxima ID
	err=mysql_query (conn, "SELECT * FROM USERS");
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	int fila;
	resultado = mysql_store_result (conn);
	fila = mysql_num_rows(resultado);
	fila++;
	return fila;
}

int Register(char *p, int ID, char consulta[512], MYSQL *conn)
{
	int err;
	MYSQL_RES *resultado;
	char IDs[11];	
	
	p = strtok( NULL, "/");
	char nombre[30];
	strcpy (nombre, p);

	strcpy(consulta, "SELECT * FROM USERS WHERE ID = ");
	sprintf(IDs, "%d", ID);
	strcat(consulta, IDs);
	strcat(consulta," OR NOMBRE = '");
	strcat(consulta, nombre);
	strcat(consulta,"'");

	err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		return 1;
	}
	int fila;
	resultado = mysql_store_result (conn);
	fila = mysql_num_rows(resultado);

	printf("Hay %i filas\n", fila);
	
	if(fila != 0)
		return 2;
	memset(consulta, 0, 512);

	p = strtok( NULL, "/");
	char mail[40];
	strcpy (mail,p);
	printf("mail: %s \n",mail);

	p = strtok( NULL, "/");
	char password[20];
	strcpy (password,p);
	printf("pass: %s \n",password);

	
	
	strcpy(consulta, "INSERT INTO USERS ");
	strcat(consulta, "(ID, NOMBRE, CORREO, PASSWORD) VALUES (");
		

	strcat (consulta, IDs); 
	strcat (consulta, ",'");

	strcat (consulta, nombre); 
	strcat (consulta, "','");

	strcat (consulta, mail); 
	strcat (consulta, "','");

	strcat (consulta, password); 
	strcat (consulta, "')");

	printf("consulta = %s\n", consulta);
	// Ahora ya podemos realizar la insercion 
	err = mysql_query(conn, consulta);
	if (err!=0) {
		printf ("Error al introducir datos la base %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	return 0;			
}

int LogIN(char *p, MYSQL *conn, char info[512])
{
	// SELECT PASSWORD FROM USERS WHERE NOMBRE = <nombre>;
	char consulta[512];
	int err;
	MYSQL_RES *resultado;	
	MYSQL_ROW *row;
	
	p = strtok( NULL, "/");
	char nombre[30];
	strcpy (nombre, p);

	p = strtok( NULL, "/");
	char password[30];
	strcpy (password, p);

	strcpy(consulta, "SELECT PASSWORD FROM USERS WHERE NOMBRE = '");
	strcat(consulta, nombre);
	strcat(consulta, "'");
	err = mysql_query(conn, consulta);

	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	char realpass[30];	
	if (row == NULL)
	// No se ha encontrado el usuario
		return 1;
	else
	{	
	// Se convierte en un str comparable la password encontrada

		sprintf (realpass, "%s", row[0] );
	}

	if(strcmp(password, realpass) == 0)
	{
		mysql_free_result(resultado);
		strcpy(consulta, "SELECT NOMBRE, CORREO FROM USERS WHERE NOMBRE = '");
		strcat(consulta, nombre);
		strcat(consulta, "'");
		err = mysql_query(conn, consulta);

		resultado = mysql_store_result(conn);
		row = mysql_fetch_row(resultado);
		strcpy(info,nombre);
		strcat(info,"/");
		strcat(info,row[1]);
		return 0;
	}
	// La password coincide con la que se ha dado

	else	
	// Password incorrecta
		return 2;
}

void *AtenderCliente(void *socket)
{
	// Iniciamos el socket dentro del thread
	int sock_conn;
	int *s;
	s= (int*) socket;
	sock_conn= *s;
	
	int  terminar = 0;
	while (terminar == 0)
	{	
		// Re/iniciamos los buffers
		char buff[512];
		char buff2[512];
		char respuesta[512];
		//--------------------------SQL Main Connection-------------------------
		MYSQL *conn;
		int err;
		char consulta [512];
		//Creamos una conexion al servidor MYSQL 
		conn = mysql_init(NULL);
		if (conn==NULL) {
			printf ("Error al crear la conexion: %u %s\n", 
					mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
		//inicializar la conexion
		conn = mysql_real_connect (conn, "localhost","root", "mysql", "db",0, NULL, 0);
		if (conn==NULL) {
			printf ("Error al inicializar la conexion: %u %s\n", 
					mysql_errno(conn), mysql_error(conn));
			exit (1);
		}				
		//--------------------------SQL Main Connection-------------------------	
		// Ahora recibimos la request del cliente, que dejamos en buff
		int ret =read(sock_conn,buff, sizeof(buff));
		printf ("Recibido\n");
		
		// Tenemos que agregar la marca de fin de string 
		// para que no escriba lo que hay despues en el buffer
		buff[ret] = '\0';

		// Detectamos el servicio que se pide
		char *p = strtok(buff, "/");
		int codigo = atoi (p);
		printf("El codigo es: %i\n",codigo);
		// A partir de aqui se seleccionara el servicio y se ejecutara
		// Registro de usuario
		if (codigo == 1)
		{	
			// Se niega el acceso a otros theads para evitar registrar dos 
			// usuarios con la misma ID
			pthread_mutex_lock(&mutex);
			int fila = SiguienteID(conn);
			printf("La proxima ID a asignar sera: %i \n", fila);

			int res = Register(p, fila, consulta, conn);
			printf("Respuesta es: %i\n", res);
			pthread_mutex_unlock(&mutex);
			if (res == 0)
			{
				sprintf(respuesta,"Se ha registrado el usuario");
			}
			else if (res == 1)
			{
				sprintf(respuesta,"Error durante el registro");
			}
			else if (res == 2)
			{	
				// Una de las condiciones es que tengan misma ID, de todas formas
				// ya no tendria que ocurrir nunca
				sprintf(respuesta,"Este usuario ya estaba registrado");
			}	
		}
		// Inicio de sesion
		else if (codigo == 2)
		{
			char info[512];
			int res = LogIN(p, conn, info);
			printf("res es: %i", res);
			if (res == 0)
			{
				sprintf(respuesta,"Se ha iniciado sesion");
				// Poner funcion para buscar toda la info del jugador
				strcat(respuesta, "/");
				// De momento solo devuelve el correo con el nombre, pero
				// en el futuro se usara para enviar mas info al iniciar.
				// Por ejemplo: lista de amigos
				strcat(respuesta, info);
			}
			else if (res == 1)
			{
				sprintf(respuesta,"No se ha encontrado el usuario");
			}
			else if (res == 2)
			{
				sprintf(respuesta,"La password es incorrecta");
			}	
		}

		// Mensaje de desconexion
		else if (codigo == 0)
			terminar = 1;
		// Envio de la respuesta (+ cerrar connexion a BBDD)
		if (codigo != 0){
			mysql_close(conn);
			printf("Respuesta: %s\n", respuesta);
			write(sock_conn, respuesta, strlen(respuesta));
		}
	}
	close(sock_conn);
}


int main(int argc, char *argv[])
{
	//------------------------------Iniciamos Servidor-----------------------------------
	int sock_conn, sock_listen;
	struct sockaddr_in serv_adr;
	// INICIALIZACIONES
	// Abrimos el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Hacemos el bind al puerto, inicializa a zero serv_addr
	memset(&serv_adr, 0, sizeof(serv_adr));
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la maquina. 
	// htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// escucharemos en el port 9070
	serv_adr.sin_port = htons(9070);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	// La cola de peticiones pendientes no podra ser superior a 4
	if (listen(sock_listen, 4) < 0)
		printf("Error en el Listen");
	

	int i = 0;
	int sockets[100];
	pthread_t thread;
	// Atenderemos a infinitas peticiones
	for(;;){
		printf ("Escuchando\n");
		//sock_conn es el socket que usaremos para este cliente
		//Aqui aceptamos la peticion de del cliente
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion \n");
		// Generamos los threads para cada conexion		
		sockets[i] = sock_conn;
		pthread_create (&thread, NULL, AtenderCliente, &sockets[i]);
		i++;
	}
}
