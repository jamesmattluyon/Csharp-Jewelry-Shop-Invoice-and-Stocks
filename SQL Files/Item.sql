USE [JEWELRY_SHOP]
GO

/****** Object:  Table [dbo].[Item]    Script Date: 14/07/2020 11:41:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Item](
	[itemId] [int] IDENTITY(1,1) NOT NULL,
	[itemName] [nvarchar](50) NOT NULL,
	[itemType] [nvarchar](50) NOT NULL,
	[itemCategory] [nvarchar](50) NOT NULL,
	[itemCondition] [nvarchar](50) NOT NULL,
	[itemPrice] [decimal](18, 2) NOT NULL,
	[itemQuantity] [decimal](18, 2) NOT NULL,
	[added_Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Item] PRIMARY KEY CLUSTERED 
(
	[itemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


