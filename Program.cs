using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ChedzaApp Api",
        Version = "v1",
        Description = "Service to support the SpyStore sample eCommercesite",
        TermsOfService = new Uri("https://example.com/terms"),
        License = new OpenApiLicense
        {
            Name = "Freeware",
            //Url= "https://en.wikipedia.org/wiki/Freeware"
            Url = new Uri ("http://localhost:23741/LICENSE.txt")
        }
    });
    /*var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);*/
});

// http://docs.asp.net/en/latest/security/cors.html
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
        //.AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c => {
        c.RouteTemplate = "ChedzaApp Api v1/swagger/{documentName}/swagger.json";
    });
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/ChedzaApp Api v1/swagger/v1/swagger.json", "ChedzaApp Api v1");
    });
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseStaticFiles();
app.UseCors("AllowAll");      
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
