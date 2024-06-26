-----------------------------------------------------------------------------
--                  Estándar para la creación de SP                        --
--                                                                         --
--   Nombre del SP: HUMANA_CATALOGS.INSERTCATALOGEXCEPTION                 --
--   Descripción del SP: Insertar Excepciones de Aplicacion                --
--   Autor: Daniel Nicolalde Mendoza                                       --
--   Fecha Creación: 09/02/2024                                            --
--   En caso de ser Editado el SP                                          --
--   Autor:                                                                --
--   Fecha Modificación                                                    --
--                                                                         --
-----------------------------------------------------------------------------
-- Nomenclatura para tipos de SP:
-- INSERT : SCHEMA.INSERTNOMBRESP
-- UPDATE : SCHEMA.UPDATENOMBRESP
-- DELETE : SCHEMA.DELETENOMBRESP
-- FIND   : SCHEMA.SEARCHNOMBRESP

--Las palabras RESERVADAS deben ser escritas en Mayúsculas
--Las variables de entradas se declaran: @i_NombreVariable TIPO
--Las variables declaradas: @w_NombreVariable TIPO
--Para datos VARCHAR usar RANGOS: 2,4,8,16,32,64,128 y 256


CREATE OR ALTER PROCEDURE [HUMANA_CATALOGS].[INSERTCATALOGEXCEPTION] (

@i_StatusCode VARCHAR(64),
@i_Description VARCHAR(64)
)
AS
DECLARE @w_CountCatalog INT,
		@w_MasterId uniqueidentifier


SELECT @w_CountCatalog = COUNT(CD.MasterId) FROM Catalog_Master CM 
INNER JOIN Catalog_Detail CD ON CM.MasterId = CD.MasterId
WHERE CM.Name = 'ERROR APP' AND CD.Name = @i_StatusCode



BEGIN

	BEGIN TRY
		
		IF(@w_CountCatalog<1)
		BEGIN
			
			SELECT @w_MasterId=MasterId 
			FROM Catalog_Master
			WHERE Name = 'ERROR APP'

			INSERT INTO Catalog_Detail
			VALUES (NEWID(),@w_MasterId, @i_StatusCode, @i_Description,null, 1, GETDATE(), GETDATE(), GETDATE())

		END
		
	END TRY
	BEGIN CATCH

		DECLARE @w_ErrorNumber INT,
				@w_ErrorName VARCHAR(64)='ERROR',
				@w_ErrorMessage VARCHAR(128),
				@w_ErrorSeverity INT,
				@w_MaterId UNIQUEIDENTIFIER,
				@w_Exist INT=0


		SELECT @w_ErrorNumber=ERROR_NUMBER(), @w_ErrorMessage=ERROR_MESSAGE(), @w_ErrorSeverity = ERROR_SEVERITY()

		SELECT @w_MaterId=MasterId 
		FROM Standard_Exception_Handling.dbo.Catalog_Master 
		WHERE Name ='ERROR DATABASE'

		SET @w_ErrorName = @w_ErrorName+' '+@w_ErrorNumber

		SELECT @w_Exist=COUNT(CD.DetailId) FROM Standard_Exception_Handling.dbo.Catalog_Master CM
		INNER JOIN Standard_Exception_Handling.dbo.Catalog_Detail CD ON CM.MasterId = CD.MasterId 
		WHERE CD.Name = @w_ErrorName


		IF(@w_Exist<1)
		BEGIN
			
			INSERT INTO Standard_Exception_Handling.dbo.CATALOG_DETAIL 
			VALUES (NEWID(),@w_MaterId, @w_ErrorName, @w_ErrorMessage, @w_ErrorSeverity,1,GETDATE(),NULL,NULL)

		END
		
		SELECT 
		[ERROR_NAME]=@w_ErrorName,
		[ERROR_MESSAGE]=@w_ErrorMessage

	END CATCH;

END