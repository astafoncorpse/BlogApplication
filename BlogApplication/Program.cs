using AutoMapper;
using BlogApplication.Data.Repositories.Interfaces;
using BlogApplication.Contracts.Models.Articles;
using BlogApplication.Contracts.Models.Comments;
using BlogApplication.Contracts.Models.Tegs;
using BlogApplication.Contracts.Models.Uesrs;
using BlogApplication.Contracts.Validation.ArticlesValidators;
using BlogApplication.Contracts.Validation.CommentValidators;
using BlogApplication.Contracts.Validation.TegValidators;
using BlogApplication.Contracts.Validation.UserValidators;
using BlogApplication.Data.Context;
using BlogApplication.Data.Repositories;
using BlogApplication.Logging.Logger;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ILogger = BlogApplication.Logger.Logger.ILogger;
using BlogApp.Data.Repositories.Interfaces;
using BlogApplication.Contracts.Models.Users;

var builder = WebApplication.CreateBuilder(args);

// ����������� ������ �����������
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BlogContext>(option => option.UseSqlServer(connectionString), ServiceLifetime.Singleton);
builder.Services.AddControllersWithViews();

// �������� ������
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// ����������� ������
builder.Services.AddSingleton<ILogger, Logger>();

// ����������� ������� ����������� ��� �������������� � ��
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<ITegRepository, TegRepository>();
builder.Services.AddSingleton<ICommentRepository, CommentRepository>();
builder.Services.AddSingleton<IArticleRepository, ArticleRepository>();

// ����������� ���������
builder.Services.AddScoped<IValidator<UserRequest>, AddUserRequestValidator>();
builder.Services.AddScoped<IValidator<EditUserRequest>, EditUserRequestValidator>();
builder.Services.AddScoped<IValidator<ArticlesReqest>, AddArticlesRequestValidator>();
builder.Services.AddScoped<IValidator<EditArticleRequest>, EditArticlesRequestValidator>();
builder.Services.AddScoped<IValidator<CommentRequest>, AddCommentReqestValidator>();
builder.Services.AddScoped<IValidator<EditCommentReqest>, EditCommentReqestValidator>();
builder.Services.AddScoped<IValidator<TegRequest>, AddTegRequestValidator>();
builder.Services.AddScoped<IValidator<EditTegRequest>, EditTegRequestValidator>();

// ��������� �������

builder.Services.AddEndpointsApiExplorer();

// ���� ������������ �� �������� ��������������, �� �������� �������
builder.Services.AddAuthentication(options => options.DefaultScheme = "Cookies")
    .AddCookie("Cookies", options =>
    {
        options.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
        {
            OnRedirectToLogin = redirectContext =>
            {
                redirectContext.HttpContext.Response.StatusCode = 401;
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddRazorPages(options => { options.RootDirectory = "/View/Pages"; });

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

// ��������� �������������� � �����������
app.UseAuthentication();
app.UseAuthorization();



app.MapRazorPages();

app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
