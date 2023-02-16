using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venaro.Models.ViewModel
{
	public class ProductVM
	{
		public Product Products { get; set; }

		[ValidateNever]
		public IEnumerable<SelectListItem> Category { get; set; }

		[ValidateNever]
		public IEnumerable<SelectListItem> Size { get; set; }

		[ValidateNever]
		public IEnumerable<SelectListItem> Colors { get; set; }

	}
}
