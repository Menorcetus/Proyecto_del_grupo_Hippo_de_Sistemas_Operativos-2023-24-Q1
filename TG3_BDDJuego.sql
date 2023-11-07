/*esta es una version de la base de datos para la version 2 el proyecto
respecto a la anterior se eliminina la tabla personajes
se modifica usuarios porque la base de datos ya no nos importa para saber en que partida esta, V2 usa una lista en C*/


DROP DATABASE IF EXISTS TG3_BDDJuego;
CREATE DATABASE TG3_BDDJuego;

USE TG3_BDDJuego;

/*para guardar partidas realizadas con resultado
hay hasta cuatro jugadores por partida, dos por equipo, se guarda el resultado por equipo
formato JUGADOR1 y JUGADOR2 en equipo 1 y 2 y 4 en equipo 2
se recogen los datos de una partida cuandoe sta finaliza*/
CREATE TABLE Usuarios (
    ID_usuario INT NOT NULL PRIMARY KEY AUTO_INCREMENT, 
    Nombre VARCHAR(30), 
    Correo VARCHAR(30), 
    Password VARCHAR(30)
    ) ENGINE = InnoDB;


CREATE TABLE Partidas (
    ID_partida INT NOT NULL PRIMARY KEY AUTO_INCREMENT, 
    Num_jug INT, Duracion FLOAT, 
    Jugador1 INT NOT NULL, 
    Jugador2 INT NOT NULL, 
    Jugador3 INT NOT NULL, 
    Jugador4 INT NOT NULL, 
    FOREIGN KEY (Jugador1) REFERENCES Usuarios(ID_usuario),
    FOREIGN KEY (Jugador2) REFERENCES Usuarios(ID_usuario),
    FOREIGN KEY (Jugador3) REFERENCES Usuarios(ID_usuario),
    FOREIGN KEY (Jugador4) REFERENCES Usuarios(ID_usuario),
    Puntos_T1 INT, Puntos_T2 INT
    ) ENGINE = InnoDB;



CREATE TABLE Cartas (
    ID_carta INT NOT NULL PRIMARY KEY AUTO_INCREMENT, 
    Nombre VARCHAR(30),
    Fuerza INT,
    Posicion INT,
    Repetible INT,
    Imagen MEDIUMBLOB
)ENGINE = InnoDB;

