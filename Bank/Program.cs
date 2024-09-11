using Bank.BankFiap.Bank.Interface;
using Bank.BankFiap.Bank.Repository;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sua API", Version = "v1" });

    // Configuração para adicionar suporte a autenticação Bearer Token
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Insira o token JWT nesta caixa. Exemplo: Bearer {seu_token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
           Array.Empty<string>()
        }
    });
});

builder.Services.AddSingleton<IUser, UserRepository>();
builder.Services.AddSingleton<IAsset, AssetRepository>();
builder.Services.AddSingleton<IDividendInterest, DividendInterestRepository>();
builder.Services.AddSingleton<IPortifolio, PortifolioRepository>();
builder.Services.AddSingleton<IPriceHistory, PriceHistoryRepository>();
builder.Services.AddSingleton<ITransaction, TransactionRepository>();
builder.Services.AddSingleton<IMarketValue, MarketValueRepository>();

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

var key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("Secret"));

builder.Services.AddAuthentication(
    x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }
   ).AddJwtBearer(x =>
   {
       x.RequireHttpsMetadata = false;
       x.SaveToken = true;
       x.TokenValidationParameters = new TokenValidationParameters()
       {
           ValidateIssuerSigningKey = true,
           IssuerSigningKey = new SymmetricSecurityKey(key),
           ValidateIssuer = false,
           ValidateAudience = false
       };
   });

// Adicione serviços ao contêiner.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("https://localhost:7287")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials());
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
