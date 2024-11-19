namespace YipYip.DockerWebAPI
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure Kestrel to listen on any IP address
            // builder.WebHost.ConfigureKestrel(serverOptions =>
            // {
            //     serverOptions.ListenAnyIP(8080); // Listen for HTTP traffic on port 5000

            // });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //app.UseAuthorization();

            // global cors policy
            app.UseCors(policy =>
            {
                policy.SetIsOriginAllowed(origin => true) // Allow any origin
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.All,
                AllowedHosts = new List<string>()
            });

            app.MapControllers();

            app.Run();
        }
    }
}
