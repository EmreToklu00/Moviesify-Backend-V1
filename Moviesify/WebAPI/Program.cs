using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IMovieService, MovieManager>();
builder.Services.AddScoped<IMovieDal, EfMovieDal>();

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();

builder.Services.AddScoped<IPublisherService, PublisherManager>();
builder.Services.AddScoped<IPublisherDal, EfPublisherDal>();

builder.Services.AddControllers();

//-------------Policy---------------
builder.Services.AddCors(options =>
{
    //Localhost must be change
    options.AddPolicy(name: "AllowOrigin", configurePolicy: builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader());
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
    SeedDatabase.Seed();

}

app.UseHttpsRedirection();

app.UseCors("AllowOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
