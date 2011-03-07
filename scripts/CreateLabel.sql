/****** Object:  Table [dbo].[Label]    Script Date: 03/06/2011 19:39:11 ******/
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

ALTER TABLE [dbo].[Label]  WITH CHECK ADD  CONSTRAINT [FK_Label_UserCreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[Label] CHECK CONSTRAINT [FK_Label_UserCreatedBy]
GO

