using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace QrMenu.Models
{
	public class Category
	{
		public int Id { get; set; }

        public byte StateId { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string Name { get; set; } = "";


		[ForeignKey(nameof(StateId))]
		public State? State { get; set; }	
	}
}

