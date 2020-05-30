using System;
using System.Linq;
using AwesomeColours.DataAccess.Entities;

namespace AwesomeColours.Service.Extensions
{
    public static class PersonExtensions
    {
        public static bool IsFullNamePalindrome(this Person person)
        {
            var fullName = string.Concat(person.FirstName, person.LastName).ToLower();
            return fullName.SequenceEqual(fullName.Reverse());
        }
    }
}
