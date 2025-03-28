using System.Runtime.ExceptionServices;

namespace Volo.ExtensionMethods;

public static class ExceptionExtensions
{
    public static void ReThrow(this Exception exception)
    {
        ExceptionDispatchInfo.Capture(exception).Throw();
    }      
}