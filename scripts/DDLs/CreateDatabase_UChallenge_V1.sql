USE [master]
GO

if not exists (select * from sys.databases where [name] = 'UChallenge')
BEGIN
	CREATE DATABASE [UCHALLENGE]
END
GO