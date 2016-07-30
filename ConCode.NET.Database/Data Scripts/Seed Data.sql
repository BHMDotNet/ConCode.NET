/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
DELETE FROM [ConCode.Net].[dbo].[SpeakerTalks]
DELETE FROM [ConCode.Net].[dbo].[SpeakerInfo]
DELETE FROM [ConCode.Net].[dbo].[Users]

DBCC CHECKIDENT ('[ConCode.Net].[dbo].[SpeakerTalks]', RESEED, 0);
DBCC CHECKIDENT ('[ConCode.Net].[dbo].[SpeakerInfo]', RESEED, 0);
DBCC CHECKIDENT ('[ConCode.Net].[dbo].[Users]', RESEED, 0);
GO

DECLARE @UserId INT
DECLARE @SpeakerId INT
-------------------------------------
-- Speaker Seed Data
-------------------------------------
INSERT INTO [ConCode.Net].[dbo].[Users]
	( [FirstName]
	, [LastName]
	, [Bio]
	, [PhotoUri]
	, [BlogUri]
	, [TwitterHandle]
	, [LinkedInUri]
	, [FacebookUri]
	, [CreatedAt]
	, [ModifiedAt]
	, [ModifiedBy]
	, [Username] )
VALUES 
	( 'Blake'
	, 'Helms'
	, 'I recommend you don''t fire until you''re within 40,000 kilometers. About four years. I got tired of hearing how young I looked. Now we know what they mean by ''advanced'' tactical training. Maybe if we felt any human loss as keenly as we feel one of those close to us, human history would be far less bloody. We know you''re dealing in stolen ore. But I wanna talk about the assassination attempt on Lieutenant Worf.'
	, 'https://pbs.twimg.com/profile_images/287277250/WebReadyColorProfilePhoto.jpg'
	, 'http://theverybestblog.com'
	, 'helmsb'
	, 'blakehelms'
	, 'blakehelms'
	, GETDATE()
	, GETDATE()
	, 'Me'
	, 'bhelms@ebsco.com' )
SELECT @UserId = @@IDENTITY

INSERT INTO [ConCode.Net].[dbo].[SpeakerInfo]
	( Tagline
	, UserId )
VALUES
	( 'Someone very interesting'
	, @UserId )
SELECT @SpeakerId = @@IDENTITY

UPDATE [ConCode.Net].[dbo].[Users]
SET [SpeakerInfoId] = @SpeakerId
WHERE [Id] = @UserId



INSERT INTO [ConCode.Net].[dbo].[Users]
	( [FirstName]
	, [LastName]
	, [Bio]
	, [PhotoUri]
	, [BlogUri]
	, [TwitterHandle]
	, [LinkedInUri]
	, [FacebookUri]
	, [CreatedAt]
	, [ModifiedAt]
	, [ModifiedBy]
	, [Username] )
VALUES 
	( 'Brandon'
	, 'Russell'
	, 'I collect spores, molds, and fungus.'
	, 'http://photos1.meetupstatic.com/photos/member/c/8/6/0/member_257331296.jpeg'
	, 'http://theverybestblog.com'
	, 'brussellz'
	, ''
	, 'blrussell'
	, GETDATE()
	, GETDATE()
	, 'Me'
	, 'brandon@alighttec.com' )
SELECT @UserId = @@IDENTITY

INSERT INTO [ConCode.Net].[dbo].[SpeakerInfo]
	( Tagline
	, UserId )
VALUES
	( 'We''re ready to believe you!'
	, @UserId )
SELECT @SpeakerId = @@IDENTITY

UPDATE [ConCode.Net].[dbo].[Users]
SET [SpeakerInfoId] = @SpeakerId
WHERE [Id] = @UserId