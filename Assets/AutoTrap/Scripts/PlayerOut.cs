using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AttackerPlayer
{
    public class PlayerOut : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                other.transform.localPosition = new Vector3(0, 1.5f, -45);
                Debug.Log("掉出界");
            }
        }
    }
}

