using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AttackerPlayer
{
    public class Trap5 : MonoBehaviour
    {
        [SerializeField] float fSpeed;
        [SerializeField] bool isTurnLeft;
        Vector3 v3TurnChoose;
        // Start is called before the first frame update
        void Start()
        {
            v3TurnChoose = isTurnLeft ? Vector3.up : Vector3.down;
        }

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(v3TurnChoose * fSpeed * Time.deltaTime);
        }
    }

}
