using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserHandler : MonoBehaviour
{
    public static UserHandler instance = null;

    public User user;
    public List<string> employeeNames;
    public List<string> shiftPositions;
    public List<string> possibleEmployees;
    public List<string> possibleShifts;
    public List<Employee> finalizedEmployees;

    public Employee swapEmployee;

    private void Awake()
    {
        //Check if there is already an instance of UserHandler
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of UserHandler.
            Destroy(gameObject);

        //Set UserHandler to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        user = new User("Helena", "Smith", "Server");

        GenerateRandomShifts(5);
    }

    private void GenerateRandomShifts(int numShifts)
    {
        possibleEmployees = employeeNames;
        possibleShifts = shiftPositions;
        finalizedEmployees = new List<Employee>();

        // generate employee names and positions for this shift
        for (int i = 0; i <= numShifts; ++i)
        {
            int r = Random.Range(0, possibleEmployees.Count);
            int r1 = Random.Range(0, possibleShifts.Count);
            finalizedEmployees.Add(new Employee(possibleEmployees[r], possibleShifts[r1]));

            possibleEmployees.RemoveAt(r);
            possibleShifts.RemoveAt(r);
        }
    }
}
