using Domain.Errors;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects;

public sealed class Password : ValueObject
{
    private const int MaxLength = 128;
    private const int MinLength = 5;
    private Password(string value)
    {
        Value = value;
    }

    private Password() 
    {
        
    }
    public string Value { get;  private set; }

    public static Result<Password> Create(string password) =>
        Result.Create(password)
        .Ensure(
            pw => pw.Length >= MinLength,
        DomainErrors.Password.TooLong)
        .Ensure(
            pw => pw.Length <= MaxLength,
            DomainErrors.Password.TooShort)
        .Map(pw => new Password(pw));
        

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
