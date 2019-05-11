Azure Functions with Dependency Injection
=======================

This is a simple Azure Functions v2 application I created for myself to figure out how Dependency Injection works in Azure Functions applications.

I've kept the code as simple as possible so that the stuff that actually matters is more prominent, and not hidden behind a lot of boilerplate code that does not help with the actual subject, Dependency Injection.


Introduction
------------

[Dependency injection in Azure Functions](https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-dependency-injection) builds on the [dependency injection functionality in ASP.NET Core](https://docs.microsoft.com/en-gb/aspnet/core/fundamentals/dependency-injection). I suggest you scroll through those before digging deeper into this sample, if you're not that familiar with how dependency injection works in ASP.NET Core.


Steps to Enable Dependency Injection
------------------------

It is pretty straight-forward to leverage dependency injection in your functions applications. Below is a summary of the steps you need to take.

- Create a standard Azure Functions application (v2)
- Add a reference to the [Microsoft.Azure.Functions.Extensions](https://www.nuget.org/packages/Microsoft.Azure.Functions.Extensions/) Nuget package
- [Create a `Startup` class](https://docs.microsoft.com/en-us/azure/azure-functions/functions-dotnet-dependency-injection) with an assembly-level attribute that defines the startup class.
- Add your services in the `Configure` method of the `Startup` class.
- Create your function methods as **instance methods** in non-static classes.
- Add your services as parameters in the constructors on your function classes.


Instance methods in Azure Functions
-----------------------------------

The main enabler for dependency injection in Azure Functions is the support for instance methods as function methods. The dependency injection functionality in ASP.NET Core builds on injecting dependencies through constructors, which implies that you need to have class instances to leverage dependency injection.

Instance methods were introduced in [Azure Functions Runtime v2.0.12265](https://github.com/Azure/azure-functions-host/releases/tag/v2.0.12265).