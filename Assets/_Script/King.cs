using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class King : MonoBehaviour
{
    [SerializeField]int happynessMeter; //1,2,3
    [SerializeField] GameObject normalMouth;
    [SerializeField] GameObject happyMouth;
    [SerializeField] GameObject angryMouth;
    [SerializeField] int happynessRecoveryRate;
    [Space]
    [SerializeField] Player player;

    public UnityEvent OnGameOver;

    Dictionary<int, GameObject> mouthDictionary;
    private void Awake() {
        mouthDictionary = new Dictionary<int, GameObject>();
        StartCoroutine(RecoverHappyness());
        player.OnPlayerMistake.AddListener(DecreaseHappyness);
        mouthDictionary.Add(1, angryMouth);
        mouthDictionary.Add(2, normalMouth);
        mouthDictionary.Add(3, happyMouth);

        happynessMeter = 2;
        SetKingHappyness(2);

    }

    private IEnumerator RecoverHappyness() {
        while (gameObject.activeInHierarchy) {
            yield return new WaitForSeconds(happynessRecoveryRate);
            HappynessMeter++;
        }

    }

    public int HappynessMeter { get { return happynessMeter; }
                                set { SetKingHappyness(value); } }

    private void SetKingHappyness(int value) {
        
        if(value == 0) {
            Time.timeScale = 0;
            OnGameOver?.Invoke();
            StartCoroutine(ReloadScene());
            return;
        }

        if (value >= 4)
            return;

        mouthDictionary[happynessMeter].SetActive(false);
        mouthDictionary[value].SetActive(true);
        happynessMeter = value;


    }

    private IEnumerator ReloadScene() {
        yield return new WaitForSecondsRealtime(5);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void DecreaseHappyness() {
        HappynessMeter--;
    }


    private void OnDisable() {
        player.OnPlayerMistake.RemoveListener(DecreaseHappyness);
    }
}
