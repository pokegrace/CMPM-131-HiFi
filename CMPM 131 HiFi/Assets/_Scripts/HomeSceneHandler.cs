using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeSceneHandler : MonoBehaviour
{
    [SerializeField] private Button myShiftButton;
    [SerializeField] private GameObject shiftButton;
    [SerializeField] private GameObject upcomingShiftsRect;

    private void Start()
    {
        User user = UserHandler.instance.user;

        if(user.currentShift != null)
        {
            myShiftButton.transform.GetChild(0).GetComponent<Text>().text = "You - " + user.currentShift.shiftPosition + ": " + 
                user.currentShift.FormatShiftTime(user.currentShift.shiftStartTime, user.currentShift.shiftEndTime);
        }

        // display employee shifts as buttons
        foreach (Employee e in UserHandler.instance.finalizedEmployees)
        {
            GameObject newButton = Instantiate(shiftButton, upcomingShiftsRect.transform);
            newButton.transform.GetChild(0).GetComponent<Text>().text = e.name + " - " + e.shift.shiftPosition + ": " + 
                e.shift.FormatShiftTime(e.shift.shiftStartTime, e.shift.shiftEndTime);
            newButton.GetComponent<Button>().onClick.AddListener(() => { UserHandler.instance.swapEmployee = e; SceneManager.LoadScene("SwapScene"); });
        }
    }
}