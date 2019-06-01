using UnityEngine;
using UnityEngine.UI;

public class dateButtonHandler : MonoBehaviour
{
    [SerializeField] private Sprite redCircle;
    [SerializeField] private Sprite none;
    [SerializeField] private Button dateButton;
    [SerializeField] private GameObject calendarPanel;

    private Button lastClicked;

    private void Start()
    {
        PopulateCalendar(28, 62);
    }

    private void PopulateCalendar(int start, int end)
    {
        for(int i = start; i <= end; ++i)
        {
            if(i <= 30)
            {
                Button b = Instantiate(dateButton, calendarPanel.transform);
                b.onClick.AddListener(() => ClickDate(b));
                b.transform.GetChild(0).GetComponent<Text>().text = i.ToString();
            }
            else if(i > 30 && i < 62)
            {
                Button b = Instantiate(dateButton, calendarPanel.transform);
                b.onClick.AddListener(() => ClickDate(b));
                b.transform.GetChild(0).GetComponent<Text>().text = (i - 30).ToString();
                b.transform.GetChild(0).GetComponent<Text>().fontStyle = FontStyle.Bold;
            }
            else
            {
                Button b = Instantiate(dateButton, calendarPanel.transform);
                b.onClick.AddListener(() => ClickDate(b));
                b.transform.GetChild(0).GetComponent<Text>().text = (i - 61).ToString();
            }
        }
    }

    public void ClickDate(Button b)
    {
        if (lastClicked != null)
            lastClicked.GetComponent<Image>().sprite = none;

        b.GetComponent<Image>().sprite = redCircle;
        lastClicked = b;
    }
}
