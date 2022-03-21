using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class checkAnswer : MonoBehaviour
{
    public string input;
    List<string> inputLetters = null;
    List<string> solutionLetters = null;
    public string currentWord = "";
    public string solutionWord = "";

    public List<Transform> LetterBoxes = new List<Transform>();
    int currentLetterBox;
    public wordPicker _wordPicker;

    private void Awake()
    {
        _wordPicker = GameObject.FindObjectOfType<wordPicker>();
        if (Input.anyKey) {

            Debug.Log(input);
        }
    }

    private void Start()
    {
    }

    public void readInput(string s)
    {
        input = s;
        solutionWord = _wordPicker.solution;

        Debug.Log("(readInput methodundan geliyor)input: " + input);

        inputLetters = new List<string>(input.Select(c => c.ToString()));
        solutionLetters = new List<string>(_wordPicker.solution.Select(c => c.ToString())); 

        if (Enumerable.SequenceEqual(solutionLetters, inputLetters))
        {
            Debug.Log("readInput : Kazandin");
        }

        else
        {
            for (int i = 0; i < 5; i++)
            {
                if (isLetterInPlace(i))
                {
                    currentLetterBox = i;
                    AddLetterToLetterBox(inputLetters[i]);
                    inputLetters[i] = null;
                }
                else if (isLetterContained(i))
                {
                    AddLetterToLetterBox(inputLetters[i]);
                    currentLetterBox = i;
                    inputLetters[i] = null;
                }
                else
                {
                    currentLetterBox = i;
                    AddLetterToLetterBox(inputLetters[i]);
                }

            }
        }
        }

    public void AddLetterToLetterBox(string letter)
    {
        LetterBoxes[currentLetterBox].GetChild(0).GetComponent<Text>().text=letter;
        currentLetterBox ++;
    }
    public bool isLetterInPlace(int index)
    {
        return inputLetters[index] == solutionLetters[index];
    }
    public bool isLetterContained(int index)
    {
        return solutionLetters.Contains(inputLetters[index]);
    }

}