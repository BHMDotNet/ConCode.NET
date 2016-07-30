CREATE TABLE [dbo].[SpeakerTalks]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY (1, 1), 
    [SpeakerId] INT NOT NULL, 
    [TalkId] INT NOT NULL
)
