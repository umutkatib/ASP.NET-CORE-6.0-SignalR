using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Abstract
{
	public interface ITestimonialService : IGenericService<Testimonial>
	{
		void TChangeTestimonialStatusToFalse(int id);
		void TChangeTestimonialStatusToTrue(int id);
		List<Testimonial> TGetListStatusByTrue();

	}
}
