using System.Diagnostics;
using Xunit;

namespace Tests;

public class ServiceFactAttribute : FactAttribute
{
    public ServiceFactAttribute()
    {
        if (ShouldSkip())
            Skip = "Must run in container";
    }

    protected virtual bool ShouldSkip()
    {
        return !Debugger.IsAttached && !new IsRunningInContainerCommand().Execute();
    }
}