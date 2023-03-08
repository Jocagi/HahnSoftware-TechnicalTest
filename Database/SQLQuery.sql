CREATE DATABASE HahnDB;

USE HahnDB;

CREATE TABLE Orders (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    CustomerName NVARCHAR(50) NOT NULL,
    OrderDate DATE NOT NULL,
    TotalAmount DECIMAL(18,2) NOT NULL
);


CREATE TABLE Users (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    FirstName NVARCHAR(150) NOT NULL,
	LastName NVARCHAR(150) NOT NULL,
	Email NVARCHAR(150) NOT NULL,
	Password NVARCHAR(150) NOT NULL
);
