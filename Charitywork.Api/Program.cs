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
//services
builder.Services.AddScoped<IDbContext, DbContext>();
builder.Services.AddScoped<IRoleService,RoleService>();


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
