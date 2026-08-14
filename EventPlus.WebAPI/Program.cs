using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EventContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ITipoUsuario, TipoUsuarioRepository>();
builder.Services.AddScoped<ITipoEvento, TipoEventoRepository>();
builder.Services.AddScoped<IUsuario, UsuarioRepository>();
builder.Services.AddScoped<IInstituicao, InstituicaoRepository>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
