/****** Object:  View [dbo].[TaskLabel]    Script Date: 03/07/2011 16:06:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[TaskLabel]
AS
SELECT     dbo.Label.SourceId AS TaskId, dbo.Label.Name, dbo.Label.CreatedBy, dbo.Label.CreatedDate
FROM         dbo.Label INNER JOIN
                      dbo.Task ON dbo.Label.SourceId = dbo.Task.TaskId

GO



