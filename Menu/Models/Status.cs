using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Menu.Models
{
	public class Status
	{
		[Key]
		public byte Id { get; set; }

		[Column(TypeName="char")]
		public string Description { get; set; } = "";

	}
}

