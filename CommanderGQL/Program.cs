using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
                                        options.UseSqlServer(
                                            builder.Configuration.GetConnectionString("CommandConnectionString")));

builder.Services.AddAuthorization();
builder.Services.AddGraphQLServer().AddQueryType<Query>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapGraphQL("/graphql");

app.Run();