namespace Tests;

public class GetConnectionStringCommand
{
    public virtual string Execute()
    {
        return $"Server={GetConnectionHost()};Database=efcore-complextypes;Uid=root;Pwd=password";
    }

    protected virtual string GetConnectionHost()
    {
        return new IsRunningInContainerCommand().Execute() ? "database" : "localhost";
    }
}