USE [master]
GO
/****** Object:  Database [epiworx_test]    Script Date: 03/01/2011 17:17:27 ******/
CREATE DATABASE [epiworx_test] ON  PRIMARY 
( NAME = N'epiworx-test', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\epiworx-test.mdf' , SIZE = 7168KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'epiworx-test_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\epiworx-test_log.ldf' , SIZE = 1280KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [epiworx_test] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [epiworx_test].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [epiworx_test] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [epiworx_test] SET ANSI_NULLS OFF
GO
ALTER DATABASE [epiworx_test] SET ANSI_PADDING OFF
GO
ALTER DATABASE [epiworx_test] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [epiworx_test] SET ARITHABORT OFF
GO
ALTER DATABASE [epiworx_test] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [epiworx_test] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [epiworx_test] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [epiworx_test] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [epiworx_test] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [epiworx_test] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [epiworx_test] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [epiworx_test] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [epiworx_test] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [epiworx_test] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [epiworx_test] SET  DISABLE_BROKER
GO
ALTER DATABASE [epiworx_test] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [epiworx_test] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [epiworx_test] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [epiworx_test] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [epiworx_test] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [epiworx_test] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [epiworx_test] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [epiworx_test] SET  READ_WRITE
GO
ALTER DATABASE [epiworx_test] SET RECOVERY FULL
GO
ALTER DATABASE [epiworx_test] SET  MULTI_USER
GO
ALTER DATABASE [epiworx_test] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [epiworx_test] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'epiworx_test', N'ON'
GO
USE [epiworx_test]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 03/01/2011 17:17:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](300) NOT NULL,
	[Ordinal] [int] NOT NULL,
	[ForeColor] [nvarchar](7) NOT NULL,
	[BackColor] [nvarchar](7) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsArchived] [bit] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Category_Name] ON [dbo].[Category] 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 03/01/2011 17:17:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Salt] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Role] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsArchived] [bit] NOT NULL,
	[Notes] [nvarchar](300) NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_User_Name] ON [dbo].[User] 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 03/01/2011 17:17:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[ProjectId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](300) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsArchived] [bit] NOT NULL,
	[Notes] [nvarchar](300) NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Project_Name] ON [dbo].[Project] 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 03/01/2011 17:17:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](300) NOT NULL,
	[Ordinal] [int] NOT NULL,
	[ForeColor] [nvarchar](7) NOT NULL,
	[BackColor] [nvarchar](7) NOT NULL,
	[IsStarted] [bit] NOT NULL,
	[IsCompleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsArchived] [bit] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Status_Name] ON [dbo].[Status] 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sprint]    Script Date: 03/01/2011 17:17:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sprint](
	[SprintId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[IsCompleted] [bit] NOT NULL,
	[CompletedDate] [datetime] NOT NULL,
	[EstimatedCompletedDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsArchived] [bit] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Sprint] PRIMARY KEY CLUSTERED 
(
	[SprintId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Filter]    Script Date: 03/01/2011 17:17:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Filter](
	[FilterId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Target] [nvarchar](30) NOT NULL,
	[Query] [nvarchar](4000) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Filter] PRIMARY KEY CLUSTERED 
(
	[FilterId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feed]    Script Date: 03/01/2011 17:17:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feed](
	[FeedId] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](30) NOT NULL,
	[Data] [nvarchar](1000) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Feed] PRIMARY KEY CLUSTERED 
(
	[FeedId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Note]    Script Date: 03/01/2011 17:17:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Note](
	[NoteId] [int] IDENTITY(1,1) NOT NULL,
	[SourceType] [int] NOT NULL,
	[SourceId] [int] NOT NULL,
	[Body] [nvarchar](4000) NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Note] PRIMARY KEY CLUSTERED 
(
	[NoteId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 03/01/2011 17:17:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Task](
	[TaskId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[Description] [nvarchar](4000) NOT NULL,
	[SprintId] [int] NOT NULL,
	[AssignedTo] [int] NOT NULL,
	[AssignedDate] [datetime] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[CompletedDate] [datetime] NOT NULL,
	[EstimatedCompletedDate] [datetime] NOT NULL,
	[Duration] [decimal](10, 2) NOT NULL,
	[EstimatedDuration] [decimal](10, 2) NOT NULL,
	[Labels] [nvarchar](100) NOT NULL,
	[IsArchived] [bit] NOT NULL,
	[Notes] [nvarchar](300) NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hour]    Script Date: 03/01/2011 17:17:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hour](
	[HourId] [int] IDENTITY(1,1) NOT NULL,
	[ProjectId] [int] NOT NULL,
	[TaskId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Duration] [decimal](10, 2) NOT NULL,
	[Labels] [nvarchar](100) NOT NULL,
	[IsArchived] [bit] NOT NULL,
	[Notes] [nvarchar](300) NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Hour] PRIMARY KEY CLUSTERED 
(
	[HourId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[DatabaseReset]    Script Date: 03/01/2011 17:17:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DatabaseReset]
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM [hour]
	DELETE FROM [task]
	DELETE FROM [sprint]
	DELETE FROM [project]
	DELETE FROM [category]
	DELETE FROM [status]
	DELETE FROM [feed]
	DELETE FROM [filter]
	DELETE FROM [user]

END
GO
/****** Object:  Default [DF_Task_SprintId]    Script Date: 03/01/2011 17:17:28 ******/
ALTER TABLE [dbo].[Task] ADD  CONSTRAINT [DF_Task_SprintId]  DEFAULT ((0)) FOR [SprintId]
GO
/****** Object:  Default [DF_Task_Labels]    Script Date: 03/01/2011 17:17:28 ******/
ALTER TABLE [dbo].[Task] ADD  CONSTRAINT [DF_Task_Labels]  DEFAULT ('') FOR [Labels]
GO
/****** Object:  Default [DF_Hour_ProjectId]    Script Date: 03/01/2011 17:17:28 ******/
ALTER TABLE [dbo].[Hour] ADD  CONSTRAINT [DF_Hour_ProjectId]  DEFAULT ((0)) FOR [ProjectId]
GO
/****** Object:  ForeignKey [FK_Sprint_Project]    Script Date: 03/01/2011 17:17:28 ******/
ALTER TABLE [dbo].[Sprint]  WITH CHECK ADD  CONSTRAINT [FK_Sprint_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
GO
ALTER TABLE [dbo].[Sprint] CHECK CONSTRAINT [FK_Sprint_Project]
GO
/****** Object:  ForeignKey [FK_Sprint_UserCreatedBy]    Script Date: 03/01/2011 17:17:28 ******/
ALTER TABLE [dbo].[Sprint]  WITH CHECK ADD  CONSTRAINT [FK_Sprint_UserCreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Sprint] CHECK CONSTRAINT [FK_Sprint_UserCreatedBy]
GO
/****** Object:  ForeignKey [FK_Sprint_UserModifiedBy]    Script Date: 03/01/2011 17:17:28 ******/
ALTER TABLE [dbo].[Sprint]  WITH CHECK ADD  CONSTRAINT [FK_Sprint_UserModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Sprint] CHECK CONSTRAINT [FK_Sprint_UserModifiedBy]
GO
/****** Object:  ForeignKey [FK_Filter_UserCreatedBy]    Script Date: 03/01/2011 17:17:28 ******/
ALTER TABLE [dbo].[Filter]  WITH CHECK ADD  CONSTRAINT [FK_Filter_UserCreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Filter] CHECK CONSTRAINT [FK_Filter_UserCreatedBy]
GO
/****** Object:  ForeignKey [FK_Filter_UserModifiedBy]    Script Date: 03/01/2011 17:17:28 ******/
ALTER TABLE [dbo].[Filter]  WITH CHECK ADD  CONSTRAINT [FK_Filter_UserModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Filter] CHECK CONSTRAINT [FK_Filter_UserModifiedBy]
GO
/****** Object:  ForeignKey [FK_Feed_UserCreatedBy]    Script Date: 03/01/2011 17:17:28 ******/
ALTER TABLE [dbo].[Feed]  WITH CHECK ADD  CONSTRAINT [FK_Feed_UserCreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Feed] CHECK CONSTRAINT [FK_Feed_UserCreatedBy]
GO
/****** Object:  ForeignKey [FK_Note_UserCreatedBy]    Script Date: 03/01/2011 17:17:28 ******/
ALTER TABLE [dbo].[Note]  WITH CHECK ADD  CONSTRAINT [FK_Note_UserCreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Note] CHECK CONSTRAINT [FK_Note_UserCreatedBy]
GO
/****** Object:  ForeignKey [FK_Note_UserModifiedBy]    Script Date: 03/01/2011 17:17:28 ******/
ALTER TABLE [dbo].[Note]  WITH CHECK ADD  CONSTRAINT [FK_Note_UserModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Note] CHECK CONSTRAINT [FK_Note_UserModifiedBy]
GO
/****** Object:  ForeignKey [FK_Task_Category]    Script Date: 03/01/2011 17:17:28 ******/
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Category]
GO
/****** Object:  ForeignKey [FK_Task_Project]    Script Date: 03/01/2011 17:17:28 ******/
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Project]
GO
/****** Object:  ForeignKey [FK_Task_Sprint]    Script Date: 03/01/2011 17:17:28 ******/
ALTER TABLE [dbo].[Task]  WITH NOCHECK ADD  CONSTRAINT [FK_Task_Sprint] FOREIGN KEY([SprintId])
REFERENCES [dbo].[Sprint] ([SprintId])
NOT FOR REPLICATION
GO
ALTER TABLE [dbo].[Task] NOCHECK CONSTRAINT [FK_Task_Sprint]
GO
/****** Object:  ForeignKey [FK_Task_Status]    Script Date: 03/01/2011 17:17:28 ******/
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Status] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([StatusId])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Status]
GO
/****** Object:  ForeignKey [FK_Task_UserAssignedTo]    Script Date: 03/01/2011 17:17:28 ******/
ALTER TABLE [dbo].[Task]  WITH NOCHECK ADD  CONSTRAINT [FK_Task_UserAssignedTo] FOREIGN KEY([AssignedTo])
REFERENCES [dbo].[User] ([UserId])
NOT FOR REPLICATION
GO
ALTER TABLE [dbo].[Task] NOCHECK CONSTRAINT [FK_Task_UserAssignedTo]
GO
/****** Object:  ForeignKey [FK_Hour_Project]    Script Date: 03/01/2011 17:17:28 ******/
ALTER TABLE [dbo].[Hour]  WITH CHECK ADD  CONSTRAINT [FK_Hour_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
GO
ALTER TABLE [dbo].[Hour] CHECK CONSTRAINT [FK_Hour_Project]
GO
/****** Object:  ForeignKey [FK_Hour_Task]    Script Date: 03/01/2011 17:17:28 ******/
ALTER TABLE [dbo].[Hour]  WITH NOCHECK ADD  CONSTRAINT [FK_Hour_Task] FOREIGN KEY([TaskId])
REFERENCES [dbo].[Task] ([TaskId])
NOT FOR REPLICATION
GO
ALTER TABLE [dbo].[Hour] NOCHECK CONSTRAINT [FK_Hour_Task]
GO
/****** Object:  ForeignKey [FK_Hour_User]    Script Date: 03/01/2011 17:17:28 ******/
ALTER TABLE [dbo].[Hour]  WITH CHECK ADD  CONSTRAINT [FK_Hour_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Hour] CHECK CONSTRAINT [FK_Hour_User]
GO
