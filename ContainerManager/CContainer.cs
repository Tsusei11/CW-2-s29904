namespace ContainerManager;

public class CContainer(float containerWeight, float height, float depth, float maxWeight, string productType) 
    : Container("C", containerWeight, height, depth, maxWeight)
{
    private static readonly Dictionary<string, float> Temperatures = LoadTemperatures();
    public float ContainerTemperature { get; }= Temperatures.GetValueOrDefault(productType.ToLower());
    public string ProductType { get; } = productType;

    private static Dictionary<String, float> LoadTemperatures()
    {
        var temp = new Dictionary<string, float>();
        using (var reader = new StreamReader("../../../data/temperatures.txt"))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                var info = line.Split(' ');

                temp.Add(info[0].ToLower(), Convert.ToSingle(info[1]));
            }
        }
        return temp;
    }

    public void Load(float weight, string productType)
    {
        if (productType != ProductType)
            Console.WriteLine("Container can store only products of the same type");
        else 
            base.Load(weight);
    }

    public void Unload()
    {
        base.Unload(LoadWeight);
    }
    
    public override string ToString()
    {
        return $"{base.ToString()}\n" +
               $"Current container temperature: {ContainerTemperature};\n" +
               $"Container product type: {ProductType};";

    }
}