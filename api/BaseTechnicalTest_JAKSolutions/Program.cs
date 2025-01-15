using BaseTechnicalTest_JAKSolutions.Repositories.Interfaces;
using BaseTechnicalTest_JAKSolutions.Repositories;
using BaseTechnicalTest_JAKSolutions.Services.Interfaces;
using BaseTechnicalTest_JAKSolutions.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// services
builder.Services.AddSingleton<IProductService, ProductService>();

// repositories
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "ReactDotNetApi", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ReactDotNetApi v1"));
}

app.UseRouting();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();