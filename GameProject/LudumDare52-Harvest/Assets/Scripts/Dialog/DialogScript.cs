using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialog", menuName = "ScriptableObjects/DialogFile", order = 1)]
public class DialogScript : ScriptableObject
{
    public string text;
    public DialogScript next;
}
