
/*Creamos la base de datos para el bazar*/
--CREATE DATABASE Bazar;

/*Empezamos a usar la base de datos*/
USE Bazar;

CREATE TABLE Productos(
id INT Identity(1,1) NOT NULL,
title VARCHAR(100),
description VARCHAR(MAX),
price decimal(10,2),
discountPercentage decimal(10,2),
rating decimal(10,2),
stock INT,
brand VARCHAR(50),
category VARCHAR(50),
thumbnail VARCHAR(MAX),
images VARCHAR(MAX),
);

SELECT * FROM Productos;

SELECT images FROM Productos WHERE brand = 'Apple';