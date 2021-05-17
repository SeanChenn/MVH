using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefenderPlayer
{
    public class PlayerPosResetScript : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            if (other.tag=="Player")
            {
                other.transform.localPosition = new Vector3(-45,1.5f,0);
                Debug.Log("掉出界");
            }
        }
    }
}
