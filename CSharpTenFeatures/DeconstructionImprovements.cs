namespace CSharpTenFeatures;

internal static class DeconstructionImprovements
{
    internal static void DeconstructionImprovementsMain()
    {
        Car car = new("VAZ 2114", "Blue");

        // C# 9 - либо инициализация
        var (model, color) = car;
        
        // либо присваивание
        string model1 = string.Empty;
        string color1 = string.Empty;
        (model1, color1) = car;

        // C# 10 - можно и то и другое одновременно
        string model3 = string.Empty;
        (model3, var color3) = car;
    }
}

record Car(string Name, string Color);
