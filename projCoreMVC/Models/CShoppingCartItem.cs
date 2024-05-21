namespace projCoreMVC.Models
{
    public class CShoppingCartItem
    {
        public int roomID { get; set; }
        public decimal price { get; set; }
        public int count { get; set; }
        public TRoom? room { get; set; }
    }
}
