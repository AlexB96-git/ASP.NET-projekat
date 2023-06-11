using Application.Commands.Authors;
using Application.Commands.Books;
using Application.Commands.Genres;
using Application.Commands.Users;
using Application.Email;
using Application;
using Implementation.Commands.Authors;
using Implementation.Commands.Books;
using Implementation.Commands.Genres;
using Implementation.Commands.Users;
using Implementation.Email;
using Implementation.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;
using Api.Core;
using EFDataAccess;
using Implementation.Validators;
using Application.Commands.UseCases;
using Implementation.Commands.UseCases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IApplicationActor>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();

    var user = accessor.HttpContext.User;

    if (user.FindFirst("ActorData") == null)
    {
        var unauthorisedUser = new JwtActor
        {
            Id = 0,
            Identity = "Unauthorised actor",
            AllowedUseCases = new List<int> {  }
        };

        return unauthorisedUser;
    }

    var actorString = user.FindFirst("ActorData").Value;

    var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

    return actor;
});
builder.Services.AddTransient<UseCaseExecutor>();
builder.Services.AddTransient<IUseCaseLogger, SQLLogger>();
builder.Services.AddTransient<JwtManager>();
builder.Services.AddTransient<IEmailSender, SmtpEmailSender>();

builder.Services.AddTransient<DBKnjizaraContext>();

//ispod je za automapper

//builder.Services.AddAutoMapper(typeof(EfCreateBook).Assembly);
//builder.Services.AddAutoMapper(typeof(EfCreateAuthor).Assembly);
//builder.Services.AddAutoMapper(typeof(EfCreateGenre).Assembly);
//builder.Services.AddAutoMapper(typeof(EfCreateUser).Assembly);
builder.Services.AddAutoMapper(typeof(EfCreateUseCase).Assembly);

#region UseCase
builder.Services.AddTransient<IAddUseCaseCommand, EfCreateUseCase>();
#endregion

//#region Authors
//builder.Services.AddTransient<IAddAuthorCommand, EfCreateAuthor>();
//builder.Services.AddTransient<IDeleteAuthorCommand, EfDeleteAuthor>();
//builder.Services.AddTransient<IEditAuthorCommand, EfUpdateAuthor>();
//#endregion

//#region Genres
//builder.Services.AddTransient<IDeleteGenreCommand, EfDeleteGenre>();
//builder.Services.AddTransient<IAddGenreCommand, EfCreateGenre>();
//builder.Services.AddTransient<IEditGenreCommand, EfUpdateGenre>();
//#endregion

//#region Books
//builder.Services.AddTransient<IAddBookCommand, EfCreateBook>();
//builder.Services.AddTransient<IDeleteBookCommand, EfDeleteBook>();
//builder.Services.AddTransient<IEditBookCommand, EfUpdateBook>();
//#endregion

//#region Users
//builder.Services.AddTransient<IAddUserCommand, EfCreateUser>();
//builder.Services.AddTransient<IDeleteUserCommand, EfDeleteUser>();
//builder.Services.AddTransient<IEditUserCommand, EfUpdateUser>();
//#endregion

//#region Validators
//builder.Services.AddTransient<BookDTOValidator>();
//builder.Services.AddTransient<AuthorDTOValidator>();
//builder.Services.AddTransient<GenreDTOValidator>();
//builder.Services.AddTransient<UserDTOValidator>();
//builder.Services.AddTransient<LogDTOValidator>();
//builder.Services.AddTransient<RoleDTOValidator>();
//builder.Services.AddTransient<ShippingMethodDTOValidator>();
builder.Services.AddTransient<UseCaseDTOValidator>();
//builder.Services.AddTransient<OrderDTOValidator>();
//#endregion


builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = "asp_api",
        ValidateIssuer = true,
        ValidAudience = "Any",
        ValidateAudience = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();


app.UseRouting();
app.UseMiddleware<GlobalExceptionHandler>();

app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
