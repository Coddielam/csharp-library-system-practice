using System.Text.Json.Serialization;
using Library.Applications;
using Library.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddScoped<IBookAppService, BookAppService>();
    builder.Services.AddScoped<IBorrowingAppService, BorrowingAppService>();
    builder.Services.AddScoped<IPatronAppService, PatronAppService>();
    builder.Services.AddDbContext<LibraryDbContext>(options =>
                options.UseSqlite("Data Source=./Library.db"));
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    // app.UseErrorHandlingMiddleware();
    app.UseHttpsRedirection();
    app.MapControllers();

    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<LibraryDbContext>();
        db.Database.Migrate();
    }

    app.Run();
}
