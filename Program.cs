if(args[0] == "all") goto DoAll;

try 
{
    switch(args.Length) 
    {
        case 0:
            throw new Exception("Please provide a challenge to run. 1 - 25 (Usage: 'dotnet run 1' or 'dotnet run 1 2')");

        case 1:
            SantasHelper(args[0]);
            break;

        case > 1:
            foreach(var arg in args)
            {
                SantasHelper(arg);
            }
            break;

        default:
            throw new Exception("An unknown expection occurred, please retry");
    }
}
catch (Exception ex) 
{
    Console.WriteLine(ex.Message);
}

static void SantasHelper(string passedArgument) {
    if(!int.TryParse(passedArgument, out var challengeNumber))
        throw new Exception($"Invalid numeric argument passed: '{passedArgument}'. Please fix and retry.");
        
    var className = $"Challenge{challengeNumber}";
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
    else 
    {
        Console.WriteLine($"Challenge class not yet created for {passedArgument}");
    }
}

// We want to bypass previous stuff. Lets do some good ole' fashion 'goto' :)
DoAll:
    for(var i = 1; i < 26; i++)
        SantasHelper(i.ToString());