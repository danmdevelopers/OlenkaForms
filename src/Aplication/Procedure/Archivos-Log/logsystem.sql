Create DataBase Nombre_Proyecto
Go
Use Nombre_Proyecto
GO

/****** Object:  Table [dbo].[logsystem]    Script Date: 9/19/2023 8:57:13 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[logsystem](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TYPE] [varchar](5) NULL,
	[APPLICATION_NAME] [varchar](max) NULL,
	[APPLICATION_VERSION] [varchar](max) NULL,
	[SERVICE_NAME] [varchar](max) NULL,
	[DATE_INI] [varchar](max) NULL,
	[DATE_END] [varchar](max) NULL,
	[DATE_DIFF_MILISECONDS] [varchar](max) NULL,
	[REFERENCE_ID] [varchar](max) NULL,
	[SEVERITY] [varchar](max) NULL,
	[HTTP_METHOD] [varchar](max) NULL,
	[HTTP_RESPONSE_CODE] [varchar](max) NULL,
	[CONSUMER] [varchar](max) NULL,
	[PRODUCER] [varchar](max) NULL,
	[CODE] [varchar](max) NULL,
	[DESCRIPTION] [varchar](max) NULL,
	[REFERENCE_DATA] [varchar](max) NULL,
	[MESSAGE_IN] [varchar](max) NULL,
	[MESSAGE_OUT] [varchar](max) NULL,
	[MICROSERVICE_URL] [varchar](max) NULL,
	[ENVIRONMENT] [varchar](max) NULL,
	[MACHINE] [varchar](max) NULL,
	[TimeStamp] [varchar](max) NULL,
	[BUSINESS_DATA] [varchar](max) NULL,
	[DataValues] [varchar](max) NULL,
	[HEADER] [varchar](max) NULL,
	[CUSTOMER_MESSAGE_IN] [varchar](max) NULL,
 CONSTRAINT [PK_logsystem] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


