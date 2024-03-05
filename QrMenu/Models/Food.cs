using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QrMenu.Models
{
	public class Food
	{
		public int Id { get; set; }

		public byte StateId { get; set; }

		[StringLength(100, MinimumLength = 2)]
		[Column(TypeName ="nvarchar(100)")]
		public string Name { get; set; } = "";

		[Range(0,float.MaxValue)]
		public float Price { get; set; }

		[StringLength(200)]
		[Column(TypeName ="nvarchar(200)")]
		public string? Description { get; set; }

		[ForeignKey("StateId")]
		public State? State { get; set; }
	}
}