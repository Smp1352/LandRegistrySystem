
using LandRegistrySystem.Data;
using LandRegistrySystem.Data.Repositories;
using LandRegistrySystem.Services;
using LandRegistrySystem.Validators;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using LandRegistrySystem.Mappings;

var builder = WebApplication.CreateBuilder(args);


// ==========================================
// 1. ثبت DbContext
// ==========================================
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// ==========================================
// ثبت AutoMapper
// ==========================================
builder.Services.AddAutoMapper(typeof(MappingProfile));

// ==========================================
// ثبت Repository‌ها
// ==========================================
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IParcelRepository, ParcelRepository>();



// ثبت Generic Repository
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// ثبت Repositoryهای اختصاصی
builder.Services.AddScoped<IParcelRepository, ParcelRepository>();

// ==========================================
// 3. ثبت Service‌ها
// ==========================================
builder.Services.AddScoped<IParcelService, ParcelService>();
// برای سرویس‌های دیگر در آینده:
// builder.Services.AddScoped<IProvinceService, ProvinceService>();
// builder.Services.AddScoped<IPersonService, PersonService>();
// ==========================================
// ثبت FluentValidation
// ==========================================
builder.Services.AddFluentValidationAutoValidation();  // اعتبارسنجی خودکار
builder.Services.AddFluentValidationClientsideAdapters();  // اعتبارسنجی سمت کلاینت

// ثبت تمام Validators
builder.Services.AddValidatorsFromAssemblyContaining<ParcelCreateValidator>();

// ==========================================
// ثبت Repository و Service
// ==========================================
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IParcelRepository, ParcelRepository>();
builder.Services.AddScoped<IParcelService, ParcelService>();

// ==========================================
// 4. ثبت سایر سرویس‌های ASP.NET Core
// ==========================================
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IPersonService, PersonService>();

builder.Services.AddRazorPages();

// اگر از AutoMapper استفاده می‌کنید:
// builder.Services.AddAutoMapper(typeof(Program));

// اگر از FluentValidation استفاده می‌کنید:
// builder.Services.AddValidatorsFromAssemblyContaining<Program>();

var app = builder.Build();

// ==========================================
// 5. اعمال Migration به‌صورت خودکار (اختیاری)
// ==========================================
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    // اگر دیتابیس وجود ندارد، ایجاد کن
    dbContext.Database.EnsureCreated();
    // یا اگر می‌خواهید Migration‌ها اعمال شوند:
    // dbContext.Database.Migrate();
}
// ==========================================
// تنظیمات Routing برای صفحه پیش‌فرض
// ==========================================
app.MapRazorPages();

app.MapGet("/", async context =>
{
    await Task.Run(() =>
    {
        context.Response.Redirect("/Parcels");
    });
});

// ==========================================
// 6. Middleware Pipeline
// ==========================================
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();