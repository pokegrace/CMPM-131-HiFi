using System.Collections.Generic;
using UnityEngine;

public class User
{
    public Shift currentShift;
    public string name;

    public User(string userName, string position)
    {
        name = userName;
        currentShift = new Shift(position);
    }
}