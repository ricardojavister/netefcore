USE [MyDb]
GO
/****** Object:  Table [dbo].[product]    Script Date: 3/23/2020 11:42:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[idproduct] [int] IDENTITY(1,1) NOT NULL,
	[productname] [varchar](50) NOT NULL,
	[price] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_product] PRIMARY KEY CLUSTERED 
(
	[idproduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
