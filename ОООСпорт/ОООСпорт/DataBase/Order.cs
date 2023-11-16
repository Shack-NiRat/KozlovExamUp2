using System;
using System.Collections.Generic;

namespace ОООСпорт;

public partial class Order
{
    public int OrderId { get; set; }

    public string OrderComposition { get; set; } = null!;

    public DateTime OrderDate { get; set; }

    public DateTime OrderDeliveryDate { get; set; }

    public int OrderPickupPoint { get; set; }

    public string ClientName { get; set; } = null!;

    public string ClientSurname { get; set; } = null!;

    public string UserPatronymic { get; set; } = null!;

    public string Client { get; set; } = null!;

    public int CodeToGet { get; set; }

    public string OrderStatus { get; set; } = null!;

    public virtual PickupPoint OrderPickupPointNavigation { get; set; } = null!;
}
