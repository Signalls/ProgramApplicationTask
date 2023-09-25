// See https://aka.ms/new-console-template for more information
using Backend;
using Backend.UI;
using Microsoft.Extensions.DependencyInjection;

// Dependency injection container
var serviceProvider = new ServiceCollection()
    .AddScoped<ITab1Interface, Tab1Interface>()
    .AddScoped<ITab2Interface, Tab2Interface>()
    .AddScoped<ITab3Interface, Tab3Interface>()
    .AddScoped<ITab4Interface, Tab4Interface>()

    .AddScoped<ApplicationInterface>()
    .BuildServiceProvider();

var applicationInterface = serviceProvider.GetRequiredService<ApplicationInterface>();

// Starting application
applicationInterface.StartProgram();






