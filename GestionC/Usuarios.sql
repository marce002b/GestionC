USE [ChallengeGC]
GO

/****** Object: Table [dbo].[Usuario] Script Date: 2022-07-04 1:36:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Usuario] (
    [Id]       INT           NOT NULL,
    [Nombre]   NVARCHAR (50) NULL,
    [Apellido] NVARCHAR (50) NULL,
    [Email]    NVARCHAR (50) NULL,
    [Password] NCHAR (10)    NULL
);


