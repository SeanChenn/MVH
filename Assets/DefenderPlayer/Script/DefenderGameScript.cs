using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefenderPlayer
{
    public class DefenderGameScript : MonoBehaviour
    {
        [SerializeField] DefenderUIScript defenderUI;
        [SerializeField] LayerMask _layerMask;

        // Update is called once per frame
        void Update()
        {
            TrapClick();
        }

        void TrapClick()
        {
            RaycastHit hit;
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray2 = defenderUI.cameraCurrent.ScreenPointToRay(Input.mousePosition);//滑鼠位置
                if (Physics.Raycast(ray2, out hit, Mathf.Infinity, _layerMask))
                {
                    //Debug.Log(string.Format("Touch - Name:{0}, Position:{1}, Point:{2}", hit.transform.name, hit.transform.position, hit.point));
                    if (hit.transform.tag=="Trap")
                    {
                        Debug.Log($"點到陷阱 : {hit.transform.name}");
                        if (!hit.transform.GetComponent<TrapScript>().isTrapCDTime)
                        {
                            hit.transform.GetComponent<TrapScript>().isTrapTurnOn = true;
                            hit.transform.GetComponent<TrapScript>().isTrapCDTime = true;
                        }
                    }
                }
            }
        }

    }
}
