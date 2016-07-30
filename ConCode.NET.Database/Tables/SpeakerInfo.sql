CREATE TABLE [dbo].[SpeakerInfo]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY (1, 1), 
    [Tagline] NVARCHAR(200) NULL, 
    [UserId] INT NOT NULL
)
