using System;
using System.Collections.Generic;

namespace ОООСпорт;

public partial class PickupPoint
{
    public int PickupPointId { get; set; }

    public string? PickupPointIndex { get; set; }

    public string? PickupPointSity { get; set; }

    public string? PickupPointStreet { get; set; }

    public string? PickupPointHouse { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
