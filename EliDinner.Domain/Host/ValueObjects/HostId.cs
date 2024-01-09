using System;
using EliDinner.Domain.Common.Models;

namespace EliDinner.Domain.Host.ValueObjects
{
    public sealed class HostId : ValueObject
    {
        public Guid Value { get; }
        // private constructor so only we can initialize it.
        private HostId(Guid value)
        {
            Value = value;
        }

        //public statis method for initializing this property.
        //it creates a new menu id object.
        public static HostId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
        public static HostId Create(Guid id)
        {
            return new( Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

