namespace Core;

public static class Extensions
{
    private static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
    {
        return k == 0
            ? new[] { new T[0] }
            : elements.SelectMany((e, i) =>
                elements.Skip(i + 1).Combinations(k - 1).Select(c => (new[] { e }).Concat(c)));
    }


    public static List<List<float>> GetSolutions(List<List<float>> list, int n = 26)
    {
        // n = 26 => 8 + 8 + 10, 9 + 9 + 8

        // size = 8 => [3]-[42]
        // size = 9 => [43] - [344]
        // size = 10 => [345] - [402]

        var list8 = list.Take(new Range(3, 42)).ToList();
        var list9 = list.Take(new Range(43, 344)).ToList();
        var list10 = list.Take(new Range(345, 402)).ToList();

        // var intersection8_10 = GetDiffers(GetDiffers(list8, list8), list10);
        // var solutions8_10 = GetSolutionsByDiffers(intersection8_10);
        
        var intersection8_9 = GetDiffers(GetDiffers(list9, list9), list8);


        return new List<List<float>>();
    }

    private static List<List<float>> GetSolutionsByDiffers(List<List<float>> differs)
    {
        var result = new List<List<float>>();
        for (int i = 0; i < differs.Count; i++)
        {
            for (int j = 0; j < differs.Count - 1; j++)
            {
                if (IsDiffer(differs[j], differs[j + 1]))
                {
                    if (!result.Contains(differs[j]))
                        result.Add(differs[j]);
                    if (!result.Contains(differs[j+1]))
                        result.Add(differs[j+1]);
                }
            }
        }

        return result;
    }

    private static bool IsDiffer(List<float> list1, List<float> list2)
    {
        foreach (var l1 in list1)
        foreach (var l2 in list2)
            if (l1 == l2)
                return false;
        return true;
    }

    private static List<List<float>> GetDiffers(List<List<float>> list8, List<List<float>> list9)
    {
        var result = new List<List<float>>();

        foreach (var l8 in list8)
        {
            foreach (var l9 in list9)
            {
                if (IsDiffer(l8, l9))
                {
                    if (!result.Contains(l8))
                        result.Add(l8);
                    if (!result.Contains(l9))
                        result.Add(l9);
                }
            }
        }

        return result;
    }

    /// <summary>
    /// array SHOULD BE SORTED! Very slow algo!
    /// </summary>
    public static List<List<float>> GetSequencesWithSumOfLength(IEnumerable<float> array, float sum, int length)
    {
        var result = new List<List<float>>();
        int size = length;

        var temp = Combinations(array, size);

        foreach (var t in temp)
        {
            if (t.Sum() == sum)
                result.Add(t.ToList());
        }

        return result;
    }
}