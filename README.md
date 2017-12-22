# Wilcommerce.Auth.Data.EFCore
Contains an implementation of [Wilcommerce.Auth](https://github.com/wilcommerce/Wilcommerce.Auth) package using Entity Framework Core as persistence framework.

## Usage
Add the AuthContext class to your project.

For example in an ASP.NET Core project add this line to the ConfigureServices method in Startup.cs
```<C#>
services.AddDbContext<AuthContext>(options => // Specify your provider);
```