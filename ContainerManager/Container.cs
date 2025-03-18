namespace ContainerManager;

public abstract class Container
{
    public static List<Container> Containers { get; } = [];
    
    public float LoadWeight { get; protected set; }
    public float ContainerWeight { get; }
    public float Height { get; }
    public float Depth { get; }
    public string SerialNumber { get; }
    public float MaxWeight { get; }

    protected Container(string containerType, float containerWeight, float height, float depth, float maxWeight)
    {
        Containers.Add(this);
        ContainerWeight = containerWeight;
        Height = height;
        Depth = depth;
        SerialNumber = $"KON-{containerType}-{Containers.Count}";
        MaxWeight = maxWeight;
    }

    public virtual void Load(float weight)
    {
        if (MaxWeight - LoadWeight < weight)
            throw new OverfillException("Load weight is greater than container capacity");
        
        LoadWeight += weight;
        Console.WriteLine($"Loaded container {SerialNumber} on {weight}kg");
    }

    protected void Unload(float weight)
    {
        LoadWeight -= weight;
        Console.WriteLine($"Unloaded container {SerialNumber}");
    }

    public override string ToString()
    {
        return $"Container serial number: {SerialNumber};\n" +
               $"Container weight: {ContainerWeight};\n" +
               $"Container max weight: {MaxWeight};\n" +
               $"Container height: {Height};\n" +
               $"Container depth: {Depth};\n" +
               $"Current load weight: {LoadWeight};";
    }
}