using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;
using GeometryLibrary; // IShape, Square, Rectangle, Triangle

// Step 2: Feature flags in-memory (as in the brief)
var featureManagement = new Dictionary<string, string?>
{
    ["FeatureManagement:Square"]    = "true",
    ["FeatureManagement:Rectangle"] = "false", // flip to "true" to enable
    ["FeatureManagement:Triangle"]  = "true"
};

// Build configuration from the in-memory flags
IConfigurationRoot configuration = new ConfigurationBuilder()
    .AddInMemoryCollection(featureManagement)
    .Build();

// Step 3: DI + Feature Management
var services = new ServiceCollection();
services.AddFeatureManagement(configuration);
var serviceProvider = services.BuildServiceProvider();

// Step 4: Feature gating
var featureManager = serviceProvider.GetRequiredService<IFeatureManager>();

Console.WriteLine("=== GeometryApp ===");
Console.WriteLine("Type a shape name (Square / Rectangle / Triangle) or 'exit' to quit.");

bool squareOn    = await featureManager.IsEnabledAsync("Square");
bool rectangleOn = await featureManager.IsEnabledAsync("Rectangle");
bool triangleOn  = await featureManager.IsEnabledAsync("Triangle");

Console.Write("Enabled: ");
if (squareOn) Console.Write("Square ");
if (rectangleOn) Console.Write("Rectangle ");
if (triangleOn) Console.Write("Triangle ");
Console.WriteLine();

while (true)
{
    Console.Write("\nshape> ");
    var choice = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();
    if (choice is "exit" or "quit") break;
    if (string.IsNullOrWhiteSpace(choice)) continue;

    // Gate by feature flags
    if (choice == "square" && !squareOn)       { Console.WriteLine("Square is disabled."); continue; }
    if (choice == "rectangle" && !rectangleOn) { Console.WriteLine("Rectangle is disabled."); continue; }
    if (choice == "triangle" && !triangleOn)   { Console.WriteLine("Triangle is disabled."); continue; }

    try
    {
        IShape shape = choice switch
        {
            "square" => new Square(ReadDouble("Side: ")),
            "rectangle" => new Rectangle(ReadDouble("Width: "), ReadDouble("Height: ")),
            "triangle" => new Triangle(ReadDouble("Side A: "), ReadDouble("Side B: "), ReadDouble("Side C: ")),
            _ => throw new InvalidOperationException("Unknown shape")
        };

        Console.WriteLine($"Area: {shape.CalculateArea()}");
        Console.WriteLine($"Perimeter: {shape.CalculatePerimeter()}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

static double ReadDouble(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        var s = Console.ReadLine();
        if (double.TryParse(s, out var v) && v > 0) return v;
        Console.WriteLine("Please enter a positive number.");
    }
}
