using System.ComponentModel.Design.Serialization;

public class DeliveryItem
{
    public string TrackingNumber{get; }
    public double Weight{get; }
    public DeliveryItem(string trackingNumber)
    {
        TrackingNumber = trackingNumber;
        Weight = weight;
    }
    public abstract double CalculateCost();
    public virtual void PrintInfo()
    {
        Console.WriteLine($"Tracking number: {TrackingNumber}, Weight: {Weight}");
    }

}
public class Letter : DeliveryItem
{
    public Letter(string trackingNumber, double weight) : base(trackingNumber, weight)
    {
        Console.ReadLine($"Tracking number: {TrackingNumber}, Weight: {Weight}");
    }
    public override CalculateCost()
    {
        base.CalculateCost();
        return 15+Weight*10;
    }
    
}

public class Parcel : DeliveryItem
{
    public string Dimensions {get; set;}
    public Parcel(string trackingNumber, double weight, string dimensions) : base(trackingNumber, weight)
    {
        Dimensions = dimensions;
    }
    public overridedouble CalculateCost()
    {
        return 50 + Weight*25;
    }
    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Dimensions: {Dimensions}");
    }
}

public class CargoContainer<T> where T : DeliveryItem
{
    private List<T> _items = new List<T>();
    public void AddItem(T item)
    {
        _items.Add(item);
        Console.WriteLine($"Added: {item.TrackingNumber}");
    }
    public double GetTotalCost()
    {
        double totalCost = 0;
        foreach (var item in _items)
        {
            totalCost += item.CalculateCost();
        }
        return totalCost;
    }
}

