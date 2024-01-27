using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OstacoliSpawner : MonoBehaviour
{
    [SerializeField]List<OggettoDanneggiante> oggettiList;
    [SerializeField]List<GameObject> spawnPoints;

    public List<GameObject> SpawnPoints { get => spawnPoints; set => spawnPoints = value; }
}
