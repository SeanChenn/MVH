using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AttackerPlayer
{
    public class Trap1 : MonoBehaviour
    {
        [SerializeField] float fSpeed;
        float fRotateZ;
        Vector3 v3Rotate;
        [SerializeField] bool isTurnLeft;
        // Start is called before the first frame update
        void Start()
        {
            v3Rotate = transform.eulerAngles;
            fRotateZ = transform.eulerAngles.z;
        }

        // Update is called once per frame
        void Update()
        {
            TrapRotate();
        }
        void TrapRotate()
        {
            if (fRotateZ <= -60)
            {
                isTurnLeft = true;
            }
            else if (fRotateZ >= 60)
            {
                isTurnLeft = false;
            }
            if (isTurnLeft)
            {
                fRotateZ += fSpeed * Time.deltaTime;
            }
            else if (!isTurnLeft)
            {
                fRotateZ -= fSpeed * Time.deltaTime;
            }

            v3Rotate.z = fRotateZ;
            transform.eulerAngles = v3Rotate;
            //Debug.Log($"v3Rotate : {v3Rotate}");
        }
    }
}
