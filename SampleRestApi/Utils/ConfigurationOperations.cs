using SampleRestApi.Extensions;
using SampleRestApi.ViewModels;

namespace SampleRestApi.Utils
{
    public class ConfigurationOperations
    {
        private static string _fileName => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.Development.json");

        public static ConfigurationViewModel ReadConfiguration()
        {
            var json = File.ReadAllText(_fileName);
            return json.JsonToItem<ConfigurationViewModel>();
        }

        public static void SaveChanges(ConfigurationViewModel configuration)
        {
            configuration.JsonToFile(_fileName);
        }
    }
}