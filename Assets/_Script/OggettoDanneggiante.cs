using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OggettoDanneggiante : MonoBehaviour
{
    [SerializeField] OmbraOggettoDanneggiante ombra;
    [SerializeField] Sprite sprite;
    [SerializeField] int size = 1;

    private void Awake() {
        ombra.OnAvvisoCompleto += Parti;

        transform.localScale *= size;
        ombra.transform.localScale *= size;
    }
    void Parti() {
        transform.DOMoveY(ombra.transform.position.y, 1).SetEase(Ease.Linear);
    }

    


}
