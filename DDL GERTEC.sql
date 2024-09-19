CREATE DATABASE GertecDb;
USE GertecDb;

-- DDL: tabela tblEndereco
CREATE TABLE tblEndereco (
    Id BIGINT AUTO_INCREMENT PRIMARY KEY, 
    Pais VARCHAR(100) NOT NULL,  
	Estado VARCHAR(100) NOT NULL,  
    Cidade VARCHAR(100) NOT NULL,      
    Bairro VARCHAR(100),               
    Rua VARCHAR(255) NOT NULL,         
    Numero VARCHAR(10) NOT NULL,       
    Complemento VARCHAR(255)           
);

-- DDL: tabela tblCliente
CREATE TABLE tblCliente (
    Id BIGINT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(255) NOT NULL,
    Cpf CHAR(11) NOT NULL UNIQUE,
    Idade INT,
    Telefone VARCHAR(15),
    IdEndereco BIGINT NOT NULL,
    Ativo BOOLEAN NOT NULL DEFAULT TRUE,
    FOREIGN KEY (IdEndereco) REFERENCES tblEndereco(Id)
);

-- DDL: tabela tblProduto
CREATE TABLE tblProduto (
    Id BIGINT AUTO_INCREMENT PRIMARY KEY,
    Descricao VARCHAR(255) NOT NULL,
    Valor DECIMAL(10, 2) NOT NULL,
    PartNumber VARCHAR(50),
    DataCriacao DATETIME NOT NULL,
    Quantidade INT NOT NULL,
    DataAtualizacao DATETIME,
    Ativo BOOLEAN NOT NULL DEFAULT TRUE
);

-- DDL: tabela tblVenda
CREATE TABLE tblVenda (
    Id BIGINT AUTO_INCREMENT PRIMARY KEY,
    Vendedor VARCHAR(255) NOT NULL,
    PrecoMedio DECIMAL(10, 2) NOT NULL,
    PrecoTotal DECIMAL(10, 2) NOT NULL,
    DataCompra DATETIME NOT NULL,
    IdProduto BIGINT NOT NULL,
    IdCliente BIGINT NOT NULL,
	Quantidade int NOT NULL,
    FOREIGN KEY (IdProduto) REFERENCES tblProduto(Id),
    FOREIGN KEY (IdCliente) REFERENCES tblCliente(Id) 
);

-- DDL: tabela tblLog
CREATE TABLE tblLog (
    Id BIGINT AUTO_INCREMENT PRIMARY KEY,
    Message VARCHAR(255) NOT NULL,
	StackTrace VARCHAR(1000) NOT NULL,
	Data DATETIME NOT NULL
);

-- DDL: índices
CREATE INDEX idx_IdProduto ON tblVenda(IdProduto);
CREATE INDEX idx_IdCliente ON tblVenda(IdCliente);