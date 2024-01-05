using System;
using EliDinner.Domain.Common.Models;
using EliDinner.Domain.Dinner.ValueObjects;
using EliDinner.Domain.Host.ValueObjects;
using EliDinner.Domain.Menu.Entities;
using EliDinner.Domain.Menu.ValueObjects;
using EliDinner.Domain.MenuReview.ValueObjects;

namespace EliDinner.Domain.Menu
{
	public sealed class Menu : AggregateRoot<MenuId>
	{
		private readonly List<MenuSection> _sections = new();
        private readonly List<DinnerId> _dinnerIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();

        public string Name { get; }

		public string Description { get; }

		public float AverageRating { get; }

        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

		public HostId HostId { get; }

		public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();

        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

		public DateTime CreatedDateTime { get; }

		public DateTime UpdatedDateTime { get; }



		private Menu(
			MenuId menuId,
			string name,
			string description,
			HostId hostId,
			DateTime createdDateTime,
			DateTime updatedDateTime)
			: base(menuId)
		{
			Name = name;
			Description = description;
			HostId = hostId;
			CreatedDateTime = createdDateTime;
			UpdatedDateTime = updatedDateTime;
		}

		public static Menu Create(
			string name,
			string description,
			HostId hostId)
		{
			return new(
				MenuId.CreateUnique(),
				name,
				description,
				hostId,
				DateTime.UtcNow,
				DateTime.UtcNow);
		}
    }
}

