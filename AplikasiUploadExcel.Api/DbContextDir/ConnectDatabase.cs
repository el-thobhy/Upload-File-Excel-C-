using Microsoft.EntityFrameworkCore;

namespace AplikasiUploadExcel.Api.DbContextDir
{
    public static class ConnectDatabase
    {
        public static ConfigurationManager Config;
        public static void AddDomainContext(this IServiceCollection services, ConfigurationManager config)
        {
            Config = config;
            services.AddDbContext<DatabaseKaryawanContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DB_Conn"));
            });
        }
    }
}
