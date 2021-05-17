using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AttackerPlayer
{
    public class Trap3 : MonoBehaviour
    {
        [SerializeField] Transform transformParent;
        Rigidbody rigidbodySelf;

        [SerializeField] bool isTread;
        [SerializeField] float fDuration=3;
        // Start is called before the first frame update
        void Start()
        {
            rigidbodySelf = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            if (isTread)
            {
                fDuration -= Time.deltaTime;
                Debug.Log($"fDuration : {fDuration}");
                if (fDuration<=0)
                {
                    rigidbodySelf.isKinematic = false;
                }
            }
            if (transform.position.y<=-30)
            {
                isTread = false;
                fDuration = 3;
                rigidbodySelf.isKinematic = true;
                transform.position = transformParent.position;
                transform.eulerAngles = transformParent.eulerAngles;
            }
        }
        private void OnCollisionEnter(Collision hit)
        {
            if (hit.gameObject.tag=="Player")
            {
                isTread = true;
            }
        }
    }
}

