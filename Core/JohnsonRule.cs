namespace Core;

public class JohnsonRule
{
    public List<WorkCenter> WorkCenters { get; set; }
    public int TasksCount { get; set; }
    private List<int>? _schedule = null;


    // l - count of work centres, n - count of tasks
    public JohnsonRule(int l, int n, List<TimeFunciton> timeFuncs)
    {
        if (timeFuncs.Count != l)
            throw new Exception("Wrong condition!");

        var workCenters = new List<WorkCenter>();
        for (int i = 0; i < l; i++)
            workCenters.Add(new WorkCenter(timeFuncs[i]));

        TasksCount = n;
        WorkCenters = workCenters;
    }

    // TODO: выдавать всевозможные расписания?
    public List<int>? GetOptimalSchedule()
    {
        if (_schedule is not null) return _schedule;

        List<int>? schedule = null;

        switch (WorkCenters.Count) // TODO: make it dynamic
        {
            case 2:
                schedule = CalculateOptimalSchedule(WorkCenters.First(), WorkCenters.Last());
                break;

            case 3:
                // TODO: create valid plus function for Func<T,TResult>
                var A = new WorkCenter(WorkCenters[0].TimeFunction + WorkCenters[1].TimeFunction);
                var B = new WorkCenter(WorkCenters[1].TimeFunction + WorkCenters[2].TimeFunction);

                schedule = CalculateOptimalSchedule(A, B);

                break;
        }

        _schedule = schedule;
        return schedule;
    }

    private List<int> CalculateOptimalSchedule(WorkCenter A, WorkCenter B)
    {
        var schedule1 = new List<int>();
        var schedule2 = new List<int>();

        for (int i = 0; i < TasksCount; i++)
        {
            if (A.TimeFunction.Invoke(i) <= B.TimeFunction.Invoke(i))
                schedule1.Add(i);
            else schedule2.Add(i);
        }

        //todo: test
        schedule1.Sort((a, b) => A.TimeFunction.Invoke(a).CompareTo(A.TimeFunction.Invoke(b)));
        schedule2.Sort((a, b) => B.TimeFunction.Invoke(b).CompareTo(B.TimeFunction.Invoke(a)));

        schedule1.AddRange(schedule2);
        return schedule1;
    }
}