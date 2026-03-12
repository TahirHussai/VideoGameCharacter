using VideoGameCharacter.UI.Components;
using VideoGameCharacter.UI.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// --- Authentication & Local Storage ---
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<JwtAuthorizationHandler>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<ApiErrorHandlingHandler>();

// --- API Clients & Configuration ---
var apiBaseUrl = builder.Configuration["ApiBaseUrl"] ?? "https://localhost:7100/";

builder.Services.AddHttpClient<CharacterApiClient>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
}).AddHttpMessageHandler<JwtAuthorizationHandler>();
// .AddHttpMessageHandler<ApiErrorHandlingHandler>();

builder.Services.AddHttpClient<AuthApiService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
})//.AddHttpMessageHandler<JwtAuthorizationHandler>()
 .AddHttpMessageHandler<ApiErrorHandlingHandler>();

builder.Services.AddHttpClient<AdminApiService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
})//.AddHttpMessageHandler<JwtAuthorizationHandler>()
  .AddHttpMessageHandler<ApiErrorHandlingHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<VideoGameCharacter.UI.Components.App>()
    .AddInteractiveServerRenderMode();

app.Run();
