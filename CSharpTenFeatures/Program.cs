// https://habr.com/ru/company/pvs-studio/blog/584490/ - человеческое описание
// https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10#improvements-of-structure-types - Майкрософт для гиков

int mode = 4;

switch (mode)
{
    case 1: CSharpTenFeatures.StructureExamples.StructureExamplesMain(); break;
    case 2: CSharpTenFeatures.RecordImprovementsExamples.RecordImprovementsExamples_RecordStruct(); break;
    case 3: CSharpTenFeatures.RecordImprovementsExamples.RecordImprovementsExamples_SealedToString(); break;
    case 4: CSharpTenFeatures.DeconstructionImprovements.DeconstructionImprovementsMain(); break;

    default: throw new KeyNotFoundException(nameof(mode));
}

#region интерполирование константных строк

// использование интерполирования строк с константами
const string constStrFirst = "FirstStr";
const string summaryConstStr = $"SecondStr {constStrFirst}";

#endregion

#region упрощенные шаблонные методы

//public record TestRec(string name, string surname);

//static string TakeFourSymbols(TestRec obj) => obj switch
//{
//    // старый способ:
//    //TestRec { name: {Length: > 4} } rec => rec.name.Substring(0,4),

//    // новый способ:
//    TestRec { name.Length: > 4 } rec => rec.name.Substring(0, 4),
//    TestRec rec => rec.name,
//};

#endregion