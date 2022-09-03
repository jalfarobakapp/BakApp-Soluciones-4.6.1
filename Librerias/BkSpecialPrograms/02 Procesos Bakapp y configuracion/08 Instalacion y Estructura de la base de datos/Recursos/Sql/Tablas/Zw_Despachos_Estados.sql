USE [#Base#]

CREATE TABLE [dbo].[Zw_Despachos_Estados](
	[Id_Estado]			[int] IDENTITY(1,1) Not Null,
	[Id_Despacho]		[int]			Not Null DEFAULT (''),
	[Estado]			[char](3)		Not Null DEFAULT (''),
	[CodFuncionario]	[varchar](3)	Not Null DEFAULT (''),
	[Observacion]		[varchar](500)	Not Null DEFAULT (''),
	[Fecha_Fijacion]	[datetime]		Not Null DEFAULT (''),	
 CONSTRAINT [PK_Zw_Despachos_Estados] PRIMARY KEY CLUSTERED 
(
	[Id_Estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
