USE [DB_PRUEBA]
GO

/****** Object:  Table [dbo].[Usuarios]    Script Date: 4/1/2023 3:44:05 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuarios](
	[id_usuario] [bigint] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[correo] [varchar](50) NOT NULL,
	[fecha_nacimiento] [date] NOT NULL,
	[telefono] [int] NULL,
	[pais_residencia] [varchar](10) NOT NULL,
	[recibir_informacion] [bit] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

