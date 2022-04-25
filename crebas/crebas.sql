
/*==============================================================*/
/* Table: CLIENTE                                               */
/*==============================================================*/
create table CLIENTE (
   IDCLIENTE           int primary key identity(1,1),
   IDPERSONA            int              null,
   CONTRASENA           varchar(100)         null,
   ESTADO               varchar(20)          null,
)
go

/*==============================================================*/
/* Index: ES_UN2_FK                                             */
/*==============================================================*/


/*==============================================================*/
/* Table: CUENTA                                                */
/*==============================================================*/
create table CUENTA (
   IDCUENTA             int primary key identity(1,1),
   IDCLIENTE            int              null,
   NUMEROCUENTA         varchar(100)         null,
   TIPOCUENTA           varchar(50)          null,
   SALDOINICIAL         decimal(18,2)        null,
   ESTADO               varchar(20)          null,
)
go

/*==============================================================*/
/* Index: TENER_FK                                              */
/*==============================================================*/


/*==============================================================*/
/* Table: MOVIMIENTO                                            */
/*==============================================================*/
create table MOVIMIENTO (
   IDMOVIMIENTO         int primary key identity(1,1),
   IDCUENTA             int              null,
   FECHA                datetime             null,
   TIPO                 varchar(50)          null,
   VALOR                decimal(18,2)        null,
   SALDO                decimal(18,2)        null,
)
go

/*==============================================================*/
/* Index: CONTIENE_FK                                           */
/*==============================================================*/


/*==============================================================*/
/* Table: PERSONA                                               */
/*==============================================================*/
create table PERSONA (
   IDPERSONA            int primary key identity(1,1),
   IDCLIENTE            int              null,
   NOMBRE               varchar(500)         null,
   GENERO               varchar(100)         null,
   EDAD                 int                  null,
   IDENTIFICACION       varchar(50)          null,
   DIRECCION            varchar(500)         null,
   TELEFONO             varchar(500)         null,
)
go

CREATE TABLE [dbo].[REPORTE](
	[IDMOVIMIENTO] [int] Primary key NOT NULL,
	[FECHA] [datetime] NULL,
	[CLIENTE] [varchar](500) NULL,
	[NUMEROCUENTA] [varchar](100) NULL,
	[TIPO] [varchar](50) NULL,
	[SALDOINICIAL] [decimal](18, 2) NULL,
	[ESTADO] [varchar](20) NULL,
	[MOVIMIENTO] [decimal](18, 2) NULL,
	[SALDODISPONIBLE] [decimal](18, 2) NULL,
	IDCLIENTE int NULL,
) ON [PRIMARY]

GO

/*==============================================================*/
/* Index: ES_UN_FK                                              */
/*==============================================================*/


ALTER TABLE dbo.CLIENTE ADD CONSTRAINT  ES_UN_FK FOREIGN KEY (IDPERSONA) REFERENCES dbo.PERSONA (IDPERSONA)
GO
ALTER TABLE dbo.CUENTA ADD CONSTRAINT  TENER_FK FOREIGN KEY (IDCLIENTE) REFERENCES dbo.CLIENTE (IDCLIENTE)
GO
ALTER TABLE dbo.MOVIMIENTO ADD CONSTRAINT  CONTIENE_FK FOREIGN KEY (IDCUENTA) REFERENCES dbo.CUENTA (IDCUENTA)
GO

CREATE PROC sp_generar_reporte (@idcliente INT)
AS 
BEGIN

TRUNCATE TABLE dbo.REPORTE

INSERT INTO dbo.REPORTE
(
    IDMOVIMIENTO,
    FECHA,
    CLIENTE,
    NUMEROCUENTA,
    TIPO,
    SALDOINICIAL,
    ESTADO,
    MOVIMIENTO,
    SALDODISPONIBLE,
    IDCLIENTE
)
SELECT IDMOVIMIENTO,FECHA,NOMBRE AS CLIENTE,NUMEROCUENTA,TIPOCUENTA AS TIPO
	,(SALDO - VALOR) AS SALDOINICIAL,CUENTA.ESTADO,VALOR AS MOVIMIENTO,SALDO AS SALDODISPONIBLE,CLIENTE.IDCLIENTE
FROM dbo.PERSONA INNER JOIN dbo.CLIENTE ON CLIENTE.IDPERSONA = PERSONA.IDPERSONA
INNER JOIN dbo.CUENTA ON CUENTA.IDCLIENTE = CLIENTE.IDCLIENTE
INNER JOIN dbo.MOVIMIENTO ON MOVIMIENTO.IDCUENTA = CUENTA.IDCUENTA
--WHERE CLIENTE.IDCLIENTE = @idcliente
ORDER BY TIPOCUENTA,NUMEROCUENTA

END

