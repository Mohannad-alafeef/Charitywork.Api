using CharityWork.Core.Common;
using CharityWork.Core.Repository;
using CharityWork.Core.Services;
using CharityWork.Infra.Common;
using CharityWork.Infra.Repository;
using CharityWork.Infra.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//repos
builder.Services.AddScoped<IRoleRepository,RoleRepository>();
builder.Services.AddScoped<ILoginRepository,LoginRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//services
builder.Services.AddScoped<IDbContext, DbContext>();
builder.Services.AddScoped<IRoleService,RoleService>();
builder.Services.AddScoped<ILoginService,LoginService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
