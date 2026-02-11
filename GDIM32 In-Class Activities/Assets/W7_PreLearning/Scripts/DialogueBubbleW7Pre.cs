using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Assertions;

using TMPro;

public class DialogueBubbleW7Pre : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void ShowDialogue(string dialogue)
    {
        _text.text = dialogue;
        gameObject.SetActive(true);
    }

    public void HideDialogue()
    {
        gameObject.SetActive(false);
    }
}