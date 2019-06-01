using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockHandler : MonoBehaviour
{
    [SerializeField] private Text dateTimeText;
    [SerializeField] private Text nameText;
    [SerializeField] private Text shiftText;
    [SerializeField] private Button clockInButton;
    [SerializeField] private Color clockInColor;
    [SerializeField] private Color clockOutColor;

    private DateTime dateTime;
    private User user;
    private bool clockedIn;

    private void Start()
    {
        dateTime = DateTime.Now;
        user = UserHandler.instance.user;

        dateTimeText.text = dateTime.ToShortTimeString();
        nameText.text = user.name + " " + user.lastName;
        shiftText.text = user.currentShift.FormatShiftTime(user.currentShift.shiftStartTime, user.currentShift.shiftEndTime);

        clockInButton.onClick.AddListener(() => ClockClick(clockInButton));
    }

    private void ClockClick(Button b)
    {
        if(!clockedIn)
        {
            b.GetComponent<Image>().color = clockOutColor;
            b.transform.GetChild(0).GetComponent<Text>().text = "Clock Out";
            clockedIn = true;
        }
        else
        {
            b.GetComponent<Image>().color = clockInColor;
            b.transform.GetChild(0).GetComponent<Text>().text = "Clock In";
            clockedIn = false;
        }
    }
}
