using System;
namespace Menu.Models
{
	public class UserRestaurant
	{
		public int UserId { get; set; }

		public int RestaurantId { get; set; }

		public User? User { get; set; }

		public Restaurant? Restaurant { get; set; }
	}
}

