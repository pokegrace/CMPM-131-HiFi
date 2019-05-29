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
    
    private void Start()
    {
        homeButton.onClick.AddListener(() => SceneManager.LoadScene("HomeScene"));
        calendarButton.onClick.AddListener(() => SceneManager.LoadScene("CalendarScene"));
        notifButton.onClick.AddListener(() => SceneManager.LoadScene("NotificationScene"));
        clockButton.onClick.AddListener(() => SceneManager.LoadScene("ClockScene"));
        swapButton.onClick.AddListener(() => SceneManager.LoadScene("SwapScene"));
        messageButton.onClick.AddListener(() => SceneManager.LoadScene("MessageScene"));
        profileButton.onClick.AddListener(() => SceneManager.LoadScene("ProfileScene"));
    }
}
