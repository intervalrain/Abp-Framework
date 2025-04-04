namespace Volo.Abp.Abp;

public class AbpException : Exception
{
    public AbpException()
    {
    }

    public AbpException(string message)
        : base(message)
    {
    }

    public AbpException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}