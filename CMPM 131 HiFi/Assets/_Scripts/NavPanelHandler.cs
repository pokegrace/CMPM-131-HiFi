using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NavPanelHandler : MonoBehaviour
{
    [SerializeField] private Button homeButton;
    [SerializeField] private Button calendarButton;
    [SerializeField] private Button notifButton;
    [SerializeField] private Button clockButton;
    [SerializeField] private Button swapButton;
    [SerializeField] private Button messageButton;
    [SerializeField] private Button profileButton;

    private Button lastClicked;
    
    private void Start()
    {
        homeButton.onClick.AddListener(() => NavClicked("HomeScene", homeButton));
        calendarButton.onClick.AddListener(() => NavClicked("CalendarScene", calendarButton));
        notifButton.onClick.AddListener(() => NavClicked("NotificationScene", notifButton));
        clockButton.onClick.AddListener(() => NavClicked("ClockScene", clockButton));
        swapButton.onClick.AddListener(() => NavClicked("SwapScene", swapButton));
        messageButton.onClick.AddListener(() => NavClicked("MessageScene", messageButton));
        profileButton.onClick.AddListener(() => NavClicked("ProfileScene", profileButton));
    }

    private void NavClicked(string sceneName, Button b)
    {
        if (lastClicked != null)
            lastClicked.transform.localScale = new Vector3(1, 1, 1);

        SceneManager.LoadScene(sceneName);
        b.transform.localScale = new Vector3(1.2f, 1.2f, 1);
        lastClicked = b;
    }
}
