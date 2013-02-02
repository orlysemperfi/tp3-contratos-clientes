use TMD
go

Declare @Codigo_Organizacion varchar(5)

Set @Codigo_Organizacion='00001'

-- TABLAS GENERALES Y OTROS MODULOS
INSERT INTO GEN.ORGANIZACION VALUES (@Codigo_Organizacion,'TMD','','')

INSERT INTO GEN.AREA VALUES ('Administraci�n','','',@Codigo_Organizacion)
INSERT INTO GEN.AREA VALUES ('Contabilidad','','',@Codigo_Organizacion)
INSERT INTO GEN.AREA VALUES ('Sistemas','','',@Codigo_Organizacion)
INSERT INTO GEN.AREA VALUES ('Marketing','','',@Codigo_Organizacion)
INSERT INTO GEN.AREA VALUES ('Finanzas','','',@Codigo_Organizacion)

INSERT INTO GEN.PUESTO VALUES ('Contador General')
INSERT INTO GEN.PUESTO VALUES ('Analista de SW')
INSERT INTO GEN.PUESTO VALUES ('Dise�ador de SW')
INSERT INTO GEN.PUESTO VALUES ('Dise�ador de Base de Datos')
INSERT INTO GEN.PUESTO VALUES ('Administrador de Base de Datos')
INSERT INTO GEN.PUESTO VALUES ('Analista de Calidad de SW')

INSERT INTO GEN.ROL VALUES ('Jefe de Proyecto')
INSERT INTO GEN.ROL VALUES ('Analista')
INSERT INTO GEN.ROL VALUES ('Desarrollador')

INSERT INTO GEN.TIPODOCUMENTO VALUES ('01','DNI')
INSERT INTO GEN.TIPODOCUMENTO VALUES ('02','RUC')
INSERT INTO GEN.TIPODOCUMENTO VALUES ('03','Pasaporte')

INSERT INTO CR.SEGMENTACION (CODIGO_SEGMENTACION,NOMBRE_APROBADOR,RESPONSABLE,FECHA_DE_SEGMENTACION,FECHA_DE_APROBACION,PUNTAJE_CLV,PUNTAJE_RFM,ESTADO)
VALUES (1,'A','A','01-01-2013','01-01-2013',1,1,'1')
INSERT INTO CR.SEGMENTACION (CODIGO_SEGMENTACION,NOMBRE_APROBADOR,RESPONSABLE,FECHA_DE_SEGMENTACION,FECHA_DE_APROBACION,PUNTAJE_CLV,PUNTAJE_RFM,ESTADO)
VALUES (2,'B','B','01-01-2013','01-01-2013',1,1,'1')
INSERT INTO CR.SEGMENTACION (CODIGO_SEGMENTACION,NOMBRE_APROBADOR,RESPONSABLE,FECHA_DE_SEGMENTACION,FECHA_DE_APROBACION,PUNTAJE_CLV,PUNTAJE_RFM,ESTADO)
VALUES (3,'C','C','01-01-2013','01-01-2013',1,1,'1')
INSERT INTO CR.SEGMENTACION (CODIGO_SEGMENTACION,NOMBRE_APROBADOR,RESPONSABLE,FECHA_DE_SEGMENTACION,FECHA_DE_APROBACION,PUNTAJE_CLV,PUNTAJE_RFM,ESTADO)
VALUES (4,'D','D','01-01-2013','01-01-2013',1,1,'1')
INSERT INTO CR.SEGMENTACION (CODIGO_SEGMENTACION,NOMBRE_APROBADOR,RESPONSABLE,FECHA_DE_SEGMENTACION,FECHA_DE_APROBACION,PUNTAJE_CLV,PUNTAJE_RFM,ESTADO)
VALUES (5,'E','E','01-01-2013','01-01-2013',1,1,'1')

INSERT INTO GEN.PERSONA VALUES ('Isabel','Martinez','Sabogal','NA','01','08564738','Calle 5 San Borja','','','','1','F','')
INSERT INTO GEN.PERSONA VALUES ('Melissa','Saenz','Gallardo','NA','01','09684562','Calle 6 San Borja','','','','1','F','')
INSERT INTO GEN.PERSONA VALUES ('Javier','Soto','Gonzales','NA','01','09886433','Calle 7 San Borja','','','','1','M','')
INSERT INTO GEN.PERSONA VALUES ('Natalia','Galindo','Torres','NA','01','09997612','Calle 8 San Borja','','','','1','F','')
INSERT INTO GEN.PERSONA VALUES ('Cecilia','Vargas','Vargas','NA','01','08987721','Calle 5 San Borja','','','','1','F','')

INSERT INTO GEN.EMPLEADO VALUES (3,2,3000,NULL,NULL,1,1)
INSERT INTO GEN.EMPLEADO VALUES (3,3,3000,NULL,NULL,2,2)
INSERT INTO GEN.EMPLEADO VALUES (3,5,3000,NULL,NULL,3,3)
INSERT INTO GEN.EMPLEADO VALUES (3,6,3000,NULL,NULL,4,4)
INSERT INTO GEN.EMPLEADO VALUES (2,1,5000,NULL,NULL,5,5)

Declare @Codigo_Jefe int
Set @Codigo_Jefe=4
UPDATE GEN.EMPLEADO SET CODIGO_JEFE=@Codigo_Jefe WHERE CODIGO_EMPLEADO IN (1,2,3)

----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------

-- TABLAS GESTION DESEMPE�O DEL PERSONAL
-- Agregar registros a PROYECTO
INSERT INTO GD.PROYECTO (DESCRIPCION,FECHA_INICIO,FECHA_FIN) VALUES ('Proyecto 1','20130102','20130628')
INSERT INTO GD.PROYECTO (DESCRIPCION,FECHA_INICIO,FECHA_FIN) VALUES ('Proyecto 2','20130102','20130628')
INSERT INTO GD.PROYECTO (DESCRIPCION,FECHA_INICIO,FECHA_FIN) VALUES ('Proyecto 3','20130102','20130628')
INSERT INTO GD.PROYECTO (DESCRIPCION,FECHA_INICIO,FECHA_FIN) VALUES ('Proyecto 4','20130102','20130628')
INSERT INTO GD.PROYECTO (DESCRIPCION,FECHA_INICIO,FECHA_FIN) VALUES ('Proyecto 5','20130102','20130628')

-- Agregar registros a TIPO_CALIFICACION_EVALUACION
INSERT INTO GD.TIPO_CALIFICACION_EVALUACION (DESCRIPCION) VALUES ('Competencia')
INSERT INTO GD.TIPO_CALIFICACION_EVALUACION (DESCRIPCION) VALUES ('Indicador')

-- Agregar registros a COMPETENCIA_INDICADOR
INSERT INTO GD.COMPETENCIA_INDICADOR (CODIGO_TIPO_CALIFICACION_EVALUACION,DESCRIPCION) VALUES (1,'Negocios')
INSERT INTO GD.COMPETENCIA_INDICADOR (CODIGO_TIPO_CALIFICACION_EVALUACION,DESCRIPCION) VALUES (1,'Personas')
INSERT INTO GD.COMPETENCIA_INDICADOR (CODIGO_TIPO_CALIFICACION_EVALUACION,DESCRIPCION) VALUES (1,'Entorno Organizacional')
INSERT INTO GD.COMPETENCIA_INDICADOR (CODIGO_TIPO_CALIFICACION_EVALUACION,DESCRIPCION) VALUES (1,'Competencias Organizacionales')
INSERT INTO GD.COMPETENCIA_INDICADOR (CODIGO_TIPO_CALIFICACION_EVALUACION,DESCRIPCION) VALUES (2,'Gesti�n')
INSERT INTO GD.COMPETENCIA_INDICADOR (CODIGO_TIPO_CALIFICACION_EVALUACION,DESCRIPCION) VALUES (2,'Desempe�o')

-- Agregar registros a COMPETENCIA_INDICADOR_DETALLE
INSERT INTO GD.COMPETENCIA_INDICADOR_DETALLE (CODIGO_COMPETENCIA_INDICADOR,CODIGO_TIPO_CALIFICACION_EVALUACION,DESCRIPCION,NIVEL_1,NIVEL_2,NIVEL_3,NIVEL_4,NIVEL_5)
VALUES (1,1,'Anticipaci�n de Oportunidades y Problemas','Reacciona ante oportunidades o problemas actuales','Reacciona ante problemas cuando el tiempo apremia',
'Act�a con 1 a 3 meses de anticipaci�n','Act�a con 4 a 12 meses de anticipaci�n','Act�a con m�s de un a�o de anticipaci�n')

INSERT INTO GD.COMPETENCIA_INDICADOR_DETALLE (CODIGO_COMPETENCIA_INDICADOR,CODIGO_TIPO_CALIFICACION_EVALUACION,DESCRIPCION,NIVEL_1,NIVEL_2,NIVEL_3,NIVEL_4,NIVEL_5)
VALUES (1,1,'B�squeda de informaci�n','Formula preguntas directas a personas que puedan responder acerca de una situaci�n','Investiga cu�l es el problema o situaci�n m�s all� de las preguntas de rutina',
'Investiga con mayor profundidad','Investiga de manera ordenada y sistem�tica','Utiliza sistemas propios')

INSERT INTO GD.COMPETENCIA_INDICADOR_DETALLE (CODIGO_COMPETENCIA_INDICADOR,CODIGO_TIPO_CALIFICACION_EVALUACION,DESCRIPCION,NIVEL_1,NIVEL_2,NIVEL_3,NIVEL_4,NIVEL_5)
VALUES (1,1,'Pasi�n por las metas y los resultados','Fija par�metros de excelencia propios','Mejora el desempe�o',
'Fija objetivos desafiantes y trabaja para alcanzarlos','Realiza an�lisis de riesgo/beneficio','Asume riesgos de negocios calculados')

INSERT INTO GD.COMPETENCIA_INDICADOR_DETALLE (CODIGO_COMPETENCIA_INDICADOR,CODIGO_TIPO_CALIFICACION_EVALUACION,DESCRIPCION,NIVEL_1,NIVEL_2,NIVEL_3,NIVEL_4,NIVEL_5)
VALUES (1,1,'Pensamiento anal�tico','Desglosa los problemas o situaciones','Establece relaciones causales sencillas',
'Desglosa un problema complejo complejo en varias partes','Realiza Planes o An�lisis Complejos','')

INSERT INTO GD.COMPETENCIA_INDICADOR_DETALLE (CODIGO_COMPETENCIA_INDICADOR,CODIGO_TIPO_CALIFICACION_EVALUACION,DESCRIPCION,NIVEL_1,NIVEL_2,NIVEL_3,NIVEL_4,NIVEL_5)
VALUES (1,1,'Planificaci�n y Organizaci�n','Planifica su propio trabajo','Maneja m�ltiples tareas',
'','','')

INSERT INTO GD.COMPETENCIA_INDICADOR_DETALLE (CODIGO_COMPETENCIA_INDICADOR,CODIGO_TIPO_CALIFICACION_EVALUACION,DESCRIPCION,NIVEL_1,NIVEL_2,NIVEL_3,NIVEL_4,NIVEL_5)
VALUES (1,1,'Foco en el cliente','Responde apropiadamente','Mantiene una comunicaci�n clara',
'Asume responsabilidad en la correcci�n de un problema','Act�a para mejorar la situaci�n del cliente','Se ocupa de las necesidades b�sicas del cliente')

INSERT INTO GD.COMPETENCIA_INDICADOR_DETALLE (CODIGO_COMPETENCIA_INDICADOR,CODIGO_TIPO_CALIFICACION_EVALUACION,DESCRIPCION,NIVEL_1,NIVEL_2,NIVEL_3,NIVEL_4,NIVEL_5)
VALUES (1,1,'Visi�n Estrat�gica del Cliente','','',
'','','')

INSERT INTO GD.COMPETENCIA_INDICADOR_DETALLE (CODIGO_COMPETENCIA_INDICADOR,CODIGO_TIPO_CALIFICACION_EVALUACION,DESCRIPCION,NIVEL_1,NIVEL_2,NIVEL_3,NIVEL_4,NIVEL_5)
VALUES (1,1,'Pensamiento de Negocios','Conoce el negocio y comprende las fuerzas que operan en �l','Act�a sin perder de vista el entorno de negocios',
'Ayuda a integrar la gesti�n de su �rea con el entorno de negocios','Capta las tendencias en el mediano plazo del mercado y el impacto que tendr� en la empresa','Capta las tendencias emergentes en el largo plazo')

INSERT INTO GD.COMPETENCIA_INDICADOR_DETALLE (CODIGO_COMPETENCIA_INDICADOR,CODIGO_TIPO_CALIFICACION_EVALUACION,DESCRIPCION,NIVEL_1,NIVEL_2,NIVEL_3,NIVEL_4,NIVEL_5)
VALUES (2,1,'Liderazgo de Equipos','Maneja reuniones de Equipo Adecuadamente','Mantiene a las Personas Informadas',
'Promueve Efectividad dentro del Equipo','Obtiene recursos / Se preocupa por el Equipo','Se posiciona como L�der y Comunica una Visi�n Inspiradora')

INSERT INTO GD.COMPETENCIA_INDICADOR_DETALLE (CODIGO_COMPETENCIA_INDICADOR,CODIGO_TIPO_CALIFICACION_EVALUACION,DESCRIPCION,NIVEL_1,NIVEL_2,NIVEL_3,NIVEL_4,NIVEL_5)
VALUES (2,1,'Construcci�n de Capacidad y Talento','Expresa expectativas positivas','Da instrucciones a Corto Plazo, orientadas a la tarea',
'Explica razones y brinda soporte','Da feedback para estimular el proceso de desarrollo','Brinda formaci�n, capacitaci�n o adiestramiento intensivo')

INSERT INTO GD.COMPETENCIA_INDICADOR_DETALLE (CODIGO_COMPETENCIA_INDICADOR,CODIGO_TIPO_CALIFICACION_EVALUACION,DESCRIPCION,NIVEL_1,NIVEL_2,NIVEL_3,NIVEL_4,NIVEL_5)
VALUES (2,1,'Foco en la Obtenci�n de Resultados','','',
'','','')

INSERT INTO GD.COMPETENCIA_INDICADOR_DETALLE (CODIGO_COMPETENCIA_INDICADOR,CODIGO_TIPO_CALIFICACION_EVALUACION,DESCRIPCION,NIVEL_1,NIVEL_2,NIVEL_3,NIVEL_4,NIVEL_5)
VALUES (3,1,'Autocontrol','Siente la presi�n de la situaci�n y se mantiene alejado de la discusi�n','Siente emociones fuertes y consigue controlarlas',
'Siente emociones, las controlay contin�a hablando, actuando o trabajando con calma','','')

INSERT INTO GD.COMPETENCIA_INDICADOR_DETALLE (CODIGO_COMPETENCIA_INDICADOR,CODIGO_TIPO_CALIFICACION_EVALUACION,DESCRIPCION,NIVEL_1,NIVEL_2,NIVEL_3,NIVEL_4,NIVEL_5)
VALUES (3,1,'Impacto e Influencia','','',
'','Maneja efectivamente sus emociones','')

INSERT INTO GD.COMPETENCIA_INDICADOR_DETALLE (CODIGO_COMPETENCIA_INDICADOR,CODIGO_TIPO_CALIFICACION_EVALUACION,DESCRIPCION,NIVEL_1,NIVEL_2,NIVEL_3,NIVEL_4,NIVEL_5)
VALUES (3,1,'Confianza en si mismo','Act�a con confianza en una cierta Funci�n','Act�a con confianza Casi al l�mite de su Funci�n',
'Expresa Confianza en la Propia Capacidad','Asume Desaf�os','Asume Situaciones Extremadamente Desafiantes')

INSERT INTO GD.COMPETENCIA_INDICADOR_DETALLE (CODIGO_COMPETENCIA_INDICADOR,CODIGO_TIPO_CALIFICACION_EVALUACION,DESCRIPCION,NIVEL_1,NIVEL_2,NIVEL_3,NIVEL_4,NIVEL_5)
VALUES (3,1,'Sinergia','','',
'','','')

INSERT INTO GD.COMPETENCIA_INDICADOR_DETALLE (CODIGO_COMPETENCIA_INDICADOR,CODIGO_TIPO_CALIFICACION_EVALUACION,DESCRIPCION,NIVEL_1,NIVEL_2,NIVEL_3,NIVEL_4,NIVEL_5)
VALUES (3,1,'Innovaci�n','Acepta la necesidad de hacer las cosas de manera diferente','Identifica nuevas formas de realizar trabajos y procesos simples',
'Introduce cambios b�sicos en los procesos a su cargo','Dise�a y/o propone nuevos procesos de trabajo','Dise�a productos y servicios o nuevos modelos de negocios que rompen con lo tradicional')

INSERT INTO GD.COMPETENCIA_INDICADOR_DETALLE (CODIGO_COMPETENCIA_INDICADOR,CODIGO_TIPO_CALIFICACION_EVALUACION,DESCRIPCION,NIVEL_1,NIVEL_2,NIVEL_3,NIVEL_4,NIVEL_5)
VALUES (4,1,'Compromiso','Entiende lo que se espera de �l','Trata de adaptarse a la empresa',
'Demuestra lealtad','Apoya a la organizaci�n','Prioriza a la organizaci�n frente a sus intereses individuales')

INSERT INTO GD.COMPETENCIA_INDICADOR_DETALLE (CODIGO_COMPETENCIA_INDICADOR,CODIGO_TIPO_CALIFICACION_EVALUACION,DESCRIPCION,NIVEL_1,NIVEL_2,NIVEL_3,NIVEL_4,NIVEL_5)
VALUES (4,1,'Integridad','Es abierto y honesto en situaciones de trabajo','Act�a en consecuencia con valores y creencias',
'Desaf�a a otros a actuar de acuerdo a los valores y creencias','Admite que ha cometido un error y desaf�a su entorno','Trabaja seg�n sus valores, aunque ello conlleve un importante coste o riesgo')

---- Agregar registros a TIPO_MERECIMIENTO_EVALUACION
--INSERT INTO GD.TIPO_MERECIMIENTO_EVALUACION (DESCRIPCION) VALUES ('Premio')
--INSERT INTO GD.TIPO_MERECIMIENTO_EVALUACION (DESCRIPCION) VALUES ('Sanci�n')

---- Agregar registros a RANGO_MERECIMIENTO
--INSERT INTO GD.RANGO_MERECIMIENTO (CODIGO_TIPO_MERECIMIENTO_EVALUACION,VALOR_MINIMO,VALOR_MAXIMO,DESCRIPCION) VALUES (1,18,20,'Viaje')
--INSERT INTO GD.RANGO_MERECIMIENTO (CODIGO_TIPO_MERECIMIENTO_EVALUACION,VALOR_MINIMO,VALOR_MAXIMO,DESCRIPCION) VALUES (1,15,17,'Curso Especializaci�n')
--INSERT INTO GD.RANGO_MERECIMIENTO (CODIGO_TIPO_MERECIMIENTO_EVALUACION,VALOR_MINIMO,VALOR_MAXIMO,DESCRIPCION) VALUES (2,12,14,'Charla con Jefatura')
--INSERT INTO GD.RANGO_MERECIMIENTO (CODIGO_TIPO_MERECIMIENTO_EVALUACION,VALOR_MINIMO,VALOR_MAXIMO,DESCRIPCION) VALUES (2,10,11,'Carta de Advertencia')

-- Agregar registros a SECCION
INSERT INTO GD.SECCION (DESCRIPCION) VALUES ('Secci�n A. Desempe�o del Evaluado')
INSERT INTO GD.SECCION (DESCRIPCION) VALUES ('Secci�n B. Perfil Profesional')
INSERT INTO GD.SECCION (DESCRIPCION) VALUES ('Secci�n C. Evaluaci�n')

-- Agregar registros a SECCION_DETALLE
INSERT INTO GD.SECCION_DETALLE (CODIGO_SECCION,DESCRIPCION) VALUES (1,'Logros')
INSERT INTO GD.SECCION_DETALLE (CODIGO_SECCION,DESCRIPCION) VALUES (1,'Obst�culos')
INSERT INTO GD.SECCION_DETALLE (CODIGO_SECCION,DESCRIPCION) VALUES (2,'Fortalezas')
INSERT INTO GD.SECCION_DETALLE (CODIGO_SECCION,DESCRIPCION) VALUES (2,'Oportunidades de Mejora')
INSERT INTO GD.SECCION_DETALLE (CODIGO_SECCION,DESCRIPCION) VALUES (2,'Compromisos/Plan de Acci�n')
INSERT INTO GD.SECCION_DETALLE (CODIGO_SECCION,DESCRIPCION) VALUES (3,'')

-- Agregar registros a PROYECTO_ROL
INSERT INTO GD.PROYECTO_ROL VALUES (1,1,1)
INSERT INTO GD.PROYECTO_ROL VALUES (1,2,1)
INSERT INTO GD.PROYECTO_ROL VALUES (1,3,1)
INSERT INTO GD.PROYECTO_ROL VALUES (2,1,2)
INSERT INTO GD.PROYECTO_ROL VALUES (2,2,2)
INSERT INTO GD.PROYECTO_ROL VALUES (2,3,2)
INSERT INTO GD.PROYECTO_ROL VALUES (3,1,3)
INSERT INTO GD.PROYECTO_ROL VALUES (3,2,3)
INSERT INTO GD.PROYECTO_ROL VALUES (3,3,3)

-- Agregar registros a PROYECTO_ROL_EMPLEADO
INSERT INTO GD.PROYECTO_ROL_EMPLEADO VALUES (1,2,2)
INSERT INTO GD.PROYECTO_ROL_EMPLEADO VALUES (2,1,3)
INSERT INTO GD.PROYECTO_ROL_EMPLEADO VALUES (3,3,1)

