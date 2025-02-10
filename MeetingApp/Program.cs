var builder = WebApplication.CreateBuilder(args);

//Controller views iliþkisi için
builder.Services.AddControllersWithViews();

var app = builder.Build();

//static doyalarýn aktifleþtimek için (wwwroot altýndaki)
app.UseStaticFiles();


//Yazmadan da çalýþýþýr ancak custom routinglerde
//bu þekilde tanýmlamamýz lazým karýþýklýk olamamsý için
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern:"{controller=Home}/{action=Index}/{id?}"
    
    );

app.Run();
