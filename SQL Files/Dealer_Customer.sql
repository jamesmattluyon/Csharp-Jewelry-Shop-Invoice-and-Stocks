USE [JEWELRY_SHOP]
GO

/****** Object:  Table [dbo].[Dealer_Customer]    Script Date: 14/07/2020 11:40:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Dealer_Customer](
	[dealer_customerId] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[contactNo] [nvarchar](50) NULL,
	[age] [nvarchar](50) NULL,
	[address] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[type] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[dealer_customerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


