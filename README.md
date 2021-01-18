# TaskApi

Först måste man skapa en db i sql-server (localhost):

1. Kolla så den inte finns redan, i så fall droppa den:

USE master
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'DHTest')
    DROP DATABASE [DHTest]
GO

2.Skapa databasen och en tabell:
CREATE DATABASE [DHTest]

GO

USE [DHTest]

GO


CREATE TABLE [DHTasks] 
(
[TaskId] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
[Task] [nvarchar](500) NOT NULL,
[Completed] [bit] NOT NULL DEFAULT 0
)

insert into [DHTest].[dbo].[DHTasks]
(Task) values ('Bli frisk från covid')
insert into [DHTest].[dbo].[DHTasks]
(Task) values ('Beställa Maxi-påse')
insert into [DHTest].[dbo].[DHTasks]
(Task) values ('Hämta Maxi-påse')
insert into [DHTest].[dbo].[DHTasks]
(Task) values ('Hämta ved')
