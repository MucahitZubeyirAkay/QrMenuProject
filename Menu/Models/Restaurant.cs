using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Menu.Models
{
	public class Restaurant
	{
		public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; } = "";

		public int CompanyId { get; set; }

		public byte StatusId { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Phone { get; set; } = "";

        [Column(TypeName = "nvarchar(200)")]
        public string AdressDetails { get; set; } = "";

        [Column(TypeName = "char(5)")]
        public string PostalCode { get; set; } = "";

        [Column(TypeName = "smalldatetime")]
        public DateTime RegisterDate { get; set; }



		[ForeignKey(nameof(CompanyId))]
		public Company? Company { get; set; }

		[ForeignKey(nameof(StatusId))]
		public Status? Status { get; set; }

        public ICollection<UserRestaurant> UsersRestaurants { get; set; }
    }
}

