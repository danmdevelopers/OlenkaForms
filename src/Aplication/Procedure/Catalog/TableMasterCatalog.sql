
CREATE TABLE [dbo].[Catalog_Master](
	[MasterId] [uniqueidentifier] NOT NULL,
	[Name] [varchar](32) NULL,
	[Description] [varchar](128) NULL,
	[IsActive] [bit] NULL,
	[CreatedAt] [datetime] NULL,
	[UpdateAt] [datetime] NULL,
	[DeleteAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[MasterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Catalog_Master] ADD  DEFAULT (newid()) FOR [MasterId]
GO


