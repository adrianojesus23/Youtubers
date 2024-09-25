
public class ISBN: IEquatable<ISBN>
{
    public string Value { get; private set; }

    public ISBN(string value)
    {
        if (!IsValidISBN(value))
            throw new ArgumentNullException("Invalid ISBN format", nameof(value));
        Value = value;
    }

    public static ISBN Create(string value)
    {
        return new ISBN(value);
    }
    private bool IsValidISBN(string isbn)
    {
        return !string.IsNullOrWhiteSpace(isbn) && isbn.Length == 13;
    }

    public bool Equals(ISBN? other)
    {
        return Value == other?.Value;
    }

    public override bool Equals(object? obj)
    {
        return obj is ISBN other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public override string ToString()
    {
        return Value;
    }
}