using Bank.BankFiap.Bank.Interface;
using Bank.BankFiap.Bank.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IUser, UserRepository>();
builder.Services.AddSingleton<IAsset, AssetRepository>();
builder.Services.AddSingleton<IDividendInterest, DividendInterestRepository>();
builder.Services.AddSingleton<IPortifolio, PortifolioRepository>();
builder.Services.AddSingleton<IPriceHistory, PriceHistoryRepository>();
builder.Services.AddSingleton<ITransaction, TransactionRepository>();
builder.Services.AddSingleton<IMarketValue, MarketValueRepository>();

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
