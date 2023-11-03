//1) builder adında bir web uygulaması inşa edici oluşturuyoruz.(WebApplicationBuilder tipinde)
var builder = WebApplication.CreateBuilder(args);

//builder adlı WebApplicationBuilder nesnesinin MVC özellikleriyle donatılmasını sağlar.
builder.Services.AddControllersWithViews();

//2) Oluşturulan builder isimle WebApplicationBuilder nesnesini derliyoruz. Ve app adında bir WebApplication elde ediyoruz.(WebApplication tipinde)
var app = builder.Build();

//Bu aşamada app run edilene kadar app üzerine ihtiyaç duyulan MiddleWare(ara yazılım) yapıları eklenir.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


// https://localhost:5236/home/privacy
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//3) Oluşturulan app adındaki WebApplication'ı çalıştırıyoruz.
app.Run();
