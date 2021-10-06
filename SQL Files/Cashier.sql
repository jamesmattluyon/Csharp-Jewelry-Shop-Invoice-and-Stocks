USE [JEWELRY_SHOP]
GO

/****** Object:  Table [dbo].[Cashier]    Script Date: 14/07/2020 11:40:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cashier](
	[cashierId] [int] IDENTITY(1,1) NOT NULL,
	[cashierName] [nvarchar](50) NOT NULL,
	[contactNo] [nvarchar](50) NULL,
	[username] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[added_date] [datetime] NULL,
	[added_by] [int] NULL,
 CONSTRAINT [PK_Cashier] PRIMARY KEY CLUSTERED 
(
	[cashierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


