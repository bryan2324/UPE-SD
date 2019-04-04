Create database UPSDTCUX;
USE [UPSDTCUX]
GO
/****** Object:  Table [dbo].[mensajex]    Script Date: 13/3/2019 12:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mensajex](
	[idMensaje] [int] IDENTITY(1,1) NOT NULL,
	[cuerpo] [varchar](6000) NULL,
	[fecha] [datetime] NULL,
	[idUsuario] [int] NULL,
	visible int
PRIMARY KEY CLUSTERED 
(
	[idMensaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuariox]    Script Date: 13/3/2019 12:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuariox](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NOT NULL,
	[pass] [varchar](100) NULL,
	[cedula] [varchar](100) NOT NULL,
	[idRol] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[mensajex]  WITH CHECK ADD FOREIGN KEY([idUsuario])
REFERENCES [dbo].[usuariox] ([idUsuario])
GO





create table tokens(
idToken int identity (1,1)  primary key,
token int
)


insert into usuariox (cedula,idRol,nombre,pass) values('336218406',2,'InitialAdmin','3362184069_sandiego2019');
insert into tokens values(5525);



