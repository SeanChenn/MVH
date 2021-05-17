using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AttackerPlayer
{
    public class Trap4 : MonoBehaviour
    {
        [SerializeField] float fSpeed;
        Vector3 v3OriPos;
        float fRange;
        bool isTurnLeft;
        // Start is called before the first frame update
        void Start()
        {
            v3OriPos = transform.position;
            fRange = v3OriPos.x - 10;
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.x>=v3OriPos.x)
            {
                isTurnLeft = true;
            }
            if (transform.position.x<= fRange)
            {
                isTurnLeft = false;
            }
            if (isTurnLeft)
            {
                transform.Translate(Vector3.left * fSpeed * Time.deltaTime);
            }
            if (!isTurnLeft)
            {
                transform.Translate(Vector3.right * fSpeed * Time.deltaTime);
            }
        }
    }
}

