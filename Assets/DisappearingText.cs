
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisappearingText : MonoBehaviour {
    [SerializeField] float disappearTime;
    // Start is called before the first frame update
    void Update() {
        disappearTime -= Time.deltaTime;
        if (disappearTime <= 0)
            Destroy(gameObject);
    }
}



