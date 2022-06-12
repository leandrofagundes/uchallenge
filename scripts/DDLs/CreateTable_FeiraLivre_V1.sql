USE [UCHALLENGE]
GO
if not exists (select * from sys.tables where [name] = 'FeiraLivre')
	CREATE TABLE [dbo].[FeiraLivre](
		[Identificador] [int] NOT NULL,
		[NomeFeiraLivre] [nvarchar](30) NOT NULL,
		[RegistroFeiraLivre] [nvarchar](6) NOT NULL,
		[Longitude] [float] NOT NULL,
		[Latitude] [float] NOT NULL,
		[SetorCensitario] [int] NOT NULL,
		[AreaPonderacao] [bigint] NOT NULL,
		[CodigoDistritoIBGE] [int] NOT NULL,
		[NomeDistritoMunicipal] [nvarchar](18) NOT NULL,
		[CodigoSubprefeitura] [nvarchar](2) NOT NULL,
		[NomeSubprefeitura] [nvarchar](25) NOT NULL,
		[RegiaoDivisaoEm5Areas] [nvarchar](6) NOT NULL,
		[RegiaoDivisaoEm8Areas] [nvarchar](7) NOT NULL,
		[Logradouro] [nvarchar](34) NOT NULL,
		[Numero] [nvarchar](5) NOT NULL,
		[Bairro] [nvarchar](20) NULL,
		[PontoDeReferencia] [nvarchar](30) NULL,
	 CONSTRAINT [PK_FEIRALIVRE] PRIMARY KEY CLUSTERED 
	(
		[Identificador] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]
GO