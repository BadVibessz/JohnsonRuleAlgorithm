using Core;


// var x = new TimeFunciton(5, j => j + 1f);
// var y = new TimeFunciton(5, j => j + 2f);
// var z = x + y;
//
// Console.WriteLine(x.Invoke(0));
// Console.WriteLine(y.Invoke(0));
// Console.WriteLine(z.Invoke(0));


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

const int N = 18;
const int n = 26;
var func = new Func<int, float>(i => (i + N) * (n * N - i + 1)); // straight
//var func = new Func<int, float>(i => Math.Abs((i * N) * (n * (N-n+i*3) - i + 1))); // not straight


var timeFucn1 = new TimeFunciton(n, func);
var timeFucn2 = new TimeFunciton(n, func);
var timeFucn3 = new TimeFunciton(n, func);

var rule = new JohnsonRule(3, n, new List<TimeFunciton> { timeFucn1, timeFucn2, timeFucn3 });
var schedule = rule.GetOptimalSchedule(); // TODO: wrong?


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
Console.Write("Optimal schedule: { ");
foreach (var i in schedule)
    Console.Write(i == schedule.Count - 1 ? $"{i + 1} " : $"{i + 1}, ");
Console.Write("}");