using Bufao.LeilaoOnline.WebApp.Dados;
using Bufao.LeilaoOnline.WebApp.Dados.EFCore;
using Bufao.LeilaoOnline.WebApp.Dados.EFCore.Dao;
using Bufao.LeilaoOnline.WebApp.Dados.EFCore.Seeding;
using Bufao.LeilaoOnline.WebApp.Services.Handlers;
using Bufao.LeilaoOnline.WebApp.Services;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

#region ConfigureServices (Add services to the container.)
DatabaseGenerator.Seed();

builder.Services.AddTransient<ICategoriaDao, CategoriaDaoComEfCore>();
builder.Services.AddScoped<ILeilaoDao,LeilaoDaoComEFCore>();
builder.Services.AddTransient<IProdutoService, DefaultProdutoService>();
builder.Services.AddTransient<IAdminService, ArquivamentoAdminService>();
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddControllersWithViews();
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    }); 
#endregion

var app = builder.Build();

#region Configure (Configure the HTTP request pipeline.)
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseHsts();
}

app.UseStatusCodePagesWithRedirects("/Home/StatusCode/{0}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoinst =>
{
    endpoinst.MapControllers();

    endpoinst.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

#endregion
app.Run();