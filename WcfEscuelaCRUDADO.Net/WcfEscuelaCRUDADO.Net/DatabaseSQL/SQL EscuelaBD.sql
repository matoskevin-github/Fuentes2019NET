USE master;


IF EXISTS ( SELECT  name
            FROM    master.dbo.sysdatabases
            WHERE   name = N'EscuelaBD' )
    DROP DATABASE EscuelaBD;

CREATE DATABASE EscuelaBD;
GO

USE EscuelaBD;
GO

CREATE TABLE Maestro
    (
      idMaestro INT PRIMARY KEY
                    IDENTITY ,
      Nombre VARCHAR(50) NOT NULL ,
      ApellidoPaterno VARCHAR(50) NOT NULL ,
      ApellidoMaterno VARCHAR(50) NOT NULL ,
      FechaNacimiento DATE NOT NULL ,
      FechaIngreso DATE NOT NULL
    );

GO
CREATE PROCEDURE sp_Maestro_Add
    (
      @Nombre VARCHAR(50) ,
      @ApellidoPaterno VARCHAR(50) ,
      @ApellidoMaterno VARCHAR(50) ,
      @FechaNacimiento DATE ,
      @FechaIngreso DATE
    )
AS
    BEGIN
        INSERT  INTO dbo.Maestro
                ( Nombre ,
                  ApellidoPaterno ,
                  ApellidoMaterno ,
                  FechaNacimiento ,
                  FechaIngreso
                )
        VALUES  ( @Nombre , -- Nombre - varchar(50)
                  @ApellidoPaterno , -- ApellidoPaterno - varchar(50)
                  @ApellidoMaterno , -- ApellidoMaterno - varchar(50)
                  @FechaNacimiento , -- FechaNacimiento - date
                  @FechaIngreso  -- FechaIngreso - date
                );
    END;
GO

GO
CREATE PROCEDURE sp_Maestro_Update
    (
      @idMaestro INT ,
      @Nombre VARCHAR(50) ,
      @ApellidoPaterno VARCHAR(50) ,
      @ApellidoMaterno VARCHAR(50) ,
      @FechaNacimiento DATE ,
      @FechaIngreso DATE
    )
AS
    BEGIN
        UPDATE  dbo.Maestro
        SET     Nombre = @Nombre ,
                ApellidoPaterno = @ApellidoPaterno ,
                ApellidoMaterno = @ApellidoMaterno ,
                FechaNacimiento = @FechaNacimiento ,
                FechaIngreso = @FechaIngreso
        WHERE   idMaestro = @idMaestro;

    END;

GO 
CREATE PROCEDURE sp_Maestro_Delete ( @idMaestro INT )
AS
    BEGIN
        DELETE  FROM dbo.Maestro
        WHERE   idMaestro = @idMaestro;
    END;
GO

GO 
CREATE PROCEDURE sp_Maestro_GetAll
AS
    BEGIN
        SELECT  idMaestro ,
                Nombre ,
                ApellidoPaterno ,
                ApellidoMaterno ,
                FechaNacimiento ,
                FechaIngreso
        FROM    dbo.Maestro;
    END;
GO

GO 
CREATE PROCEDURE sp_Maestro_GetById ( @idMaestro INT )
AS
    BEGIN
        SELECT  idMaestro ,
                Nombre ,
                ApellidoPaterno ,
                ApellidoMaterno ,
                FechaNacimiento ,
                FechaIngreso
        FROM    dbo.Maestro
        WHERE   idMaestro = @idMaestro;
    END;
GO  

GO 
CREATE PROCEDURE sp_Maestro_GetByCriterio ( @Criterio VARCHAR(50) )
AS
    BEGIN
        SELECT  idMaestro ,
                Nombre ,
                ApellidoPaterno ,
                ApellidoMaterno ,
                FechaNacimiento ,
                FechaIngreso
        FROM    dbo.Maestro
        WHERE   Nombre LIKE '%' + @Criterio + '%';
    END;
GO  

SELECT * FROM dbo.Maestro


