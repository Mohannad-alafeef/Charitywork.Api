using CharityWork.Core.Common;
using CharityWork.Core.Repository;
using CharityWork.Core.Services;
using CharityWork.Infra.Common;
using CharityWork.Infra.Repository;
using CharityWork.Infra.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options => {
	options.AddPolicy("policy", builder => {
		builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
	});
});
builder.Services.AddAuthentication(opt => {
	opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
	options.TokenValidationParameters = new TokenValidationParameters {
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("CharityWorkSuperSecretKey@345"))
	};
});

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
builder.Services.AddScoped<IIssuesReportRepository, IssuesReportRepository>();
builder.Services.AddScoped<ICharityRepository, CharityRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IGoalRepository, GoalRepository>();
builder.Services.AddScoped<IVisaCardRepository, VisaCardRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IEmailRepository, EmailRepository>();


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
builder.Services.AddScoped<IIssuesReportService, IssuesReportService>();
builder.Services.AddScoped<ICharityService, CharityService>();
builder.Services.AddScoped<IGoalService, GoalService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IVisaCardService, VisaCardService>();
builder.Services.AddScoped<IContactService,ContactService>();
builder.Services.AddScoped<IEmailService,EmailService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseCors("policy");

app.Run();

////