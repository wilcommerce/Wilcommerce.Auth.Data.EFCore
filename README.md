# Wilcommerce.Auth.Data.EFCore
Contains an implementation of [Wilcommerce.Auth](https://github.com/wilcommerce/Wilcommerce.Auth) package using Entity Framework Core as persistence framework.

## Installation
Nuget package available here

[https://www.nuget.org/packages/Wilcommerce.Auth.Data.EFCore](https://www.nuget.org/packages/Wilcommerce.Auth.Data.EFCore)

## Usage
Add the AuthContext class to your project.

For example in an ASP.NET Core project add this line to the ConfigureServices method in Startup.cs
```<C#>
services.AddDbContext<AuthContext>(options => // Specify your provider);
```

The AuthContext is injected in the read model component and the Repository implementation.

## Read model Component
The CatalogDatabase class is the implementation of the [IAuthDatabase](https://github.com/wilcommerce/Wilcommerce.Auth/blob/develop/src/Wilcommerce.Auth/ReadModels/IAuthDatabase.cs) interface.

It provides a facade to access all the readonly data.
It requires an instance of AuthContext as constructor parameters.

## Repository Component
The Repository class is the implementation of the [IRepository](https://github.com/wilcommerce/Wilcommerce.Auth/blob/develop/src/Wilcommerce.Auth/Repository/IRepository.cs) interface.

It provides all the methods useful for persist an Aggregate model. 
It requires a AuthContext instance as constructor parameter.