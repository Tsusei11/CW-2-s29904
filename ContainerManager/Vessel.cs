namespace ContainerManager;

public class Vessel(float maxSpeed, int maxContainerAmount, float maxWeight)
{
    public List<Container> Containers { get; } = [];
    public float MaxSpeed { get; } = maxSpeed;
    public int MaxContainerAmount { get; } = maxContainerAmount;
    public float MaxWeight { get; } = maxWeight;
    
    public void LoadContainer(Container container)
    {
        if (container.ContainerWeight + container.LoadWeight > MaxWeight - GetContainersWeight())
            throw new OverfillException("Container weight is greater than vessel capacity");
        
        Containers.Add(container);
        Console.WriteLine($"Added container to vessel");
    }

    public void LoadContainers(List<Container> containers)
    {
        if (containers.Sum(container => container.ContainerWeight + container.LoadWeight) > MaxWeight - GetContainersWeight())
            throw new OverfillException("Containers weight is greater than vessel capacity");
        
        Containers.AddRange(containers);
        Console.WriteLine($"Added containers to vessel");
    }

    public void UnloadContainer(Container container)
    {
        if (!Containers.Contains(container))
            Console.WriteLine("Container not found");
        else
        {
            Containers.Remove(container);
            Console.WriteLine($"Removed container {container.SerialNumber} from vessel");
        }
    }

    public void ReplaceContainer(string serialNumber, Container newContainer)
    {
        var toReplace = Containers.Find(container => container.SerialNumber == serialNumber);
        if (toReplace == null)
            Console.WriteLine("Container not found");
        else
        {
            Containers.Remove(toReplace);
            Containers.Add(newContainer);
            Console.WriteLine($"Replaced container {serialNumber} with new container {newContainer.SerialNumber}");
        }
    }

    public void TransferContainer(Container container, Vessel vessel)
    {
        if (!Containers.Contains(container))
            Console.WriteLine("Container not found");
        else
        {
            vessel.LoadContainer(container);
            Containers.Remove(container);
            Console.WriteLine($"Transferred container {container.SerialNumber} to another vessel");
        }
    }
    
    private float GetContainersWeight()
    {
        return Containers.Sum(container => container.ContainerWeight + container.LoadWeight);
    }

    public override string ToString()
    {
        return $"Vessel max speed: {MaxSpeed}, max container amount: {MaxContainerAmount}, max weight: {MaxWeight};\n" +
               $"Current capacity: {MaxWeight - GetContainersWeight()};\n" +
               $"Containers amount: {Containers.Count}, containers weight: {Containers.Sum(container => container.ContainerWeight)};\n";
    }
}