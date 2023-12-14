
using IndSoftProject.Data;
using Microsoft.EntityFrameworkCore;

namespace IndSoftProject
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddDbContext<MyDbContext>(opt =>
			{
				opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
			});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			var scope = app.Services.CreateScope();
			var context = scope.ServiceProvider.GetRequiredService<MyDbContext>();
			var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
			try
			{
				context.Database.Migrate();
				DbInitializer.Initialize(context);
			}
			catch(Exception ex)
			{
				logger.LogError(ex, "A aparut o problema in timpul migratiei");
			}

			app.Run();
		}
	}
}
