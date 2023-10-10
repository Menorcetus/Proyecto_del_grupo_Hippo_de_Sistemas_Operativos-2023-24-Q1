#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>

int Register(char *p, int ID, char consulta[512], char conn[])
{
	int err;
	MYSQL_RES *resultado;

	strcpy(consulta, "SELECT * FROM USUARIOS WHERE ID = ");
	strcat(consulta, ID);

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
	char nombre[20];
	strcpy (nombre, p);
	printf("Nombre %s \n",nombre);

	p = strtok( NULL, "/");
	char mail[40];
	strcpy (mail,p);
	printf("mail %s \n",mail);

	p = strtok( NULL, "/");
	char password[20];
	strcpy (password,p);
	printf("pass %s \n",password);

	char IDs[11];
	
	strcpy(consulta, "INSERT INTO USUARIOS ");
	strcat(consulta, "(ID, NOMBRE, CORREO, PASSWORD) VALUES (");
		
	sprintf(IDs, "%d", ID);
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

int main(int argc, char *argv[])
{
	//------------------------------Conexi�n Servidor-Cliente-------------------------------------
	
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char buff[512];
	char buff2[512];
	char respuesta[512];
	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Fem el bind al port
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// escucharemos en el port 9050
	serv_adr.sin_port = htons(9070);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	//La cola de peticiones pendientes no podr? ser superior a 4
	if (listen(sock_listen, 2) < 0)
		printf("Error en el Listen");
	
	int i;
	// Atenderemos a infinitas peticiones
	for(;;){
		//--------------------------------SQL---------------------------------
		
		MYSQL *conn;
		int err;
		// Estructura especial para almacenar resultados de consultas 
		MYSQL_RES *resultado;
		MYSQL_ROW row;
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
			
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion \n");
		//sock_conn es el socket que usaremos para este cliente
					// Esta parte la repito aqui para cojer el siguiente ID
			err=mysql_query (conn, "SELECT * FROM USUARIOS");
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			int fila;
			resultado = mysql_store_result (conn);
			fila = mysql_num_rows(resultado);
		
			printf("Hay %i filas\n", fila);

			// Ahora recibimos su nombre, que dejamos en buff
			ret=read(sock_conn,buff, sizeof(buff));
			printf ("Recibido\n");
			
			// Tenemos que a?adirle la marca de fin de string 
			// para que no escriba lo que hay despues en el buffer
			buff[ret] = '\0';
			//Escribimos el nombre en la consola
			
			printf ("Se ha conectado: %s\n",buff);
			
			
			// ---------------------------------Registro y Inicio Sesi�n-------------------------------
			
			char *p = strtok( buff, "/");
			int codigo =  atoi (p);
			printf("Codigo es : %d", codigo);
		int  terminar = 0;
		while (terminar == 0){

			
			if (codigo == 0)
				terminar = 1;
			else if (codigo == 1)
			{
				int ID;
				if(resultado != NULL)
					ID = fila;
				else 
					ID = 1;
				int res;
				printf("ID es: %d", ID);
				res = Register(p, ID, consulta, conn);
				printf("res es: %d", res);
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
					sprintf(respuesta,"Este usuario ya estaba registrado");
				}	
			}
			
			else if (codigo == 2)
			{
				p = strtok( NULL, "/");
				char nombre[20];
				strcpy (nombre, p);
				p = strtok( NULL, "/");
				char password[20];
				strcpy (password,p);
			}

			if (codigo != 0){
				printf("Respuesta: %s\n", respuesta);
				write(sock_conn, respuesta, strlen(respuesta));
			}
		}
	}
}
