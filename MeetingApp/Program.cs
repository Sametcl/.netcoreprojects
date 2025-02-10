var builder = WebApplication.CreateBuilder(args);

//Controller views ili�kisi i�in
builder.Services.AddControllersWithViews();

var app = builder.Build();

//static doyalar�n aktifle�timek i�in (wwwroot alt�ndaki)
app.UseStaticFiles();


//Yazmadan da �al�����r ancak custom routinglerde
//bu �ekilde tan�mlamam�z laz�m kar���kl�k olamams� i�in
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern:"{controller=Home}/{action=Index}/{id?}"
    
    );

app.Run();
