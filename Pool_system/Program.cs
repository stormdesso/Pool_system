using Pool_system.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Add(new ServiceDescriptor(typeof(UserContext), new UserContext(builder.Configuration.GetConnectionString("DefaultConnection"))));

builder.Services.AddDistributedMemoryCache();// ��������� IDistributedMemoryCache

builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".MyApp.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(3600);//��� �����������
    options.Cookie.IsEssential = true;//���� �������� � ���������� ��� ������ ����� ����������
});

builder.Services.AddSession();  // ��������� ������� ������

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()){

    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();    
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();   // ��������� middleware ��� ������ � ��������

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Authorization}/{action=Index}/{id?}");

app.Run();
