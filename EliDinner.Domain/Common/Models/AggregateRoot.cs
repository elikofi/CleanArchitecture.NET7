using System;
namespace EliDinner.Domain.Common.Models
{
    //AggregateRoot is a wrapper around the entity and we are calling the base class TId
    public class AggregateRoot<TId> : Entity<TId> 
        where TId : notnull
    {
        protected AggregateRoot(TId id) : base(id)
        {

        }
    }
}

