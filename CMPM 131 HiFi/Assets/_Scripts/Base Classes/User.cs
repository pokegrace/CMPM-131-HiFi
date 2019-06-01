using System.Collections.Generic;
using UnityEngine;

public class User
{
    public Shift currentShift;
    public string name;
    public string lastName;
    public string email;
    public string phoneNumber;
    public string availability;

    public User(string userName, string userLastName, string position)
    {
        name = userName;
        lastName = userLastName;
        currentShift = new Shift(position);

        email = userName + "_" + userLastName + "@work.com";
        phoneNumber = "(555) 123 - 6789";
        availability = "MTWF : 8a - 8p";
    }
}