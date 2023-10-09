#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>

int main(int argc, char *argv[])
{
	//------------------------------Conexión Servidor-Cliente-------------------------------------
	
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char buff[512];
	char buff2[512];
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
	// Atenderemos solo 5 peticione
	for(i=0;i<7;i++){
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexi?n\n");
		//sock_conn es el socket que usaremos para este cliente
		
		// Ahora recibimos su nombre, que dejamos en buff
		ret=read(sock_conn,buff, sizeof(buff));
		printf ("Recibido\n");
		
		// Tenemos que a?adirle la marca de fin de string 
		// para que no escriba lo que hay despues en el buffer
		buff[ret]='\0';
		//Escribimos el nombre en la consola
		
		printf ("Se ha conectado: %s\n",buff);
		
		//--------------------------------SQL---------------------------------
		
		MYSQL *conn;
		int err;
		// Estructura especial para almacenar resultados de consultas 
		MYSQL_RES *resultado;
		MYSQL_ROW row;
		char consulta [80];
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
		
		err=mysql_query (conn, "SELECT ID FROM USUARIOS");
		if (err!=0) {
			printf ("Error al consultar datos de la base %u %s\n",
					mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
		
		resultado = mysql_store_result (conn);
		
		row = mysql_fetch_row (resultado);
		
		if (row == NULL)
			printf ("No se han obtenido datos en la consulta\n");
		
		
		else
			while (row !=NULL) {
				// obtenemos la siguiente fila
				row = mysql_fetch_row (resultado);
		}
		
		
		// ---------------------------------Registro y Inicio Sesión-------------------------------
		
		char *p = strtok( buff, "/");
		int codigo =  atoi (p);
		
		if (codigo == 1)
		{
			p = strtok( NULL, "/");
			char nombre[20];
			strcpy (nombre, p);
			p = strtok( NULL, "/");
			char mail[40];
			strcpy (mail,p);
			p = strtok( NULL, "/");
			char password[20];
			strcpy (password,p);
			
			int ID = atoi(row);
			
			err = scanf ("%s %s %s", nombre, mail, password);
			if (err!=4) {
				printf ("Error al introducir los datos \n");
				exit (1);
			}
			strcpy (consulta, "INSERT INTO USUARIOS VALUES ('");
			sprintf(IDs, "%d", ID);
			strcat (consulta, IDs); 
			strcat (consulta, "','");
			
			strcat (consulta, nombre); 
			strcat (consulta, "','");
			
			strcat (consulta, mail); 
			strcat (consulta, "','");
			
			strcat (consulta, password); 
			strcat (consulta, ");");
			
			printf("consulta = %s\n", consulta);
			// Ahora ya podemos realizar la insercion 
			err = mysql_query(conn, consulta);
			if (err!=0) {
				printf ("Error al introducir datos la base %u %s\n", 
						mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			// cerrar la conexion con el servidor MYSQL 
			mysql_close (conn);
			exit(0);
		]
		
		else if (codigo == 2)
		{
			p = strtok( NULL, "/");
			char nombre[20];
			strcpy (nombre, p);
			p = strtok( NULL, "/");
			char password[20];
			strcpy (password,p);
		}
	}
}
