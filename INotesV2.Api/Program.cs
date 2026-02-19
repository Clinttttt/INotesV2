using Swashbuckle.AspNetCore.SwaggerGen;
using INotesV2.Infrastructure;
using INotesV2.Application;
using INotesV2.Api;

var builder = WebApplication.CreateBuilder(args);


builder.ConfigureAuthServices();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddApi();



var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseCors("AllowBlazor");

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
