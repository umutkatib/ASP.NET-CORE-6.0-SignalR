using SignalR.BusinessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete
{
	public class OrderDetailManager : IOrderDetailService
	{
		private readonly IOrderDetailService _orderDetailService;

		public OrderDetailManager(IOrderDetailService orderDetailService)
		{
			_orderDetailService = orderDetailService;
		}

		public void TAdd(OrderDetail entity)
		{
			_orderDetailService.TAdd(entity);
		}

		public void TDelete(OrderDetail entity)
		{
			_orderDetailService.TDelete(entity);
		}

		public OrderDetail TGetByID(int id)
		{
			return _orderDetailService.TGetByID(id);
		}

		public List<OrderDetail> TGetListAll()
		{
			return _orderDetailService.TGetListAll();
		}

		public void TUpdate(OrderDetail entity)
		{
			_orderDetailService.TUpdate(entity);
		}
	}
}
