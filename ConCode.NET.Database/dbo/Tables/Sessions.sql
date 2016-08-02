CREATE TABLE [dbo].[Sessions]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Start] DATETIME2 NOT NULL, 
    [TalkTypeId] INT NOT NULL, 
    [TalkId] BIGINT NOT NULL, 
    [SessionStatus] INT NOT NULL
)
