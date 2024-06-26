USE Nombre_Proyecto
GO
/****** Object:  StoredProcedure [dbo].[sp_log_systemIn]    Script Date: 9/19/2023 8:12:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create or ALTER   PROCEDURE [dbo].[sp_log_system](
            @i_TYPE varchar (5) = NULL ,
			@i_APPLICATION_NAME varchar (254) = NULL ,
            @i_APPLICATION_VERSION varchar (200) = NULL ,
            @i_SERVICE_NAME varchar (max) = NULL ,
            @i_DATE_INI datetime = NULL ,  
			@i_DATE_END datetime = NULL ,
            @i_DATE_DIFF_MILISECONDS int = NULL ,
            @i_REFERENCE_ID varchar (500) = NULL ,    
			@i_SEVERITY varchar (254) = NULL ,
            @i_HTTP_METHOD varchar (50) = NULL ,  
			@i_HTTP_RESPONSE_CODE int = NULL ,
            @i_CONSUMER varchar (max) = NULL ,   
			@i_PRODUCER varchar (max) = NULL ,
            @i_CODE varchar (50) = NULL ,
            @i_DESCRIPTION varchar (max) = NULL ,    
            @i_MESSAGE_IN varchar (max) = NULL ,    
			@i_MESSAGE_OUT varchar (max) = NULL ,
            @i_MICROSERVICE_URL varchar (max) = NULL ,
            @i_ENVIRONMENT varchar (254) = NULL ,
            @i_MACHINE varchar (254) = NULL ,
            @i_TimeStamp datetime = NULL ,
			@i_HEADER varchar (max) = NULL ,
            @i_CUSTOMER_MESSAGE_IN varchar (max) = NULL
)
as 


INSERT INTO logsystem
           ([TYPE]
		   ,[APPLICATION_NAME]
           ,[APPLICATION_VERSION]
           ,[SERVICE_NAME]		   
           ,[DATE_INI]
		   ,[DATE_END]
           ,[DATE_DIFF_MILISECONDS]
           ,[REFERENCE_ID] 
		   ,[SEVERITY]
           ,[HTTP_METHOD]  
		   ,[HTTP_RESPONSE_CODE]
           ,[CONSUMER]          
		   ,[PRODUCER]
           ,[CODE]
           ,[DESCRIPTION]  
           ,[MESSAGE_IN]
		   ,[MESSAGE_OUT]
           ,[MICROSERVICE_URL]
           ,[ENVIRONMENT]
           ,[MACHINE]
           ,[TimeStamp]
		   ,[HEADER]
		   ,[CUSTOMER_MESSAGE_IN])
     VALUES
           (@i_TYPE,
		   @i_APPLICATION_NAME,
           @i_APPLICATION_VERSION,
           @i_SERVICE_NAME,
           @i_DATE_INI, 
		   @i_DATE_END,
           @i_DATE_DIFF_MILISECONDS,
           @i_REFERENCE_ID,   
		   @i_SEVERITY,
           @i_HTTP_METHOD,         
		   @i_HTTP_RESPONSE_CODE,
           @i_CONSUMER,
		   @i_PRODUCER,
           @i_CODE,
           @i_DESCRIPTION,  
           @i_MESSAGE_IN,
		   @i_MESSAGE_OUT,
           @i_MICROSERVICE_URL,
           @i_ENVIRONMENT,
           @i_MACHINE,
           @i_TimeStamp,
		   @i_HEADER,
           @i_CUSTOMER_MESSAGE_IN)





select @@ROWCOUNT as codigo