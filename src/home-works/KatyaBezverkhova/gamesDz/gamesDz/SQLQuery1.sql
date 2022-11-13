USE [GamesDatabase]
GO

/****** Object:  Table [dbo].[games]    Script Date: 13.11.2022 13:56:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[games](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Creator] [nvarchar](max) NOT NULL,
	[PlayStyle] [nvarchar](max) NOT NULL,
	[RealiseDate] [int] NOT NULL,
	[GameMode] [nvarchar](max) NOT NULL,
	[CopiesSold] [int] NOT NULL,
 CONSTRAINT [PK_games] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[games] ADD  DEFAULT (N'') FOR [GameMode]
GO

ALTER TABLE [dbo].[games] ADD  DEFAULT ((0)) FOR [CopiesSold]
GO


