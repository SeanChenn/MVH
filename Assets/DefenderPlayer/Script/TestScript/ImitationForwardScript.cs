using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefenderPlayer
{
    public class ImitationForwardScript : MonoBehaviour
    {
        public float fSpeed;

        public bool isStopTime;
        public bool isSlowTime;

        [SerializeField] float fOriginalSpeed;
        [SerializeField] float fDebuffCD=5;
        // Start is called before the first frame update
        void Start()
        {
            fOriginalSpeed = fSpeed;
        }

        // Update is called once per frame
        void Update()
        {
            PlayerMoveSituation();
        }


        void PlayerMoveSituation()
        {
            if (isStopTime)
            {
                fSpeed = 0;
                fDebuffCD -= Time.deltaTime;
                if (fDebuffCD <= 0)
                {
                    fSpeed = fOriginalSpeed;
                    fDebuffCD = 5;
                    isStopTime = false;
                }
            }
            else if (isSlowTime)
            {
                fSpeed = fOriginalSpeed / 2;
                fDebuffCD -= Time.deltaTime;
                if (fDebuffCD <= 0)
                {
                    fSpeed = fOriginalSpeed;
                    fDebuffCD = 5;
                    isSlowTime = false;
                }
            }
            transform.Translate(Vector3.right * fSpeed * Time.deltaTime);
        }
    }
}
