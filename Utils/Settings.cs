using Microsoft.Extensions.Configuration;
using System.IO;

namespace Utils
{
	public class AppSettings
	{
		private readonly string _filename;
		public AppSettings(string filename)
		{
			_filename = filename;
		}

		public string GetConnectionString(string name)
		{
            //var builder = new ConfigurationBuilder()
            //	.SetBasePath(Directory.GetCurrentDirectory())
            //	.AddJsonFile(_filename, optional: true, reloadOnChange: true);

            //IConfigurationRoot configuration = builder.Build();
            //return configuration.GetConnectionString(name);
            return null;
		}
	}
}
