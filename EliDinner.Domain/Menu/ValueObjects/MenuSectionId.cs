using System;
using EliDinner.Domain.Common.Models;

namespace EliDinner.Domain.Menu.ValueObjects
{
    public sealed class MenuSectionId : ValueObject
    {
        public Guid Value { get; }
        // private constructor so only we can initialize it.
        private MenuSectionId(Guid value)
        {
            Value = value;
        }

        //public statis method for initializing this property.
        //it creates a new menu id object.
        public static MenuSectionId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
        public static MenuSectionId Create(Guid value)
        {
            return new MenuSectionId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

