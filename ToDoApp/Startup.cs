using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToDoApp;
using ToDoApp.Services;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddRazorPages()
            .AddRazorPagesOptions(options =>
            {
                options.Conventions.Add(
                    new PageRouteTransformerConvention(
                        new KebabCaseParameterTransformer()));
                options.Conventions.AddPageRoute("/Error", "/error");
            });


        services.Configure<RouteOptions>(options =>
        {
            options.AppendTrailingSlash = true;
            options.LowercaseUrls = true;
            options.LowercaseQueryStrings = true;
        });

        // services.AddDbContext<ToDoContext>(options => options.UseSqlite(
        //     $"Filename={System.IO.Path.Combine(System.Environment.CurrentDirectory, "ToDo.db")}"
        //     ));

        services.AddTransient<ToDoService>();

        // services.AddDbContext<ToDoContext>(options => options.UseSqlite(
        //         $"Filename={System.IO.Path.Combine(System.Environment.CurrentDirectory, "ToDo.db")}"));
        services.AddDbContext<ToDoContext>(options => options.UseSqlite(
            Configuration.GetConnectionString("TodoLocalSqliteContext")));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseStatusCodePagesWithRedirects("/Error");
        
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
        });
    }
}

public class KebabCaseParameterTransformer : IOutboundParameterTransformer
{
    public string TransformOutbound(object value)
    {
        if (value == null) return null;
        return Regex
            .Replace(value.ToString(), "([a-z])([A-Z])", "$1-$2")
            .ToLower();
    }
}