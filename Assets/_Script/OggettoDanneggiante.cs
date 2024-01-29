using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OggettoDanneggiante : MonoBehaviour
{
    [SerializeField] OmbraOggettoDanneggiante ombra;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite sprite;
    [SerializeField] int size = 1;

    private void Awake() {
        ombra.OnAvvisoCompleto += Parti;

        transform.localScale *= size;
        ombra.transform.localScale *= size;

        spriteRenderer.sprite = sprite;
    }
    void Parti() {
        transform.DOMoveY(ombra.transform.position.y, 1).SetEase(Ease.Linear).onComplete+=Esplodi;
    }

    private void Esplodi() {
        Destroy(gameObject);
    }
}
