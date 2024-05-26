namespace Project_ASP.NET_NinjaTurtles.Models
{
    public class DashboardViewModel
    {
        //för att kunna visa ordrar grupperade på datum
        public IList<IGrouping<DateTime, Order>> GroupedOrders { get; set; }
        public IList<OrderSummaryViewModel> OrderSummaryViewModels { get; set; }
        //för att kunna visa en lista av ordrar
        public IList <Order> Orders { get; set; }
        public IList<Product> Products { get; set; }
        public IList <IGrouping<string, Order>> MostPurchased { get; set; }
        public decimal OrderedAmount{ get; set; }
    }
}
