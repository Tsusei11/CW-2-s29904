namespace ContainerManager;

public class LContainer(float containerWeight, float height, float depth, float maxWeight, bool isHazardous) 
    : Container("L", containerWeight, height, depth, maxWeight), IHazardNotifier
{
    public bool IsHazardous { get; } = isHazardous;

    public override void Load(float weight)
    {
        var capacity = MaxWeight - LoadWeight;
        if (IsHazardous && capacity * 0.5 < weight || !IsHazardous && capacity * 0.9 < weight)
            Notify();
        else
            base.Load(weight);
    }

    public void Unload()
    {
        base.Unload(LoadWeight);
    }
    
    public void Notify()
    {
        Console.WriteLine($"Dangerous situation has occured with container {SerialNumber}");
    }

    public override string ToString()
    {
        var isHazardousText = IsHazardous ? "Yes" : "No";
        return $"{base.ToString()}\n" +
               $"Is load hazardous: {isHazardousText};";
    }
}