using HotelAppBusiness;
using HotelAppBusiness.Interfaces;
using HotelAppData;
using HotelAppData.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IUserData, UserData>();
builder.Services.AddTransient<IUserBusiness, UserBusiness>();

builder.Services.AddTransient<IHotelData, HotelData>();
builder.Services.AddTransient<IHotelBusiness, HotelBusiness>();

builder.Services.AddTransient<IBedroomData, BedroomData>();
builder.Services.AddTransient<IBedroomBusiness, BedroomBusiness>();

builder.Services.AddTransient<IPassengerData, PassengerData>();
builder.Services.AddTransient<IPassengerBusiness, PassengerBusiness>();

builder.Services.AddTransient<IBookingData, BookingData>();
builder.Services.AddTransient<IBookingBusiness, BookingBusiness>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("NuevaPolitica");

app.UseAuthorization();

app.MapControllers();

app.Run();
