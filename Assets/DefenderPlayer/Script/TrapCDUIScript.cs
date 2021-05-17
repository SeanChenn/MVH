using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DefenderPlayer
{
    public class TrapCDUIScript : MonoBehaviour
    {
        Image imageTrapCD;
        [SerializeField] TrapScript trapScript;

        float fCDOriginal;

        // Start is called before the first frame update
        void Start()
        {
            imageTrapCD = GetComponent<Image>();
            fCDOriginal = trapScript.fTrapCD;
        }

        // Update is called once per frame
        void Update()
        {
            imageTrapCD.fillAmount = trapScript.fTrapCD / fCDOriginal;
        }
    }
}

