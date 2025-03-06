using BlogApp.Data.Concrete.EFCore;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BlogContext>(option => { // bu bir servistir 
    var config = builder.Configuration; // aoosettingDeve configuration üzerinden direk ulaşabiliyoruz daatbasedeki adrese
    var connectionstring=config.GetConnectionString("DefaultConnection");
    option.UseSqlServer(connectionstring); // bağlantı sağlandı 
});

var app = builder.Build();
app.MapGet("/", () => "Hello World!");

app.Run();
