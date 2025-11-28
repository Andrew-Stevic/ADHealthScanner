using ADHealthScanner.Core.PowerShell;

Console.WriteLine("AD Health Scanner - PowerShell Test");
Console.WriteLine("====================================");
Console.WriteLine();

try
{
    // Create script loader and PowerShell runner
    var scriptLoader = new ScriptLoader();
    using var psRunner = new PowerShellRunner(scriptLoader);

    Console.WriteLine("PowerShell initialized successfully.");
    Console.WriteLine("Active Directory module imported.");
    Console.WriteLine();

    // Execute test script
    Console.WriteLine("Executing test script...");
    var results = psRunner.ExecuteScript("Get-ADHealthTest.ps1");

    Console.WriteLine($"Script returned {results.Count} result(s).");
    Console.WriteLine();

    // Display results
    foreach (var result in results)
    {
        Console.WriteLine("Results:");
        Console.WriteLine($"  Domain Name: {result.Properties["DomainName"]?.Value}");
        Console.WriteLine($"  Domain Mode: {result.Properties["DomainMode"]?.Value}");
        Console.WriteLine($"  Forest: {result.Properties["Forest"]?.Value}");
        Console.WriteLine($"  Status: {result.Properties["Status"]?.Value}");
        Console.WriteLine($"  Message: {result.Properties["Message"]?.Value}");
    }

    Console.WriteLine();
    Console.WriteLine("Test completed successfully!");
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Error: {ex.Message}");
    Console.ResetColor();
    return 1;
}

return 0;
