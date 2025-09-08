namespace DemoShopApplication.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DemoShopPieDBContext _demoShopPieDBContext;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(DemoShopPieDBContext demoShopPieDBContext, IShoppingCart shoppingCart)
        {
            _demoShopPieDBContext = demoShopPieDBContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Pie.PieId,
                    Price = shoppingCartItem.Pie.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _demoShopPieDBContext.Orders.Add(order);

            _demoShopPieDBContext.SaveChanges();
        }
    }
}
