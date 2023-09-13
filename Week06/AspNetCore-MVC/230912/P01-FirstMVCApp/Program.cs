//1- builder adında bir web uygulaması inşa edici oluşturuyoruz (WebAplicationBuilder tipinde)
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Builder adlı WebApplicationBuilder nesnesinin MVC özellikleri ile donatılmasını sağlar.
builder.Services.AddControllersWithViews();

//2- Oluşturulan builder isimle WebApplicationBuilder nesnesini derliyoruz. Ve app adında bir webApplication elde ederiyoruz (WebAplication tipinde)
var app = builder.Build();

// Configure the HTTP request pipeline.
//Bu aşamada app run edilene kadar app üzerine ihtiyaç duyulan MiddleWare (ara yazılım) yapıları eklenir
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Oluşturulan app adındaki WebApplication'ı çalıştırıyoruz.
app.Run();
