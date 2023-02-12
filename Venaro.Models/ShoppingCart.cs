using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Venaro.Models
{
	public class ShoppingCart
	{
		public Clothes Product { get; set; }

		[Range(1,1000,ErrorMessage ="Cannot Accept More than 1000 products")]
		public int Count { get; set; }
	}
}
