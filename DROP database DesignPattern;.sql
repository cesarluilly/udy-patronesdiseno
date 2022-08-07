DROP database DesignPattern;

CREATE DATABASE DesignPattern;
USE DesignPattern;


CREATE TABLE Beer
(
    Pk int IDENTITY (1, 1) not null,
    CONSTRAINT Pk_Beer PRIMARY KEY (Pk),
    
    Name NVARCHAR(50) NOT NULL,
    Style NVARCHAR(50) NOT NULL

    PkBrand int null,
    CONSTRAINT FK_Beer_Brand_PkBrand FOREIGN KEY (PkBrand) REFERENCES Brand (Pk),
    
);
GO


USE DesignPattern;

CREATE TABLE Brand
(
    Pk int IDENTITY (1, 1) not null,
    CONSTRAINT Pk_Brand PRIMARY KEY (Pk),
    
    Name NVARCHAR(50) NOT NULL,
);
GO