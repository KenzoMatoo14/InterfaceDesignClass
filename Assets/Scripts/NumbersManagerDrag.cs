using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.Audio.ProcessorInstance;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class NumbersManagerDrag : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI NumberDisplay;

    public int Number;
    void Start()
    {
        NumberDisplay.text = string.Format(Number.ToString());
    }


}
