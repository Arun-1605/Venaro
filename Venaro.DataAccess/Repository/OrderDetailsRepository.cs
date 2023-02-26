using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venaro.Data;
using Venaro.DataAccess.Repository;
using Venaro.DataAccess.Repository.IRepository;
using Venaro.Models;

namespace Venaro.DataAccess.Repository
{
		public class OrderDetailsRepository : Repository<OrderDetail>, IOrderDetailsRepository
	{
			private ApplicationDbContext _db;

			public OrderDetailsRepository(ApplicationDbContext db) : base(db)
			{
				_db = db;
			}


			public void Update(OrderDetail obj)
			{
				_db.OrderDetail.Update(obj);
			}

		
	}
}
