namespace ContainerManager;

public class GContainer(float containerWeight, float height, float depth, float maxWeight, bool isHazardous) 
    : Container("G", containerWeight, height, depth, maxWeight), IHazardNotifier
{
    public bool IsHazardous { get; } = isHazardous;

    public void Unload()
    {
        base.Unload(LoadWeight*0.95f);
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