using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class OstacoliSpawner : MonoBehaviour
{
    [SerializeField]List<OggettoDanneggiante> oggettiList;
    [SerializeField]List<GameObject> spawnPoints;
    
    bool canSpawn;

    public List<GameObject> SpawnPoints { get => spawnPoints; set => spawnPoints = value; }

    private void Awake() {
        canSpawn = true;
        StartCoroutine(SpawnObstacles());
    }

    private IEnumerator SpawnObstacles() {
        while (canSpawn) {
            yield return new WaitForSeconds(5);

            List<GameObject> chosenSpawnPoints = GetRandomSpawnPoints();
            int chosenObj = UnityEngine.Random.Range(0, oggettiList.Count);
            for(int i = 0; i < chosenSpawnPoints.Count; i++) {
                Instantiate(oggettiList[chosenObj],chosenSpawnPoints[i].transform);
            }



        }
    }

    private List<GameObject> GetRandomSpawnPoints() {
        int min = 3;
        int max=Mathf.Min(3+DifficultyManager.Instance.level,spawnPoints.Count);

        Random random = new();
        int numOfObstacles = random.Next(min,max);

        List<int> interiScelti = new List<int>();
        List<GameObject> result = new List<GameObject>();

        while(result.Count < numOfObstacles) {
            //scelgo intero
            int rand = random.Next(0,spawnPoints.Count);
            //se già scelto riprovo
            if(interiScelti.Contains(rand)) {
                continue;
            }
            interiScelti.Add(rand);
            result.Add(spawnPoints[rand]);

        }
        return result;

    }
}
