CREATE TABLE #temp_FeirasLivres
(
	[Identificador] [int] NOT NULL,
	[Longitude] [bigint],
	[Latitude] [bigint],
	[SetorCensitario] [int],
	[AreaPonderacao] [bigint],
	[CodigoDistritoIBGE] [int],
	[NomeDistritoMunicipal] [nvarchar](18),
	[CodigoSubprefeitura] [int],
	[NomeSubprefeitura] [nvarchar](25),
	[RegiaoDivisaoEm5Areas] [nvarchar](6),
	[RegiaoDivisaoEm8Areas] [nvarchar](7),
	[nomeLivre] [nvarchar](30) ,
	[registroLivre] [nvarchar](6) ,
	[Logradouro] [nvarchar](34) ,
	[Numero] [nvarchar](15) ,
	[Bairro] [nvarchar](20) ,
	[PontoDeReferencia] [nvarchar](35) 
)
GO

BULK INSERT #temp_FeirasLivres
FROM 'DEINFO_AB_FEIRASLIVRES_2014.csv'
WITH
(
FORMAT = 'CSV',
FirstRow = 2
);
GO

insert into FEIRALIVRE
SELECT 
	Identificador,
	nomeLivre,
	registroLivre,
	STUFF(Longitude,4,0,'.'),
	STUFF(Latitude,4,0,'.'),
	SetorCensitario, 
	AreaPonderacao,
	CodigoDistritoIBGE,
	NomeDistritoMunicipal,
	CodigoSubprefeitura,
	NomeSubprefeitura,
	RegiaoDivisaoEm5Areas,
	RegiaoDivisaoEm8Areas,
	Logradouro,
	CASE ISNUMERIC(Numero)
		WHEN 1 THEN CAST(Cast(numero as numeric) AS NVARCHAR(5)) 
		ELSE 'S/N' 
	END,
	Bairro,
	PontoDeReferencia 
FROM #temp_FeirasLivres
GO 

DROP TABLE #temp_FeirasLivres
GO

