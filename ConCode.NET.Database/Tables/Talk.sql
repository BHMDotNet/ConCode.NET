CREATE TABLE [dbo].[Talk]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(500) NOT NULL, 
    [Abstract] NVARCHAR(2000) NULL, 
    [TimesPresented] INT NOT NULL, 
    [SpeakerInfoId] NCHAR(10) NOT NULL
)
