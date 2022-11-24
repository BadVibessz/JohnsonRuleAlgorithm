using System.Text.Json;
using System.Text.Json.Serialization;
using Core;

// var timeFucn1 = new TimeFunciton(new Dictionary<int, float>
// {
//     { 0, 16 }, { 1, 10 }, { 2, 8 }, { 3, 6 }, { 4, 12 }, { 5, 10 }, { 6, 14 }, { 7, 4 }
// });
//
// var timeFucn2 = new TimeFunciton(new Dictionary<int, float>
// {
//     { 0, 14 }, { 1, 8 }, { 2, 8 }, { 3, 10 }, { 4, 10 }, { 5, 12 }, { 6, 10 }, { 7, 6 }
// });
//
// var rule = new JohnsonRule(2, 8,new List<TimeFunciton>{timeFucn1,timeFucn2});
// var schedule = rule.GetOptimalSchedule(); // right


// var timeFucn1 = new TimeFunciton(new Dictionary<int, float>
// {
//     { 0, 20 }, { 1, 35 }, { 2, 118 }, { 3, 275 }, { 4, 314 }, { 5, 500 }, { 6, 501 }, { 7, 502 }
// });
//
// var timeFucn2 = new TimeFunciton(new Dictionary<int, float>
// {
//     { 0, 2 }, { 1, 15 }, { 2, 22 }, { 3, 333 }, { 4, 4009 }, { 5, 5020 }, { 6, 5021 }, { 7, 5082 }
// });
//
// var rule = new JohnsonRule(2, 8, new List<TimeFunciton> { timeFucn1, timeFucn2 });
// var schedule = rule.GetOptimalSchedule(); // right
// var timeFucn1 = new TimeFunciton(new Dictionary<int, float>
// {
//     { 0, 2 }, { 1, 6 }, { 2, 12 }, { 3, 14 }, { 4, 4 }
// });
//
// var timeFucn2 = new TimeFunciton(new Dictionary<int, float>
// {
//     { 0, 5 }, { 1, 11 }, { 2, 10 }, { 3, 11 }, { 4, 3 }
// });
//
// var rule = new JohnsonRule(2, 5, new List<TimeFunciton> { timeFucn1, timeFucn2 });
// var schedule = rule.GetOptimalSchedule(); // right

// print
// Console.Write("Optimal schedule: { ");
// int j = 0;
// foreach (var i in schedule)
// {
//     Console.Write(j == schedule.Count - 1 ? $"{i + 1} " : $"{i + 1}, ");
//     j++;
// }
//
// Console.Write("}");


//_________________________________________________________________________________________________
const int N = 18;
const int n = 26;
var func = new Func<int, float>(i => (i + N) * (n * N - i + 1));
var timeFucn = new TimeFunciton(n, func);

var list = new List<float>();
for (int i = 1; i <= 26; i++)
{
    list.Add(timeFucn.Invoke(i));
    //Console.WriteLine($"t_{i} = " + timeFucn.Invoke(i));
}

//Console.WriteLine($"sum: {list.Sum()}");




// for (int i = 7; i <= 10; i++)
// {
//     Console.WriteLine($"m = {i}");
//     var temp = Extensions.GetSequencesWithSumOfLength(list, 123864f, i);
//     dd.AddRange(temp);
//     foreach (var l in temp)
//     {
//         Console.Write("[");
//         foreach (var v in l)
//             Console.Write($"{timeFucn.GetArgument(v)}[{v}], ");
//
//
//         Console.Write("]");
//         Console.WriteLine();
//     }
// }

//var json = JsonSerializer.Serialize(dd);

//File.WriteAllText("matrix.json", json);

var matrix = JsonSerializer.Deserialize<List<List<float>>>(File.ReadAllText("matrix.json"));

var dd = new List<List<float>>()
{
    new List<float> { 8892, 9340, 9786, 10672, 13710, 15402, 17880, 18690,19492 },
    new List<float> { 10230, 11112, 11550, 11986, 12420, 14982, 16236, 17062,18286 },
    new List<float> { 12852, 13282, 14136, 14560, 15820, 16650, 17472, 19092},
};

foreach (var l in dd)
{
  
    Console.WriteLine($"m = {l.Count}, sum = {l.Sum()}");
    
        Console.Write("[");
        foreach (var v in l)
            Console.Write($"{timeFucn.GetArgument(v)}[{v}], ");
        Console.Write("]");
        Console.WriteLine();
    
}

//var solutions = Extensions.GetSolutions(matrix);