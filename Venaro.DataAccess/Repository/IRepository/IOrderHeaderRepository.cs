using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venaro.Models;

namespace Venaro.DataAccess.Repository.IRepository
{
	public interface IOrderHeaderRepository : IRepository<OrderHeader>
	{
		void Update(OrderHeader obj);

		void UpdateStatus(int id, string OrderStatus, string? PaymentStatus = null);

		void UpdateStipePayment(int id, string SessionId, string PaymentIntentId);
	}
}
