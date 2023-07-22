using Microsoft.EntityFrameworkCore;
using RecipeApp_RecipeAPI;
using RecipeApp_RecipeAPI.Data;
using RecipeApp_RecipeAPI.Repository;
using RecipeApp_RecipeAPI.Repository.IRepository;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICookFollowerRespository, CookFollowerRespository>();
builder.Services.AddScoped<ICookRespository, CookRespository>();
builder.Services.AddScoped<ICookTimeRepository, CookTimeRepository>();
builder.Services.AddScoped<IDietRespository, DietRespository>();
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IReactionRepository, ReactionRepository>();
builder.Services.AddScoped<IRecipeIngredientRepository, RecipeIngredientRepository>();
builder.Services.AddScoped<IRecipeInstructionRespository, RecipeInstructionRespository>();
builder.Services.AddScoped<IRecipeReactionRepository, RecipeReactionRepository>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IRecipeReviewRespository, RecipeReviewRespository>();
builder.Services.AddScoped<IRecipeTypeRepository, RecipeTypeRepository>();
builder.Services.AddScoped<IUserRespository, UserRespository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();

builder.Services.AddAutoMapper(typeof(MappingConfig));

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpsRedirection(options =>
{
    options.RedirectStatusCode = (int)HttpStatusCode.TemporaryRedirect;
    options.HttpsPort = 5000;
});

var app = builder.Build();

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
