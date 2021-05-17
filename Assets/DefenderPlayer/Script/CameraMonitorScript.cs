using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefenderPlayer
{
    public class CameraMonitorScript : MonoBehaviour
    {
        /// <summary>
        /// 玩家進入
        /// </summary>
        public bool isInScreen;
       
        private void OnTriggerEnter(Collider hit)
        {
            if (hit.tag == "Player")
            {
                Debug.Log($"玩家進入");
                isInScreen = true;
            }
        }
        private void OnTriggerStay(Collider hit)
        {
            if (hit.tag == "Player")
            {
                Debug.Log($"玩家停留");
                isInScreen = true;
            }
        }
        private void OnTriggerExit(Collider hit)
        {
            if (hit.tag == "Player")
            {
                Debug.Log($"玩家離開");
                isInScreen = false;
            }
        }
    }
}

