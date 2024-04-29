using System;
using System.Collections.Generic;

namespace RestaurantsDb;

public partial class Good
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int GoodTypeId { get; set; }

    public double Price { get; set; }

    public int QuantityInStock { get; set; }

    public virtual GoodType GoodType { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
