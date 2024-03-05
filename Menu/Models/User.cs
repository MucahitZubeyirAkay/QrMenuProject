using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Menu.Models
{
	public class User
	{
		public int Id { get; set; }

		public int CompanyId { get; set; }

		public byte StatusId { get; set; }

		[Column(TypeName ="nvarchar(100)")]
		public string UserName { get; set; } = "";

        [Column(TypeName = "nvarchar(128)")]
        public string UserPassword { get; set; } = "";

        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; } = "";

        [Column(TypeName = "nvarchar(50)")]
        public string EMail { get; set; } = "";

        [Column(TypeName = "nvarchar(30)")]
        public string Phone { get; set; } = "";

        [Column(TypeName = "smalldatetime")]
        public DateTime RegisterDate { get; set; }



		[ForeignKey(nameof(CompanyId))]
		public Company? Company { get; set; }

		[ForeignKey(nameof(StatusId))]
		public Status? Status { get; set; }

		public ICollection<UserRestaurant> UsersRestaurants { get; set; }

		

	}
}	

