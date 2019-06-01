using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageHandler : MonoBehaviour
{
    [SerializeField] private Button[] messageButtons;
    [SerializeField] private Button addMessageButton;
    [SerializeField] private Button closePanelButton;
    [SerializeField] private Button closePanelButton1;
    [SerializeField] private Button sendButton;
    [SerializeField] private Button sendButton1;
    [SerializeField] private InputField replyField;
    [SerializeField] private InputField toField;
    [SerializeField] private InputField messageField;
    [SerializeField] private GameObject messagePanel;
    [SerializeField] private GameObject addMessagePanel;

    private bool messagePanelOpen;

    private void Start()
    {
        foreach(Button b in messageButtons)
        {
            b.onClick.AddListener(() => OpenMessagePanel(b));
        }

        closePanelButton.onClick.AddListener(() => { messagePanel.SetActive(false); messagePanelOpen = false; });
        closePanelButton1.onClick.AddListener(() => { addMessagePanel.SetActive(false); });
        sendButton.onClick.AddListener(() => SendMessage());
        sendButton1.onClick.AddListener(() => SendMessage());
        addMessageButton.onClick.AddListener(() => { addMessagePanel.SetActive(true); });
    }

    private void OpenMessagePanel(Button b)
    {
        if(!messagePanelOpen)
        {
            messagePanel.SetActive(true);
            messagePanelOpen = true;
        }

        messagePanel.transform.GetChild(0).GetComponent<Text>().text = b.transform.GetChild(0).GetComponent<Text>().text;
        messagePanel.transform.GetChild(1).GetComponent<Text>().text = b.transform.GetChild(1).GetComponent<Text>().text;
    }

    private void SendMessage()
    {
        messagePanel.SetActive(false);
        addMessagePanel.SetActive(false);
        messagePanelOpen = false;

        replyField.text = "";
        toField.text = "";
        messageField.text = "";
    }
}
