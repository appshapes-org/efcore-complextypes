using System.Collections;

namespace Tests;

public class IsRunningInContainerCommand
{
    private static IDictionary _environment = Environment.GetEnvironmentVariables();

    public virtual bool Execute()
    {
        return _environment.Contains("DOTNET_RUNNING_IN_CONTAINER") &&
               bool.TryParse(_environment["DOTNET_RUNNING_IN_CONTAINER"] as string, out bool result) && result;
    }
}