using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NotificationHandler : MonoBehaviour
{
    public void MessageClick()
    {
        SceneManager.LoadScene("MessageScene");
    }

    public void SwapClick()
    {
        SceneManager.LoadScene("SwapScene");
    }

    public void CalendarClick()
    {
        SceneManager.LoadScene("CalendarScene");
    }
}
