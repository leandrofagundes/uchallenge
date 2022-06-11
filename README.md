# uchallenge
This repository is a tech challenge I'm trying to present my knowledge using C#, Asp.Net Core, Entity Framework, Patterns, SOLID, and Other stuff.

## About it

My main goal is to show a little about my knowledge with this repository.
I'm using here a few principles from many ideas, but most focused on Hexagonal Architecture based on the Clean Architecture book from Robert Martin.
Even with not using the CQRS pattern "as is", the idea runs separating the concerns of persistence and querying data. The memory cache of asp.net core will be used for show as a possibility, but the idea behind it is show the separation of concerns.

The Challenge comes to me in Portuguese, that's why the section 'Challenge' is still in Portuguese.

The code and documentation will be in English to make it easier for anyone else who wants to check it here.

One of the challenges here is the Domain. As the proposal uses "Brazilian terms", it's hard to bring the models to English, but let's get it a try.

## Challenge (in Portuguese from original scope)

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

After that, I must create a restful API where users can create/update/delete/get the loaded data from the relational database.

So, let's begin.

## Setup

### Database

You will need an SQLServer Instance running on the machine. You can create a Database using your IDE if you prefer. 
If this is your case, create with the name UChallenge and skip step 1.
Consider the last thoughts before running those scripts:
 - Creating your database with your IDE, does not need to run the script CreateDatabase_UCheckChallenge_V1.sql.
 - The connection strings by its default use a trusted connection. If you want to use a login and password for connection, configure your database correctly and change the connection string on the application (explained later).
 - CreateTable_FeiraLivre_V1 is a DDL script to create the table used for data load. If a table with the name FeiraLivre already exists, the script will not try to recreate it. Be sure there isn't a table with its name on your database or a table with a schema that fits the same script that exists.
 - The LoadTable_FeiraLivre_V1 must need you to edit the script before running it. This script has a reference to the DATA file to load on row 24. Change the path for the current DEINFO_AB_FEIRASLIVRES_2014.CSV file before running it. Change the path to best fit your environment.
 
Attention: The original DEINFO_AB_FEIRASLIVRES_2014.csv comes with an unnormalized data problem. If you prefer to download the original file, insert a comma (,) on the last row with data, at the end of the row if it does not exist.

After reading the considerations, run the scripts you need in that order.
1) \scripts\DDLs\CreateDatabase_UCheckChallenge_V1.sql 
2) \scripts\DDLs\CreateTable_FeiraLivre_V1.sql
3) \scripts\DMLs\LoadTable_FeiraLivre_V1.sql


## Final Thoughts

The solution could look overengineering for the requirements but, I want to put a few different knowledge just to show possible implementations it could have.
Off course, other principles, patterns, and strategies could be applied, but I will focus on what I think is more important. One example could be the mappers.
The model was a pain because I want to keep Portuguese, but at the same time, I want to see this repository more open to other opportunities if this one doesn't work.
A few decisions like using Exceptions in input data is probably not the better one, but I'll think later about a better approach. Probably having a TryParse solution for the value object, should resolve both problems.
Another thing is about creating Value Objects (structs) for every single attribute of a model. I believe it can give better control over models. Right now, I'm using it only for Latitude and Longitude, but maybe I evolve it.
I'll prefer to work with Portuguese for this solution or have more data about the domain in English for its project. Something we don't have for challenges.
Feel free to ask me new ideas or questions about why I used something specifically on its repository.

### A few ideas

- OData for updates and queries could be interesting. I'll try to implement it before the deadline.
-.NetCore MemoryCache must be overengineering but I'll try to implement it too.