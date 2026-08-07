CREATE DATABASE EventPlus;
GO

use EventPlus;
GO

CREATE TABLE TipoUsuario(
	IdTipoUsuario UNIQUEIDENTIFIER PRIMARY KEY,
	Titulo VARCHAR(100),
);
GO

CREATE TABLE Usuario(
	IdUsuario UNIQUEIDENTIFIER PRIMARY KEY,
	IdTipoUsuario UNIQUEIDENTIFIER FOREIGN KEY REFERENCES TipoUsuario(IdTipoUsuario),
	Nome VARCHAR(100) NOT NULL,
	Email VARCHAR(100) NOT NULL UNIQUE,
	Senha VARCHAR(60) NOT NULL,
);
GO

CREATE TABLE TipoEvento(
	IdTipoEvento UNIQUEIDENTIFIER PRIMARY KEY,
	Titulo VARCHAR(100)
);
GO

CREATE TABLE Instituicao(
	IdInstituicao UNIQUEIDENTIFIER PRIMARY KEY,
	CNPJ VARCHAR(14) NOT NULL UNIQUE,
	NomeFantasia VARCHAR(100) NOT NULL UNIQUE,
	Endereco VARCHAR(100) NOT NULL UNIQUE,
);
GO

CREATE TABLE Evento(
	IdEvento UNIQUEIDENTIFIER PRIMARY KEY,
	IdTipoEvento UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Instituicao(IdInstituicao),
	IdInstituicao UNIQUEIDENTIFIER FOREIGN KEY REFERENCES TipoEvento(IdTipoEvento),
	Nome VARCHAR(100) NOT NULL,
	Descricao text NOT NULL,
	DataEvento datetime NOT NULL,
	Imagem VARCHAR(200),
);
GO

CREATE TABLE Comentario(
	IdComentario UNIQUEIDENTIFIER PRIMARY KEY,
	IdUsuario UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Usuario(IdUsuario),
	IdEvento UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Evento(IdEvento),
	Descricao text NOT NULL,
	Exibe BIT NOT NULL,
	DataComentario datetime NOT NULL,
);
GO

CREATE TABLE Presenca(
	IdPresenca UNIQUEIDENTIFIER PRIMARY KEY,
	IdUsuario UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Usuario(IdUsuario),
	IdEvento UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Evento(IdEvento),
	Situacao BIT NOT NULL,
);
GO

declare @IdTipoUsuario UNIQUEIDENTIFIER = NEWID();
declare @IdUsuario UNIQUEIDENTIFIER = NEWID();
declare @IdTipoEvento UNIQUEIDENTIFIER = NEWID();
declare @IdEvento UNIQUEIDENTIFIER = NEWID();
declare @IdInstituicao UNIQUEIDENTIFIER = NEWID();
declare @IdComentario UNIQUEIDENTIFIER = NEWID();
declare @IdPresenca UNIQUEIDENTIFIER = NEWID();


INSERT INTO TipoUsuario(IdTipoUsuario, Titulo)
VALUES (@IdTipoUsuario, 'Espectador');

INSERT INTO Usuario(IdUsuario, IdTipoUsuario, Nome, Email, Senha)
VALUES (@IdUsuario, @IdTipoUsuario, 'Luccas Garcia Melo', 'luccas.melo@aluno.senai.br', '123123123');

INSERT INTO TipoEvento(IdTipoEvento, Titulo)
VALUES (@IdTipoEvento, 'Competição');

INSERT INTO Instituicao(IdInstituicao, CNPJ, NomeFantasia, Endereco)
VALUES (@IdInstituicao, '12345678901234', 'SENAI', 'Rua Niteroi 180');

INSERT INTO Evento(IdEvento, IdInstituicao, IdTipoEvento, Nome, Descricao, DataEvento, Imagem)
VALUES (@IdEvento, @IdTipoEvento, @IdInstituicao, 'Competição de Drones', 'Competição de Drones feitos por alunos do SENAI, comparação entre velocIdade, altura, alcance, etc.', '2026-03-08', 'C:\Users\54568203821\Downloads\alessio-soggetti-rSFxBGpnluw-unsplash.jpg');

INSERT INTO Comentario(IdComentario, IdUsuario, IdEvento, Descricao, Exibe, DataComentario)
VALUES (@IdComentario, @IdUsuario, @IdEvento, 'foi uma baita experiência participar desse evento e sair com a medalha de prata. obrigado a todos os envolvIdos.', 0, '2026-03-08');

INSERT INTO Presenca(IdPresenca, IdUsuario, IdEvento, Situacao)
VALUES (@IdPresenca, @IdUsuario, @IdEvento, 1);
