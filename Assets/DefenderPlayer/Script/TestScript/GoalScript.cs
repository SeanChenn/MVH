using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefenderPlayer
{
    public class GoalScript : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag=="Player")
            {
                Debug.Log("Game Over");
                GameManagerScript.instance.isGameOver = true;
            }
        }
    }
}

