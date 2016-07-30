CREATE TABLE [dbo].[Talks]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Title] NVARCHAR(500) NOT NULL, 
    [Abstract] NVARCHAR(2000) NULL, 
    [TimesPresented] INT NOT NULL, 
	[Level] INT NOT NULL,
    [SpeakerInfoId] BIGINT NOT NULL
)
