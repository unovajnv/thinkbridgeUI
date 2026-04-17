using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ThinkBridge.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo 
    { 
        Title = "Invoice API", 
        Version = "v1",
        Description = "API for managing invoices"
    });
});

// Add DbContext
var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("DATABASE_URL environment variable is not set. Please configure your database connection.");
}

builder.Services.AddDbContext<InvoiceContext>(options =>
    options.UseNpgsql(connectionString));

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Invoice API V1");
        c.RoutePrefix = "api/docs";
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

// Serve static files (HTML, CSS, JS)
app.UseStaticFiles();

app.MapControllers();

// Database initialization
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<InvoiceContext>();
    db.Database.EnsureCreated();
    InitializeDatabase(db);
}

// Fallback to index.html for SPA
app.MapFallbackToFile("index.html");

app.Run();

static void InitializeDatabase(InvoiceContext db)
{
    if (!db.Invoices.Any())
    {
        var invoice = new Invoice
        {
            InvoiceID = 1,
            CustomerName = "John Doe"
        };
        db.Invoices.Add(invoice);
        db.SaveChanges();

        var items = new[]
        {
            new InvoiceItem { ItemID = 1, InvoiceID = 1, Name = "Widget A", Price = 19.99m },
            new InvoiceItem { ItemID = 2, InvoiceID = 1, Name = "Widget B", Price = 29.99m }
        };
        db.InvoiceItems.AddRange(items);
        db.SaveChanges();
    }
}
