using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Menu.Models
{
	public class Food
	{
		public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; } = "";

		public float Price { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Description { get; set; } = "";


		public int CategoryId { get; set; }

		public int StatusId { get; set; }


        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }

        [ForeignKey(nameof(StatusId))]
        public Status? Status { get; set; }
	}
}

