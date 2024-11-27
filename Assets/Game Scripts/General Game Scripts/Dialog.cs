using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialog", menuName = "Dialog")]
public class Dialog: ScriptableObject
{
    [SerializeField] private List<string> dLines;

    public List<string> dialogLines {
        get { return dLines; }
    }
}
