using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dialogue class
[System.Serializable]
public class Dialogue
{
    // Name if necessary
    public string name;

    // Sentence
    [TextArea(3, 10)]
    public string[] sentences;
}
