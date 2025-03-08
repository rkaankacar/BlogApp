using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EFCore;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(); //  Controller bu bir servisitir

builder.Services.AddDbContext<BlogContext>(option => { // bu bir servistir 
    var config = builder.Configuration; // aoosettingDeve configuration üzerinden direk ulaşabiliyoruz daatbasedeki adrese
    var connectionstring=config.GetConnectionString("DefaultConnection");
    option.UseSqlServer(connectionstring); // bağlantı sağlandı 
});

builder.Services.AddScoped<IPostRepository, EFPostRepository>(); // kendi servisimizi uygulamaya tanıttık.
var app = builder.Build();
SeedData.SeedDatabase(app);

app.MapDefaultControllerRoute(); // default controller route oluşturuldu

app.Run();
