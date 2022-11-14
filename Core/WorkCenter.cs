namespace Core;

public class WorkCenter
{
    // задает время обработки j детали на данном станке
    public TimeFunciton TimeFunction { get; set; } 

    public WorkCenter(TimeFunciton timeFunciton)
    {
        TimeFunction = timeFunciton;
    }
}