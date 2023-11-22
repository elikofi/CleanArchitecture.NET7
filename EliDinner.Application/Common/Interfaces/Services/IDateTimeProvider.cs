using System;
namespace EliDinner.Application.Common.Interfaces.Services
{
	public interface IDateTimeProvider
	{
		DateTime UtcNow { get; }
	}
}

