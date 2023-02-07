using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venaro.Models
{
	public class Category
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }

		public DateTime CreatedDateTime { get; set; } = DateTime.Now;
	}
}
