using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmbraOggettoDanneggiante : MonoBehaviour
{
    [SerializeField] private Vector3 increaseScale;
    [SerializeField] private float duration;

    public Action OnAvvisoCompleto;

    private void Awake() {
        transform.DOScale(increaseScale, duration-(DifficultyManager.Instance.level/50)).onComplete += Disable;
    }

    private void Disable() {
        OnAvvisoCompleto?.Invoke();
        gameObject.SetActive(false);
    }
}
