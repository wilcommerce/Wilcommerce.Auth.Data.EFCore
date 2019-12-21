# Wilcommerce.Auth.Data.EFCore
Contains an implementation of [Wilcommerce.Auth](https://github.com/wilcommerce/Wilcommerce.Auth) package using Entity Framework Core as persistence framework.

## Requirements
According to Entity Framework Core 3.1 requirements, this project is built using NETStandard 2.1 as Target Framework (See [https://docs.microsoft.com/it-it/ef/core/what-is-new/ef-core-3.0/breaking-changes#netstandard21](https://docs.microsoft.com/it-it/ef/core/what-is-new/ef-core-3.0/breaking-changes#netstandard21) for further informations).

This means it will not run on projects which target .NET Framework.

If you have some specific needs you can [open a issue on GitHub](https://github.com/wilcommerce/Wilcommerce.Auth.Data.EFCore/issues) or you can consider to [contribute to Wilcommerce](CONTRIBUTING.md).

## Installation
Nuget package available here

[https://www.nuget.org/packages/Wilcommerce.Auth.Data.EFCore](https://www.nuget.org/packages/Wilcommerce.Auth.Data.EFCore)

## Usage
Add the AuthContext class to your project.

For example in an ASP.NET Core project add this line to the ConfigureServices method in Startup.cs
```<C#>
services.AddDbContext<AuthContext>(options => // Specify your provider);
```

The AuthContext is injected in the read model component.

After the DbContext has been registered in the ServiceCollection, you need to add a migration using **donet** CLI or the **Package Manager Console**.
```
// Using dotnet CLI
dotnet ef migrations add -c Wilcommerce.Auth.Data.EFCore.AuthContext Initial

// Using Package Manager Console
EntityFrameworkCore\Add-Migration -Context Wilcommerce.Auth.Data.EFCore.AuthContext Initial
```

After this, you can update your database:
```
// Using dotnet CLI
dotnet ef database update -c Wilcommerce.Auth.Data.EFCore.AuthContext

// Using Package Manager Console
EntityFrameworkCore\Update-Database -Context Wilcommerce.Auth.Data.EFCore.AuthContext
```

## Read model Component
The AuthDatabase class is the implementation of the [IAuthDatabase](https://github.com/wilcommerce/Wilcommerce.Auth/blob/develop/src/Wilcommerce.Auth/ReadModels/IAuthDatabase.cs) interface.

It provides a facade to access all the readonly data.
It requires an instance of AuthContext as constructor parameter.