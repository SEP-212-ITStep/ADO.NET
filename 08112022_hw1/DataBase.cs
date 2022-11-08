using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace _08112022_hw1
{
    internal class DataBase
    {

        USE[Shop]
        GO
/****** Object:  Table [dbo].[Vegetables&Fruits]    Script Date: Tue,08-Nov-22 16:49:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE[dbo].[Vegetables&Fruits]
        (

    [Название][nvarchar](20) NULL,
	[Тип][nvarchar] (20) NULL,
	[Цвет][nvarchar] (20) NULL,
	[Калорийность][nvarchar] (20) NULL
) ON[PRIMARY]
GO
INSERT[dbo].[Vegetables&Fruits]
        ([Название], [Тип], [Цвет], [Калорийность]) VALUES(N'помидор', N'фрукт/овощ', N'красный', N'100')
INSERT[dbo].[Vegetables&Fruits]
        ([Название], [Тип], [Цвет], [Калорийность]) VALUES(N'яблоко', N'фрукт', N'зеленый', N'250')
INSERT[dbo].[Vegetables&Fruits]
        ([Название], [Тип], [Цвет], [Калорийность]) VALUES(N'редис', N'овощ', N'красный', N'270')
INSERT[dbo].[Vegetables&Fruits]
        ([Название], [Тип], [Цвет], [Калорийность]) VALUES(N'лук', N'овощ', N'коричневый', N'150')
GO
    }
}
