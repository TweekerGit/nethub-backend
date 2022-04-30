﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetHub.Core.Abstractions.Context;
using NetHub.Core.Extensions;
using NetHub.Data.SqlServer.Context;

namespace NetHub.Data.SqlServer;

public static class DependencyInjection
{
	public static void AddSqlServerDatabase(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext(configuration);
	}


	private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
	{
		if (configuration.IsTesting()) return;

		var contextFactory = new SqlServerDbContextFactory();
		services.AddDbContext<SqlServerDbContext>(cob => contextFactory.ConfigureContextOptions(cob));

		services.AddScoped<IDatabaseContext, SqlServerDbContext>();
	}
}