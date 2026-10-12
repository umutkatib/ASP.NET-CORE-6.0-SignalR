using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
	public interface IBookingService : IGenericService<Booking>
	{
		int TBookingCount();
		void TBookingStatusApproved(int id);
		void TBookingStatusCancelled(int id);
	}
}
