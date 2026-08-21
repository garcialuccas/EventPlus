using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EventContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers().AddJsonOptions(Options =>
{
    Options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

builder.Services.AddScoped<ITipoUsuario, TipoUsuarioRepository>();
builder.Services.AddScoped<ITipoEvento, TipoEventoRepository>();
builder.Services.AddScoped<IUsuario, UsuarioRepository>();
builder.Services.AddScoped<IInstituicao, InstituicaoRepository>();
builder.Services.AddScoped<IEvento, EventoRepository>();
builder.Services.AddScoped<IComentario, ComentarioRepository>();
builder.Services.AddScoped<IPresenca, PresencaRepository>();

builder.Services.AddAuthentication(options => { options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; }).AddJwtBearer(options => { options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters { ValidateIssuer = true, ValidIssuer = "EventPlus.WebAPI", ValidateAudience = true, ValidAudience = "EventPlus.WebAPI", ValidateLifetime = true, ClockSkew = TimeSpan.FromMinutes(5), IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("eventos-chave-autenticacao-webapi-dev")) }; });

builder.Services.AddAuthorization();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
