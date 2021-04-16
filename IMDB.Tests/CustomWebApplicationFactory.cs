using IMDB_api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Tests
{
	public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TestStartup>
	{
		protected override IHostBuilder CreateHostBuilder()
		{
			return base.CreateHostBuilder()
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<TestStartup>();
				});
		}
	}
}
