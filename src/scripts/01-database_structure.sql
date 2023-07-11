CREATE DATABASE dbMegamanApi
GO

USE dbMegamanApi
GO

CREATE TABLE dbo.tblRobots(
	id int NOT NULL IDENTITY(1,1),
	nome varchar(80) NOT NULL,
	codigo varchar(20) NOT NULL,
	hp int NOT NULL,
	imagem varchar(200) NOT NULL,
	CONSTRAINT PK_Regioes PRIMARY KEY (id)
)
GO