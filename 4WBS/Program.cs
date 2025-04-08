using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.OpenApi.Models;
    using Persistance;
    
    var builder = WebApplication.CreateBuilder(args);
    
    // Add services to the container.
    
    builder.Services.AddControllers();
    // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
    builder.Services.AddEndpointsApiExplorer();
    
    builder.Services.AddSwaggerGen(opt => 
        opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = "JWT Authorization header using the Bearer scheme",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        }));
    
    builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite("Data Source=./libDb.db;"));
    
    // If you don't have an AppIdentityDbContext, remove these lines
    // or replace with your actual identity context
    // builder.Services.AddDbContext<AppIdentityDbContext>(opt => opt.UseSqlite("Data Source=./users.db;"));
    
    builder.Services.AddAuthorization();
    builder.Services.AddScoped<ILibraryService, BddLibraryService>();
    
    var app = builder.Build();
    
    // Les using permettent de libérer la ressource quand on en a plus besoin (Try with ressource)
    // (Libérés une fois la BDD créée)
    using var service = app.Services.CreateScope();
    using var context = service.ServiceProvider.GetRequiredService<AppDbContext>();
    
    // Remove or replace with your actual identity context
    // using var identityContext = service.ServiceProvider.GetRequiredService<AppIdentityDbContext>();
    // identityContext.Database.EnsureCreated();
    
    context.Database.EnsureCreated();
    
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    
    app.UseHttpsRedirection();
    
    app.UseAuthorization();
    
    app.MapControllers();
    
    app.Run();