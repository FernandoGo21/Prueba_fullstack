using GodoyTest.Data;
using GodoyTest.Mappings;
using GodoyTest.Providers;
using GodoyTest.Providers.Interfaces;
using GodoyTest.Services;
using GodoyTest.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IHistorySearchsService, HistorySearchsService>();
builder.Services.AddScoped<IQueryExtractorService, QueryExtractorService>();
builder.Services.AddScoped<ISearchAndSaveHistory, SearchAndSaveHistory>();
builder.Services.AddHttpClient<IGiphyService, GiphyService>();
builder.Services.AddHttpClient<ICatFactService, CatFactService>();
builder.Services.AddSingleton<IWordsProvider, WordsProvider>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


//Add context of DB
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Habilitar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseDefaultFiles();      // Servir index.html automáticamente
app.UseStaticFiles();       // Servir archivos estáticos desde wwwroot

app.UseCors("AllowAngularDev");

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("index.html");  // Redirige rutas de Angular a index.html

app.Run();
