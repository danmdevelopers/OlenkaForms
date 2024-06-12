
CREATE TABLE [dbo].[Catalog_Detail](
	[DetailId] [uniqueidentifier] NOT NULL,
	[MasterId] [uniqueidentifier] NULL,
	[Name] [varchar](32) NULL,
	[Value] [varchar](256) NULL,
	[Relation] [int] NULL,
	[IsActive] [bit] NULL,
	[CreatedAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
	[DeleteAt] [datetime] NULL,
 CONSTRAINT [PK__Catalog___135C316D1DD7CB68] PRIMARY KEY CLUSTERED 
(
	[DetailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Catalog_Detail] ADD  CONSTRAINT [DF__Catalog_D__Detai__276EDEB3]  DEFAULT (newid()) FOR [DetailId]
GO

ALTER TABLE [dbo].[Catalog_Detail]  WITH CHECK ADD  CONSTRAINT [FK__Catalog_D__Maste__286302EC] FOREIGN KEY([MasterId])
REFERENCES [dbo].[Catalog_Master] ([MasterId])
GO

ALTER TABLE [dbo].[Catalog_Detail] CHECK CONSTRAINT [FK__Catalog_D__Maste__286302EC]
GO


