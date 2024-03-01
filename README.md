# Pokemon Store Backend :sunglasses:

The Pokemon Store Backend is used for the Pokemon Store App

## How to run it locally :rocket:

1. Clone this project
2. This project use **NET 6**, first install the [SDK](https://dotnet.microsoft.com/en-us/download) in your machine
3. Run `dotnet build && dotnet run --project PokemonStore.Backend.Api/PokemonStore.Backend.Api.csproj` inside the root folder for start
```bash
$ dotnet build && dotnet run --project PokemonStore.Backend.Api/PokemonStore.Backend.Api.csproj
```
4. Navigate to `http://localhost:5001/api/swagger`. The app will show the Swagger Documentation

## Technologies :scroll:

1. NET 6, for build the Open Web API
2. Entity Framework InMemory, for simulate a Database in your machine
3. MeadiatR, for manage the CQRS Pattern
4. FluentValidation, for validate the Command & Queries Inputs
5. xUnit and Moq, for Unit Testing

## References :mega:

- [NET 6 Clean Arquitecture Template](https://github.com/jasontaylordev/CleanArchitecture)
- [Custom the FluentValidation Outputs](https://code-maze.com/cqrs-mediatr-fluentvalidation/)
- [Clean Arquitecture explained in ASP.NET](https://www.c-sharpcorner.com/article/clean-architecture-in-asp-net-core-web-api/)
- [Pok�dex](https://pokemondb.net/pokedex/all)