using System;
using EliDinner.Domain.Common.Models;

namespace EliDinner.Domain.Menu.ValueObjects
{
    public sealed class MenuItemId : ValueObject
    {
        public Guid Value { get; }
        // private constructor so only we can initialize it.
        private MenuItemId(Guid value)
        {
            Value = value;
        }

        //public statis method for initializing this property.
        //it creates a new menu id object.
        public static MenuItemId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

