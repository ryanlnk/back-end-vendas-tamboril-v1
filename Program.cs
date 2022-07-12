using Microsoft.EntityFrameworkCore;
using VendasTamboril.Data;
using VendasTamboril.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<TamborilContext>(
    options =>
        options.UseMySql(
        builder.Configuration.GetConnectionString("DB"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DB"))
)
);

builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<PaymentService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<BankAccountService>();
builder.Services.AddScoped<ProductService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Desabilitando CROS para o front
app.UseCors(policy =>
    policy.WithOrigins("http://localhost:3000")
    .AllowAnyMethod()
    .AllowAnyHeader()
);

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
