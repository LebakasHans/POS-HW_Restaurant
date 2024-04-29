using System;
using System.Collections.Generic;

namespace RestaurantsDb;

public partial class Table
{
    public int Id { get; set; }

    public int Nr { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
