using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venaro.Data;
using Venaro.DataAccess.Repository.IRepository;
using Venaro.Models;

namespace Venaro.DataAccess.Repository
{
		public class ColorRepository : Repository<Colors>, IColorRepository
		{
			private ApplicationDbContext _db;

			public ColorRepository(ApplicationDbContext db) : base(db)
			{
				_db = db;
			}


			public void Update(Colors obj)
			{
				_db.Colors.Update(obj);
			}
		}
}
