using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{

   public UnityEvent OnPlayerMistake;
   public void GetDamaged() {
        print("MISTAKE");
        DifficultyManager.Instance.Level /= 2;
        OnPlayerMistake.Invoke();
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        OggettoDanneggiante objectHit;

        if(!collision.gameObject.TryGetComponent(out objectHit)) {
            return;
        }

        GetDamaged();
    }
}
