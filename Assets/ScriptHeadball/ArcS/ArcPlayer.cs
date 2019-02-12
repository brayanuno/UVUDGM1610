using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcPlayer : MonoBehaviour
{
    [SerializeField]
    private GamePlay gameplay;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Ball")
        {
            gameplay.scorePlayer++;
        }
    }
}
