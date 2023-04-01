USE [DB_PRUEBA]
GO

/****** Object:  Table [dbo].[Actividades]    Script Date: 4/1/2023 3:44:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Actividades](
	[id_actividad] [bigint] IDENTITY(1,1) NOT NULL,
	[create_date] [date] DEFAULT (getdate()) NOT NULL,
	[id_usuario] [bigint] NOT NULL,
	[actividad] [varchar](50) NOT NULL
) ON [PRIMARY]
GO


