namespace CSharpTenFeatures.RecordsChanges;

internal static class RecordImprovementsExamples
{
    internal static void RecordImprovementsExamplesMain()
    {
        DemoComparisonRulesForRecordStructs();
    }

    /// <summary>
    /// При сравнении record struct действуют те же правила, что и для record, т.е. равенство по значению,
    /// а не ссылке, как у class. struct сам по себе при сравнении ведет себя как record.
    /// </summary>
    private static void DemoComparisonRulesForRecordStructs()
    {
        var firstRecord = new RecordStructTest("Nick", "Smith");
        var secondRecord = new RecordStructTest("Robert", "Smith");
        var thirdRecord = new RecordStructTest("Nick", "Smith");

        Console.WriteLine(firstRecord == secondRecord); // False
        Console.WriteLine(firstRecord == thirdRecord); // True
    }
}


// теперь при определении рекорда можно добавить class, чтобы уточнить, что это ref type
record class Test1(string Name, string Surname);
record Test2(string Name, string Surname);


// структуры ничем не хуже, поэтому можно ими модифицировать рекорды
// это лишает автогенерируемы свойства рекорда дефолтовой имьютабильности
record struct RecordStructTest(string Name, string Surname);
// string Name { get; set; } - "set;", а не "init";
