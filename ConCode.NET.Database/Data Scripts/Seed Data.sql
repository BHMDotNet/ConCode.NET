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
DELETE FROM [dbo].[Sponsors]
DELETE FROM [dbo].[Talks]
DELETE FROM [dbo].[SpeakerTalks]
DELETE FROM [dbo].[AttendeeInfo]
DELETE FROM [dbo].[SpeakerInfo]
DELETE FROM [dbo].[Users]

DBCC CHECKIDENT ('[dbo].[Sponsors]', RESEED, 0);
DBCC CHECKIDENT ('[dbo].[Talks]', RESEED, 0);
DBCC CHECKIDENT ('[dbo].[SpeakerTalks]', RESEED, 0);
DBCC CHECKIDENT ('[dbo].[AttendeeInfo]', RESEED, 0);
DBCC CHECKIDENT ('[dbo].[SpeakerInfo]', RESEED, 0);
DBCC CHECKIDENT ('[dbo].[Users]', RESEED, 0);
GO

DECLARE @UserId INT
DECLARE @AttendeeId INT
DECLARE @SpeakerId INT
-------------------------------------
-- Speaker Seed Data
-------------------------------------
INSERT INTO [dbo].[Users]
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

INSERT INTO [dbo].[SpeakerInfo]
	( Tagline
	, UserId )
VALUES
	( 'Someone very interesting'
	, @UserId )
SELECT @SpeakerId = @@IDENTITY

INSERT INTO [dbo].[AttendeeInfo]
	( IsAttending
	, UserId )
VALUES
	( 1
	, @UserId )
SELECT @AttendeeId = @@IDENTITY

UPDATE [dbo].[Users]
SET [SpeakerInfoId] = @SpeakerId
	, [AttendeeInfoId] = @AttendeeId
WHERE [Id] = @UserId



INSERT INTO [dbo].[Users]
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

INSERT INTO [dbo].[SpeakerInfo]
	( Tagline
	, UserId )
VALUES
	( 'We''re ready to believe you!'
	, @UserId )
SELECT @SpeakerId = @@IDENTITY

INSERT INTO [dbo].[AttendeeInfo]
	( IsAttending
	, UserId )
VALUES
	( 1
	, @UserId )
SELECT @AttendeeId = @@IDENTITY

UPDATE [dbo].[Users]
SET [SpeakerInfoId] = @SpeakerId
	, [AttendeeInfoId] = @AttendeeId
WHERE [Id] = @UserId


-------------------------------------
-- Talk Seed Data
-------------------------------------
INSERT INTO [dbo].[Talks]
	( [Title]
	, [Abstract]
	, [TimesPresented]
	, [Level]
	, [SpeakerInfoId] )
VALUES
	( 'Deep Dive Into Workflow Foundation'
	, 'I recommend you don''t fire until you''re within 40,000 kilometers. About four years. I got tired of hearing how young I looked. Now we know what they mean by ''advanced'' tactical training. Maybe if we felt any human loss as keenly as we feel one of those close to us, human history would be far less bloody. We know you''re dealing in stolen ore. But I wanna talk about the assassination attempt on Lieutenant Worf.'
	, 27
	, 2
	, 1 )

INSERT INTO [dbo].[Talks]
	( [Title]
	, [Abstract]
	, [TimesPresented]
	, [Level]
	, [SpeakerInfoId] )
VALUES
	( 'The Color Tuple'
	, 'Sometimes we just need to have a talk about these things.'
	, 1
	, 1
	, 2 )

-------------------------------------
-- Sponsor Seed Data
-------------------------------------
INSERT INTO [dbo].[Sponsors]
	( [Name]
	, [WebsiteUrl]
	, [ImageUrl] )
VALUES
	( 'Initech'
	, 'http://www.initech.com'
	, 'http://moviesmedia.ign.com/movies/image/article/115/1157513/initech_1301965579.jpg' )

INSERT INTO [dbo].[Sponsors]
	( [Name]
	, [WebsiteUrl]
	, [ImageUrl] )
VALUES
	( 'Dunder Mifflin, Inc.'
	, 'http://www.dundermifflin.com'
	, 'http://ih1.redbubble.net/image.55130916.7058/ap,550x550,16x12,1,transparent,t.png' )

INSERT INTO [dbo].[Sponsors]
	( [Name]
	, [WebsiteUrl]
	, [ImageUrl] )
VALUES
	( 'Pied Piper'
	, 'http://www.piedpiper.com'
	, 'http://static.squarespace.com/static/531f2c4ee4b002f5b011bf00/t/536bdcefe4b03580f8f6bb16/1399577848961/hbosiliconvalleypiedpiperoldlogo' )