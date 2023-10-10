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
	char IDs[11];	
	
	p = strtok( NULL, "/");
	char nombre[30];
	strcpy (nombre, p);

	strcpy(consulta, "SELECT * FROM USUARIOS WHERE ID = ");
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
	printf("mail %s \n",mail);

	p = strtok( NULL, "/");
	char password[20];
	strcpy (password,p);
	printf("pass %s \n",password);

	
	
	strcpy(consulta, "INSERT INTO USUARIOS ");
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

char Jugador_muerto(char conn) // retorna todos los jugadores cuyos personajes tienen HP = 0 Formato ID1/ID2/...IDF/
{
    MYSQL_ROW row;
	MYSQL_RES *resultado;
	char respuesta [100];
	char IDs [10];
	int err;
    err=mysql_query (conn, "SELECT ID FROM USUARIOS WHERE PERSONAJES.ID = USUARIOS.ID_PERS AND PERSONAJES.HP = 0");
    if (err!=0){
        printf ("Error al consultar datos de la base %u %s\n",
                mysql_errno(conn), mysql_error(conn));
        exit (1);
    }

    resultado = mysql_store_result (conn); 
    row = mysql_fetch_row (resultado);
	while (row!= NULL)
	{           
		if (row == NULL)
			{printf ("No se ha obtenido el usuario con HP = 0.\n");}
		else
		{
			printf ("%s tiene HP = 0.\n", row[1] ); //generar
			sprintf(IDs, "%i", row[0]);
			strcat(IDs, "/");
			strcat(respuesta, IDs);
			row = mysql_fetch_row (resultado); 

		}

	}

    // cerrar la conexion con el servidor MYSQL 
	return(respuesta);
    mysql_close (conn);
    exit(0);
 }

 char BuscarUsuarios(char ID, char conn[])
{
	
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[80];
	char respuesta [100];
	int err;
	char IDs[10];
	
	sprintf(consulta, "SELECT ID_PARTIDA FROM USUARIOS WHERE ID = %s",ID);
	err = mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL)
		printf ("No se han obtenido datos en la consulta\n");
	else{
		while (row !=NULL) {
			printf ("ID: %d\n", atoi(row[0]));
			// obtenemos la siguiente fila
			sprintf(IDs, "%i", row[0]);
			strcat(IDs, "/");
			strcat(respuesta, IDs);
			row = mysql_fetch_row (resultado);
		}
	}
	return(respuesta);
	mysql_close (conn);
	exit(0);
}

char BuscarPersonaje(char ID, char conn[])
{
	
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	char consulta[80];
	char respuesta [100];
	int err;
	char IDs[10];
	
	sprintf(consulta, "SELECT ID_PARTIDA FROM USUARIOS WHERE ID_PERS = %s",ID);
	err = mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL)
		printf ("No se han obtenido datos en la consulta\n");
	else{
		while (row !=NULL) {
			printf ("ID: %d\n", atoi(row[0]));
			// obtenemos la siguiente fila
			sprintf(IDs, "%i", row[0]);
			strcat(IDs, "/");
			strcat(respuesta, IDs);
			row = mysql_fetch_row (resultado);
		}
	}
	return(respuesta);
	mysql_close (conn);
	exit(0);
}



int LogIN(char *p, char consulta[512], char conn[])
{
	// SELECT PASSWORD FROM USUARIOS WHERE NOMBRE = <nombre>;
	int err;
	MYSQL_RES *resultado;	
	MYSQL_ROW *row;
	
	p = strtok( NULL, "/");
	char nombre[30];
	strcpy (nombre, p);

	p = strtok( NULL, "/");
	char password[30];
	strcpy (password, p);

	strcpy(consulta, "SELECT PASSWORD FROM USUARIOS WHERE NOMBRE = '");
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
	// La password coincide con la que se ha dado
		return 0;
	else	
	// Password incorrecta
		return 2;
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
		printf ("Escuchando\n");		

		
		// ---------------------------------Registro y Inicio Sesi�n-------------------------------
		


		int  terminar = 0;
		while (terminar == 0)
		{
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
			// Comprobamos cual es la ultima ID, el numero de filas existentes sera la proxima ID
			err=mysql_query (conn, "SELECT * FROM USUARIOS");
			if (err!=0) {
				printf ("Error al consultar datos de la base %u %s\n",
						mysql_errno(conn), mysql_error(conn));
				exit (1);
			}
			int fila;
			resultado = mysql_store_result (conn);
			fila = mysql_num_rows(resultado);
			fila++;

			printf("Hay %i filas\n", fila);
			//--------------------------------SQL---------------------------------			
			//sock_conn es el socket que usaremos para este cliente
			//Aqui aceptamos la peticion de del cliente
			sock_conn = accept(sock_listen, NULL, NULL);
			printf ("He recibido conexion \n");
			
			// Ahora recibimos su nombre, que dejamos en buff
			ret =read(sock_conn,buff, sizeof(buff));
			printf ("Recibido\n");
			
			// Tenemos que a?adirle la marca de fin de string 
			// para que no escriba lo que hay despues en el buffer
			buff[ret] = '\0';
			//Escribimos el nombre en la consola

			char *p = strtok(buff, "/");
			int codigo = atoi (p);

			if (codigo == 1)
			{
				int res = Register(p, fila, consulta, conn);
				printf("res es: %i", res);
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
				int res = LogIN(p, consulta, conn);
				printf("res es: %i", res);
				if (res == 0)
				{
					sprintf(respuesta,"Se ha iniciado sesion");
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

			else if (codigo == 3)
			{
				char jud_dead = Jugador_muerto(conn);
				sprintf(respuesta, "%s", jud_dead);
	
			}

			else if (codigo == 4)
			{
				char Busc_Pers = BuscarPersonaje(ID,conn);
				sprintf(respuesta, "%s", Busc_Pers);
	
			}

			else if (codigo == 5)
			{
				char Busc_Us = BuscarUsuarios(ID,conn);
				sprintf(respuesta, "%s", Busc_Us);
	
			}



			else if (codigo == 0)
				terminar = 1;
			if (codigo != 0){
				mysql_close(conn);
				printf("Respuesta: %s\n", respuesta);
				write(sock_conn, respuesta, strlen(respuesta));
			}
		}
		close(sock_conn);
	}
}
