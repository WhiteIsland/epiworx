USE [epiworx]
GO
/****** Object:  User [epiworx]    Script Date: 01/08/2011 12:30:29 ******/
CREATE USER [epiworx] FOR LOGIN [epiworx] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 01/08/2011 12:30:31 ******/
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
/****** Object:  Table [dbo].[Project]    Script Date: 01/08/2011 12:30:31 ******/
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
/****** Object:  Table [dbo].[Category]    Script Date: 01/08/2011 12:30:31 ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 01/08/2011 12:30:31 ******/
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
CREATE UNIQUE NONCLUSTERED INDEX [IX_User_Email] ON [dbo].[User] 
(
	[Email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_User_Name] ON [dbo].[User] 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Task]    Script Date: 01/08/2011 12:30:31 ******/
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
/****** Object:  Table [dbo].[Hour]    Script Date: 01/08/2011 12:30:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hour](
	[HourId] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  StoredProcedure [dbo].[DatabaseReset]    Script Date: 01/08/2011 12:30:33 ******/
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
	DELETE FROM [project]
	DELETE FROM [customer]
	DELETE FROM [category]
	DELETE FROM [status]
	DELETE FROM [user]

END
GO
/****** Object:  Default [DF_Status_Ordinal]    Script Date: 01/08/2011 12:30:31 ******/
ALTER TABLE [dbo].[Status] ADD  CONSTRAINT [DF_Status_Ordinal]  DEFAULT ((0)) FOR [Ordinal]
GO
/****** Object:  Default [DF_Status_ForeColor]    Script Date: 01/08/2011 12:30:31 ******/
ALTER TABLE [dbo].[Status] ADD  CONSTRAINT [DF_Status_ForeColor]  DEFAULT ('') FOR [ForeColor]
GO
/****** Object:  Default [DF_Status_BackColor]    Script Date: 01/08/2011 12:30:31 ******/
ALTER TABLE [dbo].[Status] ADD  CONSTRAINT [DF_Status_BackColor]  DEFAULT ('') FOR [BackColor]
GO
/****** Object:  Default [DF_Category_Ordinal_1]    Script Date: 01/08/2011 12:30:31 ******/
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_Ordinal_1]  DEFAULT ((0)) FOR [Ordinal]
GO
/****** Object:  Default [DF_Category_ForeColor_1]    Script Date: 01/08/2011 12:30:31 ******/
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_ForeColor_1]  DEFAULT ('') FOR [ForeColor]
GO
/****** Object:  Default [DF_Category_BackColor_1]    Script Date: 01/08/2011 12:30:31 ******/
ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_BackColor_1]  DEFAULT ('') FOR [BackColor]
GO
/****** Object:  Default [DF_Task_Category]    Script Date: 01/08/2011 12:30:31 ******/
ALTER TABLE [dbo].[Task] ADD  CONSTRAINT [DF_Task_Category]  DEFAULT ((1)) FOR [CategoryId]
GO
/****** Object:  ForeignKey [FK_Task_Category]    Script Date: 01/08/2011 12:30:31 ******/
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Category]
GO
/****** Object:  ForeignKey [FK_Task_Project]    Script Date: 01/08/2011 12:30:31 ******/
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Project]
GO
/****** Object:  ForeignKey [FK_Task_Status]    Script Date: 01/08/2011 12:30:31 ******/
ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Status] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([StatusId])
GO
ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Status]
GO
/****** Object:  ForeignKey [FK_Hour_Task]    Script Date: 01/08/2011 12:30:31 ******/
ALTER TABLE [dbo].[Hour]  WITH CHECK ADD  CONSTRAINT [FK_Hour_Task] FOREIGN KEY([TaskId])
REFERENCES [dbo].[Task] ([TaskId])
GO
ALTER TABLE [dbo].[Hour] CHECK CONSTRAINT [FK_Hour_Task]
GO
