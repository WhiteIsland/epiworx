USE [epiworx]
GO

/****** Object:  Table [dbo].[Category]    Script Date: 01/19/2011 17:25:09 ******/
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

USE [epiworx]
GO

/****** Object:  Table [dbo].[Filter]    Script Date: 01/19/2011 17:25:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Filter](
	[FilterId] [int] NOT NULL,
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

USE [epiworx]
GO

/****** Object:  Table [dbo].[Hour]    Script Date: 01/19/2011 17:25:09 ******/
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

USE [epiworx]
GO

/****** Object:  Table [dbo].[Project]    Script Date: 01/19/2011 17:25:09 ******/
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

USE [epiworx]
GO

/****** Object:  Table [dbo].[Status]    Script Date: 01/19/2011 17:25:09 ******/
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

USE [epiworx]
GO

/****** Object:  Table [dbo].[Task]    Script Date: 01/19/2011 17:25:09 ******/
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

USE [epiworx]
GO

/****** Object:  Table [dbo].[User]    Script Date: 01/19/2011 17:25:09 ******/
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

ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_Ordinal_1]  DEFAULT ((0)) FOR [Ordinal]
GO

ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_ForeColor_1]  DEFAULT ('') FOR [ForeColor]
GO

ALTER TABLE [dbo].[Category] ADD  CONSTRAINT [DF_Category_BackColor_1]  DEFAULT ('') FOR [BackColor]
GO

ALTER TABLE [dbo].[Filter]  WITH CHECK ADD  CONSTRAINT [FK_Filter_UserCreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[Filter] CHECK CONSTRAINT [FK_Filter_UserCreatedBy]
GO

ALTER TABLE [dbo].[Filter]  WITH CHECK ADD  CONSTRAINT [FK_Filter_UserModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[Filter] CHECK CONSTRAINT [FK_Filter_UserModifiedBy]
GO

ALTER TABLE [dbo].[Hour]  WITH CHECK ADD  CONSTRAINT [FK_Hour_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
GO

ALTER TABLE [dbo].[Hour] CHECK CONSTRAINT [FK_Hour_Project]
GO

ALTER TABLE [dbo].[Hour]  WITH NOCHECK ADD  CONSTRAINT [FK_Hour_Task] FOREIGN KEY([TaskId])
REFERENCES [dbo].[Task] ([TaskId])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[Hour] NOCHECK CONSTRAINT [FK_Hour_Task]
GO

ALTER TABLE [dbo].[Hour] ADD  CONSTRAINT [DF_Hour_ProjectId]  DEFAULT ((0)) FOR [ProjectId]
GO

ALTER TABLE [dbo].[Status] ADD  CONSTRAINT [DF_Status_Ordinal]  DEFAULT ((0)) FOR [Ordinal]
GO

ALTER TABLE [dbo].[Status] ADD  CONSTRAINT [DF_Status_ForeColor]  DEFAULT ('') FOR [ForeColor]
GO

ALTER TABLE [dbo].[Status] ADD  CONSTRAINT [DF_Status_BackColor]  DEFAULT ('') FOR [BackColor]
GO

ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO

ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Category]
GO

ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
GO

ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Project]
GO

ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Status] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([StatusId])
GO

ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Status]
GO

ALTER TABLE [dbo].[Task] ADD  CONSTRAINT [DF_Task_Category]  DEFAULT ((1)) FOR [CategoryId]
GO


