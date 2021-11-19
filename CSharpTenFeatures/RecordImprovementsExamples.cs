namespace CSharpTenFeatures;

#region record CLASS

// теперь при определении рекорда можно добавить class, чтобы уточнить, что это ref type
record class Test1(string Name, string Surname);
record Test2(string Name, string Surname);

#endregion

#region record STRUCT

// struct ничем не хуже class, поэтому можно ими модифицировать рекорды
record struct RecordStructTest(string Name, string Surname);
// это лишает автогенерируемые свойства рекорда дефолтовой имьютабильности
// string Name { get; set; } - "set;", а не "init";


internal static partial class RecordImprovementsExamples
{
    internal static void RecordImprovementsExamples_RecordStruct()
    {
        Demo_ComparisonRulesForRecordStructs();
        Demo_InternalBehaviorOfKeywordWithForRecordStructs();
    }

    /// <summary>
    /// При сравнении record struct действуют те же правила, что и для record, т.е. равенство по значению,
    /// а не ссылке, как у class. struct сам по себе при сравнении ведет себя как record.
    /// </summary>
    private static void Demo_ComparisonRulesForRecordStructs()
    {
        var firstRecord = new RecordStructTest("Nick", "Smith");
        var secondRecord = new RecordStructTest("Robert", "Smith");
        var thirdRecord = new RecordStructTest("Nick", "Smith");

        Console.WriteLine(firstRecord == secondRecord); // False
        Console.WriteLine(firstRecord == thirdRecord); // True
    }

    /// <summary>
    /// record struct при копировании с помощью with не определяет и не использует
    /// конструктор копирования, даже если он определен вручную, а использует обычное присваивание,
    /// действуя аналогично record class и struct
    /// 
    /// Если сделать эти поля приватными, то во всех случаях с with будет ошибка
    /// </summary>
    private static void Demo_InternalBehaviorOfKeywordWithForRecordStructs()
    {
        var recordClass1 = new Record_Class_WithCtorTest("n1", "s1");
        var recordClass2 = recordClass1 with { Name = "n2" };

        var recordStruct1 = new Record_Struct_WithCtorTest("n1", "s1");
        var recordStruct2 = recordStruct1 with { Name = "n2" };

        var Struct1 = new Struct_WithCtorTest("n1", "s1");
        var Struct2 = Struct1 with { Name = "n2" };
    }
}

record class Record_Class_WithCtorTest
{
    public string Name { get; set; }
    public string Surname { get; set; }

    // бряка упадет 1 раз - при создании первого объекта
    public Record_Class_WithCtorTest(string Name, string Surname)
    {
        this.Name = Name;
        this.Surname = Surname;
    }
}

record struct Record_Struct_WithCtorTest
{
    public string Name { get; set; }
    public string Surname { get; set; }

    // бряка упадет 1 раз - при создании первого объекта
    public Record_Struct_WithCtorTest(string Name, string Surname)
    {
        this.Name = Name;
        this.Surname = Surname;
    }
}

struct Struct_WithCtorTest
{
    public string Name { get; set; }
    public string Surname { get; set; }

    // бряка упадет 1 раз - при создании первого объекта
    public Struct_WithCtorTest(string Name, string Surname)
    {
        this.Name = Name;
        this.Surname = Surname;
    }
}

#endregion

#region sealed ToString() for record

internal static partial class RecordImprovementsExamples
{
    internal static void RecordImprovementsExamples_SealedToString()
    {
        // без sealed .ToString() в наследнике будет переопределен компилятором
        var baseRecordWithoutSealed = new BaseRecordWithoutSealed("Alex", "Black");
        var inheritedRecordWithoutSealed = new InheritedRecordWithoutSealed("Phill", "Jonhson");

        Console.WriteLine(baseRecordWithoutSealed); // Alex - Black
        Console.WriteLine(inheritedRecordWithoutSealed); // InheritedRecordWithoutSealed { Name = Phill, Surname = Jonhson }

        // с sealed .ToString() в наследнике будет унаследован, не переопределен
        var baseRecordWithSealed = new BaseRecordWithSealed("Alex", "Black");
        var inheritedRecordWithSealed = new InheritedRecordWithSealed("Phill", "Jonhson");

        Console.WriteLine(baseRecordWithSealed); // Alex - Black
        Console.WriteLine(inheritedRecordWithSealed); // Phill - Jonhson
    }
}

record BaseRecordWithoutSealed(string Name, string Surname)
{
    public override string ToString()
    {
        return $"{Name} - {Surname}";
    }
}

record InheritedRecordWithoutSealed : BaseRecordWithoutSealed
{
    public InheritedRecordWithoutSealed(string name, string surname)
        : base(name, surname)
    {

    }
}

record BaseRecordWithSealed(string Name, string Surname)
{
    public sealed override string ToString()
    {
        return $"{Name} - {Surname}";
    }
}

record InheritedRecordWithSealed : BaseRecordWithSealed
{
    public InheritedRecordWithSealed(string name, string surname)
        : base(name, surname)
    {

    }
}

#endregion