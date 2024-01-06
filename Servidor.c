#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <mysql.h>
#include <pthread.h>
//#include <my_global.h>


// Variables globales, usados para dimensionar arrays a lo largo del programa
#define Max 30
#define Max2 100
#define buffer 512
#define MaxBuffer 1490
#define MAX 100

// Variables para la implementacion de una lista de sockets con cross threading
int socket_num = 0;
int sockets[100];
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

/*
Estructura de usuario:
	-> un booleano para indicar si el usuario esta conectado
	-> un string para el nombre
	-> un bool indicando si el usuario esta jugando
	-> un int para guardar el socket
	-> una estructura para listarlos
*/
typedef struct{
	int con;
	char Nombre [Max];
	int jugando;
	int Socket;
} Usuario;

typedef struct {
	Usuario usuarios[Max2];
	int num;
} ListaUsuarios;
/*
Estructura para almacenar partida:
	-> un identificador
	-> una lista de los jugadores (solo se usan dos)
	-> un array de dos int para almacenar los puntos por jugador
	-> un booleano sobre si la partida ha iniciado o no
	-> un int que guarda el numero de personas que han pasado turno. Se reinicia al 
	   acabar cada turno.
	-> un int con el numero total de turnos que se han acordado: 1,3,5 (no implementado)
	-> un int con el numero del turno en juego: 1,2,3
	-> un int con el numero de cartas por baraja: 6-10
	-> una estructura para listarlos
*/
typedef struct{
	int id;
	Usuario jugadores[2];
	int puntos[2];
	int init;
	int pasados;
	int num_turnos;
	int turno_actual;
	int num_cartas;
} Partida;

typedef struct {
	Partida partidas[Max];
	int num;
} ListaPartidas;

/*
Estructura para almacenar las cartas:
	-> un int para identificar
	-> un string para el nombre
	-> un int para la fuerza
	-> un int para identificar el tipo: 
 */

typedef struct{
	int id;
	char nombre[MAX];
	int fuerza;
	int tipo;
} Carta;

typedef struct {
	Carta cartas[Max];
	int num;
} ListaCartas;

// Inicializacion de listas + contadores globales
ListaUsuarios Usuarios;
ListaUsuarios Conectados;
int  conectados_num;
int Usuarios_num;
ListaPartidas Partidas;
ListaCartas Cartas;

//=============================================================================================================
// Funciones:

int GenerarListaUsuarios(ListaUsuarios *lista, MYSQL *conn){
	// Rellena la lista y devuelve el numero de usuarios en la base de datos

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
		lista->usuarios[num].Socket = NULL;
		// printf("%s\n",lista->usuarios[num].Nombre);
		num++;
		row = mysql_fetch_row(resultado);

	}
	lista->num = num;
	return num;
}

int ActualizarListaUsuarios(ListaUsuarios *lista, char nombre[Max]){
	// Concatena un usuario a la lista, se usara para Register de forma mas ordenada

	// num declara la ultima posicion de la lista
	int num = lista->num;
	// Detecta si la lista esta llena
	if(num < Max2){
		strcpy(lista->usuarios[num].Nombre, nombre);
		lista->usuarios[num].con = 0;
		lista->usuarios[num].jugando = 0;
		lista->usuarios[num].Socket = NULL;
		num++;
		return 0; // completado
	}
	else
		return 1; // lista llena
}	

int DarConectados(ListaUsuarios *lista, ListaUsuarios *conectados){
	// Rellena una lista de usuarios conectados con la info de la lista general

	// Primero borramos el contenido de la lista de conectados
	for(int i=0; i <= conectados->num; i++)
	{	
		strcpy(conectados->usuarios[i].Nombre,"\0");
		conectados->usuarios[i].con = NULL;
		conectados->usuarios[i].jugando = NULL;
		conectados->usuarios[i].Socket = NULL;
	}
	// Rellenamos la lista de conectados a prtir de la general, si esta conectado lo incluira
	conectados->num = 0;
	int j=0;
	for(int i=0; i <= lista->num; i++)
	{
		if((lista->usuarios[i].con == 1) && (lista->usuarios[i].Nombre != NULL))
		{	
			strcpy(conectados->usuarios[j].Nombre,lista->usuarios[i].Nombre);
			conectados->usuarios[j].con = lista->usuarios[i].con;
			conectados->usuarios[j].jugando = lista->usuarios[i].jugando;
			conectados->usuarios[j].Socket = lista->usuarios[i].Socket;
			conectados->num++;
			j++;
		}
	}
	// El numero de personas conectadas
	return j;
}

int Register(char *p, char consulta[buffer], MYSQL *conn, ListaUsuarios *lista){
	// Comprueva si el usuario ya existe: si exite devuelve 2, sino, lo incluye a la base de datos
	// y devuelve 0 (1 si hay problemas con la conexion)

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

int DesRegister(char *p, MYSQL *conn, ListaUsuarios *lista){
	// Desconecta un usuario y lo elimina de la base de datos.
	// Tambien modifica partidas para que salga como N_A.

	// MYSQL variables
	char consulta[buffer];
	int err;
	MYSQL_RES *resultado;
	
	// Desconectamos el usuario
	p = strtok( NULL, "/");
	char nombre[30];
	strcpy (nombre, p);
	
	int i = 0;
	while (strcmp(lista->usuarios[i].Nombre, nombre) != 0)
		i++;
	lista->usuarios[i].con = 0; 
	lista->usuarios[i].Socket = NULL; 
	printf("Estado actualizado:\n");
	printf("-> Nombre: %s\n",lista->usuarios[i].Nombre);
	printf("-> Conectado? %i\n",lista->usuarios[i].con);
	printf("-> Socket: %i\n",lista->usuarios[i].Socket);

	// Consultas MYSQL
	// Quitar keys
	strcpy(consulta, "SET FOREIGN_KEY_CHECKS=0;");
	if (mysql_query(conn, consulta) != 0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
	}
	err=mysql_query (conn, consulta);
	
	// Cambiar nombre a N_A
	strcpy(consulta, "UPDATE Partidas SET Jugador1 = 'N_A' WHERE Jugador1 = '");
	strcat(consulta, nombre);
	strcat(consulta, "';");
	err=mysql_query (conn, consulta);
	
	strcpy(consulta, "UPDATE Partidas SET Jugador2 = 'N_A' WHERE Jugador2 = '");
	strcat(consulta, nombre);
	strcat(consulta, "';");
	err=mysql_query (conn, consulta);
	
	// Eliminar el usuario
	strcpy(consulta, "DELETE FROM Usuarios WHERE Nombre = '");
	strcat(consulta, nombre);
	strcat(consulta,"';");
	err=mysql_query (conn, consulta);
	
	// Poner keys
	strcpy(consulta, "SET FOREIGN_KEY_CHECKS=1;");
	if (mysql_query(conn, consulta) != 0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
	}
	
	err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		return 1;
	}
}

int LogIN(char *p, MYSQL *conn, char info[buffer], ListaUsuarios *lista, int Socket){
	// Comprueva la existencia de un usuario y comprueva si la password es correcta

	// MYSQL variables
	char consulta[buffer];
	int err;
	MYSQL_RES *resultado;	
	MYSQL_ROW *row;
	
	// Comprovamos existencia
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
		lista->usuarios[i].con = 1; 
		lista->usuarios[i].Socket = Socket;
		// Debugg
		printf("Estado actualizado:\n");
		printf("-> Nombre: %s\n",lista->usuarios[i].Nombre);
		printf("-> Conectado? %i\n",lista->usuarios[i].con);
		printf("-> Socket: %i\n",lista->usuarios[i].Socket);
		return 0;
	}
	// Password incorrecta
	else if (strcmp(password, realpass) == 0)	
		return 2;
}

int LogOUT(char *p, ListaUsuarios *lista){
	// Cambia la lista de conectados para decir que se ha cerrado sesion
	p = strtok( NULL, "/");
	char nombre[30];
	strcpy (nombre, p);

	int i = 0;
	while (strcmp(lista->usuarios[i].Nombre, nombre) != 0)
		i++;
	// Debugg
	lista->usuarios[i].con = 0; 
	lista->usuarios[i].Socket = NULL; 
	printf("Estado actualizado:\n");
	printf("-> Nombre: %s\n",lista->usuarios[i].Nombre);
	printf("-> Conectado? %i\n",lista->usuarios[i].con);
	printf("-> Socket: %i\n",lista->usuarios[i].Socket);
	return 0;
}

int CrearPartida(char *p, ListaPartidas *partidas, ListaUsuarios *usuarios, char jugador1[Max], char jugador2[Max], int num_cartas){
	// Crea una partida una vez se han aceptado las invitaciones
	// Devuelve la id de la partida o -1 si no se puede agregar mas partidas
	int num = partidas->num;
	if (num == Max2)
		return -1;

	// Condiciones iniciales de partida
	partidas->partidas[num].num_cartas = num_cartas;
	partidas->partidas[num].num_turnos = 3;
	partidas->partidas[num].turno_actual = 1;
	partidas->partidas[num].puntos[0] = -1;
	partidas->partidas[num].puntos[1] = -1;

	for (int i = 0; i < usuarios->num; i++){
		if (strcmp(usuarios->usuarios[i].Nombre, jugador1) == 0)
		{
			strcpy(partidas->partidas[num].jugadores[0].Nombre, usuarios->usuarios[i].Nombre);
			partidas->partidas[num].jugadores[0].Socket = usuarios->usuarios[i].Socket;
			partidas->partidas[num].jugadores[0].con = usuarios->usuarios[i].con;
			partidas->partidas[num].jugadores[0].jugando = usuarios->usuarios[i].jugando;
		}
		else if (strcmp(usuarios->usuarios[i].Nombre, jugador2) == 0)
		{
			strcpy(partidas->partidas[num].jugadores[1].Nombre, usuarios->usuarios[i].Nombre);
			partidas->partidas[num].jugadores[1].Socket = usuarios->usuarios[i].Socket;
			partidas->partidas[num].jugadores[1].con = usuarios->usuarios[i].con;
			partidas->partidas[num].jugadores[1].jugando = usuarios->usuarios[i].jugando;
		}
	}
	partidas->num++;
	return num;
}

int BuscarPartidaPorID(int id_partida,ListaPartidas *Partidas){ 
	// Busca la posicion de la partida
	int enc = 0;
	for (int i=0; i <= Partidas->num;i++)
	{
		if (Partidas->partidas[i].id == id_partida)
			return  i;
	}
	if (enc == 0)
	return -1; // no se ha encontrado
}

void GenerarListaCartas (MYSQL *conn, ListaCartas *listaCartas){
	// Genera lista de todas cartas al iniciar servidor en el main

	// MYSQL variables
	int err;
	MYSQL_RES * resultado;
	MYSQL_ROW * row;
	char consulta[buffer];

	// Consulta de la base de datos
	strcpy(consulta, "SELECT ID,Nombre,Fuerza,Posicion FROM Cartas");
	err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n",
				mysql_errno(conn), mysql_error(conn));
		return -1;
	}

	// Almacenar los resultados en la lista
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row(resultado);
	int num = 0;
	pthread_mutex_lock(&mutex);
	while (row != NULL)
	{
		listaCartas->cartas[num].id =  atoi(row[0]);
		//printf("%s\n",listaCartas->cartas[num].id);
		strcpy(listaCartas->cartas[num].nombre, row[1]);
		//printf("%s\n",listaCartas->cartas[num].nombre);
		listaCartas->cartas[num].fuerza = atoi(row[2]);
		//printf("%s\n",listaCartas->cartas[num].fuerza);
		listaCartas->cartas[num].tipo = atoi(row[3]);
		//printf("%s\n\n",listaCartas->cartas[num].tipo);
		num++;
		listaCartas->num++;
		row = mysql_fetch_row(resultado);
	}
	pthread_mutex_unlock(&mutex);
}

void DarCarta (ListaCartas *CARTAS, int ID, Carta *carta){ 
	// Copia datos en una carta en funcion de la id
	for (int i = 0 ; i<CARTAS->num; i++)
	{ 	
		printf("ID que itera: %d\n", CARTAS->cartas[i].id);
		printf("ID que buscamos: %d\n\n", ID);
		if (ID == CARTAS->cartas[i].id)
		{
			carta->id = i;
			strcpy(carta->nombre, CARTAS->cartas[i].nombre);
			carta->fuerza =  CARTAS->cartas[i].fuerza;
			carta->tipo =  CARTAS->cartas[i].tipo;
			printf("La fuerza es %d y el tipo es %d \n",carta->fuerza, carta->tipo);
		}
	}
}

void DarMano(char *respuesta, ListaCartas *cartas, int numMano){ 
	// Genera un mazo de cartas en funcion de la cantidad que se especifique	   
	
	// Variables para usar funcion DarCarta + iterar
	Carta carta;
    int i = 0;
	int num_ID;
	int fuerza;
	int tipo;
	
	// Flags para cartas no repetibles
	int enc0 = 0;
	int enc28 = 0;
	int enc9 =0; 
	int enc4 =0; 

	strcpy(respuesta, "8");
	sprintf(respuesta, "%s/%d" , respuesta, numMano);
	int num = cartas->num;
	srand(time(NULL)); 
    while (i<numMano)  
    {  

        num_ID = rand()%num; // obtener num aleatorio entre 0 y 29
		// Condiciones para no repetir las no repetibles
		if (num_ID == 0 && enc0 == 0) 
		{
			DarCarta(cartas, num_ID, &carta);
			sprintf(respuesta, "%s/%d/%d/%d",respuesta,carta.id,carta.fuerza,carta.tipo);   
			enc0 = 1;
			i++;
		}
		else if (num_ID == 4 && enc4 == 0)
		{
			DarCarta(cartas, num_ID, &carta);
			sprintf(respuesta, "%s/%d/%d/%d",respuesta,carta.id,carta.fuerza,carta.tipo); 
			enc4 = 1;
			i++;
		}
		else if (num_ID == 9 && enc9 == 0) 
		{
			DarCarta(cartas, num_ID, &carta);
			sprintf(respuesta, "%s/%d/%d/%d",respuesta,carta.id,carta.fuerza,carta.tipo); 
			enc9 = 1;
			i++;
		}
		else if (num_ID == 28 && enc28 == 0) 
		{
			DarCarta(cartas, num_ID, &carta);
			sprintf(respuesta, "%s/%d/%d/%d",respuesta,carta.id,carta.fuerza,carta.tipo); 
			enc28 = 1;
			i++;
		}
		else
		{
			DarCarta(cartas, num_ID, &carta);
			sprintf(respuesta, "%s/%d/%d/%d",respuesta,carta.id,carta.fuerza,carta.tipo); 
			i++;
		}
		//Formato final: 8/numCartas/ID1/Fuerza1/Tipo1/ID2/Fuerza2/...
		printf("Mano: %s\n",respuesta);
	}
}

int AnalizarTurno(int id_partida, ListaPartidas *Partidas, char *jugador, char *p, char *Reenvio){
	// Reenvia la poscion de las cartas al contrincante, tambien detecta si se ha pasado turno o no

	// Descomponemos Fuerzas
	p = strtok(NULL, "/");
	int FuerzaMel = atoi(p);
	p = strtok(NULL, "/");
	int FuerzaRan = atoi(p);
	p = strtok(NULL, "/");
	int FuerzaArt = atoi(p);
	p = strtok(NULL, "/");
	int FuerzaMel_M = atoi(p);
	p = strtok(NULL, "/");
	int FuerzaRan_M = atoi(p);
	p = strtok(NULL, "/");
	int FuerzaArt_M = atoi(p);

	// Creamos mensaje para reenviar a los jugadores
	sprintf(Reenvio,"9/%i/%i/%i/%i/%i/%i/%i",id_partida,
			FuerzaArt,FuerzaRan,FuerzaMel,FuerzaArt_M,FuerzaRan_M,FuerzaMel_M);

	// Reensamblar vector de posiciones
	for (int i = 0; i < 27; i++){
		p = strtok(NULL, "/");
		int posicion = atoi(p);
		p = strtok(NULL, "/");
		int fuerza = atoi(p);
		sprintf(Reenvio, "%s/%i/%i", Reenvio, posicion, fuerza);
	}
	// Comprovamos si pasa turno
	p = strtok(NULL, "/");
	int pasarturno = atoi(p);
	if (pasarturno == 1)
	{
		Partidas->partidas[id_partida].pasados++;
		sprintf(Reenvio, "%s/%i",Reenvio, pasarturno);
	}
	return pasarturno;
}

int jugadorPrimero(){
	// Da 1 o 2 para decidir que jugador inicia el primer turno
	// Activa como true en cliente el booleano "accion", que por defecto es false para ambos
	srand(time(NULL)); 
	int primero = rand()%2;
	return primero;
}

int FinalizarTurno(int id_partida, ListaPartidas *Partidas, char *p, int *FuerzaTotal, int *FuerzaTotal_M){
	// Suma y compara las fuerzas totales de la ronda. Si el usuario que ha enviado el mensaje gana envia 1,
	// si perde 0 y si empata 2. Las fuerzas se sacan como variables, por ello son pointers

	// Descomponemos fuerzas
	p = strtok(NULL, "/");
	int FuerzaMel = atoi(p);
	p = strtok(NULL, "/");
	int FuerzaRan = atoi(p);
	p = strtok(NULL, "/");
	int FuerzaArt = atoi(p);
	p = strtok(NULL, "/");
	int FuerzaMel_M = atoi(p);
	p = strtok(NULL, "/");
	int FuerzaRan_M = atoi(p);
	p = strtok(NULL, "/");
	int FuerzaArt_M = atoi(p);
	
	// Suma las fuerzas
	*FuerzaTotal = FuerzaMel + FuerzaArt + FuerzaRan;
	*FuerzaTotal_M = FuerzaMel_M + FuerzaRan_M + FuerzaArt_M;
	
	// Comparacion
	int resultado;
	if (FuerzaTotal < FuerzaTotal_M)
		resultado = 0; // El usuario pierde
	else if (FuerzaTotal > FuerzaTotal_M)
		resultado = 1;  // El usuario gana
	else if (FuerzaTotal == FuerzaTotal_M)
		resultado = 2;  // Empate
	
	// Pase + reinicio de turno
	Partidas->partidas[id_partida].pasados = 0;
	Partidas->partidas[id_partida].turno_actual++;

	return resultado;
}
	
int FinalizarPartida(int id_partida, ListaPartidas *Partidas, char *ganador){
	// Comprueva quien ha ganado la partida

	int resultado;
	int Fuerza1 = Partidas->partidas[id_partida].puntos[0];
	int Fuerza2 = Partidas->partidas[id_partida].puntos[1];
	
	if (Fuerza1 < Fuerza2){
		resultado = 0; // El jugador1 pierde, el jugador2 gana
		strcpy(ganador, Partidas->partidas[id_partida].jugadores[1].Nombre);
	}
	else if (Fuerza1 > Fuerza2){
		resultado = 1;  // El jugador1 gana, el jugado2 pierde
		strcpy(ganador, Partidas->partidas[id_partida].jugadores[0].Nombre);
	}
	else if (Fuerza1 == Fuerza2){
		resultado = 2;  // Empate: ambos ganan :D
	}
	return resultado;
}

int GuardarPartida(MYSQL *conn, ListaPartidas *Partidas, int id_partida){
	// Recoge los datos basicos de la partida que ha acabado para guardarlas en la base de datos

	// MYSQL variables
	char consulta[buffer];
	int err;
	
	// Generamos los datos a guardar
	char jugador1[Max];
	strcpy(jugador1, Partidas->partidas[id_partida].jugadores[0].Nombre);
	char jugador2[Max];
	strcpy(jugador2, Partidas->partidas[id_partida].jugadores[1].Nombre);
	int puntos1 = Partidas->partidas[id_partida].puntos[0];
	int puntos2 = Partidas->partidas[id_partida].puntos[1];

	// Generamos consulta
	sprintf(consulta, "INSERT INTO Partidas (Jugador1, Jugador2, Puntos_T1, Puntos_T2) VALUES ('%s','%s','%i','%i')",
	jugador1, jugador2, puntos1, puntos2);
	printf("consulta:\n %s\n", consulta);

	// Hacemos la consulta
	err = mysql_query(conn, consulta);
	if (err!=0) {
		printf ("Error al introducir datos la base %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	return err;
}

int Galeria(MYSQL *conn, char *GaleriaInfo){
	// Genera mensaje con la informacion de todas las cartas para enviarlas al cliente

	// MYSQL variables
	char consulta[buffer];
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW *row;

	// Generamos consulta
	sprintf(consulta, "SELECT  ID, Nombre, Fuerza FROM Cartas");
	printf("consulta:\n %s\n", consulta);

	// Hacemos la consulta
	err = mysql_query(conn, consulta);
	if (err!=0) {
		printf ("Error al recoger datos de la base %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}

	// Guardamos la informacion de la consulta
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	strcpy(GaleriaInfo,"13");
	while (row != NULL){
		sprintf(GaleriaInfo,"%s/%i/%s/%i",GaleriaInfo,atoi(row[0]),row[1],atoi(row[2]));
		row = mysql_fetch_row(resultado);
	}
	return 1;
}

int JugadoresEnfrentados(char *p, MYSQL *conn, char *Enfrentados){
	// Busca jugadores contra los que ha jugado el usuario

	// MYSQL variables
	char consulta[buffer];
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW *row;
	
	// Hacemos la consulta
	p = strtok( NULL, "/");
	char nombre[30];
	strcpy (nombre, p);
	
	strcpy(consulta, "SELECT DISTINCT Jugador1 FROM Partidas WHERE Jugador2 = '");
	strcat(consulta, nombre);
	strcat(consulta, "' UNION SELECT DISTINCT Jugador2 FROM Partidas WHERE Jugador1 = '");
	strcat(consulta, nombre);
	strcat(consulta, "';");
	
	err = mysql_query(conn, consulta);
	if (err!=0) {
		printf ("Error al recoger datos de la base %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	// Creamos el mensaje
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	strcpy(Enfrentados,"14");
	if(row == NULL)
		strcpy(Enfrentados,"14/-1");
	while (row != NULL){
			sprintf(Enfrentados,"%s/%s",Enfrentados,row[0]);
			row = mysql_fetch_row(resultado);
	}
	return 1;
}

int ResultadosPartidas(char *p, MYSQL *conn, char *Resultados){
	// Recupera los puntos de las partidas en las que participan el usuario y otro jugador
	
	// MYSQL variables
	char consulta[buffer];
	int err;
	MYSQL_RES *resultado;
	MYSQL_RES *resultado2;
	MYSQL_ROW *row;
	MYSQL_ROW *row2;
	
	// Preparamos los nombre
	p = strtok( NULL, "/");
	char nombre[30];
	strcpy (nombre, p);

	p = strtok(NULL, "/");
	char rival[30];
	strcpy(rival,p);
	
	// Hacemos consultas
	strcpy(consulta, "SELECT Puntos_T1 FROM Partidas WHERE Jugador1 = '");
	strcat(consulta, nombre);
	strcat(consulta, "' AND Jugador2 = '");
	strcat(consulta, rival);
	strcat(consulta, "' UNION SELECT Puntos_T2 FROM Partidas WHERE Jugador1 = '");
	strcat(consulta, rival);
	strcat(consulta, "' AND Jugador2 = '");
	strcat(consulta, nombre);
	strcat(consulta, "';");
	
	err = mysql_query(conn, consulta);
	if (err!=0) {
		printf ("Error al recoger datos de la base %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	
	strcpy(consulta, "SELECT Puntos_T2 FROM Partidas WHERE Jugador1 = '");
	strcat(consulta, nombre);
	strcat(consulta, "' AND Jugador2 = '");
	strcat(consulta, rival);
	strcat(consulta, "' UNION SELECT Puntos_T1 FROM Partidas WHERE Jugador1 = '");
	strcat(consulta, rival);
	strcat(consulta, "' AND Jugador2 = '");
	strcat(consulta, nombre);
	strcat(consulta, "';");
	
	err = mysql_query(conn, consulta);
	if (err!=0) {
		printf ("Error al recoger datos de la base %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	// Guardamos info y creamos mensaje para enviar
	resultado2 = mysql_store_result(conn);
	row2 = mysql_fetch_row(resultado2);

	strcpy(Resultados,"15");	
	if(row == NULL)
		strcpy(Resultados,"15/-1");
	while (row != NULL && row2 != NULL){
		sprintf(Resultados,"%s/%i/%i",Resultados,atoi(row[0]),atoi(row2[0]));
		row = mysql_fetch_row(resultado);
		row2 =  mysql_fetch_row(resultado2);
	}
	return 1;
}

int DarPeriodosPartidas(char *p, MYSQL *conn, char *Periodos){
	// Busca las partidas en un intervalo de tiempo

	// MYSQL variables
	char consulta[buffer];
	int err;
	MYSQL_RES *resultado;
	MYSQL_ROW *row;

	//Guardar las fechas por separado

	p = strtok( NULL, "/");
	char anno_init[15];
	strcpy (anno_init, p);
	p = strtok( NULL, "/");
	char mes_init[15];
	strcpy (mes_init, p);
	p = strtok( NULL, "/");
	char dia_init[15];
	strcpy (dia_init, p);
	p = strtok( NULL, "/");
	char anno_end[15];
	strcpy (anno_end, p);
	p = strtok( NULL, "/");
	char mes_end[15];
	strcpy (mes_end, p);
	p = strtok( NULL, "/");
	char dia_end[15];
	strcpy (dia_end, p);

	//;%s-%s-%s' AND '2016-20-31'"	
	//para seleccionar el intervalo de fechas
	strcpy(consulta, "SELECT * FROM `Partidas` WHERE HPartida BETWEEN '"); 
	strcat(consulta, anno_init);
	strcat(consulta, "-");
	strcat(consulta, mes_init);
	strcat(consulta, "-");
	strcat(consulta, dia_init);
	strcat(consulta, "' AND '");
	strcat(consulta, anno_end);
	strcat(consulta, "-");
	strcat(consulta, mes_end);
	strcat(consulta, "-");
	strcat(consulta, dia_end);
	strcat(consulta, "';");


	err = mysql_query(conn, consulta);
		if (err!=0)
		{
			printf ("Error al recoger datos de la base %u %s\n", 
					mysql_errno(conn), mysql_error(conn));
			exit (1);
		}

	// Creamos el mensaje
	resultado = mysql_store_result(conn);
	row = mysql_fetch_row(resultado);
	strcpy(Periodos,"16");
	if(row == NULL)
		strcpy(Periodos,"16/-1");
	while (row != NULL){
			sprintf(Periodos,"%s/%s/%s/%i/%s/%i",Periodos,row[1],row[2],atoi(row[5]),row[3],atoi(row[4]));
			row = mysql_fetch_row(resultado);
	}
	return 1;

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
		char notificacion[buffer];
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
		conn = mysql_real_connect (conn, "localhost","root", "mysql", "TG3_BDDJuego",0, NULL, 0);
		if (conn==NULL) {
			printf ("Error al inicializar la conexion: %u %s\n", 
					mysql_errno(conn), mysql_error(conn));
			exit (1);
		}				
		//--------------------------SQL Main Connection-------------------------	
		// Ahora recibimos la request del cliente, que dejamos en buff
		int ret =read(sock_conn,buff, sizeof(buff));
		printf ("Recibido:\n");
		
		// Tenemos que agregar la marca de fin de string 
		// para que no escriba lo que hay despues en el buffer
		buff[ret] = '\0';
		printf("%s.\n", buff);

		// Detectamos el servicio que se pide
		char *p = strtok(buff, "/");
		int codigo = atoi (p);
		// A partir de aqui se seleccionara el servicio y se ejecutara
		switch (codigo){
			// Registro de usuario
			// Recibe: 1/<Nombre>/<Correo>/<Password>
			case 1:	{
				// Se niega el acceso a otros theads para evitar registrar dos 
				// usuarios con la misma ID (primera y ultima vez que lo comento)
				pthread_mutex_lock(&mutex);
				int res = Register(p, consulta, conn, &Usuarios);
				// printf("Respuesta es: %i\n", res);
				pthread_mutex_unlock(&mutex);

				if (res == 0)
					sprintf(respuesta,"1/Se ha registrado el usuario");
				else if (res == 1)
					sprintf(respuesta,"1/Error durante el registro");
				else if (res == 2)
					sprintf(respuesta,"1/Este usuario ya estaba registrado");

				break;
			}
			// Inicio de sesion
			// Recibe: 2/<Nombre>/<Password>
			case 2:{	
				char info[buffer]; 
				pthread_mutex_lock(&mutex);
				int res = LogIN(p, conn, info, &Usuarios, sock_conn);
				pthread_mutex_unlock(&mutex);
				
				if (res == 0)
				{
					sprintf(respuesta,"2/Se ha iniciado sesion");
					// Poner funcion para buscar toda la info del jugador
					strcat(respuesta, "/");
					// De momento solo devuelve el correo con el nombre, pero
					// en el futuro se usara para enviar mas info al iniciar.
					// Por ejemplo: lista de amigos (no implementado)
					strcat(respuesta, info);
				}
				else if (res == 1)
					sprintf(respuesta,"2/No se ha encontrado el usuario");
				else if (res == 2)
					sprintf(respuesta,"2/La password es incorrecta");

				break;
			}
			// Crear partida
			// Recibe: 3/<jugador1>/<jugador2>/<numero de cartas>
			case 3:{
					char invitacion[buffer];
					p = strtok(NULL, "/");
					char jugador1[Max];
					strcpy(jugador1,p);
					p = strtok(NULL, "/");
					char jugador2[Max];
					strcpy(jugador2,p);
					p = strtok(NULL, "/");
					int num_cartas = atoi(p);

					// 4/<Persona que ha invitado>/<numero de cartas>
					sprintf(invitacion,"4/%s/%i", jugador1, num_cartas);
					printf("Invitacion: %s \n", invitacion);

					// Envia mensaje de inicio de partida al invitado
					for(int i = 0; i < Conectados.num; i++){
						if(strcmp(Conectados.usuarios[i].Nombre, jugador2) == 0)
						write(Conectados.usuarios[i].Socket, invitacion, strlen(invitacion));
					}

				break;
			}
			// LogOut
			// Recibe: 4/<Nombre>
			case 4:{
				pthread_mutex_lock(&mutex);
				int res = LogOUT(p, &Usuarios);
				pthread_mutex_unlock(&mutex);
				break;
			}
			// Aceptar partida
			// Recibe: 5/<id de partida>/<acepta o no>/<jugador1>/<jugador2>
			// 	-> Si acepta la partida tambien: ../<num_cartas>
			case 5:{
				p = strtok(NULL, "/");
				int aceptado = atoi(p);
				p = strtok(NULL, "/");
				char jugador1[Max];
				strcpy(jugador1, p);
				p = strtok(NULL, "/");
				char jugador2[Max];
				strcpy(jugador2, p);

				// No ha aceptado la partida, se informa al otro host y no se crea la partida
				if (aceptado == 0)
				{
					for(int i = 0; i < Conectados.num; i++){
						if(strcmp(Conectados.usuarios[i].Nombre, jugador2) == 0){
							sprintf(respuesta, "5/0/%s", jugador1);
							printf("Respuesta: %s\n", respuesta);
							write(Conectados.usuarios[i].Socket,
									respuesta, strlen(respuesta));
						}
					}
				}
				// Se ha aceptado la partida
				else if(aceptado == 1)
				{
					p = strtok(NULL, "/");
					int num_cartas = atoi(p);

					pthread_mutex_lock(&mutex);
					int id_partida = CrearPartida(p, &Partidas, &Conectados, jugador1, jugador2, num_cartas);
					pthread_mutex_unlock(&mutex);

					// Se informa de que si se va a jugar la partida
					sprintf(respuesta, "5/1/%s", jugador1);
					printf("Respuesta: %s\n", respuesta);
					write(Partidas.partidas[id_partida].jugadores[1].Socket,
							respuesta, strlen(respuesta));

					// Se decide quien empieza y se les informa a los jugadores
					int primero = jugadorPrimero();
						
					printf("Se va a iniciar partida: %s\n", respuesta);
					for (int i=0; i<= 1; i++)
					{
						if (primero == i)
						{
							sprintf(respuesta, "6/%i/1/%i/%s/%s", id_partida, num_cartas, jugador1, jugador2); // 1 para el que inicia la primera accion
							write(Partidas.partidas[id_partida].jugadores[i].Socket,
							respuesta, strlen(respuesta));
						}
						else
						{
							sprintf(respuesta, "6/%i/0/%i/%s/%s", id_partida, num_cartas, jugador1, jugador2);
							write(Partidas.partidas[id_partida].jugadores[i].Socket,
							respuesta, strlen(respuesta));
						}
					}
				}
				break;
			}
			// Chat
			// Recibe: 6/<id_partida>/<emisario del mensaje>/<mensaje>
			case 6:{
				p = strtok(NULL, "/");
				int id_partida = atoi(p);
				p = strtok(NULL, "/");
				char persona[Max];
				strcpy(persona, p);
				p = strtok(NULL, "/");
				char mensaje[Max2];
				strcpy(mensaje, p);

				sprintf(respuesta, "7/%i/%s/%s", id_partida,persona, mensaje);
				printf("Respuesta: %s\n", respuesta);
				for (int i=0;i<= 1; i++)
				write(Partidas.partidas[id_partida].jugadores[i].Socket,
					respuesta, strlen(respuesta));
				break;
			}
			// Pedir Mazo
			// Recibe: 7/<id_partida>
			case 7:{ 
				char mazo[MaxBuffer];
				p = strtok(NULL, "/");
				int id_partida = atoi(p);

				int posPartida = BuscarPartidaPorID(id_partida, &Partidas);
				int numCartas = Partidas.partidas[posPartida].num_cartas; 
				if (posPartida != -1)
				{
					pthread_mutex_lock(&mutex);
					DarMano(&mazo, &Cartas, numCartas);
					pthread_mutex_unlock(&mutex);
					printf("Cartas: %s\n", mazo);
					// Se envia des de aqui por que el paquete es mas grande de lo normal
					write(sock_conn, mazo, strlen(mazo));
				}
				else if (posPartida == -1)
					printf("Partida no encontrada.\n");
				break;
			}
			// Turnos y acciones
			// Recibe: 8/<id_partida>/<jugador>/<vector con fuerza y posiciones de cartas>/<pasar turno o no>
			case 8:{ 
				p = strtok(NULL, "/");
				int id_partida = atoi(p);
				p = strtok(NULL, "/");
				char jugador[Max];
				strcpy(jugador,p);

				// Mensaje grande
				char Reenvio[MaxBuffer];
				pthread_mutex_lock(&mutex);
				// Comprueva si se ha acabado el turno o solo la accion
				if (Partidas.partidas[id_partida].pasados == 2)
				{
					int FuerzaTotal;
					int FuerzaTotal_M;
					int resultado = FinalizarTurno(id_partida, &Partidas, p, &FuerzaTotal, &FuerzaTotal_M);
					int turno_actual = Partidas.partidas[id_partida].turno_actual;
					for (int i=0;i <= 1; i++)
					{
						// Envio de resultado a cada jugador
						if(strcmp(Partidas.partidas[id_partida].jugadores[i].Nombre, jugador) == 0)
						{
							sprintf(Reenvio, "10/%i/%i/%i/%i/%i", id_partida,FuerzaTotal,FuerzaTotal_M, resultado, turno_actual);
							printf("Se envia: %s\n",Reenvio);
							write(Partidas.partidas[id_partida].jugadores[i].Socket,
							  Reenvio, strlen(Reenvio));
						}
						else
						{
							int resultado_M;
							if (resultado == 0)
								resultado_M = 1;
							else if (resultado == 1)
								resultado_M = 0;
							else if (resultado == 2)
								resultado_M = 2;
							sprintf(Reenvio, "10/%i/%i/%i/%i/%i", id_partida,FuerzaTotal_M,FuerzaTotal, resultado_M, turno_actual);
							printf("Se envia: %s\n",Reenvio);
							write(Partidas.partidas[id_partida].jugadores[i].Socket,
								  Reenvio, strlen(Reenvio));
						}
					}
					if(Partidas.partidas[id_partida].turno_actual > 3){
						// Se ha llegado al maximo de turnos.
						// Pedir a los jugadores el numero de turnos ganados
						sprintf(Reenvio, "11/%i",id_partida);
						for(int i = 0; i<=1; i++)
						write(Partidas.partidas[id_partida].jugadores[i].Socket,
								  Reenvio, strlen(Reenvio));
					}
				}
				// Aun no se ha acabado el turno, solo reenvia posiciones
				else
				{
					int res = AnalizarTurno(id_partida, &Partidas, &jugador, p, &Reenvio);
					for (int i=0;i <= 1; i++)
						if(strcmp(Partidas.partidas[id_partida].jugadores[i].Nombre, jugador) != 0)
							write(Partidas.partidas[id_partida].jugadores[i].Socket,
							  Reenvio, strlen(Reenvio));
				}
				pthread_mutex_unlock(&mutex);

				break;
			}
			// Fin partida
			// Recibe: 9/<id_partida>/<jugador>/<rondas ganadas>
			case 9:{ 

				p = strtok(NULL, "/");
				int id_partida = atoi(p);
				
				p = strtok(NULL, "/");
				char jugador[Max];
				strcpy(jugador,p);

				p = strtok(NULL, "/");
				int rondas = atoi(p);

				pthread_mutex_lock(&mutex);
				// Buscamos que jugador ha contestado y le assignamos las rondas
				int pos_jug;
				if(strcmp(Partidas.partidas[id_partida].jugadores[0].Nombre, jugador)==0)
					pos_jug = 0;
				else
					pos_jug = 1;
				printf("%i\n", pos_jug);

				Partidas.partidas[id_partida].puntos[pos_jug] = rondas;
				printf("%i\n", rondas);

				pthread_mutex_unlock(&mutex);
				printf("%i\n", Partidas.partidas[id_partida].puntos[0]);
				printf("%i\n", Partidas.partidas[id_partida].puntos[1]);
				// Cuando detecte que ambos han constestado hace el computo final
				if ((Partidas.partidas[id_partida].puntos[0] != -1) && (Partidas.partidas[id_partida].puntos[1] != -1))
				{
					char ganador[Max];
					int res = FinalizarPartida(id_partida, &Partidas, &ganador);
					// Funcion para hacer llamada a MYSQL
					err = GuardarPartida(conn, &Partidas, id_partida);

					// Las diferentes combinaciones para enviar los resultados correspondientes a cada jugador
					switch (res){
						case 0:{
								sprintf(respuesta, "12/%i/0/%s", id_partida, ganador);
								printf("Se envia: %s\n", respuesta);
								write(Partidas.partidas[id_partida].jugadores[0].Socket,
								respuesta, strlen(respuesta));

								sprintf(respuesta, "12/%i/1/%s", id_partida, ganador);
								printf("Se envia: %s\n", respuesta);
								write(Partidas.partidas[id_partida].jugadores[1].Socket,
								respuesta, strlen(respuesta));

							break;
						}
						case 1:{
								sprintf(respuesta, "12/%i/1/%s", id_partida, ganador);
								printf("Se envia: %s\n", respuesta);
								write(Partidas.partidas[id_partida].jugadores[0].Socket,
								respuesta, strlen(respuesta));

								sprintf(respuesta, "12/%i/0/%s", id_partida, ganador);
								printf("Se envia: %s\n", respuesta);
								write(Partidas.partidas[id_partida].jugadores[1].Socket,
								respuesta, strlen(respuesta));
								
							break;
						}
						case 2:{
								sprintf(respuesta, "12/%i/2", id_partida);
								printf("Se envia: %s\n", respuesta);
								write(Partidas.partidas[id_partida].jugadores[0].Socket,
								respuesta, strlen(respuesta));

								sprintf(respuesta, "12/%i/2", id_partida);
								printf("Se envia: %s\n", respuesta);
								write(Partidas.partidas[id_partida].jugadores[1].Socket,
								respuesta, strlen(respuesta));

							break;
						}
					}
				}
				break;
			}
			// Galeria
			// Recibe: 10
			case 10:{
				char GaleriaInfo[MaxBuffer];
				int res = Galeria(conn, &GaleriaInfo);
				printf("Galeria: %s\n", GaleriaInfo);
				write(sock_conn, GaleriaInfo, strlen(GaleriaInfo));
				break;
			}
			// Darse de baja
			// Recibe: 11/<nombre>
			case 11: { 
					pthread_mutex_lock(&mutex);
					int res = DesRegister(p, conn, &Usuarios);
					pthread_mutex_unlock(&mutex);
					break;
			}
			// Consulta enfrentamientos
			// Recibe: 12/<jugador>
			case 12:{
					char Enfrentados[MaxBuffer];
					int res = JugadoresEnfrentados(p, conn, &Enfrentados);
					printf("Jugadores enfrentados: %s\n", Enfrentados);
					write(sock_conn, Enfrentados, strlen(Enfrentados));
					break;
			}
			// Resultados contra otro jugador
			// Recibe: 13/<jugador1>/<jugador2>
			case 13:{
					char Resultados[MaxBuffer];
					int res = ResultadosPartidas(p, conn, &Resultados);
					printf("Resultados: %s\n", Resultados);
					write(sock_conn, Resultados, strlen(Resultados));
					break;
			}
			// Intervalo de tiempo
			// Recibe: 14/<anno inicio>/<mes inicio>/<dia inicio>/<anno final>/<mes final>/<dia final>
			case 14:{
					char Periodos[MaxBuffer];
					int res = DarPeriodosPartidas(p, conn, &Periodos);
					printf("Periodos: %s\n", Periodos);
					write(sock_conn, Periodos, strlen(Periodos));
					break;
			}
			// Mensaje de desconexion
			// Recibe: 0/
			case 0:{
				printf("Se ha desconectado.\n");
				terminar = 1;
				break;
			}
		}

		// Si el mensaje no es de desconexion, cerramos la conexion a mysql y enviamos 
		// la respuesta al cliente.
		if ((codigo != 0) && (codigo != 3) && (codigo != 4) && (codigo != 5) && (codigo != 6) && (codigo != 7) && (codigo != 8) && (codigo != 9) && (codigo != 10) && (codigo != 11) && (codigo != 12) && (codigo != 13) && (codigo != 14)){
			mysql_close(conn);
			printf("Respuesta: %s\n", respuesta);
			write(sock_conn, respuesta, strlen(respuesta));
		}

		// Generacion de la notificacion de conectados
		if ((codigo == 1) || (codigo == 2) || (codigo == 4)){
			pthread_mutex_lock(&mutex);
			conectados_num = DarConectados(&Usuarios, &Conectados);
			if(conectados_num != 0){
				sprintf(notificacion,"3/%d",conectados_num);
				for(int i = 0; i < conectados_num; i++ ){
					if(Conectados.usuarios[i].Nombre != NULL){
						sprintf(notificacion,"%s/%s",notificacion,Conectados.usuarios[i].Nombre);
						// Debugg para consola
						printf("Conectado: %s\n", Conectados.usuarios[i].Nombre);
					}
				}	
			}
			else if(conectados_num == 0)
				strcpy(notificacion,"3/0/");
			pthread_mutex_unlock(&mutex);
			printf("Notificacion: %s\n", notificacion);
			for (int j = 0; j < Conectados.num; j++)
				if(Conectados.usuarios[j].Nombre != NULL)
					write(Conectados.usuarios[j].Socket, notificacion, strlen(notificacion));
		}
	}
	close(sock_conn);
}

//=======================================================================================

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
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "TG3_BDDJuego",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", 
				mysql_errno(conn), mysql_error(conn));
		exit (1);
	}

	// Rellenamos la lista de usuarios en el servidor con la informacion del la BBDD
	Usuarios_num = GenerarListaUsuarios(&Usuarios, conn);
	GenerarListaCartas(conn, &Cartas);
	mysql_close(conn);
	// Cerramos conexion mysql para ahorrar recursos

	// Generamos las variables necesarias para la utilizacion de threads para cada cliente
	pthread_t thread;
	// Atenderemos a infinitas peticiones
	for(;;){
		printf ("Escuchando\n");
		//sock_conn es el socket que usaremos para este cliente
		//Aqui aceptamos la peticion de del cliente
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion \n");
		// Generamos los threads para cada conexion		
		sockets[socket_num] = sock_conn;
		pthread_create (&thread, NULL, AtenderCliente, &sockets[socket_num]);
		socket_num++;
	}
}
