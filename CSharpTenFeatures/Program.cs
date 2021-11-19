// https://habr.com/ru/company/pvs-studio/blog/584490/ - человеческое описание
// https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10#improvements-of-structure-types - Майкрософт для гиков

int mode = 3;

switch (mode)
{
    case 1: CSharpTenFeatures.StructChanges.StructureExamples.StructureExamplesMain(); break;
    case 2: CSharpTenFeatures.RecordsChanges.RecordImprovementsExamples.RecordImprovementsExamples_RecordStruct(); break;
    case 3: CSharpTenFeatures.RecordsChanges.RecordImprovementsExamples.RecordImprovementsExamples_SealedToString(); break;

    default: throw new KeyNotFoundException(nameof(mode));
}

// использование интерполирования строк с константами
const string constStrFirst = "FirstStr";
const string summaryConstStr = $"SecondStr {constStrFirst}";