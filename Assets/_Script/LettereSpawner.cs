using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class LettereSpawner : MonoBehaviour
{
    [SerializeField] KeyCode[] keys;
    [SerializeField] float spawnInterval;
    [SerializeField] GameObject lettereHolder;
    [SerializeField] GameObject lettera;
    [SerializeField] Player player;
    private bool canSpawn;

    private List<Lettera> currentlyActiveLetters;
    private static readonly List<KeyCode> safeKeyCodes = new List<KeyCode>() { 
                    KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow,
                    KeyCode.Escape, KeyCode.Mouse0, KeyCode.Mouse1 };

    private void Awake() {
        currentlyActiveLetters = new List<Lettera>();
        canSpawn = true;

    }

    private void Start() {
        StartCoroutine(SpawnLetter());
    }
    private void Update() {

        if(currentlyActiveLetters.Count > 0) {
            ManageFirstLetter();
        }
        
    }

    private void ManageFirstLetter() {
        Lettera letter = currentlyActiveLetters[0];


        letter.timeRemaining -= Time.deltaTime;
        if (letter.timeRemaining < 0) {
            currentlyActiveLetters.ForEach(letter => Destroy(letter.gameObject));
            currentlyActiveLetters.Clear();
            player.GetDamaged();
        }


        if (Input.GetKeyDown(letter.key)){
            Destroy(letter.gameObject);
            currentlyActiveLetters.Remove(letter);
            return;
        }

        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode))) {
            if (Input.GetKeyDown(kcode) && !safeKeyCodes.Contains(kcode)) {
                currentlyActiveLetters.ForEach(letter => Destroy(letter.gameObject));
                currentlyActiveLetters.Clear();
                player.GetDamaged();
            }
        }


    }


    private IEnumerator SpawnLetter() {
        while (canSpawn) {

            yield return new WaitForSeconds(spawnInterval);

            if (currentlyActiveLetters.Count > 0) {
                currentlyActiveLetters.ForEach(letter => Destroy(letter.gameObject));
                currentlyActiveLetters.Clear();
                player.GetDamaged();
                continue;
            }

            int random = Random.Range(Mathf.Min(3,DifficultyManager.Instance.Level+1), Mathf.Min(5, DifficultyManager.Instance.Level));
            for (int i = 0; i < random ; i++) {

                Lettera letter = (Instantiate(lettera, lettereHolder.transform)).GetComponent<Lettera>();
                letter.timeRemaining = spawnInterval;
                letter.key = keys[Random.Range(0, Mathf.Min(keys.Length , DifficultyManager.Instance.Level+1))];
                currentlyActiveLetters.Add(letter);

            }
        }
    }


    private void OnDisable() {
        StopAllCoroutines();
    }
}
