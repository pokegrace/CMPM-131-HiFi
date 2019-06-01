using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapHandler : MonoBehaviour
{
    [SerializeField] private GameObject overlayPanel;
    [SerializeField] private GameObject toSwapPanel;
    [SerializeField] private GameObject shiftDesiredPanel;
    [SerializeField] private GameObject requestPrompt;
    [SerializeField] private GameObject cancelPrompt;
    [SerializeField] private Button requestButton;
    [SerializeField] private Button cancelButton;

    private bool overlayActive;
    private bool requestPromptActive;
    private bool cancelPromptActive;

    private User user;

    private void Start()
    {
        user = UserHandler.instance.user;

        PopulatePanels();

        requestButton.onClick.AddListener(() => ClickRequest());
        cancelButton.onClick.AddListener(() => ClickCancel());
    }

    private void PopulatePanels()
    {
        // populate panels
        if (UserHandler.instance.swapEmployee != null)
        {
            Employee e = UserHandler.instance.swapEmployee;
            shiftDesiredPanel.transform.GetChild(0).GetComponent<Text>().text = e.name;
            shiftDesiredPanel.transform.GetChild(1).GetComponent<Text>().text = e.shift.shiftPosition;
            shiftDesiredPanel.transform.GetChild(2).GetComponent<Text>().text = e.shift.FormatShiftTime(e.shift.shiftStartTime, e.shift.shiftEndTime);
        }
        toSwapPanel.transform.GetChild(0).GetComponent<Text>().text = user.name;
        toSwapPanel.transform.GetChild(1).GetComponent<Text>().text = user.currentShift.shiftPosition;
        toSwapPanel.transform.GetChild(2).GetComponent<Text>().text = user.currentShift.FormatShiftTime(user.currentShift.shiftStartTime, user.currentShift.shiftEndTime);
    }

    private void ClickRequest()
    {
        if (!requestPromptActive)
        {
            requestPrompt.SetActive(true);
            requestPromptActive = true;
        }

        requestPrompt.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() => SwapShift());
        requestPrompt.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => { requestPrompt.SetActive(false); requestPromptActive = false; });
    }

    private void ClickCancel()
    {
        if (!cancelPromptActive)
        {
            cancelPrompt.SetActive(true);
            cancelPromptActive = true;
        }

        cancelPrompt.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() => CancelRequest());
        cancelPrompt.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(() => { cancelPrompt.SetActive(false); cancelPromptActive = false; });
    }

    private void SwapShift()
    {
        Shift temp = UserHandler.instance.swapEmployee.shift;
        UserHandler.instance.swapEmployee.shift = user.currentShift;
        user.currentShift = temp;

        PopulatePanels();

        if (requestPromptActive)
        {
            requestPrompt.SetActive(false);
            requestPromptActive = false;
        }
    }

    // reset all values
    private void CancelRequest()
    {
        UserHandler.instance.swapEmployee = null;

        shiftDesiredPanel.transform.GetChild(0).GetComponent<Text>().text = "";
        shiftDesiredPanel.transform.GetChild(1).GetComponent<Text>().text = "";
        shiftDesiredPanel.transform.GetChild(2).GetComponent<Text>().text = "";

        toSwapPanel.transform.GetChild(0).GetComponent<Text>().text = "";
        toSwapPanel.transform.GetChild(1).GetComponent<Text>().text = "";
        toSwapPanel.transform.GetChild(2).GetComponent<Text>().text = "";

        if (cancelPromptActive)
        {
            cancelPrompt.SetActive(false);
            cancelPromptActive = false;
        }
    }

    public void SwapPanelClick()
    {
        if (overlayActive)
        {
            overlayPanel.SetActive(false);
            overlayActive = false;
        }
    }

    public void RequestPanelClick()
    {
        if(!overlayActive)
        {
            overlayPanel.SetActive(true);
            overlayActive = true;
        }
    }
}
