using Application.Leads.GetLeads;
using Application.Services;
using Domain.Common;
using Domain.Leads;
using Domain.Leads.Contacts;
using Domain.ValueObjects;
using Infrastructure.Database;
using Infrastructure.Domain.Leads;
using Infrastructure.Services;
using MediatR;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(LeadDto).Assembly);
var cnn = new SqliteConnection("Filename=:memory:");

cnn.Open();
builder.Services.AddDbContext
<LeadDbContext>(o => o.UseSqlite(cnn));

builder.Services.AddScoped<ILeadRepository, LeadRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailService, EmailService>();

var app = builder.Build();
AddCustomerData(app);
app.UseCors(options =>
{
    options.WithOrigins("http://localhost:3000");
    options.AllowAnyHeader();
    options.AllowAnyMethod();
});
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

static void AddCustomerData(WebApplication app)
{
    var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetService<LeadDbContext>();

    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    var contact1 = new Contact
    {
        Name = new Name("Bill", "Clinton"),
        Email = new Email("bill.clinton@gmail.com"),
        Id = 1,
        PhoneNumber = new PhoneNumber("31", "998850341"),
    };

    var contact2 = new Contact
    {
        Name = new Name("Craig", "Sanderson"),
        Email = new Email("craigsands@gmail.com"),
        Id = 2,
        PhoneNumber = new PhoneNumber("32", "978850351"),
    };

    var lead1 = new Lead
        (
            contact: contact1,
            date: new DateTime(2023, 1, 1),
            suburb: "Yanderra 2547",
            description: "Need to paint 2 windows",
            price: 22.54M,
            jobCategory: JobCategory.Painters
        );

    var lead2 = new Lead
        (
            contact: contact2,
            date: new DateTime(2023, 1, 1),
            suburb: "Wolooware 2230",
            description: "Internal wall",
            price: 601.54M,
            jobCategory: JobCategory.InteriorPainters
        );

    db.Leads.Add(lead1);
    db.Leads.Add(lead2);

    db.SaveChanges();
}