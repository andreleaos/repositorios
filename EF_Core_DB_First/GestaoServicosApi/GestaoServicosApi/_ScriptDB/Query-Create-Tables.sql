USE [servicosdb]
GO
/****** Object:  Table [dbo].[analistaSuporte]    Script Date: 16/09/2022 01:15:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[analistaSuporte](
	[analistaSuporteId] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[ramal] [varchar](50) NULL,
	[analistaAtivo] [bit] NULL,
 CONSTRAINT [PK_analistaSuporte] PRIMARY KEY CLUSTERED 
(
	[analistaSuporteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ordemTrabalho]    Script Date: 16/09/2022 01:15:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ordemTrabalho](
	[requisicaoId] [int] NOT NULL,
	[ordemTrabalhoId] [int] IDENTITY(1,1) NOT NULL,
	[descricao] [varchar](200) NULL,
	[dataAtualizacao] [datetime] NULL,
	[statusOrdemTrabalhoId] [int] NULL,
	[analistaSuporteId] [int] NULL,
 CONSTRAINT [PK_ordemTrabalho] PRIMARY KEY CLUSTERED 
(
	[requisicaoId] ASC,
	[ordemTrabalhoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[requisicao]    Script Date: 16/09/2022 01:15:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[requisicao](
	[requisicaoId] [int] IDENTITY(1,1) NOT NULL,
	[descricao] [varchar](200) NULL,
	[dataAbertura] [datetime] NULL,
	[dataUltimaAtualizacao] [datetime] NULL,
	[dataFechamento] [datetime] NULL,
	[statusId] [int] NULL,
 CONSTRAINT [PK_requisicao] PRIMARY KEY CLUSTERED 
(
	[requisicaoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[statusOrdemTrabalho]    Script Date: 16/09/2022 01:15:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[statusOrdemTrabalho](
	[statusOrdemTrabalhoId] [int] IDENTITY(1,1) NOT NULL,
	[descricao] [varchar](50) NULL,
 CONSTRAINT [PK_statusOrdemTrabalho] PRIMARY KEY CLUSTERED 
(
	[statusOrdemTrabalhoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[statusRequisicao]    Script Date: 16/09/2022 01:15:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[statusRequisicao](
	[statusId] [int] IDENTITY(1,1) NOT NULL,
	[descricao] [varchar](50) NULL,
 CONSTRAINT [PK_statusRequisicao] PRIMARY KEY CLUSTERED 
(
	[statusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ordemTrabalho]  WITH CHECK ADD  CONSTRAINT [FK_ordemTrabalho_analistaSuporte] FOREIGN KEY([analistaSuporteId])
REFERENCES [dbo].[analistaSuporte] ([analistaSuporteId])
GO
ALTER TABLE [dbo].[ordemTrabalho] CHECK CONSTRAINT [FK_ordemTrabalho_analistaSuporte]
GO
ALTER TABLE [dbo].[ordemTrabalho]  WITH CHECK ADD  CONSTRAINT [FK_ordemTrabalho_requisicao] FOREIGN KEY([requisicaoId])
REFERENCES [dbo].[requisicao] ([requisicaoId])
GO
ALTER TABLE [dbo].[ordemTrabalho] CHECK CONSTRAINT [FK_ordemTrabalho_requisicao]
GO
ALTER TABLE [dbo].[ordemTrabalho]  WITH CHECK ADD  CONSTRAINT [FK_ordemTrabalho_statusOrdemTrabalho] FOREIGN KEY([statusOrdemTrabalhoId])
REFERENCES [dbo].[statusOrdemTrabalho] ([statusOrdemTrabalhoId])
GO
ALTER TABLE [dbo].[ordemTrabalho] CHECK CONSTRAINT [FK_ordemTrabalho_statusOrdemTrabalho]
GO
ALTER TABLE [dbo].[requisicao]  WITH CHECK ADD  CONSTRAINT [FK_requisicao_statusRequisicao] FOREIGN KEY([statusId])
REFERENCES [dbo].[statusRequisicao] ([statusId])
GO
ALTER TABLE [dbo].[requisicao] CHECK CONSTRAINT [FK_requisicao_statusRequisicao]
GO
