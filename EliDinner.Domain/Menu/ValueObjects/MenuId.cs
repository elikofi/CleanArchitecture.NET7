using System;
using EliDinner.Domain.Common.Models;

namespace EliDinner.Domain.Menu.ValueObjects
{
    public sealed class MenuId : ValueObject
    {
        public Guid Value { get; }
        // private constructor so only we can initialize it.
        private MenuId(Guid value)
        {
            Value = value;
        }

        //public statis method for initializing this property.
        //it creates a new menu id object.
        public static MenuId CreateUnique()
        {
            return new MenuId(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static MenuId Create(Guid value)
        {
            return new MenuId(value);
        }
    }
}

