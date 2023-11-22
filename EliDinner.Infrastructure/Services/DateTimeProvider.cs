using System;
using EliDinner.Application.Common.Interfaces.Services;

namespace EliDinner.Infrastructure.Services
{
	public class DateTimeProvider : IDateTimeProvider
	{

        public DateTime UtcNow => DateTime.UtcNow;
    }
}

