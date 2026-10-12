using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
	public interface IBookingDal : IGenericDal<Booking>
	{
		int BookingCount();
		void BookingStatusApproved(int id);
		void BookingStatusCancelled(int id);
	}
}
