using AutoMapper; // Для AutoMapper
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TodoApi; // Ваш проект


var builder = WebApplication.CreateBuilder(args);

// Реєстрація контролерів
builder.Services.AddControllers();

// Реєстрація AutoMapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile()); // Використовуйте ваш профіль мапінгу
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

//// Реєстрація Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SportComplex API",
        Version = "v1",
        Description = "API для управління спортивним комплексом.",
        Contact = new OpenApiContact
        {
            Name = "Максим Мангуст",
            Email = "maksym.khrustavchuk.pz.2022@lpnu.ua"
        }
    });

    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    c.DocumentFilter<SwaggerControllerSorter>();
});

// Реєстрація DbContext
builder.Services.AddDbContext<SportComplexContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();