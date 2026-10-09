using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
	public interface ITestimonialDal : IGenericDal<Testimonial>
	{
		void ChangeTestimonialStatusToFalse(int id);
		void ChangeTestimonialStatusToTrue(int id);
		List<Testimonial> GetListStatusByTrue();
	}
}
