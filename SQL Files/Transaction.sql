USE [JEWELRY_SHOP]
GO

/****** Object:  Table [dbo].[BusinessTransaction]    Script Date: 14/07/2020 11:40:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BusinessTransaction](
	[transactionNo] [int] IDENTITY(1,1) NOT NULL,
	[invoiceNo] [int] NULL,
	[itemId] [int] NULL,
	[price] [decimal](18, 2) NULL,
	[qty] [decimal](18, 2) NULL,
	[total] [decimal](18, 2) NULL,
	[added_date] [datetime] NULL,
	[dealer_customerId] [int] NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[transactionNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BusinessTransaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_Item] FOREIGN KEY([itemId])
REFERENCES [dbo].[Item] ([itemId])
GO

ALTER TABLE [dbo].[BusinessTransaction] CHECK CONSTRAINT [FK_Transaction_Item]
GO

ALTER TABLE [dbo].[BusinessTransaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_Transaction] FOREIGN KEY([invoiceNo])
REFERENCES [dbo].[Invoice] ([invoiceNo])
GO

ALTER TABLE [dbo].[BusinessTransaction] CHECK CONSTRAINT [FK_Transaction_Transaction]
GO


