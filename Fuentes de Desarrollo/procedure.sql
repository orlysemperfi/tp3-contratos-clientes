USE TMD
GO
/********************************************************************/
IF  EXISTS (SELECT 0 FROM sys.objects WHERE object_id = OBJECT_ID(N'[CC].[CLIENTE_BYRUC]') AND type in (N'P', N'PC'))
DROP PROCEDURE [CC].[CLIENTE_BYRUC]
GO
CREATE PROCEDURE CC.CLIENTE_BYRUC
@RUC VARCHAR(11)
AS
SELECT [CODIGO_CLIENTE]
      ,[RUC]
      ,[RAZON_SOCIAL]
      ,[TIPO_CLIENTE]
      ,[CONTACTO]
  FROM [TMD].[CR].[CLIENTE]
  WHERE @RUC=[RUC]
 GO
/**********************************************************************/
IF  EXISTS (SELECT 0 FROM sys.objects WHERE object_id = OBJECT_ID(N'[CC].[MONEDA_LIST]') AND type in (N'P', N'PC'))
DROP PROCEDURE [CC].[MONEDA_LIST]
GO
CREATE PROCEDURE CC.MONEDA_LIST
AS
	SELECT [CODIGO_MONEDA] ,[NOMBRE] FROM [TMD].[CC].[MONEDA]
GO
/************************************************************************/
IF  EXISTS (SELECT 0 FROM sys.objects WHERE object_id = OBJECT_ID(N'[CC].[SERVICIO_LIST]') AND type in (N'P', N'PC'))
DROP PROCEDURE [CC].[SERVICIO_LIST]
GO
CREATE PROCEDURE CC.SERVICIO_LIST
AS
SELECT [CODIGO_SERVICIO]
      ,S.[DESCRIPCION]
      ,S.[CODIGO_LINEA_SERVICIO]
	  ,L.[DESCRIPCION]
  FROM [TMD].[CC].[SERVICIO] S
		INNER JOIN [TMD].[CC].[LINEA_SERVICIO] L
		ON S.[CODIGO_LINEA_SERVICIO]=L.[CODIGO_LINEA_SERVICIO]
GO
/****************************************************************************/
IF  EXISTS (SELECT 0 FROM sys.objects WHERE object_id = OBJECT_ID(N'[CC].[TIPO_CLAUSULA_LIST]') AND type in (N'P', N'PC'))
DROP PROCEDURE [CC].[TIPO_CLAUSULA_LIST]
GO
CREATE PROCEDURE CC.TIPO_CLAUSULA_LIST
AS
SELECT [CODIGO_TIPO_CLAUSULA]
      ,[NOMBRE]
  FROM [TMD].[CC].[TIPO_CLAUSULA]
GO
/****************************************************************************/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[CC].[ROL_LIST]') AND type in (N'P', N'PC'))
DROP PROCEDURE [CC].[ROL_LIST]
GO
CREATE PROCEDURE CC.ROL_LIST
AS
SELECT [CODIGO_ROL]
      ,[DESCRIPCION]
  FROM [TMD].[GEN].[ROL]
GO
/******************************************************************************/
IF  EXISTS (SELECT 0 FROM sys.objects WHERE object_id = OBJECT_ID(N'[CC].[ENTREGABLE_LIST]') AND type in (N'P', N'PC'))
DROP PROCEDURE [CC].[ENTREGABLE_LIST]
GO
CREATE PROCEDURE CC.ENTREGABLE_LIST
AS
SELECT [CODIGO_ENTREGABLE]
      ,[DESCRIPCION]
  FROM [TMD].[CC].[ENTREGABLE]
GO
/*****************************************************************************/
IF  EXISTS (SELECT 0 FROM sys.objects WHERE object_id = OBJECT_ID(N'[CC].[INDICADOR_LIST]') AND type in (N'P', N'PC'))
DROP PROCEDURE [CC].[INDICADOR_LIST]
GO
CREATE PROCEDURE CC.INDICADOR_LIST
AS
SELECT [CODIGO_INDICADOR]
      ,[DESCRIPCION]
      ,[TIPO_INDICADOR]
  FROM [TMD].[CC].[INDICADOR]
GO
/***********************************************************************************/
IF  EXISTS (SELECT 0 FROM sys.objects WHERE object_id = OBJECT_ID(N'[CC].[CONTRATO_INSERT]') AND type in (N'P', N'PC'))
DROP PROCEDURE [CC].[CONTRATO_INSERT]
GO
CREATE PROCEDURE CC.CONTRATO_INSERT
@CODIGO_CONTRATO INT OUTPUT,
@CODIGO_CLIENTE INT,
@NUMERO_BUENA_PRO varchar(15),
@NUMERO_CARTA_FIANZA varchar(15),
@FECHA_INICIO datetime,
@FECHA_FIN datetime,
@CODIGO_MONEDA char(3),
@MONTO money,
@DESCRIPCION varchar(500),
@CODIGO_SERVICIO INT
AS
DECLARE @NUMERO_CONTRATO CHAR(10)
SELECT @NUMERO_CONTRATO=ISNULL(MAX(NUMERO_CONTRATO),1)+1 FROM [TMD].[CC].[CONTRATO]
INSERT INTO [TMD].[CC].[CONTRATO]
           ([NUMERO_CONTRATO]
           ,[CODIGO_CLIENTE]
           ,[NUMERO_BUENA_PRO]
           ,[NUMERO_CARTA_FIANZA]
           ,[FECHA_INICIO]
           ,[FECHA_FIN]
           ,[CODIGO_MONEDA]
           ,[MONTO]
           ,[DESCRIPCION]
           ,[CODIGO_SERVICIO])
     VALUES
           (@NUMERO_CONTRATO
           ,@CODIGO_CLIENTE
           ,@NUMERO_BUENA_PRO
           ,@NUMERO_CARTA_FIANZA
           ,@FECHA_INICIO
           ,@FECHA_FIN
           ,@CODIGO_MONEDA
           ,@MONTO
           ,@DESCRIPCION
           ,@CODIGO_SERVICIO)
           
SELECT @CODIGO_CONTRATO=@@IDENTITY
GO
/***********************************************************************************/
IF  EXISTS (SELECT 0 FROM sys.objects WHERE object_id = OBJECT_ID(N'[CC].[CLAUSULA_INSERT]') AND type in (N'P', N'PC'))
DROP PROCEDURE [CC].[CLAUSULA_INSERT]
GO
CREATE PROCEDURE CC.CLAUSULA_INSERT
@CODIGO_CONTRATO int,
@DESCRIPCIÓN varchar(500),
@SUJETO_PENALIDAD BIT,
@TIPO_SANCION char(1) = NULL,
@SANCION decimal(10,2) = NULL,
@CODIGO_TIPO_CLAUSULA int
AS
DECLARE @NUMERO_CLAUSULA smallint
SELECT @NUMERO_CLAUSULA=ISNULL(MAX(NUMERO_CLAUSULA),1)+1 FROM [TMD].[CC].[CLAUSULA]
	WHERE [CODIGO_CONTRATO]=@CODIGO_CONTRATO
	
INSERT INTO [TMD].[CC].[CLAUSULA]
           ([CODIGO_CONTRATO]
           ,[NUMERO_CLAUSULA]
           ,[DESCRIPCIÓN]
           ,[SUJETO_PENALIDAD]
           ,[TIPO_SANCION]
           ,[SANCION]
           ,[CODIGO_TIPO_CLAUSULA]
           ,ESTADO)
     VALUES
           (@CODIGO_CONTRATO
           ,@NUMERO_CLAUSULA
           ,@DESCRIPCIÓN
           ,@SUJETO_PENALIDAD
           ,@TIPO_SANCION
           ,@SANCION
           ,@CODIGO_TIPO_CLAUSULA
           ,'A')
GO
/***********************************************************************************/
IF  EXISTS (SELECT 0 FROM sys.objects WHERE object_id = OBJECT_ID(N'[CC].[CONTRATO_ROL_INSERT]') AND type in (N'P', N'PC'))
DROP PROCEDURE [CC].[CONTRATO_ROL_INSERT]
GO
CREATE PROCEDURE CC.CONTRATO_ROL_INSERT
@CODIGO_CONTRATO INT,
@CODIGO_ROL INT
AS
INSERT INTO [TMD].[CC].[CONTRATO_ROL]
           ([CODIGO_CONTRATO]
           ,[CODIGO_ROL])
     VALUES
           (@CODIGO_CONTRATO
           ,@CODIGO_ROL)
GO
/***********************************************************************************/
IF  EXISTS (SELECT 0 FROM sys.objects WHERE object_id = OBJECT_ID(N'[CC].[CONTRATO_ENTREGABLE_INSERT]') AND type in (N'P', N'PC'))
DROP PROCEDURE [CC].[CONTRATO_ENTREGABLE_INSERT]
GO
CREATE PROCEDURE CC.CONTRATO_ENTREGABLE_INSERT
@CODIGO_CONTRATO INT,
@CODIGO_ENTREGABLE INT,
@CODIGO_ROL INT,
@FECHA_PACTADA DATETIME
AS
INSERT INTO [TMD].[CC].[CONTRATO_ENTREGABLE]
           ([CODIGO_CONTRATO]
           ,[CODIGO_ENTREGABLE]
           ,[CODIGO_ROL]
           ,[FECHA_PACTADA]
           ,ESTADO)
     VALUES
           (@CODIGO_CONTRATO
           ,@CODIGO_ENTREGABLE
           ,@CODIGO_ROL
           ,@FECHA_PACTADA
           ,'P')
GO
/***********************************************************************************/
IF  EXISTS (SELECT 0 FROM sys.objects WHERE object_id = OBJECT_ID(N'[CC].[CONTRATO_INDICADOR_INSERT]') AND type in (N'P', N'PC'))
DROP PROCEDURE [CC].[CONTRATO_INDICADOR_INSERT]
GO
CREATE PROCEDURE CC.CONTRATO_INDICADOR_INSERT
@CODIGO_CONTRATO INT,
@CODIGO_INDICADOR INT,
@VALOR_OBJETIVO varchar(20),
@FRECUENCIA char(1)
AS
INSERT INTO [TMD].[CC].[CONTRATO_INDICADOR]
           ([CODIGO_CONTRATO]
           ,[CODIGO_INDICADOR]
           ,[VALOR_OBJETIVO]
           ,[FRECUENCIA]
           ,ESTADO)
     VALUES
           (@CODIGO_CONTRATO
           ,@CODIGO_INDICADOR
           ,@VALOR_OBJETIVO
           ,@FRECUENCIA
           ,'P')
GO
/***********************************************************************************/
/***********************************************************************************/













