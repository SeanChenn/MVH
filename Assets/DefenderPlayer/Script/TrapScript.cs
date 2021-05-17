using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefenderPlayer
{
    public class TrapScript : MonoBehaviour
    {
        public enTrapType enTrapType;

        Vector3 v3OrigiPos;
        public bool isTrapTurnOn;
        public bool isTrapCDTime;
        public float fTrapCD=10;
        [SerializeField] float fTrapContinuedTime=1;

        float fTrapCDOriginal;
        float fTrapContinuedTimeOriginal;
        // Start is called before the first frame update
        void Start()
        {
            fTrapCDOriginal = fTrapCD;
            fTrapContinuedTimeOriginal = fTrapContinuedTime;
        }

        // Update is called once per frame
        void Update()
        {
            TrapContinued();
            TrapCD();
        }
        void TrapContinued()
        {
            if (isTrapTurnOn)
            {
                fTrapContinuedTime -= Time.deltaTime;
                Debug.Log($"fTrapContinuedTime : {fTrapContinuedTime:0}");
                if (fTrapContinuedTime<=0)
                {
                    isTrapTurnOn = false;
                    fTrapContinuedTime = fTrapContinuedTimeOriginal;
                    Debug.Log($"fTrapContinuedTime : {fTrapContinuedTime:0}");
                }
            }
        }
        void TrapCD()
        {
            if (isTrapCDTime)
            {
                fTrapCD -= Time.deltaTime;
                Debug.Log($"fTrapCD : {fTrapCD:0}");
                if (fTrapCD <= 0)
                {
                    isTrapCDTime = false;
                    fTrapCD = fTrapCDOriginal;
                    Debug.Log($"fTrapCD : {fTrapCD:0}");
                }
            }
        }

        private void OnTriggerStay(Collider hit)
        {
            if (isTrapTurnOn)
            {
                if (hit.transform.tag == "Player")
                {
                    switch (enTrapType)
                    {
                        case enTrapType.送回起點:
                            v3OrigiPos.x = -45;
                            v3OrigiPos.y = 1.5f;
                            v3OrigiPos.z = 0;
                            hit.transform.localPosition = v3OrigiPos;
                            Debug.Log($"送回原點 :{hit.name}");
                            break;
                        case enTrapType.暫時禁止移動:
                            hit.transform.GetComponent<ImitationForwardScript>().isStopTime = true;
                            Debug.Log($"暫時禁止移動 :{hit.name}");
                            break;
                        case enTrapType.暫時緩速:
                            hit.transform.GetComponent<ImitationForwardScript>().isSlowTime = true;
                            Debug.Log($"暫時緩速 :{hit.name}");
                            break;
                        case enTrapType.即死:

                            break;
                        case enTrapType.中毒持續扣血:

                            break;
                        case enTrapType.暫時操作變反方向:

                            break;
                        case enTrapType.暫時奪走視力:

                            break;
                        case enTrapType.暫時封鎖技能:

                            break;
                        case enTrapType.Count:
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
