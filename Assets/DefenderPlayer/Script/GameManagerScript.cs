using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefenderPlayer
{
    public class GameManagerScript : MonoBehaviour
    {
        public static GameManagerScript instance;

        public bool isGameOver;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

    }

    /// <summary>
    /// 陷阱類型
    /// </summary>
    public enum enTrapType
    {
        送回起點,
        暫時禁止移動,
        暫時緩速,
        即死,
        中毒持續扣血,
        暫時操作變反方向,
        暫時奪走視力,
        暫時封鎖技能,
        Count
    }
}

