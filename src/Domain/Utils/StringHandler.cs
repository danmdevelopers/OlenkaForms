namespace Domain.Utils
{
    public class StringHandler
    {
        // Nombres de módulo y proyecto
        public const string ModuleName = "Modulo";
        public const string ProjectName = "Proyecto";
        public const int Version = 1;

        // Nombres de procedimientos
        public const string ProcedureExample = "pr_example";


        //Variable de Entorno Base de Datos
        public const string DATABASELIQ = "DATABASE";

        //Variable de Servicio OAuth, configurar Launch Settings
        public const string OAuthValidateToken = "OAuthFunctionValidateToken";

        //Errores store procedures
        public const string ERROR_00003 = "ERROR_00003";

        public const string SqlContectionStandard = "SQLConnectionString";
        public const string SqlContectionRedisCache = "AzureRedisCache";


        public const string SP_SEARCHCATALOGBYNAME = "HUMANA_STANDARD.SEARCHCATALOGBYNAME";
        public const string SP_INSERTCATALOGMASTER = "HUMANA_STANDARD.INSERTCATALOGMASTER";




        //RedisCache Nombre Tablas

        public const string CatalogByName = "CatalogByName";
    }
}
