SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table1](
	[Name] [nvarchar](100) NOT NULL,
	[Type] [nvarchar](100) NOT NULL,
	[Color] [nvarchar](100) NOT NULL,
	[Сalories] [int] NOT NULL
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [vegetables&fruits] SET  READ_WRITE 
GO
