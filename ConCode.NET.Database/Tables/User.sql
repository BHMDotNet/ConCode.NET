CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(100) NOT NULL, 
    [LastName] NVARCHAR(100) NOT NULL, 
    [Bio] NVARCHAR(500) NULL, 
    [PhotoUri] NVARCHAR(200) NULL, 
    [BlogUri] NVARCHAR(200) NULL, 
    [TwitterHandle] NVARCHAR(50) NULL, 
    [LinkedInUri] NVARCHAR(200) NULL, 
    [FacebookUri] NVARCHAR(200) NULL, 
    [CreatedAt] DATETIME NOT NULL, 
    [ModifiedAt] DATETIME NOT NULL, 
    [ModifiedBy] NVARCHAR(50) NOT NULL, 
    [Username] NVARCHAR(50) NOT NULL
)
