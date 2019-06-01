using UnityEngine;
using UnityEngine.UI;

public class dateButtonHandler : MonoBehaviour
{
    [SerializeField] private Sprite redCircle;
    [SerializeField] private Sprite none;
    [SerializeField] private Button dateButton;
    [SerializeField] private GameObject calendarPanel;
    [SerializeField] private Text textField;

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

        // right now, this is the same result for all buttons
        foreach(Employee e in UserHandler.instance.finalizedEmployees)
        {
            // randomize shifts for the employees
            int newShiftStart = e.shift.RandomizeShiftStartTime(8, 13);
            int newShiftEnd = e.shift.RandomizeShiftEndTime(newShiftStart, 20);
            string newShift = e.shift.FormatShiftTime(newShiftStart, newShiftEnd);

            textField.text = textField.text + e.name + " - " + e.shift.shiftPosition + ": " + newShift + "\n";
        }
    }
}
