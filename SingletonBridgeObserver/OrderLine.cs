namespace SingletonBridgeObserver
{
    public class OrderLine
    {
        public OrderLine(string partNumber, int quantityOrdered, decimal unitPrice, decimal unitCost)
        {
            PartNumber = partNumber;
            QuantityOrdered = quantityOrdered;
            UnitPrice = unitPrice;
            UnitCost = unitCost;
        }

        public int Number { get; set; }
        public string PartNumber { get; set; }
        public int QuantityOrdered { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitCost { get; set; }
    }
}