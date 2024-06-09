namespace Test2_Mock.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException()
    {
    }

    public NotFoundException(string? message) : base(message)
    {
    }
}