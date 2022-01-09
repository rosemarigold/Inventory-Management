-- Script DDL for the Inventory project (with MS SQL Server Studio Management)

-- Create database
DROP DATABASE IF EXISTS inventory;
CREATE DATABASE inventory
CHARACTER SET utf8mb4 
COLLATE utf8mb4_unicode_ci;

-- Use database
USE ProjetInventaire;

-- Create table InfoProduit
DROP TABLE IF EXISTS InfoProduit;
CREATE TABLE InfoProduit(
    NumeroProduit INT NOT NULL PRIMARY KEY,
    Nom VARCHAR(50),
	Description VARCHAR(50),
	TypeProduit VARCHAR(50)
);

-- Create table Inventaire
DROP TABLE IF EXISTS Inventaire;
CREATE TABLE Inventaire(
    NumeroProduit INT,
    QuantiteActuelle INT,
	SeuilMinimum INT,
    FOREIGN KEY (NumeroProduit) REFERENCES InfoProduit(NumeroProduit)
);

-- Create table Fournisseur
DROP TABLE IF EXISTS Fournisseur;
CREATE TABLE Fournisseur(
    NumeroFournisseur INT NOT NULL PRIMARY KEY,
    Nom VARCHAR(50),
	Prenom VARCHAR(50),
	Adresse VARCHAR(50),
	Courriel VARCHAR(50),
	Telephone VARCHAR(20)
);

-- Create table ListeFournisseur
DROP TABLE IF EXISTS ListeFournisseur;
CREATE TABLE ListeFournisseur(
    NumeroFournisseur INT FOREIGN KEY REFERENCES Fournisseur(NumeroFournisseur),
    NumeroProduit INT FOREIGN KEY REFERENCES InfoProduit(NumeroProduit)
);

-- Create table ListeAchat
DROP TABLE IF EXISTS ListeAchat;
CREATE TABLE ListeAchat(
    NumeroProduit INT FOREIGN KEY REFERENCES InfoProduit(NumeroProduit),
	Quantite INT
);

