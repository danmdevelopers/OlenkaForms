using BibliotecasBase.Utils.DataBase.Controllers;
using BibliotecasBase.Utils.DataBase.Interfaces;
using BibliotecasBase.Utils.Log;
using BibliotecasBase.Utils.Log.DataBaseClient;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NexTi_Hexagonal_Functions;
using OlenkaForms.src.Aplication.Ports.Primary;
using OlenkaForms.src.Aplication.Ports.Secondary;
using OlenkaForms.src.Aplication.UseCases;
using OlenkaForms.src.Infrastructure.Adapters.GraphQL.Mutation;
using OlenkaForms.src.Infrastructure.Adapters.GraphQL.Queries;
using OlenkaForms.src.Infrastructure.Controllers;
using OlenkaForms.src.Infrastructure.Repositories;
using System;
using System.Reflection;

[assembly: FunctionsStartup(typeof(Startup))]

namespace NexTi_Hexagonal_Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<ILogHandler, LogHandler>();
            builder.Services.AddTransient<ISqlServer, SqlServer>();
            builder.Services.AddTransient<IUtilityDataBaseClient, UtilityDataBaseClient>();

            //Injección de dependencia para User

            builder.Services.AddSingleton<IHandleUser, UserUseCase>();
            builder.Services.AddSingleton<IMappingUser, UserRepository>();
            builder.Services.AddTransient<UserController>();

           //Inyección de dependencia para Email
            builder.Services.AddSingleton<IHandleEmail, EmailUseCase>();
            builder.Services.AddSingleton<IMappingEmail, EmailRepository>();

            builder.Services.AddSingleton<IConfiguration>(config =>
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Environment.CurrentDirectory)
                    .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables();

                return builder.Build();
            });


            // Se debe ingresar las clases que correspondan para la mutación y para los queries

            builder.AddGraphQLFunction(b =>
            {
                b.AddQueryType(d => d.Name("Query"))
                 .AddType<UserQuery>();
                b.AddMutationType(d => d.Name("Mutation"))
                .AddType<UserMutation>();
                // b.AllowIntrospection(false);
            });

           
        }

       

    }
}
