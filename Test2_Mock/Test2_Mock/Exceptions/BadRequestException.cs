namespace Test2_Mock.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException()
    {
    }

    public BadRequestException(string? message) : base(message)
    {
    }
}