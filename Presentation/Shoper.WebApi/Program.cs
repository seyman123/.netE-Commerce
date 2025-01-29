using Microsoft.AspNetCore.Identity;
using Shoper.Application.Interfaces;
using Shoper.Application.Interfaces.ICartItemsRepository;
using Shoper.Application.Interfaces.ICartsRepository;
using Shoper.Application.Interfaces.IOrderRepository;
using Shoper.Application.Interfaces.IProductsRepository;
using Shoper.Application.Usecasess.CartItemSevices;
using Shoper.Application.Usecasess.CartServices;
using Shoper.Application.Usecasess.CategoryServices;
using Shoper.Application.Usecasess.CustomerServices;
using Shoper.Application.Usecasess.OrderItemServices;
using Shoper.Application.Usecasess.OrderServices;
using Shoper.Application.Usecasess.ProductServices;
using Shoper.Persistence.Context;
using Shoper.Persistence.Context.Identity;
using Shoper.Persistence.Repositories;
using Shoper.Persistence.Repositories.CartItemsRepository;
using Shoper.Persistence.Repositories.CartsRepository;
using Shoper.Persistence.Repositories.OrdersRepository;
using Shoper.Persistence.Repositories.ProductsRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<IOrderRepository, OrdersRepository>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<ICartsRepository, CartsRepository>();
builder.Services.AddScoped<ICartItemsRepository, CartItemsRepository>();
builder.Services.AddScoped<IUserIdentityRepository, UserIdentityRepository>();

builder.Services.AddIdentity<AppIdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<ICategoryServices, CategoryServices>();
builder.Services.AddScoped<ICustomerServices, CustomerServices>();
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICartItemService, CartItemService>();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
