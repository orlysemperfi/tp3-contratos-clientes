USE [TMD]
GO

/****** Object:  StoredProcedure [GEN].[LISTARORGANIZACION]    Script Date: 01/14/2013 21:57:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [GEN].[LISTARORGANIZACION]
AS
 BEGIN
SELECT TOP 1000 [CODIGO_ORGANIZACION]
      ,[NOMBRE]
      ,[VISION]
      ,[MISION]
  FROM [TMD].[GEN].[ORGANIZACION]
  END
  
  
GO

USE [TMD]
GO

/****** Object:  StoredProcedure [GEN].[ORGANIZACION_INS]    Script Date: 01/14/2013 21:57:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [GEN].[ORGANIZACION_INS]
@Codigo varchar(150),
@Nombre varchar(150),
@Mision varchar(150),
@Vision varchar(150)
AS
 BEGIN
  INSERT INTO [TMD].[GEN].[ORGANIZACION]
           ([CODIGO_ORGANIZACION]
           ,[NOMBRE]
           ,[VISION]
           ,[MISION])
     VALUES
           (
           @Codigo, @Nombre, @Mision,@Vision
           )
 END
GO


