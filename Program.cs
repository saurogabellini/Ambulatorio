using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using AmbulatorioApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using AmbulatorioApp.Auth; // Assicurati che questo using sia corretto per DbInitializer se è lì

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(); // Necessario per Identity UI e _Host
builder.Services.AddServerSideBlazor();

// Configurazione della connessione al database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddDefaultIdentity<IdentityUser>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
}).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();


builder.Services.ConfigureApplicationCookie(options =>
{
    // Il percorso della TUA pagina di login Blazor
    options.LoginPath = "/Identity/Account/Login"; // Assicurati che corrisponda alla @page del tuo Login.razor

    // Puoi configurare anche altri percorsi se necessario:
    // options.LogoutPath = "/logout"; // Se hai una pagina di logout separata
    // options.AccessDeniedPath = "/access-denied"; // Pagina da mostrare se l'utente è loggato MA non autorizzato (es. per ruoli/policy)
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting(); // <-- Routing prima

// -------- AGGIUNGI QUESTI DUE --------
app.UseAuthentication(); // <-- Identifica l'utente
app.UseAuthorization();  // <-- Applica le regole di accesso
// -------------------------------------

app.MapBlazorHub(); // <-- Endpoint Blazor (richiede auth)
app.MapFallbackToPage("/_Host"); // <-- Endpoint Fallback (richiede auth)
// Se stai usando pagine Identity scaffoldate, potresti aver bisogno anche di:
app.MapRazorPages();

// Creare e inizializzare il database se non esiste
// È ok lasciarlo qui, viene eseguito all'avvio, non per richiesta
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        // Assicurati che DbInitializer sia nello scope corretto o sia statico
        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Si è verificato un errore durante l'inizializzazione del database.");
    }
}

app.Run();