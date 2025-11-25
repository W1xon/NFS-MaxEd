using NFSMaxEd.Models;

namespace NFSMaxEd.Extensions;

public static class ListExtensions
{
    public static void UpdateNames<T>(this IList<T> list, string baseName) where T : BaseEntity
    {
        var existingNumbers = list
            .Where(l => !string.IsNullOrWhiteSpace(l.Name) && l.Name.StartsWith(baseName))
            .Select(l =>
            {
                var digits = new string(l.Name.Skip(baseName.Length).ToArray());
                return int.TryParse(digits, out int n) ? n : 0;
            })
            .ToHashSet();

        int counter = 1;

        foreach (var item in list)
        {
            if (string.IsNullOrWhiteSpace(item.Name))
            {
                while (existingNumbers.Contains(counter))
                    counter++;

                item.Name = $"{baseName}{counter}";
                existingNumbers.Add(counter);
            }
        }

        var sorted = list.OrderBy(item => GetIndexFromName(item.Name)).ToList();

        for (int i = 0; i < sorted.Count; i++)
            list[i] = sorted[i];
    }
    private static int GetIndexFromName(string name)
    {
        var digits = new string(name.Reverse().TakeWhile(char.IsDigit).Reverse().ToArray());
        return int.TryParse(digits, out int val) ? val : -1;
    }
}