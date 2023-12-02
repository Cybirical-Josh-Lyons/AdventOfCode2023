try 
{
    switch(args.Length) 
    {
        case 0:
            throw new Exception("Please provide a challenge to run. 1 - 25 (Usage: 'dotnet run 1' or 'dotnet run 1 2')");

        case 1:
            var className = $"Challenge{args[0]}";
            var objectType = Type.GetType(className);
            if(objectType != null) {
                dynamic instanceObject = Activator.CreateInstance(objectType) ?? throw new Exception("Unable to create class from provided argument.");
                try 
                {
                    instanceObject.HelpSantaPartOne();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Could not help Santa (part 1): {e.Message}");
                }
                try 
                {
                    instanceObject.HelpSantaPartTwo();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Could not help Santa (part 2): {e.Message}");
                }
            }
            break;

        case > 1:
            // If multiple arguments provided; loop through and output pretty-like
            break;

        default:
            throw new Exception("An unknown expection occurred, please retry");
    }
}
catch (Exception ex) 
{
    Console.WriteLine(ex.Message);
}
