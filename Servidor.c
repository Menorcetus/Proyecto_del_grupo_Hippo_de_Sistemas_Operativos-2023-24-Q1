#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
#include <pthread.h>
#include <my_global.h>

#define Max 30
#define Max2 100
#define buffer 512

pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

typedef struct{
	int con;
	char Nombre [Max];
	int jugando;
} Usuario;

typedef struct {
	Usuario usuarios[Max2];
	int num;
} ListaUsuarios;

ListaUsuarios Usuarios;
int  conectados_num;
int Usuarios_num;

int GenerarListaUsuarios(ListaUsuarios *lista, MYSQL *conn){
	// Esta funcion modifica la lista y devuelve el numero de usuarios en la base de datos
	// Si no se puede conectar a la base de datos devuelve -1
	int err;
	MYSQL_RES * resultado;
	MYSQL_ROW * row;
	char consulta[buffer];
	strcpy(consulta, "SELECT Nombre FROM Usuarios");

	err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		return -1;
	}

	resultado = mysql_store_result (conn);
	row = mysql_fetch_row(resultado);
	int num = 0;
	while (row != NULL)
	{
		strcpy(lista->usuarios[num].Nombre, row[0]);
		lista->usuarios[num].con = 0;
		lista->usuarios[num].jugando = 0;
		// printf("%s\n",lista->usuarios[num].Nombre);
		num++;
		row = mysql_fetch_row(resultado);

	}
	lista->num = num;
	return num;
}

int ActualizarListaUsuarios(ListaUsuarios *lista, char nombre[Max]){
	// Funcion para concatenar un usuario a la lista, se usara para Register de forma mas ordenada
	// num declara la ultima posicion de la lista
	int num = lista->num;
	// Detecta si la lista esta llena
	if(num < Max2){
		strcpy(lista->usuarios[num].Nombre, nombre);
		lista->usuarios[num].con = 0;
		lista->usuarios[num].jugando = 0;
		num++;
		return 0;
	}
	else
		return 1;
}	

int DarConectados(ListaUsuarios *lista, ListaUsuarios *conectados){
	// Rellena una lista de usuarios conectados con la info de la lista general
	int j = 0;
	for(int i=0; i <= conectados->num; i++)
	{	
		strcpy(conectados->usuarios[j].Nombre,"\0");
		conectados->usuarios[j].con = NULL;
		conectados->usuarios[j].jugando = NULL;
		j++;
	}
	conectados->num = 0;
	j=0;
	for(int i=0; i <= lista->num; i++)
	{
		if(lista->usuarios[i].con == 1)
		{	// no se si funciona jajajaj
			strcpy(conectados->usuarios[j].Nombre,lista->usuarios[i].Nombre);
			conectados->usuarios[j].con = lista->usuarios[i].con;
			conectados->usuarios[j].jugando = lista->usuarios[i].jugando;
			conectados->num++;
			j++;
		}
	}
	// El numero de personas conectadas
	return j;
}

int Register(char *p, char consulta[buffer], MYSQL *conn, ListaUsuarios *lista){
	// Hacemos la querry para detectar si el usuario ya existe
	int err;
	MYSQL_RES *resultado;
	
	p = strtok( NULL, "/");
	char nombre[30];
	strcpy (nombre, p);

	strcpy(consulta, "SELECT * FROM Usuarios WHERE Nombre = '");
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

	printf("Hay %i usuarios con ese nombre.\n", fila);
	
	// El usuario ya existe
	if(fila != 0)
		return 2;
	memset(consulta, 0, buffer);

	// El usuario aun no existe
	p = strtok( NULL, "/");
	char mail[40];
	strcpy (mail,p);
	printf("mail: %s \n",mail);

	p = strtok( NULL, "/");
	char password[20];
	strcpy (password,p);
	printf("pass: %s \n",password);

	
	
	strcpy(consulta, "INSERT INTO Usuarios ");
	strcat(consulta, "(Nombre, Correo, Password) VALUES ('");

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
	// Ahora hay que actualizar la lista de usuarios
	err = ActualizarListaUsuarios(lista, nombre);
	if (err == 1){
		printf("No se ha podidio agregar el usuario a la lista\n");
		return 1;
	}
	else
		return 0;			
}

int LogIN(char *p, MYSQL *conn, char info[buffer], ListaUsuarios *lista){
	// SELECT PASSWORD FROM USERS WHERE NOMBRE = <nombre>;
	char consulta[buffer];
	int err;
	MYSQL_RES *resultado;	
	MYSQL_ROW *row;
	
	p = strtok( NULL, "/");
	char nombre[30];
	strcpy (nombre, p);

	p = strtok( NULL, "/");
	char password[30];
	strcpy (password, p);

	strcpy(consulta, "SELECT Password FROM Usuarios WHERE Nombre = '");
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

	// La password coincide con la que se ha dado
	if(strcmp(password, realpass) == 0)
	{
		mysql_free_result(resultado);
		strcpy(consulta, "SELECT Nombre, Correo FROM Usuarios WHERE Nombre = '");
		strcat(consulta, nombre);
		strcat(consulta, "'");
		err = mysql_query(conn, consulta);
		
		// Devuelve diversa info del usuario al cliente durante el inicio de sesion
		resultado = mysql_store_result(conn);
		row = mysql_fetch_row(resultado);
		strcpy(info,nombre);
		strcat(info,"/");
		strcat(info,row[1]);
		// Busca el usuario en la lista de usuarios y lo define como conectado
		int i = 0;
		while (strcmp(lista->usuarios[i].Nombre, nombre) != 0)
			i++;
		// Debugg
		printf("%s\n",lista->usuarios[i].Nombre);
		lista->usuarios[i].con = 1; 
		printf("%i\n",lista->usuarios[i].con);
		return 0;
	}
	// Password incorrecta
	else	
		return 2;
}

int LogOUT(char *p, ListaUsuarios *lista){
	// Cambiaremos la lista de conectados para decir que se ha cerrado sesion
	p = strtok( NULL, "/");
	char nombre[30];
	strcpy (nombre, p);

	int i = 0;
	while (strcmp(lista->usuarios[i].Nombre, nombre) != 0)
		i++;
	// Debugg
	printf("%s\n",lista->usuarios[i].Nombre);
	lista->usuarios[i].con = 0; 
	printf("%i\n",lista->usuarios[i].con);
	return 0;
}

void *AtenderCliente(void *socket){
	// Iniciamos el socket dentro del thread
	int sock_conn;
	int *s;
	s= (int*) socket;
	sock_conn= *s;
	
	// Empezamos bucle para el analisis de peticiones
	int  terminar = 0;
	while (terminar == 0)
	{	
		// Re/iniciamos los buffers
		char buff[buffer];
		char buff2[buffer];
		char respuesta[buffer];
		//--------------------------SQL Main Connection-------------------------
		MYSQL *conn;
		int err;
		char consulta [buffer];
		//Creamos una conexion al servidor MYSQL 
		conn = mysql_init(NULL);
		if (conn==NULL) {
			printf ("Error al crear la conexion: %u %s\n", 
					mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
		//inicializar la conexion
		conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "TG3_BDDJuego",0, NULL, 0);
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
		switch (codigo){
			// Registro de usuario
			// Recibe: 1/<Nombre>/<Correo>/<Password>
			case 1:	{
				// Se niega el acceso a otros theads para evitar registrar dos 
				// usuarios con la misma ID
				pthread_mutex_lock(&mutex);
				int res = Register(p, consulta, conn, &Usuarios);
				// printf("Respuesta es: %i\n", res);
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
				break;
			}
			// Inicio de sesion
			// Recibe: 2/<Nombre>/<Password>
			case 2:{	
				char info[buffer];
				pthread_mutex_lock(&mutex);
				int res = LogIN(p, conn, info, &Usuarios);
				pthread_mutex_unlock(&mutex);
				// printf("res es: %i", res);
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
				break;
			}
			// Dar lista de conectados a peticion
			// Recibe: 3
			case 3:{
				ListaUsuarios Conectados;
				conectados_num = DarConectados(&Usuarios, &Conectados);
				sprintf(respuesta,"%d",conectados_num);
				for(int i = 0; i <= conectados_num; i++ ){
					sprintf(respuesta,"%s/%s",respuesta,Conectados.usuarios[i].Nombre);
					// Debugg para consola
					printf("Conectado: %s.\n", Conectados.usuarios[i].Nombre);
				}
				break;
			}
			// LogOut
			// Recibe: 4/<Nombre>
			case 4:{
				pthread_mutex_lock(&mutex);
				int res = LogOUT(p, &Usuarios);
				pthread_mutex_unlock(&mutex);
				if(res == 0)
					sprintf(respuesta,"Se ha cerrado la sesion\n");
				break;
			}
			// Mensaje de desconexion
			case 0:{
				terminar = 1;
				break;
			}
		}
		// Si el mensaje no es de desconexion, cerramos la conexion a mysql y enviamos 
		// la respuesta al cliente
		if (codigo != 0){
			mysql_close(conn);
			printf("Respuesta: %s\n", respuesta);
			write(sock_conn, respuesta, strlen(respuesta));
		}
	}
	close(sock_conn);
}


int main(int argc, char *argv[]){
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
	// escucharemos en el port 50060
	serv_adr.sin_port = htons(50060);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	// La cola de peticiones pendientes no podra ser superior a 4
	if (listen(sock_listen, 4) < 0)
		printf("Error en el Listen");
	
	MYSQL *conn;
	int err;
	char consulta [buffer];
	//Creamos una conexion al servidor MYSQL 
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//inicializar la conexion
	conn = mysql_real_connect (conn, "shiva2.upc.es","root", "mysql", "TG3_BDDJuego",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}

	// Rellenamos la lista de usuarios en el servidor con la informacion del la BBDD
	Usuarios_num = GenerarListaUsuarios(&Usuarios, conn);
	mysql_close(conn);
	// Cerramos conexion mysql para ahorrar recursos
	
	// Generamos las variables necesarias para la utilizacion de threads para cada cliente
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
