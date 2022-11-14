namespace Core;

public class TimeFunciton
{
    public Dictionary<int, float> MapRule { get; set; }

    public TimeFunciton(int n, Func<int, float> func)
    {
        MapRule = new Dictionary<int, float>();
        for (int i = 0; i < n; i++)
            MapRule.Add(i, func(i));
    }

    public TimeFunciton(Dictionary<int, float> mapRule)
    {
        MapRule = mapRule;
    }

    public static TimeFunciton operator +(TimeFunciton func1, TimeFunciton func2)
    {
        if (func1.MapRule.Count != func2.MapRule.Count)
            throw new Exception("Cannot add");

        var newMapRule = new Dictionary<int, float>();
        for (int i = 0; i < func1.MapRule.Count; i++)
            newMapRule.Add(i, func1.MapRule[i] + func2.MapRule[i]);

        return new TimeFunciton(newMapRule);
    }

    public float Invoke(int i)
    {
        if (i >= MapRule.Count) throw new Exception("Cannot invoke");
        return MapRule[i];
    }
    // todo: override invoke
}