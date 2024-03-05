using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Menu.Models
{
	public class Category
	{
		public int Id { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string Name { get; set; } = "";

		public int RestaurantId { get; set; }

		public byte StatusId { get; set; }



		[ForeignKey(nameof(RestaurantId))]
		public Restaurant? Restaurant { get; set; }

        [ForeignKey(nameof(StatusId))]
        public Status? Status { get; set; }
	}
}

