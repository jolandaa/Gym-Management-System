USE [master]
GO

CREATE DATABASE [GymDB]
GO
ALTER DATABASE [GymDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GymDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [GymDB] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [GymDB] SET ANSI_NULLS OFF
GO
ALTER DATABASE [GymDB] SET ANSI_PADDING OFF
GO
ALTER DATABASE [GymDB] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [GymDB] SET ARITHABORT OFF
GO
ALTER DATABASE [GymDB] SET AUTO_CLOSE ON
GO
ALTER DATABASE [GymDB] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [GymDB] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [GymDB] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [GymDB] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [GymDB] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [GymDB] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [GymDB] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [GymDB] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [GymDB] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [GymDB] SET  DISABLE_BROKER
GO
ALTER DATABASE [GymDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [GymDB] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [GymDB] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [GymDB] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [GymDB] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [GymDB] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [GymDB] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [GymDB] SET  READ_WRITE
GO
ALTER DATABASE [GymDB] SET RECOVERY SIMPLE
GO
ALTER DATABASE [GymDB] SET  MULTI_USER
GO
ALTER DATABASE [GymDB] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [GymDB] SET DB_CHAINING OFF
GO
USE [GymDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TblTrainers](
	[trainerid] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[address] [varchar](300) NULL,
	[contactno] [varchar](20) NULL,
	[gender] [varchar](10) NULL,
	[dob] [date] NULL,
	[email] [varchar](70) NULL,
	[city] [varchar](25) NULL,
	[state] [varchar](25) NULL,
	[salary] [int] NULL,
	[password] [varchar](500) NULL,
	[doj] [varchar](50) NULL,
 CONSTRAINT [PK_TblTrainers] PRIMARY KEY CLUSTERED ([trainerid] ASC)
 WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[TblMembers](
	[memberid] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[address] [varchar](300) NULL,
	[contactno] [varchar](20) NULL,
	[gender] [varchar](10) NULL,
	[dob] [varchar](50) NULL,
	[email] [varchar](70) NULL,
	[city] [varchar](25) NULL,
	[state] [varchar](25) NULL,
	[month] [int] NULL,
	[onemonthfee] [int] NULL,
	[totalfee] [int] NULL,
	[receivedfee] [int] NULL,
	[password] [varchar](500) NULL,
	[doj] [varchar](50) NULL,
	[expiredate] [varchar](50) NULL,
 CONSTRAINT [PK_TblMembers] PRIMARY KEY CLUSTERED 
(
	[memberid] ASC
)
WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO


CREATE TABLE [dbo].[TblMeasurements] (
    [measurementId] INT IDENTITY (1, 1) NOT NULL,
    [memberid]      INT NOT NULL,
    [height]        INT NOT NULL,
    [weight]        INT NOT NULL,
    [BMI]           INT NOT NULL,
    CONSTRAINT [PK_TblMeasurements] PRIMARY KEY CLUSTERED ([measurementId] ASC)
	WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
    CONSTRAINT [FK1] FOREIGN KEY ([memberid]) REFERENCES [dbo].[TblMembers] ([memberid])
);
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[TblTrainerAllocation](
	[trainerid] [int] NOT NULL,
	[memberid] [int] NOT NULL,
	    CONSTRAINT [FK2] FOREIGN KEY ([memberid]) REFERENCES [dbo].[TblMembers] ([memberid]),
    CONSTRAINT [FK3] FOREIGN KEY ([trainerid]) REFERENCES [dbo].[TblTrainers] ([trainerid])
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[TblMemberPlan] (
    [planId] INT IDENTITY (1, 1) NOT NULL,
    [memberid]      INT NOT NULL,
	[mon] [varchar](200) NULL,
	[tues] [varchar](200) NULL,
	[wed] [varchar](200) NULL,
	[thu] [varchar](200) NULL,
	[fri] [varchar](200) NULL,
	[satu] [varchar](200) NULL,
	[sun] [varchar](200) NULL,
	[fromtime] [varchar](100) NULL,
	[totime] [varchar](100) NULL,
    CONSTRAINT [PK_TblMemberPlan] PRIMARY KEY CLUSTERED ([planId] ASC)
	WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
    CONSTRAINT [FK_MemberPlan_1] FOREIGN KEY ([memberid]) REFERENCES [dbo].[TblMembers] ([memberid])
);
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[TblAdmin](
	[email] [varchar](50) NOT NULL,
	[password] [varchar](50) NULL,
 CONSTRAINT [PK_TblAdmin] PRIMARY KEY CLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF

GO

/* procedure to search member by name */
CREATE PROCEDURE [dbo].[FindMember]
	@memberName NVARCHAR(30)
AS
Begin
Set NOCOUNT ON;
SELECT *,CONVERT(VARCHAR(10), dob, 105) as d,(totalfee - receivedfee) as remainingfee FROM [dbo].[TblMembers]
INNER JOIN [dbo].[TblMeasurements] 
ON TblMembers.memberid = TblMeasurements.memberid AND TblMembers.name LIKE '%' + @memberName + '%'
INNER JOIN [dbo].[TblMemberPlan]
ON TblMeasurements.memberid = TblMemberPlan.memberid
END
GO

/* procedure to search trainer by name */
CREATE PROCEDURE [dbo].[FindTrainer]
@trainerName NVARCHAR(30)
AS
Begin
Set NOCOUNT ON;
SELECT *,CONVERT(VARCHAR(10), dob, 105) as d FROM [dbo].[TblTrainers]
WHERE TblTrainers.name LIKE '%' + @trainerName + '%'
END

GO

/* create rule for phone number it should be with length = 14, first letter should be + and fifth letter should be - */
CREATE RULE rule_PhoneNo AS (@phone='UnknownNumber') 
OR (LEN(@phone)=14
AND SUBSTRING(@phone,1,1)='+'
AND SUBSTRING(@phone,5,1)='-')
GO

/* create default value for phone number */
CREATE DEFAULT Default_PhNo AS 'UnknownNumber' 
GO

/* create data type for phone number and change columns types*/
CREATE TYPE [dbo].[PhoneNumberNew] FROM [nvarchar](50) NULL
GO
Alter table [dbo].[TblMembers] alter column   [contactno] [dbo].[PhoneNumberNew]
Alter table [dbo].[TblTrainers] alter column   [contactno] [dbo].[PhoneNumberNew]

/* bing default value and rule to data type phone number */
EXEC sys.sp_bindefault @defname=N'[dbo].[Default_PhNo]', @objname=N'[dbo].[PhoneNumberNew]' , @futureonly='futureonly'
GO
EXEC sys.sp_bindrule @rulename=N'[dbo].[rule_PhoneNo]', @objname=N'[dbo].[PhoneNumberNew]' , @futureonly='futureonly'
GO


/* View to get all informations of members and trainers that are allocated */
CREATE VIEW TrainersMembersAllocationList
AS
select T.name AS [TrainerName] , 
T.email AS [TrainerEmail], M.name as [MemberName], M.email as [MemberEmail], A.trainerid as trainerid, A.memberid as memberid from [dbo].[TblTrainerAllocation] A
INNER JOIN [dbo].[TblTrainers] T
ON A.trainerid = T.trainerid
INNER JOIN [dbo].[TblMembers] M
ON A.memberid = M.memberid
GO

/* View to get remaining memberships */
CREATE VIEW RemainingMembership
AS
select M.memberid as memberid, M.name as name, M.address as address, M.contactno as contactno, M.gender as gender, M.email as email, M.city as city, M.state as state, M.month as month, 
M.onemonthfee as onemonthfee, M.totalfee as totalfee, M.receivedfee as receivedfee, M.password as password, M.doj as doj, M.expiredate as expiredate ,
CONVERT(VARCHAR(10), dob, 105) as d,(totalfee - receivedfee) as remainingfee, MMeas.height as height, MMeas.weight as weight, MMeas.BMI as BMI, MMeas.measurementId as measurementId, 
MPLAN.planId as planId, MPlan.fromtime as fromtime, MPlan.totime as totime from [dbo].[TblMembers] M
left join TblMeasurements MMeas ON M.memberid = MMeas.memberid AND (M.totalfee - M.receivedfee) != 0 
left join TblMemberPlan MPlan ON M.memberid = MPlan.memberid
Go	




/* create function to calculate remaining value for member that is passes as parameter */
IF OBJECT_ID (N'dbo.ufnGetRemainingValue', N'FN') IS NOT NULL
    DROP FUNCTION ufnGetRemainingValue;
GO
CREATE FUNCTION dbo.ufnGetRemainingValue(@memberid int)
RETURNS int
AS
-- Returns the remaining value of one member
BEGIN
    DECLARE @ret int;
    SELECT @ret = (Members.totalfee - Members.receivedfee)
    FROM TblMembers Members
    WHERE Members.memberid = @memberid
     IF (@ret IS NULL)
        SET @ret = 0;
    RETURN @ret;
END;
GO
/* using function to calculate Remaining value */
select *,CONVERT(VARCHAR(10), dob, 105) as d,dbo.ufnGetRemainingValue(TblMembers.memberid)AS remainingfee from TblMembers INNER JOIN TblMeasurements ON TblMembers.memberid = TblMeasurements.memberid INNER JOIN TblMemberPlan ON TblMembers.memberid = TblMemberPlan.memberid Order By name ASC;
GO

