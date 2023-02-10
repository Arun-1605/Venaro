using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Venaro.Models
{
    public class Clothes
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [ValidateNever]
        public string Image { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

		public double ListPrice { get; set; }

		public bool IsSold { get; set; }


		/// <summary>
		/// Navigation Property
		/// </summary>
		/// 

		[ForeignKey("CategoryId")]
		public int CategoryId { get; set; }

		[ValidateNever]
		public Category Category { get; set; }  


	}
}
