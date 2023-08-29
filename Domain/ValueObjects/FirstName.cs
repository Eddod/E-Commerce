using Domain.Errors;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects;

public sealed class FirstName : ValueObject
{
    private const int MaxLength = 100;

    private FirstName(string value) => Value = value;
    
    private FirstName() 
    { 

    }

    public string Value { get; private set; }

    public static Result<FirstName> Create(string firstName) =>
        Result.Create(firstName)
        .Ensure(
            f => !string.IsNullOrWhiteSpace(f),
            DomainErrors.FirstName.Empty)
        .Ensure(
            f => f.Length <= MaxLength,
            DomainErrors.FirstName.TooLong)
        .Map(e => new FirstName(e));


    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
