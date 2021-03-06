
USE [MagicECertCA]
GO
/****** Object:  Table [dbo].[X509Certificate]    Script Date: 06/03/2017 17:55:31 ******/
CREATE TABLE [dbo].[X509Certificate](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[version] [float] NOT NULL,
	[serial_number] [varchar](max) NOT NULL,
	[signature_algorithm] [varchar](max) NOT NULL,
	[issuer_name] [nvarchar](255) NOT NULL,
	[validity_period] [varchar](50) NOT NULL,
	[subject_name] [nvarchar](255) NOT NULL,
	[public_key] [nvarchar](max) NOT NULL,
	[extensions] [nvarchar](255) NULL,
	[signature] [varchar](max) NOT NULL,
 CONSTRAINT [PK_X509Certificate] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)
)
/****** Object:  Table [dbo].[User]    Script Date: 06/03/2017 17:55:31 ******/

GO
CREATE TABLE [dbo].[User](
	[uId] [int] IDENTITY(1,1) NOT NULL,
	[uName] [nvarchar](50) NOT NULL,
	[uPasswd] [nvarchar](max) NOT NULL,
	[uEmail] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[uId] ASC
))
GO
/****** Object:  StoredProcedure [dbo].[spUpdateX509Cert]    Script Date: 06/03/2017 17:55:32 ******/
CREATE PROCEDURE [dbo].[spUpdateX509Cert]
@ID int,
@Version nvarchar(max),
@SerialNumber nvarchar(max),
@SignatureAlgorithm nvarchar(max),
@IssuerName nvarchar(max),
@ValidityPeriod nvarchar(max),
@PublicKey nvarchar(max),
@SubjectuniqueID nvarchar(max),
@Extensions nvarchar(max),
@Signature nvarchar(max)
as
Update X509Certificate set version=@Version,serial_number=@SerialNumber,
signature_algorithm=@SignatureAlgorithm, issuer_name=@IssuerName,
validity_period=@ValidityPeriod,public_key=@PublicKey,
subject_name=@SubjectuniqueID,extensions=@Extensions,signature=@Signature
Where Id=@ID
GO
/****** Object:  StoredProcedure [dbo].[spUpdateUser]    Script Date: 06/03/2017 17:55:32 ******/
GO
Create PROCEDURE [dbo].[spUpdateUser]
@Id int,
@UserName nvarchar(max),
@Password nvarchar(max),
@Mail nvarchar(max)
as
Update [User] set uName=@UserName,uPasswd=@Password,uEmail=@Mail where uId = @Id
GO
/****** Object:  StoredProcedure [dbo].[spInsertX509Cert]    Script Date: 06/03/2017 17:55:32 ******/
GO
-- =============================================
-- Author:		phituoc
-- Create date: 30-5-2017
-- Description:	insert to x509 cert
-- =============================================
CREATE PROCEDURE [dbo].[spInsertX509Cert] 
	-- Add the parameters for the stored procedure here
@version float,
@serial varchar(MAX),
@signatureAlgorithm varchar(Max),
@issuer varchar(50),
@validity varchar(50),
@subject nvarchar(50),
@public varchar(50),
@extensions nvarchar(50),
@signature varchar(MAX) 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into X509Certificate(version, serial_number, signature_algorithm, issuer_name, validity_period, subject_name, public_key, extensions, signature)
	values (@version, @serial, @signatureAlgorithm, @issuer, @validity, @subject, @public, @extensions, @signature)
END
GO
/****** Object:  StoredProcedure [dbo].[spInsertUser]    Script Date: 06/03/2017 17:55:32 ******/
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spInsertUser]
@UserName nvarchar(max),
@Password nvarchar(max),
@Mail nvarchar(max)
as
Insert into [User] (uName,uPasswd,uEmail) values(@UserName,@Password,@Mail)
GO
/****** Object:  StoredProcedure [dbo].[spDeleteCA]    Script Date: 06/03/2017 17:55:32 ******/
GO
-- =============================================
-- Author:		nguyenvanphituoc
-- Create date: 30/05
-- Description:	delete
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteCA]
@Id int
as
Delete from X509Certificate where id=@Id
GO
/****** Object:  Table [dbo].[PersonalData]    Script Date: 06/03/2017 17:55:32 ******/
GO
CREATE TABLE [dbo].[PersonalData](
	[uId] [int] NOT NULL,
	[ca_serial_number] [varchar](max) NOT NULL,
	[ca_id] [int] NOT NULL,
	[caPriKey] [varchar](max) NOT NULL,
	[caPubkey] [varchar](max) NOT NULL,
	[caEnable] [bit] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
GO
/****** Object:  StoredProcedure [dbo].[spDeleteUser]    Script Date: 06/03/2017 17:55:32 ******/
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spDeleteUser]
@id int
 as
Delete from [dbo].[User] where uId=@Id
GO
/****** Object:  StoredProcedure [dbo].[spDeletePersonData]    Script Date: 06/03/2017 17:55:32 ******/
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spDeletePersonData]
@uId int ,
@caId int
as
Delete from PersonalData where uId=@uId and ca_id = @caId
GO
/****** Object:  StoredProcedure [dbo].[spInsertPersonalData]    Script Date: 06/03/2017 17:55:32 ******/
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spInsertPersonalData]

@PublicKey nvarchar(max),
@PrivateKey nvarchar(max),
@SerialNumber varchar(max),
@UId int,
@CAId int
as
Insert into PersonalData (uId, ca_serial_number, ca_id, caPriKey, caPubkey, caEnable) values(@UId, @SerialNumber, @CAId, @PrivateKey, @PublicKey, 1)
GO
/****** Object:  Default [DF_PersonalData_caEnable]    Script Date: 06/03/2017 17:55:32 ******/
ALTER TABLE [dbo].[PersonalData] ADD  CONSTRAINT [DF_PersonalData_caEnable]  DEFAULT ((1)) FOR [caEnable]
GO
/****** Object:  ForeignKey [FK_PersonalData_User]    Script Date: 06/03/2017 17:55:32 ******/
ALTER TABLE [dbo].[PersonalData]  WITH CHECK ADD  CONSTRAINT [FK_PersonalData_User] FOREIGN KEY([uId])
REFERENCES [dbo].[User] ([uId])
GO
ALTER TABLE [dbo].[PersonalData] CHECK CONSTRAINT [FK_PersonalData_User]
GO
/****** Object:  ForeignKey [FK_PersonalData_X509Certificate]    Script Date: 06/03/2017 17:55:32 ******/
ALTER TABLE [dbo].[PersonalData]  WITH CHECK ADD  CONSTRAINT [FK_PersonalData_X509Certificate] FOREIGN KEY([ca_id])
REFERENCES [dbo].[X509Certificate] ([id])
GO
ALTER TABLE [dbo].[PersonalData] CHECK CONSTRAINT [FK_PersonalData_X509Certificate]
GO
