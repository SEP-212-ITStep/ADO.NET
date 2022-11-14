

USE [Shop]
GO
/****** Object:  Table [dbo].[Vegetables&Fruits]    Script Date: Tue,08-Nov-22 16:49:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vegetables&Fruits](
	[Name] [nvarchar](20) NULL,
	[Type] [nvarchar](20) NULL,
	[Color] [nvarchar](20) NULL,
	[Calories] [nvarchar](20) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Vegetables&Fruits] (Name, Type, Color, Calories) VALUES (N'помидор', N'фрукт/овощ', N'красный', N'100')
INSERT [dbo].[Vegetables&Fruits] (Name, Type, Color, Calories) VALUES (N'яблоко', N'фрукт', N'зеленый', N'250')
INSERT [dbo].[Vegetables&Fruits] (Name, Type, Color, Calories) VALUES (N'редис', N'овощ', N'красный', N'270')
INSERT [dbo].[Vegetables&Fruits] (Name, Type, Color, Calories) VALUES (N'лук', N'овощ', N'коричневый', N'150')
GO
