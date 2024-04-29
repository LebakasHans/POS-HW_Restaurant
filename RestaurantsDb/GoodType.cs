using System;
using System.Collections.Generic;

namespace RestaurantsDb;

public partial class GoodType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsDrink { get; set; }

    public virtual ICollection<Good> Goods { get; set; } = new List<Good>();
}
