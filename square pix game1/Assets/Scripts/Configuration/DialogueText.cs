using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Text")]

public class DialogueText : ScriptableObject
{
    [SerializeField]private List<string> texts_dialogue;

    public List<string> Get_text
    {
        get
        {
            return texts_dialogue;
        }
    }
}
