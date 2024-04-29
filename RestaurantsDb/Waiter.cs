using System;
using System.Collections.Generic;

namespace RestaurantsDb;

public partial class Waiter
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Order> OrderWaiterAtOrders { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderWaiterAtPayments { get; set; } = new List<Order>();
}
