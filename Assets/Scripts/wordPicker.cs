using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;
using System.IO;

public class wordPicker : MonoBehaviour{

    public string solution;

    public void Start()
    {
        List<string> words = File.ReadAllLines("lib.txt").ToList();
        var picker = new System.Random();
        int index = picker.Next(words.Count);
        solution = words[index];
        Debug.Log("(wordPicker.cs) cevap: "+solution);
    }
}