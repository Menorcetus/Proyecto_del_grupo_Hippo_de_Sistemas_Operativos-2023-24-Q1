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
    KEY(Nombre),
    Correo VARCHAR(30), 
    Password VARCHAR(30)
    ) ENGINE = InnoDB;


CREATE TABLE Partidas (
    ID_partida INT NOT NULL PRIMARY KEY AUTO_INCREMENT, 
    Duracion FLOAT, 
    Jugador1 VARCHAR(30), 
    Jugador2 VARCHAR(30), 
    FOREIGN KEY (Jugador1) REFERENCES Usuarios(Nombre),
    FOREIGN KEY (Jugador2) REFERENCES Usuarios(Nombre),
    Puntos_T1 INT, Puntos_T2 INT
) ENGINE = InnoDB;


CREATE TABLE Cartas (
    ID INT NOT NULL PRIMARY KEY, 
    Nombre VARCHAR(30),
    Fuerza INT,
    Posicion INT,   /*1 es cuerpo a cuerpo, 2 distancia, 3 artilleria, 4 cualquiera*/
    Repetible INT  /*1 si, 0 no*/
)ENGINE = InnoDB;

INSERT INTO Usuarios(Nombre, Correo, Password) 
VALUES ('a','a','a'),('bb','bb','bb'),('c','c','c'),('d','d','d'),('s','s','s');


INSERT INTO Cartas (ID, Nombre, Fuerza, Posicion, Repetible)
VALUES (0,'Hippotenusa',8,3,0),(1,'Highppo',6,1,1),(2,'Conclave de nutrias',4,1,1),(3,'Kinkis reclutas',1,1,1),(4,'King of KinkIX',5,1,0),
(5,'Pirrata',5,1,1),(6,'Jinete de Hippo',6,1,1),(7,'Hipphombre',5,1,1),(8,'Hippo-tauro',7,1,1),(9,'Dragon-Nutria',9,4,0),(10,'Jimmy Enriques',3,2,1),(11,'Horda de ratas',2,1,1),(12,'Macaco',4,2,1),(13,'Plebeyos armados',3,2,1),(14,'Arquero elfo',6,2,1),(15,'Arcabucero enano',5,2,1),
(16,'Gnomo con tirachinas',3,2,1),(17,'Mago de fuego',6,2,1),(18,'Drac-King',5,2,1),(19,'3-mono',4,2,1),(20,'Homodino',5,3,1),(21,'Escupefuegos',6,3,1),(22,'Balista',6,3,1),(23,'Gremio de ingenieros',2,3,1),(24,'Duck',2,3,1),(25,'Bee-holder',2,3,1),(26,'Beer-holder',0,3,1),(27,'Apoyo moral',3,4,1),(28,'Superheterodino',10,4,0),(29,'Cucos',6,4,1);

