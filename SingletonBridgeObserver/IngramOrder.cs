namespace SingletonBridgeObserver
{
    public class IngramOrder : Order
    {
        public IngramOrder(string shipVia, string warehouseName)
        {
            ShipVia = shipVia;
            WarehouseName = warehouseName;
        }

        public string ShipVia { get; set; }
        public string WarehouseName { get; set; }
    }
}