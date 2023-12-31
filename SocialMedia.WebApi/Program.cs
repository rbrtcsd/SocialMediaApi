using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Data;
using SocialMedia.Data.Entities;
using SocialMedia.Services.Comments;
using SocialMedia.Services.Likes;
using SocialMedia.Services.Post;
using SocialMedia.Services.Replies;
using SocialMedia.Services.User;
// using SocialMedia.Services.Comments;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ICommentsService, CommentsService>();
builder.Services.AddScoped<IRepliesService, RepliesService>();
builder.Services.AddScoped<ILikesService, LikesService>();
builder.Services.AddHttpContextAccessor();


// Connection string and DbContext setup
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

// builder.Services.AddScoped<ICommentsService, CommentsService>();

builder.Services.AddDefaultIdentity<UserEntity>(options =>
{
    // Password configuration, optional
    options.Password.RequiredLength = 4;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
})

    .AddRoles<IdentityRole<int>>() // Enable Roles, optional
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
