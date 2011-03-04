/****** Object:  Table [dbo].[Attachment]    Script Date: 03/04/2011 14:52:54 ******/
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
	[FileType] [varchar](30) NOT NULL,
	[FileData] [image] NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Attachment] PRIMARY KEY CLUSTERED 
(
	[AttachmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
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


