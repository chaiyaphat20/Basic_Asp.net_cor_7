using BasicASPTutorial.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); //Set ให้ Controller และ View ทำงาน

//เชื่อมค่อ ฐานข้อมูล
builder.Services.AddDbContext<ApplicationDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); //กำหนดให้โปรเจครันแบบ https
app.UseStaticFiles(); // ใช้ ตัว static file

app.UseRouting(); //ใช้ route    ในโปรเจค

app.UseAuthorization();//กำหนด สิทธิ์ในใช้งานโปรเจค

app.MapControllerRoute(
    name: "default", //ใช้สำหรับ กำหนด route default
    pattern: "{controller=Student}/{action=Index}/{id?}");   //id? คือ optional
    //Home คือ Controller แรกที่จะทำงาน
    //Home คือการ เขียนย่อ เขียนแบบเต็มจะได้ HomeController

    //action คือ กระบวนการทำงาน
    //Index คือ method ที่ทำงานใน HomeController
    //ใน HomeController ต้องมี action ชื่อ index ถึงจะทำงานได้

app.Run();
