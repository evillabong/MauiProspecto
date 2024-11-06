USE MauiProspecto
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Actividad') AND TYPE IN (N'U')) DROP TABLE Actividad
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Prospecto') AND TYPE IN (N'U')) DROP TABLE Prospecto

CREATE TABLE Prospecto(
	Id BIGINT IDENTITY(1,1) NOT NULL,
	Nombre NVARCHAR(200) NOT NULL,
	Celular NVARCHAR(20) NOT NULL,
	CorreoElectronico NVARCHAR(250) NOT NULL,

	CONSTRAINT PK_Prospecto1 PRIMARY KEY  (Id),
)


INSERT Prospecto(Nombre,Celular,CorreoElectronico) VALUES
('Jose Villarreal','0910000001', 'evillabong@gmail.com'),
('Antonella Villarreal','0910000002', 'antovilla@gmail.com')

CREATE TABLE Actividad(
	Id BIGINT IDENTITY(1,1) NOT NULL,
	Descripcion NVARCHAR(250) NOT NULL,
	Tipo INT NOT NULL, 
	Fecha DATETIMEOFFSET NOT NULL,
	Calificacion INT NOT NULL DEFAULT 0,

	ProspectoId BIGINT NOT NULL,
	
	CONSTRAINT PK_Actividad1 PRIMARY KEY  (Id),
	CONSTRAINT FK_Actividad1 FOREIGN KEY (ProspectoId) REFERENCES Prospecto(Id),
	CONSTRAINT CK_Actividad1 CHECK(Calificacion > 0 AND Calificacion <=5)
)