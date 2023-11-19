using Microsoft.Extensions.Options;
using MongoDB.Driver;
using RestaurantApi.Models;
using RestaurantApi.Models.BookTableModel;
using RestaurantApi.Models.CustomerModel;
using RestaurantApi.Models.ManagerModel;
using RestaurantApi.Models.OrderModel;
using RestaurantApi.Models.StaffModel;
using RestaurantApi.Services.BookTableService;
using RestaurantApi.Services.CustomerService;
using RestaurantApi.Services.ManagerService;
using RestaurantApi.Services.OrderService;
using RestaurantApi.Services.StaffService;

var builder = WebApplication.CreateBuilder(args); 

// Add services to the container.
//Order
//class
builder.Services.Configure<OrderStoreDatabaseSetting>(builder.Configuration.GetSection(nameof(OrderStoreDatabaseSetting)));
//model
builder.Services.AddSingleton<IOrderStoreDatabaseSetting>(sp => 
        sp.GetRequiredService<IOptions<OrderStoreDatabaseSetting>>().Value);
//appsetting
builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("OrderStoreDatabaseSetting:ConnectionString")));
//Services
builder.Services.AddScoped<IOrderService, OrderService>();

//BookTable
builder.Services.Configure<BookTableStoreDatabaseSetting>(builder.Configuration.GetSection(nameof(BookTableStoreDatabaseSetting)));

builder.Services.AddSingleton<IBookTableStoreDatabaseSetting>(sp =>
        sp.GetRequiredService<IOptions<BookTableStoreDatabaseSetting>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("BookTableStoreDatabaseSetting:ConnectionString")));

builder.Services.AddScoped<IBookTableService, BookTableService>();

//customer
builder.Services.Configure<CustomerStoreDatabaseSetting>(builder.Configuration.GetSection(nameof(CustomerStoreDatabaseSetting)));

builder.Services.AddSingleton<ICustomerStoreDatabaseSetting>(sp =>
        sp.GetRequiredService<IOptions<CustomerStoreDatabaseSetting>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("CustomerStoreDatabaseSetting:ConnectionString")));

builder.Services.AddScoped<ICustomerService, CustomerService>();


//Manager
builder.Services.Configure<ManagerStoreDatabaseSetting>(builder.Configuration.GetSection(nameof(ManagerStoreDatabaseSetting)));

builder.Services.AddSingleton<IManagerStoreDatabaseSetting>(sp =>
        sp.GetRequiredService<IOptions<ManagerStoreDatabaseSetting>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("ManagerStoreDatabaseSetting:ConnectionString")));

builder.Services.AddScoped<IManagerService, ManagerService>();

//Staff
builder.Services.Configure<StaffStoreDatabaseSetting>(builder.Configuration.GetSection(nameof(StaffStoreDatabaseSetting)));

builder.Services.AddSingleton<IStaffStoreDatabaseSetting>(sp =>
        sp.GetRequiredService<IOptions<StaffStoreDatabaseSetting>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("StaffStoreDatabaseSetting:ConnectionString")));

builder.Services.AddScoped<IStaffService, StaffService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
        options.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

