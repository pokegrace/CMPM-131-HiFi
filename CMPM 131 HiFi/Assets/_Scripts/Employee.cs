using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employee
{
    public string name;
    public Shift shift;

   public Employee(string emName, string position)
   {
        name = emName;
        shift = new Shift(position);
   }
}
