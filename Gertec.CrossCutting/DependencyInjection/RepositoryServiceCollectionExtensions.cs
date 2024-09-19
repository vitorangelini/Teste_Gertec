using Gertec.Application.Interfaces.External;
using Gertec.Application.Interfaces.Repositories;
using Gertec.Application.Interfaces.Repositories.DbConnection;
using Gertec.Application.Interfaces.Repositories.External;
using Gertec.Application.Interfaces.Services;
using Gertec.Infrastructure.Repositories;
using Gertec.Infrastructure.Repositories.External;
using Gertec.Infrastructure.Repositories.MySql;
using Gertec.Infrastructure.Services;
using Gertec.Infrastructure.Services.External;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.CrossCutting.DependencyInjection
{
    public static class RepositoryServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDbConnectionFactory, DbConnection>();

            #region Service
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IVendaService, VendaService>();
            services.AddScoped<ILogService, LogService>();
            #endregion

            #region Repository
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IVendaRepository, VendaRepository>();
            services.AddScoped<ILogRepository, LogRepository>();
            #endregion

            return services;
        }
    }

}
