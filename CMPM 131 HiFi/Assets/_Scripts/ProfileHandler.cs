using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileHandler : MonoBehaviour
{
    [SerializeField] private InputField firstNameField;
    [SerializeField] private InputField lastNameField;
    [SerializeField] private InputField emailField;
    [SerializeField] private InputField phoneField;
    [SerializeField] private InputField availabilityField;
    [SerializeField] private Text firstNameText;
    [SerializeField] private Text lastNameText;
    [SerializeField] private Text emailText;
    [SerializeField] private Text phoneText;
    [SerializeField] private Text availabilityText;
    [SerializeField] private Button editNamesButton;
    [SerializeField] private Button editContactButton;

    private bool nameFieldsActive;
    private bool contactFieldsActive;

    private void Start()
    {
        firstNameText.text = UserHandler.instance.user.name;
        lastNameText.text = UserHandler.instance.user.lastName;
        emailText.text = UserHandler.instance.user.email;
        phoneText.text = UserHandler.instance.user.phoneNumber;
        availabilityText.text = UserHandler.instance.user.availability;

        firstNameField.text = UserHandler.instance.user.name;
        lastNameField.text = UserHandler.instance.user.lastName;
        emailField.text = UserHandler.instance.user.email;
        phoneField.text = UserHandler.instance.user.phoneNumber;
        availabilityField.text = UserHandler.instance.user.availability;

        editNamesButton.onClick.AddListener(() => EditNamesClick(editNamesButton));
        editContactButton.onClick.AddListener(() => EditContactsClick(editContactButton));
    }

    private void EditNamesClick(Button b)
    {
        if(!nameFieldsActive)
        {
            firstNameField.gameObject.SetActive(true);
            lastNameField.gameObject.SetActive(true);
            nameFieldsActive = true;

            b.transform.GetChild(0).GetComponent<Text>().text = "Done";
        }
        else
        {
            UserHandler.instance.user.name = firstNameField.text;
            UserHandler.instance.user.lastName = lastNameField.text;
            firstNameText.text = firstNameField.text;
            lastNameText.text = lastNameField.text;

            firstNameField.gameObject.SetActive(false);
            lastNameField.gameObject.SetActive(false);
            nameFieldsActive = false;

            b.transform.GetChild(0).GetComponent<Text>().text = "Edit";
        }
    }

    private void EditContactsClick(Button b)
    {
        if (!contactFieldsActive)
        {
            emailField.gameObject.SetActive(true);
            phoneField.gameObject.SetActive(true);
            availabilityField.gameObject.SetActive(true);
            contactFieldsActive = true;

            b.transform.GetChild(0).GetComponent<Text>().text = "Done";
        }
        else
        {
            UserHandler.instance.user.email = emailField.text;
            UserHandler.instance.user.phoneNumber = phoneField.text;
            UserHandler.instance.user.availability = availabilityField.text;
            emailText.text = emailField.text;
            phoneText.text = phoneField.text;
            availabilityText.text = availabilityField.text;

            emailField.gameObject.SetActive(false);
            phoneField.gameObject.SetActive(false);
            availabilityField.gameObject.SetActive(false);
            contactFieldsActive = false;

            b.transform.GetChild(0).GetComponent<Text>().text = "Edit";
        }
    }
}
