using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();


app.UseWebSockets();
app.MapControllers();
app.UseRouting();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "wwwroot/dist")),
    RequestPath  = ""
});

app.MapGet("/", ctx =>
{
    ctx.Response.Redirect("/index.html");
    return Task.CompletedTask;
});
app.MapFallbackToFile("index.html");

app.Run();