public delegate void Update();


/// <summary>
/// Publisher here.
/// </summary>
class UpdateStuff
{
    public event Update UpdateItemEvent;
    public event Update UpdateSaleEvent;
    public event Update UpdatePurchaseEvent;

    public void UpdateItem()
    {
        Console.WriteLine("Updated item.");
        UpdateItemEvent();
    }

    public void UpdateSale()
    {
        Console.WriteLine("Updated sale.");
        UpdateSaleEvent();
    }

    public void UpdatePurchase()
    {
        Console.WriteLine("Updated purchase.");
        UpdatePurchaseEvent();
    }
}

/// <summary>
/// Subscribers to the event here.
/// </summary>
class GetNotifications
{
    public void ItemUpdateNotification()
    {
        Console.WriteLine("Notification: the item has been updated.");
    }

    public void SaleUpdateNotification()
    {
        Console.WriteLine("Notification: the sale has been updated.");
    }

    public void PurchaseUpdateNotification()
    {
        Console.WriteLine("Notification: the purchase has been updated.");
    }
}

class Program
{
    static void Main()
    {
        UpdateStuff updateStuff = new UpdateStuff();
        GetNotifications getNotifications = new GetNotifications();

        // Subscribe to the event
        updateStuff.UpdateItemEvent += getNotifications.ItemUpdateNotification;
        updateStuff.UpdateSaleEvent += getNotifications.SaleUpdateNotification;
        updateStuff.UpdatePurchaseEvent += getNotifications.PurchaseUpdateNotification;

        // Trigger the event, notifying all subscribers
        updateStuff.UpdatePurchase();
    }
}
