using AutoMapper;
using Lab4.Abstraction.IRepository;
using Lab4.Abstraction.IServices;
using Lab4.BLL.Services;
using Lab4.DAL.Data;
using Lab4.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// ��������� ����������
builder.Services.AddControllers();

// ��������� AutoMapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile()); // �������������� ��� ������� ������
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

//// ��������� Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SportComplex API",
        Version = "v1",
        Description = "API ��� ��������� ���������� ����������.",
        Contact = new OpenApiContact
        {
            Name = "������ �������",
            Email = "maksym.khrustavchuk.pz.2022@lpnu.ua"
        }
    });

    //var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //c.IncludeXmlComments(xmlPath);

    //c.DocumentFilter<SwaggerControllerSorter>();
});

// ��������� DbContext
builder.Services.AddDbContext<SportComplexContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();

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