CREATE TABLE [dbo].[AttendeeInfo]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IsAttending] BIT NOT NULL DEFAULT 0, 
    [UserId] INT NOT NULL
)
