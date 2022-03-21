using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Keyboard : MonoBehaviour
{
    // A list populated with the text components of the keyboard letters
    public List<Button> keyboardCharacterButtons = new List<Button>();

    // All characters in the keyboard, named from top row to bottom row
    private string characterNames = "AEIİOÖUÜBCDEFGĞHJKLMNPRSTYVYZ";

    // Start is called before the first frame update
    void Start()
    {
        SetupButtons();
    }

    void SetupButtons()
    {
        // Starting from the top row, set the text of the keyboard-texts to the ones in the list
        for (int i = 0; i < keyboardCharacterButtons.Count; i++)
        {
            // Here we use GetChild and then GetComponent, it's not the most efficient way performance wise.
            // For setting things up and one shots it is usually fine, but doing it every frame inside of
            // Update() for example is not good practice and might give you dips in performance. Just a tip!
            keyboardCharacterButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = characterNames[i].ToString();
        }

        // Whenever we click a button, run the function ClickCharacter and output the character to the Console.
        foreach (var keyboardButton in keyboardCharacterButtons)
        {
            string letter = keyboardButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
            keyboardButton.GetComponent<Button>().onClick.AddListener(() => UpdateCharacter(letter));
        }
    }

    void UpdateCharacter(string letter)
    {
        // Output to the console for now
        // We will later use this function to add the letters to the wordboxes.
        Debug.Log(letter);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {

        }
    }
}