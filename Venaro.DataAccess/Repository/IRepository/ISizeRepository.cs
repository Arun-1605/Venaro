using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venaro.Models;

namespace Venaro.DataAccess.Repository.IRepository
{
	public interface ISizeRepository : IRepository<Size>
	{
		void Update(Size obj);
	}
}
