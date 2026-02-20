using Swashbuckle.AspNetCore.SwaggerGen;
using INotesV2.Infrastructure;
using INotesV2.Application;
using INotesV2.Api;
using INotesV2.Api.Extensions;
using INotesV2.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);


builder.ConfigureAuthServices();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddApi(builder.Configuration);



var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("AllowBlazor");

app.UseAuthentication();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
