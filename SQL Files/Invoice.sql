USE [JEWELRY_SHOP]
GO

/****** Object:  Table [dbo].[Invoice]    Script Date: 14/07/2020 11:41:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Invoice](
	[invoiceNo] [int] IDENTITY(1,1) NOT NULL,
	[cashierId] [int] NULL,
	[dealer_customerId] [int] NULL,
	[grandTotal] [decimal](18, 2) NULL,
	[transaction_date] [datetime] NULL,
	[vat] [decimal](18, 2) NULL,
	[discount] [decimal](18, 2) NULL,
	[payment] [decimal](18, 2) NULL,
	[change] [decimal](18, 2) NULL,
	[type] [nvarchar](50) NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[invoiceNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Cashier1] FOREIGN KEY([cashierId])
REFERENCES [dbo].[Cashier] ([cashierId])
GO

ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Cashier1]
GO

ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Dealer_Customer] FOREIGN KEY([dealer_customerId])
REFERENCES [dbo].[Dealer_Customer] ([dealer_customerId])
GO

ALTER TABLE [dbo].[Invoice] CHECK CONSTRAINT [FK_Invoice_Dealer_Customer]
GO


