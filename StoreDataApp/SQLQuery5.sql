USE [project]
GO

/****** Object:  Table [dbo].[UserData]    Script Date: 5/11/2022 3:06:57 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserData]') AND type in (N'U'))
DROP TABLE [dbo].[UserData]
GO

/****** Object:  Table [dbo].[UserData]    Script Date: 5/11/2022 3:06:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserData](
	[userName] [nchar](10) not NULL primary key,
	[phoneNo] [nchar](10) not NULL,
	[address] [nvarchar](max) not NULL,
	[email] [nvarchar](50) not NULL,
	[password] [nchar](10) not NULL,
	[re-password] [nchar](10) not NULL,
	[gender] [nchar](10) not NULL,
	[dp] [nvarchar](max) not NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO



