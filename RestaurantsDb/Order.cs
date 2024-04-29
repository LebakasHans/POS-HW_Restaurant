using System;
using System.Collections.Generic;

namespace RestaurantsDb;

public partial class Order
{
    public int Id { get; set; }

    public int WaiterAtOrderId { get; set; }

    public int? WaiterAtPaymentId { get; set; }

    public int TableId { get; set; }

    public int GoodId { get; set; }

    public int Quantity { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime? PaymentDate { get; set; }

    public virtual Good Good { get; set; } = null!;

    public virtual Table Table { get; set; } = null!;

    public virtual Waiter WaiterAtOrder { get; set; } = null!;

    public virtual Waiter? WaiterAtPayment { get; set; }
}
