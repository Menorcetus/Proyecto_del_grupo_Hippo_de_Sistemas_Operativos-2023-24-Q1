/*esta es una version de la base de datos para la version 2 el proyecto
respecto a la anterior se eliminina la tabla personajes
se modifica usuarios porque la base de datos ya no nos importa para saber en que partida esta, V2 usa una lista en C*/


DROP DATABASE IF EXISTS db;
CREATE DATABASE db;

USE db;

/*para guardar partidas realizadas con resultado
hay hasta cuatro jugadores por partida, dos por equipo, se guarda el resultado por equipo
formato JUGADOR1 y JUGADOR2 en equipo 1 y 2 y 4 en equipo 2
se recogen los datos de una partida cuandoe sta finaliza*/
CREATE TABLE PARTIDAS (ID INT NOT NULL, NUM_JUG INT, DURACION FLOAT, JUGADOR1 VARCHAR(30), JUGARDOR2 VARCHAR (30), JUGADOR3 VARCHAR(30), JUGARDOR4 VARCHAR (30), PUNTOST1 INT, PUNTOST2 INT, PRIMARY KEY (ID)) ENGINE = InnoDB;


CREATE TABLE USERS (ID INT NOT NULL, NOMBRE VARCHAR(30), CORREO VARCHAR(30), PASSWORD VARCHAR(30), PRIMARY KEY (ID)) ENGINE = InnoDB;

