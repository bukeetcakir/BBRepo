using Microsoft.EntityFrameworkCore;
using MiniShop.Data.Abstract;
using MiniShop.Data.Concrete.EfCore.Contexts;
using MiniShop.Data.Concrete.EfCore.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();//Controller yapısı kullanılmaya hazır.
builder.Services.AddDbContext<MiniShopDbContext>(options=>options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));//MiniShopDbContext oluşturuldu ve ne zaman istenilirse DI ile kullanılmaya hazır.
builder.Services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();//ICategoryRepository tipinde nesne istendiğinde şu an burada yaratılan EfCoreCategoryRepository tipindeki nesne DI ile kullanılmaya hazır.


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
