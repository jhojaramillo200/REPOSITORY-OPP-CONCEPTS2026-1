using System.ComponentModel.DataAnnotations;

namespace BLANK_SOLUTION_1._BAKEND;

public class time // atrivutos
{
    private int _hour;
    private int _minute;
    private int _second;
    private int _millisecond;
    // constructores
    public time()
    {
        _hour = 23;
        _minute = 59;
        _second = 59;
        _millisecond = 999;
    }
    public time(int hour, int minute, int second, int millisecond)
    {
        _hour = hour;
        _minute = minute;
        _second = second;
        _millisecond = millisecond;

    }
    //propiedades
    public int Hour
    { 
        get => _hour;
        set => _hour = value;
    }
    public int Minute
    { 
        get => _minute;
        set => _minute = value;
    }
    public int Second
    { 
        get => _second;
        set => _second = value; 
    }
    public int Millisecond 
    {
        get => _millisecond;
        set => _millisecond = value;
    }

}
