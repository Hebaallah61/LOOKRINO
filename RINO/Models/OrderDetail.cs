namespace RINO.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int DeviceId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Device device { get; set; } = default!;
        public Order order { get; set; } = default!;
    }
}
