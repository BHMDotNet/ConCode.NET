﻿CREATE TABLE [dbo].[Sponsors]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(255) NOT NULL,
	[WebsiteUrl] NVARCHAR(200) NULL,
	[ImageUrl] NVARCHAR(200) NULL
)
