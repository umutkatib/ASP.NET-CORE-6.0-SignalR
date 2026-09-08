using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfOrderDal : GenericRepository<Order>, IOrderDal
	{
		public EfOrderDal(SignalRContext context) : base(context)
		{
		}

		public decimal LastOrderPrice()
		{
			using var context = new SignalRContext();
			var value = context.Orders.OrderByDescending(x => x.OrderID).Take(1).Select(y => y.OrderTotalPrice).FirstOrDefault();
			return value;
		}

		public int TotalActiveOrderCount()
		{
			using var context = new SignalRContext();
			var value = context.Orders.Where(x => x.OrderDescription == "Müşteri Masada").Count();
			return value;
		}

		public int TotalOrderCount()
		{
			using var context = new SignalRContext();
			var value = context.Orders.Count();
			return value;
		}

	}
}
