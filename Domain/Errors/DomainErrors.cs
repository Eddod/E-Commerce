using Domain.Shared;

namespace Domain.Errors;

public static class DomainErrors
{
    public static class Customer
    {
        public static readonly Error EmailAlreadyInUse = new(
            "Member.EmailAlreadyInUse",
            "The specified email is already in use");

        public static readonly Func<Guid, Error> NotFound = id =>
        new Error(
            "Member.NotFound",
            $"The member with the identifier {id} was not found.");

        public static readonly Error InvalidCredentials = new(
            "Member.InvalidCredentials",
            "The provided credentials are invalid");

    }

    public static class FirstName
    {
        public static readonly Error Empty = new(
            "FirstName.Empty",
            "First name is empty");

        public static readonly Error TooLong = new(
            "FirstName.TooLong",
            "First name is too long");
    }
    public static class LastName
    {
        public static readonly Error Empty = new(
            "LastName.Empty",
            "Last name is empty");

        public static readonly Error TooLong = new(
            "LastName.TooLong",
            "Last name is too long");
    }

    public static class Email
    {
        public static readonly Error Empty = new(
            "Email.Empty",
            "Email is empty");

        public static readonly Error TooLong = new(
            "Email.TooLong",
            "Email is too long");

        public static readonly Error InvalidFormat = new(
            "Email.InvalidFormat",
            "Email format is invalid");
    }

    public static class Password
    {
        public static readonly Error Empty = new(
            "Password.Empty",
            "Password is empty");

        public static readonly Error TooLong = new(
            "Password.TooLong",
            "Password is too long");

        public static readonly Error TooShort = new(
            "Password.TooShort",
            "Password is too short");

        public static readonly Error InvalidCredentials = new(
            "Password.InvalidCredentials",
            "Password credentials are invalid");

    }
}
