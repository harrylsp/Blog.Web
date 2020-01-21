using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Blog.Common
{
    public sealed class ConfigManager
    {
        private static string path = "appsettings.json";
        public static IConfiguration Configuration { get; set; }

        static ConfigManager()
        {
            // ReloadOnChange = true， 当 appsettings.json 被修改时重新加载
            Configuration = new ConfigurationBuilder()
                .Add(new JsonConfigurationSource { Path = path, ReloadOnChange = true })
                .Build();
        }
    }
    
}
