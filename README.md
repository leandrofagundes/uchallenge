# uchallenge
This repository is a tech challenge I'm trying to present my knowledge using C#, Asp.Net Core, Entity Framework, Patterns, SOLID, and Other stuff.

## About it

My main goal is to show a little about my knowledge with this repository.
The Challenge comes to me in Portuguese, that's why the section 'Challenge' is still in Portuguese.

The code and documentation will be in English to make it easier for anyone else who wants to check it here.

One of the challenges here is the Domain. As the proposal uses "Brazilian terms", it's hard to bring the models to English, but let's get it a try.

## Challenge (in portuguese from original scope)

### Proposta:
Desenvolver uma API que exponha os dados disponíveis em http://www.prefeitura.sp.gov.br/cidade/secretarias/upload/chamadas/feiras_livres_1429113213.zip utilizando uma abordagem orientada a recursos e que atenda os requisitos listados abaixo.

### Escopo

Utilizando os dados do arquivo “DEINFO_AB_FEIRASLIVRES_2014.csv” (pasta data do projeto), implemente:

- cadastro de uma nova feira;
- exclusão de uma feira através de seu código de registro;
- alteração dos campos cadastrados de uma feira, exceto seu código de registro;
- busca de feiras utilizando ao menos um dos parâmetros abaixo: 
	-- distrito 
	-- regiao5 
	-- nome_feira 
	-- bairro

### Requisitos
utilize git ou hg para fazer o controle de versão da solução do teste e hospede-a no Github ou Bitbucket;
armazene os dados fornecidos pela Prefeitura de São Paulo em um banco de dados relacional que você julgar apropriado;
a solução deve conter um script para importar os dados do arquivo “DEINFO_AB_FEIRASLIVRES_2014.csv” para o banco relacional;
a API deve seguir os conceitos REST;
- o Content-Type das respostas da API deve ser “application/json";
- o código da solução deve conter testes e algum mecanismo documentado para gerar a informação de cobertura dos testes;
- a aplicação deve gravar logs estruturados em arquivos texto;
- a solução desta avaliação deve estar documentada em português ou inglês. Escolha um idioma em que você seja fluente;
- a documentação da solução do teste deve incluir como rodar o projeto e exemplos de requisições e suas possíveis respostas;

## Overview

First, as a challenging step, we need to import data from a CSV file existing.
I can use any relational database I want, so I go for MSSQL right now.

The “DEINFO_AB_FEIRASLIVRES_2014.csv” which we need to load can be found on the zip file here: http://www.prefeitura.sp.gov.br/cidade/secretarias/upload/chamadas/feiras_livres_1429113213.zip
or inside the folder data, on this project root.

After that, I must create a restfull API where users can create/update/delete/get the loaded data from the relational database.

So, lets begin.

## Setup

### Database

You will need an SQLServer Instance running on the machine. You can create a Database using your IDE if you prefer. If this is your case, create with the name UChallenge and skip step 1.
With your preferred client, execute the scripts on the folder scripts in this order:

Attention: To create the database. You can skip this step if you already have a database created. The database name should be UChallenge.
Attention2: To create the table we will use this application, use the script on step 2.
Attention3: The next step must need you to edit the script before running it. This script has a reference to the DATA file to load on row 24. Fill with the path for the current DEINFO_AB_FEIRASLIVRES_2014.CSV file before running it. Change the path to best fit your environment.
Attention4: The original DEINFO_AB_FEIRASLIVRES_2014.csv comes with an invalid data problem. If you prefer to download the file, insert a comma (,) on the last row with data, at the end of the row if it does not exist.
1) \scripts\DDLs\CreateDatabase_UCheckChallenge_V1.sql 
2) \scripts\DDLs\CreateTable_FeiraLivre_V1.sql
3) \scripts\DMLs\LoadTable_FeiraLivre_V1.sql


## Final Thoughts

The solution could look overengineering for the requirements but, I really want to put a few different knowledge just to show possible implementations it could have.
Off course, other principles and patterns could be applied, but I have a deadline for now.
The model was a pain because I want to keep Portuguese, but at the same time, I want to see this repository more open to other opportunities if this one doesn't work.
I'll really prefer to work with Portuguese for this solution or have more data about the domain in English for its project. Something we don't have for challenges.
Feel free to ask me new ideas or questions about why I used something specifically on its repository.

### A few ideas

- OData for updates and queries could be interesting. I'll try to implement it before the deadline.
- .NetCore MemoryCache must be overengineering but I'll try to implement it too.