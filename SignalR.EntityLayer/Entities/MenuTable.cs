namespace SignalR.EntityLayer.Entities
{
	public class MenuTable
	{
		public int MenuTableID { get; set; }
		public string MenuTableName { get; set; }
		public bool MenuTableStatus { get; set; }
		public List<Basket> Baskets { get; set; }

	}
}
