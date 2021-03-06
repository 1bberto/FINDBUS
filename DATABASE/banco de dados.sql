USE [FindBus]
GO
/****** Object:  Table [dbo].[tblBairro]    Script Date: 02/09/2013 00:43:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblBairro](
	[BairroID] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](45) NOT NULL,
	[DataInclusaoRegistro] [datetime] NULL,
 CONSTRAINT [PK_Bairro] PRIMARY KEY CLUSTERED 
(
	[BairroID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblBairroRua]    Script Date: 02/09/2013 00:43:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblBairroRua](
	[BairroRuaID] [int] IDENTITY(1,1) NOT NULL,
	[BairroID] [int] NOT NULL,
	[RuaID] [int] NOT NULL,
 CONSTRAINT [PK_BairroRua] PRIMARY KEY CLUSTERED 
(
	[BairroRuaID] ASC,
	[BairroID] ASC,
	[RuaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblCidade]    Script Date: 02/09/2013 00:43:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCidade](
	[CidadeID] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](45) NOT NULL,
	[DataInclusaoRegistro] [datetime] NULL,
 CONSTRAINT [PK_Cidade] PRIMARY KEY CLUSTERED 
(
	[CidadeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblEstado]    Script Date: 02/09/2013 00:43:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblEstado](
	[EstadoID] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](4) NOT NULL,
	[DataInclusaoRegistro] [datetime] NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[EstadoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblEstadoCidade]    Script Date: 02/09/2013 00:43:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEstadoCidade](
	[EstadoCidadeID] [int] IDENTITY(1,1) NOT NULL,
	[EstadoID] [int] NOT NULL,
	[CidadeID] [int] NOT NULL,
 CONSTRAINT [PK_EstadoCidade] PRIMARY KEY CLUSTERED 
(
	[EstadoCidadeID] ASC,
	[EstadoID] ASC,
	[CidadeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblEtinerario]    Script Date: 02/09/2013 00:43:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblEtinerario](
	[EtinerarioID] [int] IDENTITY(1,1) NOT NULL,
	[DiaSemana] [varchar](13) NOT NULL,
	[HoraSaida] [time](7) NOT NULL,
	[HoraChegada] [time](7) NOT NULL,
 CONSTRAINT [PK_Etinerario] PRIMARY KEY CLUSTERED 
(
	[EtinerarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblLogin]    Script Date: 02/09/2013 00:43:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblLogin](
	[LoginID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[UsuarioSenha] [varchar](45) NOT NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[LoginID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblPonto]    Script Date: 02/09/2013 00:43:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPonto](
	[PontoID] [int] IDENTITY(1,1) NOT NULL,
	[Latitude] [decimal](18, 18) NOT NULL,
	[Longitude] [decimal](18, 18) NOT NULL,
	[PontoParada] [bit] NOT NULL,
	[DataInclusaoRegistro] [datetime] NULL,
 CONSTRAINT [PK_Ponto] PRIMARY KEY CLUSTERED 
(
	[PontoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblRota]    Script Date: 02/09/2013 00:43:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblRota](
	[RotaID] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](20) NOT NULL,
	[DataInclusaoRegistro] [datetime] NULL,
 CONSTRAINT [PK_Rota] PRIMARY KEY CLUSTERED 
(
	[RotaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblRotaEtinerario]    Script Date: 02/09/2013 00:43:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRotaEtinerario](
	[RotaEtinerarioID] [int] IDENTITY(1,1) NOT NULL,
	[EtinerarioID] [int] NOT NULL,
	[RotaID] [int] NOT NULL,
 CONSTRAINT [PK_RotaEtinerario] PRIMARY KEY CLUSTERED 
(
	[RotaEtinerarioID] ASC,
	[EtinerarioID] ASC,
	[RotaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblRotaPonto]    Script Date: 02/09/2013 00:43:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRotaPonto](
	[RotaPontoID] [int] IDENTITY(1,1) NOT NULL,
	[RotaID] [int] NOT NULL,
	[PontoID] [int] NOT NULL,
	[OrdemPonto] [int] NOT NULL,
	[Quilometragem] [decimal](3, 3) NOT NULL,
 CONSTRAINT [PK_RotaPonto] PRIMARY KEY CLUSTERED 
(
	[RotaPontoID] ASC,
	[RotaID] ASC,
	[PontoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblRua]    Script Date: 02/09/2013 00:43:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblRua](
	[RuaID] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](45) NOT NULL,
	[DataInclusaoRegistro] [datetime] NULL,
 CONSTRAINT [PK_Rua] PRIMARY KEY CLUSTERED 
(
	[RuaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tblRuaPonto]    Script Date: 02/09/2013 00:43:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblRuaPonto](
	[PontoRuaID] [int] IDENTITY(1,1) NOT NULL,
	[RuaID] [int] NOT NULL,
	[PontoID] [int] NOT NULL,
 CONSTRAINT [PK_RuaPonto] PRIMARY KEY CLUSTERED 
(
	[PontoRuaID] ASC,
	[RuaID] ASC,
	[PontoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblUsuario]    Script Date: 02/09/2013 00:43:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblUsuario](
	[UsuarioID] [int] IDENTITY(1,1) NOT NULL,
	[NomeUsuario] [varchar](45) NOT NULL,
	[DataInclusaoRegistro] [datetime] NOT NULL,
	[NiveldeAcesso] [int] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[tblBairroRua]  WITH CHECK ADD  CONSTRAINT [FK_BairroRua] FOREIGN KEY([BairroID])
REFERENCES [dbo].[tblBairro] ([BairroID])
GO
ALTER TABLE [dbo].[tblBairroRua] CHECK CONSTRAINT [FK_BairroRua]
GO
ALTER TABLE [dbo].[tblBairroRua]  WITH CHECK ADD  CONSTRAINT [FK_BairroRua2] FOREIGN KEY([RuaID])
REFERENCES [dbo].[tblRua] ([RuaID])
GO
ALTER TABLE [dbo].[tblBairroRua] CHECK CONSTRAINT [FK_BairroRua2]
GO
ALTER TABLE [dbo].[tblEstadoCidade]  WITH CHECK ADD  CONSTRAINT [FK_EstadoCidade] FOREIGN KEY([EstadoID])
REFERENCES [dbo].[tblEstado] ([EstadoID])
GO
ALTER TABLE [dbo].[tblEstadoCidade] CHECK CONSTRAINT [FK_EstadoCidade]
GO
ALTER TABLE [dbo].[tblEstadoCidade]  WITH CHECK ADD  CONSTRAINT [FK_EstadoCidade2] FOREIGN KEY([CidadeID])
REFERENCES [dbo].[tblCidade] ([CidadeID])
GO
ALTER TABLE [dbo].[tblEstadoCidade] CHECK CONSTRAINT [FK_EstadoCidade2]
GO
ALTER TABLE [dbo].[tblLogin]  WITH CHECK ADD  CONSTRAINT [FK_Login] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[tblUsuario] ([UsuarioID])
GO
ALTER TABLE [dbo].[tblLogin] CHECK CONSTRAINT [FK_Login]
GO
ALTER TABLE [dbo].[tblRotaEtinerario]  WITH CHECK ADD  CONSTRAINT [FK_RotaEtinerario] FOREIGN KEY([EtinerarioID])
REFERENCES [dbo].[tblEtinerario] ([EtinerarioID])
GO
ALTER TABLE [dbo].[tblRotaEtinerario] CHECK CONSTRAINT [FK_RotaEtinerario]
GO
ALTER TABLE [dbo].[tblRotaEtinerario]  WITH CHECK ADD  CONSTRAINT [FK_RotaEtinerario2] FOREIGN KEY([RotaID])
REFERENCES [dbo].[tblRota] ([RotaID])
GO
ALTER TABLE [dbo].[tblRotaEtinerario] CHECK CONSTRAINT [FK_RotaEtinerario2]
GO
ALTER TABLE [dbo].[tblRotaPonto]  WITH CHECK ADD  CONSTRAINT [FK_RotaPonto] FOREIGN KEY([RotaID])
REFERENCES [dbo].[tblRota] ([RotaID])
GO
ALTER TABLE [dbo].[tblRotaPonto] CHECK CONSTRAINT [FK_RotaPonto]
GO
ALTER TABLE [dbo].[tblRotaPonto]  WITH CHECK ADD  CONSTRAINT [FK_RotaPonto2] FOREIGN KEY([PontoID])
REFERENCES [dbo].[tblPonto] ([PontoID])
GO
ALTER TABLE [dbo].[tblRotaPonto] CHECK CONSTRAINT [FK_RotaPonto2]
GO
ALTER TABLE [dbo].[tblRuaPonto]  WITH CHECK ADD  CONSTRAINT [FK_RuaPonto] FOREIGN KEY([RuaID])
REFERENCES [dbo].[tblRua] ([RuaID])
GO
ALTER TABLE [dbo].[tblRuaPonto] CHECK CONSTRAINT [FK_RuaPonto]
GO
ALTER TABLE [dbo].[tblRuaPonto]  WITH CHECK ADD  CONSTRAINT [FK_RuaPonto2] FOREIGN KEY([PontoID])
REFERENCES [dbo].[tblPonto] ([PontoID])
GO
ALTER TABLE [dbo].[tblRuaPonto] CHECK CONSTRAINT [FK_RuaPonto2]
GO
