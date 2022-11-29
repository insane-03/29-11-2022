
using Microsoft.Extensions.Configuration;

using Flopkart_Service.Implementation;

using Flopkart_Service.Interface;

using Flopkart_Repository.Implementation;

using Flopkart_Repository.Interface;

using Flopkart_Repository;


namespace Flopkart
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen();

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<ICartService, CartService>();
            services.AddTransient<ICartRepository, CartRepository>();

            
            

            services.AddSingleton<DB_Context>(
                k => new DB_Context(Configuration.GetConnectionString("MongoDB"),
                Configuration.GetValue<string>("DatabaseName")));


            services.AddAutoMapper(typeof(IProductService));
            services.AddAutoMapper(typeof(ICartService));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment()) 
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
               c.SwaggerEndpoint("/swagger/v1/swagger.json", "Flopkart");
            });

            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
            });
             
        }
    }
}
