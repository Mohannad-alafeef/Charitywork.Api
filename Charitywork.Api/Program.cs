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

builder.Services.AddScoped<IDbContext, DbContext>();
//repos
builder.Services.AddScoped<IRoleRepository,RoleRepository>();
builder.Services.AddScoped<ILoginRepository,LoginRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IAccountRepository,AccountRepository>();
builder.Services.AddScoped<ITestimonialRepository, TestimonialRepository>();
builder.Services.AddScoped<IHomePageRepository, HomePageRepository>();
builder.Services.AddScoped<IContactPageRepository, ContactPageRepository>();
builder.Services.AddScoped<IAboutPageRepository, AboutPageRepository>();
builder.Services.AddScoped<ITestimonialPageRepository,TestimonialPageRepository>();

builder.Services.AddScoped<ICharityRepository, CharityRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IGoalRepository, GoalRepository>();

//services
builder.Services.AddScoped<IRoleService,RoleService>();
builder.Services.AddScoped<ILoginService,LoginService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAccountService,AccountService>();
builder.Services.AddScoped<ITestimonialService, TestimonialService>();
builder.Services.AddScoped<IHomePageService, HomePageService>();
builder.Services.AddScoped<IContactPageService, ContactPageService>();
builder.Services.AddScoped<IAboutPageService, AboutPageService>();
builder.Services.AddScoped<ITestimonialPageService, TestimonialPageService>();
builder.Services.AddScoped<ICharityService, CharityService>();
builder.Services.AddScoped<IGoalService, GoalService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();


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

////