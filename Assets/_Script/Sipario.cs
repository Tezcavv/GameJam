using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sipario : MonoBehaviour
{

    [SerializeField] GameObject siparioDiSinistra;
    [SerializeField] GameObject siparioDiDestra;
    [SerializeField] float velocitaDiApertura;
    [SerializeField] float velocitaDiChiusura;

    public UnityEvent OnSiparioAperto;
    public UnityEvent OnSiparioChiuso;

    static bool chiuso = false;


    private void Awake() {
        OnSiparioChiuso.AddListener(Closed);
        OnSiparioAperto.AddListener(Opened);
    }

    private void Closed() {
        chiuso = true;
    }

    private void Opened() {
        chiuso= false;
    }
    private void Update() {

    }

    public void ApriSipario() {

        float screenSize = Screen.width;

        if (!chiuso)
            return;

        siparioDiDestra.GetComponent<RectTransform>().DOAnchorPosX(100,velocitaDiApertura);
        siparioDiSinistra.GetComponent<RectTransform>().DOAnchorPosX(-100, velocitaDiApertura).onComplete+=OnSiparioAperto.Invoke;

    }

    public void ChiudiSipario() {

        float screenSize = Screen.width;

        if (chiuso)
            return;

        siparioDiDestra.GetComponent<RectTransform>().DOAnchorPosX((-screenSize / 2) + 100, velocitaDiChiusura);
        siparioDiSinistra.GetComponent<RectTransform>().DOAnchorPosX((screenSize / 2) - 100, velocitaDiChiusura).onComplete += OnSiparioChiuso.Invoke;

    }




}
