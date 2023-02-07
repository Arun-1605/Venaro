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
		public class CategoryRepository : Repository<Category>, ICategoryRepository
		{
			private ApplicationDbContext _db;

			public CategoryRepository(ApplicationDbContext db) : base(db)
			{
				_db = db;
			}


			public void Update(Category obj)
			{
				_db.Categories.Update(obj);
			}
		}
}
