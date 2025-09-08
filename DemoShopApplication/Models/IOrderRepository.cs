namespace DemoShopApplication.Models
{
    public interface IOrderRepository 
    {
        void CreateOrder(Order order);
    }
}
