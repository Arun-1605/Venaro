using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venaro.Data;
using Venaro.DataAccess.Repository;
using Venaro.DataAccess.Repository.IRepository;
using Venaro.Models;

namespace Venaro.DataAccess
{
	public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
	{
		private ApplicationDbContext _db;

		public OrderHeaderRepository(ApplicationDbContext db) : base(db)

		{

			_db = db;

		}


		public void Update(OrderHeader obj)
		{
			_db.OrderHeaders.Update(obj);
		}

		public void UpdateStatus(int id, string OrderStatus, string? PaymentStatus = null)
		{
			var OrderfromDb = _db.OrderHeaders.FirstOrDefault(x => x.Id == id);
			{
				if (OrderfromDb != null)
				{
					OrderfromDb.OrderStatus = OrderStatus;
					if (PaymentStatus != null)
					{
						OrderfromDb.PaymentStatus = PaymentStatus;
					}

				}
			}
		}
	}

}