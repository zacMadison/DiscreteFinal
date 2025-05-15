using System;
using System.Collections;
using System.Globalization;
using UnityEngine;
using TMPro;

public class SetCurrentSpeedText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private float currentSpeed = GameManager.Instance.speed;
    void Update()
    {
        if (currentSpeed != 0)
        {
            text.text = currentSpeed.ToString(CultureInfo.CurrentCulture);
        }
        // this is a workaround solution because on the first run the GameController cannot be accessed yet, so it defaults to 0
        else
        {
            text.text = "1";
        }
    }


}
