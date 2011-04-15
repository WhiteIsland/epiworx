USE [epiworx]
GO

/****** Object:  Table [dbo].[Attachment]    Script Date: 04/15/2011 16:47:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Attachment](
	[AttachmentId] [int] IDENTITY(1,1) NOT NULL,
	[SourceType] [int] NOT NULL,
	[SourceId] [int] NOT NULL,
	[Name] [varchar](300) NOT NULL,
	[FileType] [varchar](100) NOT NULL,
	[FileData] [varbinary](max) NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Attachment] PRIMARY KEY CLUSTERED 
(
	[AttachmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [epiworx]
GO

/****** Object:  Table [dbo].[Category]    Script Date: 04/15/2011 16:47:55 ******/
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

/****** Object:  Table [dbo].[Feed]    Script Date: 04/15/2011 16:47:55 ******/
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

USE [epiworx]
GO

/****** Object:  Table [dbo].[Filter]    Script Date: 04/15/2011 16:47:55 ******/
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

USE [epiworx]
GO

/****** Object:  Table [dbo].[Hour]    Script Date: 04/15/2011 16:47:55 ******/
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

/****** Object:  Table [dbo].[Invoice]    Script Date: 04/15/2011 16:47:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Invoice](
	[InvoiceId] [int] IDENTITY(1,1) NOT NULL,
	[Number] [nvarchar](30) NOT NULL,
	[Description] [nvarchar](4000) NOT NULL,
	[TaskId] [int] NOT NULL,
	[Amount] [decimal](10, 2) NOT NULL,
	[IsArchived] [bit] NOT NULL,
	[Notes] [nvarchar](300) NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[InvoiceId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [epiworx]
GO

/****** Object:  Table [dbo].[Label]    Script Date: 04/15/2011 16:47:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Label](
	[SourceId] [int] NOT NULL,
	[SourceType] [int] NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Label] PRIMARY KEY CLUSTERED 
(
	[SourceId] ASC,
	[SourceType] ASC,
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [epiworx]
GO

/****** Object:  Table [dbo].[Note]    Script Date: 04/15/2011 16:47:55 ******/
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

USE [epiworx]
GO

/****** Object:  Table [dbo].[Project]    Script Date: 04/15/2011 16:47:55 ******/
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

/****** Object:  Table [dbo].[Sprint]    Script Date: 04/15/2011 16:47:55 ******/
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

USE [epiworx]
GO

/****** Object:  Table [dbo].[Status]    Script Date: 04/15/2011 16:47:55 ******/
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

/****** Object:  Table [dbo].[Task]    Script Date: 04/15/2011 16:47:55 ******/
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

USE [epiworx]
GO

/****** Object:  Table [dbo].[User]    Script Date: 04/15/2011 16:47:55 ******/
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

ALTER TABLE [dbo].[Attachment]  WITH CHECK ADD  CONSTRAINT [FK_Attachment_UserCreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[Attachment] CHECK CONSTRAINT [FK_Attachment_UserCreatedBy]
GO

ALTER TABLE [dbo].[Attachment]  WITH CHECK ADD  CONSTRAINT [FK_Attachment_UserModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[Attachment] CHECK CONSTRAINT [FK_Attachment_UserModifiedBy]
GO

ALTER TABLE [dbo].[Attachment] ADD  CONSTRAINT [DF_Table_1_FileName]  DEFAULT ('') FOR [Name]
GO

ALTER TABLE [dbo].[Attachment] ADD  CONSTRAINT [DF_Attachment_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedDate]
GO

ALTER TABLE [dbo].[Attachment] ADD  CONSTRAINT [DF_Attachment_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO

ALTER TABLE [dbo].[Feed]  WITH CHECK ADD  CONSTRAINT [FK_Feed_UserCreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[Feed] CHECK CONSTRAINT [FK_Feed_UserCreatedBy]
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

ALTER TABLE [dbo].[Hour]  WITH CHECK ADD  CONSTRAINT [FK_Hour_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[Hour] CHECK CONSTRAINT [FK_Hour_User]
GO

ALTER TABLE [dbo].[Hour] ADD  CONSTRAINT [DF_Hour_ProjectId]  DEFAULT ((0)) FOR [ProjectId]
GO

ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Task] FOREIGN KEY([TaskId])
REFERENCES [dbo].[Task] ([TaskId])
GO

ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Task]
GO

ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_UserCreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_UserCreatedBy]
GO

ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_UserModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_UserModifiedBy]
GO

ALTER TABLE [dbo].[Invoice] ADD  CONSTRAINT [DF_Invoice_ItemId]  DEFAULT ((0)) FOR [TaskId]
GO

ALTER TABLE [dbo].[Label]  WITH CHECK ADD  CONSTRAINT [FK_Label_UserCreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[Label] CHECK CONSTRAINT [FK_Label_UserCreatedBy]
GO

ALTER TABLE [dbo].[Note]  WITH CHECK ADD  CONSTRAINT [FK_Note_UserCreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[Note] CHECK CONSTRAINT [FK_Note_UserCreatedBy]
GO

ALTER TABLE [dbo].[Note]  WITH CHECK ADD  CONSTRAINT [FK_Note_UserModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[Note] CHECK CONSTRAINT [FK_Note_UserModifiedBy]
GO

ALTER TABLE [dbo].[Sprint]  WITH CHECK ADD  CONSTRAINT [FK_Sprint_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([ProjectId])
GO

ALTER TABLE [dbo].[Sprint] CHECK CONSTRAINT [FK_Sprint_Project]
GO

ALTER TABLE [dbo].[Sprint]  WITH CHECK ADD  CONSTRAINT [FK_Sprint_UserCreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[Sprint] CHECK CONSTRAINT [FK_Sprint_UserCreatedBy]
GO

ALTER TABLE [dbo].[Sprint]  WITH CHECK ADD  CONSTRAINT [FK_Sprint_UserModifiedBy] FOREIGN KEY([ModifiedBy])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[Sprint] CHECK CONSTRAINT [FK_Sprint_UserModifiedBy]
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

ALTER TABLE [dbo].[Task]  WITH NOCHECK ADD  CONSTRAINT [FK_Task_Sprint] FOREIGN KEY([SprintId])
REFERENCES [dbo].[Sprint] ([SprintId])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[Task] NOCHECK CONSTRAINT [FK_Task_Sprint]
GO

ALTER TABLE [dbo].[Task]  WITH CHECK ADD  CONSTRAINT [FK_Task_Status] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([StatusId])
GO

ALTER TABLE [dbo].[Task] CHECK CONSTRAINT [FK_Task_Status]
GO

ALTER TABLE [dbo].[Task]  WITH NOCHECK ADD  CONSTRAINT [FK_Task_UserAssignedTo] FOREIGN KEY([AssignedTo])
REFERENCES [dbo].[User] ([UserId])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[Task] NOCHECK CONSTRAINT [FK_Task_UserAssignedTo]
GO

ALTER TABLE [dbo].[Task] ADD  CONSTRAINT [DF_Task_SprintId]  DEFAULT ((0)) FOR [SprintId]
GO

ALTER TABLE [dbo].[Task] ADD  CONSTRAINT [DF_Task_Labels]  DEFAULT ('') FOR [Labels]
GO

