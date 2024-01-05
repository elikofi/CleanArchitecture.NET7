using System;
using EliDinner.Domain.Common.Models;

namespace EliDinner.Domain.MenuReview.ValueObjects
{
    public sealed class MenuReviewId : ValueObject
    {
        public Guid Value { get; }
        // private constructor so only we can initialize it.
        private MenuReviewId(Guid value)
        {
            Value = value;
        }

        //public statis method for initializing this property.
        //it creates a new menu id object.
        public static MenuReviewId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

