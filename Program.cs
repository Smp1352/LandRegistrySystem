using LandRegistrySystem.Data;
using LandRegistrySystem.Data.Repositories;
using LandRegistrySystem.Services;
using LandRegistrySystem.Validators;
using LandRegistrySystem.Mappings;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// ==========================================
// 1. ثبت DbContext
// ==========================================
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
          .LogTo(Console.WriteLine, LogLevel.Information)
          .EnableSensitiveDataLogging());

// ==========================================
// 2. ثبت AutoMapper
// ==========================================
builder.Services.AddAutoMapper(typeof(MappingProfile));

// ==========================================
// 3. ثبت FluentValidation (قبل از Build)
// ==========================================
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<ParcelCreateValidator>();

// ==========================================
// 4. ثبت Repository‌ها
// ==========================================
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IParcelRepository, ParcelRepository>();

// ==========================================
// 5. ثبت Service‌ها
// ==========================================
builder.Services.AddScoped<IParcelService, ParcelService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IPersonService, PersonService>();


// ==========================================
// 6. ثبت Razor Pages
// ==========================================
builder.Services.AddRazorPages();

// ==========================================
// 7. Build برنامه
// ==========================================
var app = builder.Build();

// ==========================================
// 8. اعمال Migration به‌صورت خودکار
// ==========================================
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();  // یا EnsureCreated()
}

// ==========================================
// 9. Middleware Pipeline
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

// ==========================================
// 10. تنظیم مسیر پیش‌فرض
// ==========================================
//app.MapGet("/", context =>
//{
//    context.Response.Redirect("/Parcels");
//    return Task.CompletedTask;
//});

app.MapRazorPages();

app.Run();