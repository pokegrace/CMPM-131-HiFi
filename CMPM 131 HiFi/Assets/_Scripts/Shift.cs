using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shift
{
    public int shiftStartTime;
    public int shiftEndTime;
    public int shiftDate;

    public bool shiftAccepted;

    public string shiftPosition;

    public Shift(string position)
    {
        shiftStartTime = RandomizeShiftStartTime(8, 13);
        shiftEndTime = RandomizeShiftEndTime(shiftStartTime, 20);
        shiftDate = RandomizeShiftDate(10, 31);
        shiftPosition = position;
        shiftAccepted = true;
    }

    private int RandomizeShiftStartTime(int min, int max)
    {
        int outTime;

        int r = Random.Range(min, max + 1);
        outTime = r;

        return outTime;
    }

    private int RandomizeShiftEndTime(int min, int max)
    {
        int outTime;

        int r = Random.Range(min + 3, max + 1);
        outTime = r;

        return outTime;
    }

    private int RandomizeShiftDate(int min, int max)
    {
        int outDate;

        int r = Random.Range(min, max + 1);
        outDate = r;

        return outDate;
    }

    public string FormatShiftTime()
    {
        string shiftTime = "";
        if (shiftStartTime <= 12)
        {
            shiftTime += shiftStartTime.ToString();
            if (shiftStartTime == 12)
                shiftTime += "p";
            else
                shiftTime += "a";
        }
        else
        {
            shiftTime += (shiftStartTime - 12).ToString();
            shiftTime += "p";
        }

        shiftTime += " - ";

        if (shiftEndTime <= 12)
        {
            shiftTime += shiftEndTime.ToString();
            if (shiftEndTime == 12)
                shiftTime += "p";
            else
                shiftTime += "a";
        }
        else
        {
            shiftTime += (shiftEndTime - 12).ToString();
            shiftTime += "p";
        }

        return shiftTime;
    }
}