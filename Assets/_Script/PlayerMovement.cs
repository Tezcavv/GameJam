using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Utilities;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]OstacoliSpawner spawnerDiOstacoli;
    GameObject currentSpawnPoint;
    

    private void Start() {

        SetToColumn(0);
        

    }

    public void Move(CallbackContext ctx) {
        if (ctx.started) {
            float xMovement = ctx.ReadValue<Vector2>().x;
            if (xMovement > 0) {

                if (spawnerDiOstacoli.SpawnPoints.IndexOf(currentSpawnPoint) >= spawnerDiOstacoli.SpawnPoints.Count - 1)
                    return;

                SetToColumn(spawnerDiOstacoli.SpawnPoints.IndexOf(currentSpawnPoint) + 1);

            } else if (xMovement < 0) {

                if (spawnerDiOstacoli.SpawnPoints.IndexOf(currentSpawnPoint) <= 0)
                    return;

                SetToColumn(spawnerDiOstacoli.SpawnPoints.IndexOf(currentSpawnPoint) - 1);
            }
        }

    }

    private void SetToColumn(int numColonna) {
        GameObject go = spawnerDiOstacoli.SpawnPoints[numColonna];
        transform.position = new Vector3(go.transform.position.x,transform.position.y,transform.position.z);
        currentSpawnPoint = go;
    }


}
