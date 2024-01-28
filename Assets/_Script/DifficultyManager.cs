using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DifficultyManager : MonoBehaviour {
    private static DifficultyManager instance;
    public static DifficultyManager Instance => instance;


    [SerializeField] float difficultyIncreaseTimer;
    public float difficultyTimer;
    public int level;



    public float DifficultyTimer { get => difficultyTimer; set => difficultyTimer = value; }
    public int Level { get => level; set => level = value; }


    private void Awake() {

        InitializeSingleton();

        Level = 0;
        DifficultyTimer = 0;
    }

    private void InitializeSingleton() {
        if (instance == null) {
            instance = this;
            return;
        }
        Destroy(gameObject);
    }

    private void Update() {
        CheckDifficulty();
    }
    private void CheckDifficulty() {

        DifficultyTimer += Time.deltaTime;

        if (DifficultyTimer < difficultyIncreaseTimer)
            return;

        Level++;
        DifficultyTimer = 0;
    }
}
