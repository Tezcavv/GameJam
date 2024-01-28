using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lettera : MonoBehaviour
{
    public KeyCode key;
    public float timeRemaining;
    [SerializeField] private TextMeshProUGUI text;

    private void Start() {
        text.text=key.ToString();
    }

}
