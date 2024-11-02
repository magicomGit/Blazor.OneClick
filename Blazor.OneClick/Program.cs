using Blazor.OneClick.Components;
using Blazor.OneClick.Components.Account;
using Blazor.OneClick.Constants;
using Blazor.OneClick.TelegramBot;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using OneClick.Data.Data;
using OneClick.Data.Helpers;
using OneClick.Data.Repositoties;
using OneClick.Domain.Domain.Balances;
using OneClick.Domain.Domain.DomainModels;
using OneClick.Services.Balances;
using OneClick.UseCases.Intefaces.App;
using OneClick.UseCases.Intefaces.Balances;
using OneClick.UseCases.Intefaces.OneClickProjects;
using OneClick.UseCases.Intefaces.User;
using Telegram.Bot;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddMudServices();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseLazyLoadingProxies()
    //.UseNpgsql(Settings.ConnectionString, b => b.MigrationsAssembly("Blazor.OneClick")));
    .UseSqlServer(Settings.ConnectionString, b => b.MigrationsAssembly("Blazor.OneClick")));



builder.Services.AddSingleton<ITelegramBotClient, TelegramBotClient>(opt => new TelegramBotClient(Settings.TelegramBotKeyInit)).AddSingleton<TelegramBotEngine>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
    options.Lockout.MaxFailedAccessAttempts = 5;
})
    .AddSignInManager()
    .AddRoles<IdentityRole>()
    .AddRoleManager<RoleManager<IdentityRole>>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

//builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();
//builder.Services.AddData();

builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});


builder.Services.AddScoped<IOneClickProjectRepositoty, OneClickProjectRepositoty>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAppSettingsRepository, AppSettingsRepository>();
builder.Services.AddScoped<ITransactionRepository<Response<OneClickTransaction>, OneClickTransaction>, TransactionRepository>();
builder.Services.AddScoped<ITransactions<Response<OneClickTransaction>, OneClickTransaction>, Transactions>();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IAppLogger, AppLogger>();
builder.Services.AddScoped<IPayments, Payments>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRequestLocalization(new RequestLocalizationOptions()
    .AddSupportedCultures(new[] { "en-US", "ru-RU" })
    .AddSupportedUICultures(new[] { "en-US", "ru-RU" })
    .SetDefaultCulture("ru-RU"));

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
