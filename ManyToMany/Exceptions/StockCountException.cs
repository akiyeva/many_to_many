namespace ManyToMany.Exceptions;

public sealed class StockCountException : Exception
{
    public StockCountException(string message) : base(message)
    {
        
    }
}
