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
using Microsoft.OpenApi.Models;
using Application.Queries.UseCases;
using Implementation.Queries.UseCases;
using Implementation.Commands.ShippingMethods;
using Application.Commands.ShippingMethods;
using Application.Queries.ShippingMethods;
using Implementation.Queries.ShippingMethods;
using Implementation.Commands.Roles;
using Application.Commands.Roles;
using Application.Queries.Roles;
using Implementation.Queries.Roles;
using Application.Queries.Genres;
using Implementation.Queries.Genres;
using Application.Queries.Authors;
using Implementation.Queries.Authors;
using Application.Queries.Books;
using Implementation.Queries.Books;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "JWTToken_Auth_API",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IApplicationActor>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();

    var user = accessor.HttpContext.User;

    if (user.FindFirst("ActorData") == null)
    {
        var unauthorisedUser = new JwtActor
        {
            Id = 3,
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

builder.Services.AddAutoMapper(typeof(EfCreateBook).Assembly);
builder.Services.AddAutoMapper(typeof(EfCreateAuthor).Assembly);
builder.Services.AddAutoMapper(typeof(EfCreateGenre).Assembly);
//builder.Services.AddAutoMapper(typeof(EfCreateUser).Assembly);
builder.Services.AddAutoMapper(typeof(EfCreateUseCase).Assembly);
builder.Services.AddAutoMapper(typeof(EfCreateShippingMethod).Assembly);
builder.Services.AddAutoMapper(typeof(EfCreateRole).Assembly);

#region UseCase
builder.Services.AddTransient<IAddUseCaseCommand, EfCreateUseCase>();
builder.Services.AddTransient<IEditUseCaseCommand, EfUpdateUseCase>();
builder.Services.AddTransient<IDeleteUseCaseCommand, EfDeleteUseCase>();
builder.Services.AddTransient<IGetUseCaseQuery, EfGetUseCase>();
builder.Services.AddTransient<IGetUseCasesQuery, EfGetUseCases>();
#endregion

#region ShippingMethod
builder.Services.AddTransient<IAddShippingMethodCommand, EfCreateShippingMethod>();
builder.Services.AddTransient<IEditShippingMethodCommand, EfUpdateShippingMethod>();
builder.Services.AddTransient<IDeleteShippingMethodCommand, EfDeleteShippingMethod>();
builder.Services.AddTransient<IGetShippingMethodQuery, EfGetShippingMethod>();
builder.Services.AddTransient<IGetShippingMethodsQuery, EfGetShippingMethods>();
#endregion

#region Role
builder.Services.AddTransient<IAddRoleCommand, EfCreateRole>();
builder.Services.AddTransient<IEditRoleCommand, EfUpdateRole>();
builder.Services.AddTransient<IDeleteRoleCommand, EfDeleteRole>();
builder.Services.AddTransient<IGetRoleQuery, EfGetRole>();
builder.Services.AddTransient<IGetRolesQuery, EfGetRoles>();
#endregion

#region Authors
builder.Services.AddTransient<IAddAuthorCommand, EfCreateAuthor>();
builder.Services.AddTransient<IDeleteAuthorCommand, EfDeleteAuthor>();
builder.Services.AddTransient<IEditAuthorCommand, EfUpdateAuthor>();
builder.Services.AddTransient<IGetAuthorsQuery, EfGetAuthors>();
builder.Services.AddTransient<IGetAuthorQuery, EfGetAuthor>();
#endregion

#region Genres
builder.Services.AddTransient<IDeleteGenreCommand, EfDeleteGenre>();
builder.Services.AddTransient<IAddGenreCommand, EfCreateGenre>();
builder.Services.AddTransient<IEditGenreCommand, EfUpdateGenre>();
builder.Services.AddTransient<IGetGenresQuery, EfGetGenres>();
builder.Services.AddTransient<IGetGenreQuery, EfGetGenre>();
#endregion

#region Books
builder.Services.AddTransient<IAddBookCommand, EfCreateBook>();
builder.Services.AddTransient<IDeleteBookCommand, EfDeleteBook>();
builder.Services.AddTransient<IEditBookCommand, EfUpdateBook>();
builder.Services.AddTransient<IGetBookQuery, EfGetBook>();
builder.Services.AddTransient<IGetBooksQuery, EfGetBooks>();
#endregion

//#region Users
//builder.Services.AddTransient<IAddUserCommand, EfCreateUser>();
//builder.Services.AddTransient<IDeleteUserCommand, EfDeleteUser>();
//builder.Services.AddTransient<IEditUserCommand, EfUpdateUser>();
//#endregion

//#region Validators
builder.Services.AddTransient<BookDTOValidator>();
builder.Services.AddTransient<BookInsertDTOValidator>();
builder.Services.AddTransient<BookUpdateDTOValidator>();
builder.Services.AddTransient<AuthorDTOValidator>();
builder.Services.AddTransient<GenreDTOValidator>();
//builder.Services.AddTransient<UserDTOValidator>();
//builder.Services.AddTransient<LogDTOValidator>();
builder.Services.AddTransient<RoleDTOValidator>();
builder.Services.AddTransient<ShippingMethodDTOValidator>();
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
