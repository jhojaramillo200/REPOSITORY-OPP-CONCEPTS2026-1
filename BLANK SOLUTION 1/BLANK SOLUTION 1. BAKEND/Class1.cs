using System.ComponentModel.DataAnnotations;

namespace BLANK_SOLUTION_1._BAKEND;

public class Time // atrivutos
{
    private int _hour;
    private int _minute;
    private int _second;
    private int _millisecond;
    // constructores
    public Time()
    {
        _hour = 0;
        _millisecond = 0;
        _minute = 0;
        _second = 0;

    }


    public Time(int hour)
    {
        Hour = hour;
    }

    public Time(int hour, int minute)
    {
        Hour = hour;
        Minute = minute;
    }

    public Time(int hour, int minute, int second)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
    }

    public Time(int hour, int minute, int second, int millisecond)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = millisecond;
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
    // metodos 1
    public int ToMilliseconds()
    {
        if (ValidHour(Hour) < 0 || ValidHour(Hour) > 23) return 0;
        if (ValidMinute(Minute) < 0 || ValidMinute(Minute) > 59) return 0;
        if (ValidSecond(Second) < 0 || ValidSecond(Second) > 59) return 0;
        if (ValidMillisecond(Millisecond) < 0 || ValidMillisecond(Millisecond) > 999) return 0;

        return (Hour * 3600000) +
               (Minute * 60000) +
               (Second * 1000) +
                Millisecond;
    }

    public int ToMinutes()
    {
        if (ValidHour(Hour) < 0 || ValidHour(Hour) > 23) return 0;
        if (ValidMinute(Minute) < 0 || ValidMinute(Minute) > 59) return 0;
        if (ValidSecond(Second) < 0 || ValidSecond(Second) > 59) return 0;
        if (ValidMillisecond(Millisecond) < 0 || ValidMillisecond(Millisecond) > 999) return 0;

        return (Hour * 60) +
               Minute +
               (Second / 60) +
               (Millisecond / 60000);
    }

    public int ToSeconds()
    {
        if (ValidHour(Hour) < 0 || ValidHour(Hour) > 23) return 0;
        if (ValidMinute(Minute) < 0 || ValidMinute(Minute) > 59) return 0;
        if (ValidSecond(Second) < 0 || ValidSecond(Second) > 59) return 0;
        if (ValidMillisecond(Millisecond) < 0 || ValidMillisecond(Millisecond) > 999) return 0;

        return (Hour * 3600) +
               (Minute * 60) +
               Second +
               (Millisecond / 1000);
    }

    public override string ToString()
    {
        if (ValidHour(Hour) < 0 || ValidHour(Hour) > 23)
            if (ValidMinute(Minute) < 0 || ValidMinute(Minute) > 59)
                if (ValidSecond(Second) < 0 || ValidSecond(Second) > 59)
                    if (ValidMillisecond(Millisecond) < 0 || ValidMillisecond(Millisecond) > 999)

                    {
                        throw new ArgumentOutOfRangeException("Invalid time");
                    }


        int h12 = Hour % 12;
        if (h12 == 0) h12 = 12;
        {
            string period = Hour < 12 ? "AM" : "PM";

            return $"{h12:00}:{Minute:00}:{Second:00}.{Millisecond:000} {period}";
        }
    }

    public bool IsOtherDay(Time other)
    {
        int totalMs = this.ToMilliseconds() + other.ToMilliseconds();
        return totalMs >= 24 * 3600000;
    }

    public Time Add(Time other)
    {
        int totalMs = this.ToMilliseconds() + other.ToMilliseconds();

        int diaMs = 24 * 3600000;
        totalMs = totalMs % diaMs;

        int h = (totalMs / 3600000);
        totalMs %= 3600000;

        int m = (totalMs / 60000);
        totalMs %= 60000;

        int s = (totalMs / 1000);
        int ms = (totalMs % 1000);

        return new Time(h, m, s, ms);
    }

    // Valides

    private int ValidHour(int hour)
    {
        if (hour < 0 || hour > 23)
        {
            throw new ArgumentOutOfRangeException(nameof(hour), $"The hour: {hour}, is not valid.");
        }
        return hour;
    }

    private int ValidMinute(int minute)
    {
        if (minute < 0 || minute > 59)
        {
            throw new ArgumentOutOfRangeException(nameof(minute), $"The minute: {minute},is not valid.");
        }
        return minute;
    }
    private int ValidSecond(int second)
    {
        if (second < 0 || second > 59)
        {
            throw new ArgumentOutOfRangeException(nameof(second), $"The second: {second}, is not valid.");
        }
        return second;
    }

    private int ValidMillisecond(int millisecond)
    {
        if (millisecond < 0 || millisecond > 999)
        {
            throw new ArgumentOutOfRangeException(nameof(millisecond), $"The millisecond: {millisecond},is not valid.");
        }
        return millisecond;
    }


}

