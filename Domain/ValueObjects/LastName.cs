using Domain.Errors;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects;

public sealed class LastName : ValueObject
{
    public const int MaxLength = 50;

    private LastName(string value) => Value = value;

    private LastName() 
    { 

    }
    

    public string Value { get; private set; }


    public static Result<LastName> Create(string lastName)
    {
        Result.Create(lastName)
        .Ensure(
            f => !string.IsNullOrWhiteSpace(f),
            DomainErrors.LastName.Empty)
        .Ensure(
            f => f.Length <= MaxLength,
            DomainErrors.LastName.TooLong)
        .Map(e => new LastName(e));

        return new LastName(lastName);

    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
