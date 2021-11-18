namespace CSharpTenFeatures.StructChanges;

internal static class StructureExamples
{
    internal static void StructureExamplesMain()
    {
        DemoKeywordWithForStructure();
    }

    private static void DemoKeywordWithForStructure()
    {
        User myUser = new("Chris", 21);

        // теперь with доступен также для структур, как был в 9 для рекордов
        User otherUser = myUser with { Name = "David" };

        Console.WriteLine("otherUser.Name: " + otherUser.Name); // David
    }
}

public struct User
{
    // для полей и свойств структуры с С#10 можно добавлять инициализаторы
    public int _age = 18;
    public string Name { get; set; } = string.Empty;

    // теперь возможен пустой конструктор, но с обязательно 
    // инициализированными полями и/или свойствами
    public User()
    {

    }

    public User(string name, int age)
    {
        _age = age;
        Name = name;
    }
}

