using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeSceneHandler : MonoBehaviour
{
    [SerializeField] private Button myShiftButton;
    [SerializeField] private GameObject shiftButton;
    [SerializeField] private GameObject upcomingShiftsRect;

    public List<string> employeeNames;
    public List<string> shiftPositions;

    private User user;
    private void Start()
    {
        user = new User("Helena", "Server");

        if(user.currentShift != null)
        {
            myShiftButton.transform.GetChild(0).GetComponent<Text>().text = "You - " + user.currentShift.shiftPosition + ": " + user.currentShift.FormatShiftTime();
        }

        GenerateRandomShifts(5);
    }

    private void GenerateRandomShifts(int numShifts)
    {
        Dictionary<string, string> employees = new Dictionary<string, string>();
        List<string> possibleEmployees = employeeNames;
        List<string> possibleShifts = shiftPositions;

        // generate employee names and positions for this shift
        for(int i = 0; i <= numShifts; ++i)
        {
            int r = Random.Range(0, possibleEmployees.Count);
            int r1 = Random.Range(0, possibleShifts.Count);
            employees.Add(possibleEmployees[r], possibleShifts[r1]);
            possibleEmployees.RemoveAt(r);
            possibleShifts.RemoveAt(r);
        }

        foreach(KeyValuePair<string, string> kvp in employees)
        {
            Employee e = new Employee(kvp.Key, kvp.Value);
            GameObject newButton = Instantiate(shiftButton, upcomingShiftsRect.transform);
            newButton.transform.GetChild(0).GetComponent<Text>().text = e.name + " - " + e.shift.shiftPosition + ": " + e.shift.FormatShiftTime();
        }
    }
}