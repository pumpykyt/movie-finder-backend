using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using MovieFinder.Application.Extensions;
using MovieFinder.Application.Handlers;
using MovieFinder.Application.Profiles;
using MovieFinder.Data;
using MovieFinder.Domain.Configs;
using MovieFinder.Domain.Interfaces;
using MovieFinder.Domain.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(LoginHandler));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IMarkService, MarkService>();
builder.Services.AddScoped<IActorService, ActorService>();
builder.Services.AddScoped<ISearchService, SearchService>();
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));
builder.Services.AddDbContext<DataContext>(a =>
    a.UseNpgsql(builder.Configuration.GetSection("ConnectionString").Value,
        b => b.MigrationsAssembly("MovieFinder.Web")
    )
);
builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
        {
            x.TokenValidationParameters = new TokenValidationParameters();
        }
    );
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseFileServer();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "wwwroot")),
    RequestPath = "/wwwroot"
});
app.UseHttpsRedirection();
app.UseErrorHandlerMiddleware();
app.UseAuthorization();
app.MapControllers();
app.Run();