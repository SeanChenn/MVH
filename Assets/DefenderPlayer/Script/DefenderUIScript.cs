using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DefenderPlayer
{
    public class DefenderUIScript : MonoBehaviour
    {
        [SerializeField] GridLayoutGroup gridX;
        [SerializeField] RectTransform rect;
        [SerializeField] Button btnTurnL, btnTurnR;
        [SerializeField] Outline outlineBtnTxtLeft, outlineBtnTxtRight;
        [SerializeField] Image[] imageRedPoint;
        ////[SerializeField] Image[] imageTrapCD;
        /// <summary>
        /// 監視器
        /// </summary>
        [SerializeField] CameraMonitorScript[] cameraMonitors;
        [SerializeField] Button[] btnsScreen;
        [SerializeField] Camera[] camerasScreen;
        [SerializeField] CanvasGroup canvasTextGamaOver;
        public Camera cameraCurrent;

        
        Color colorRight = Color.red;
        Color colorLeft = Color.red;

        /// <summary>
        /// 監視器寬
        /// </summary>
        [SerializeField] float fCellSizeX;
        /// <summary>
        /// 最左邊螢幕 (0,0)
        /// </summary>
        Vector2 v2RectLeft;
        /// <summary>
        /// 最右邊螢幕 (fCellSizeX,0)
        /// </summary>
        Vector2 v2RectRight;
        /// <summary>
        /// 螢幕大小
        /// </summary>
        Vector2 v2RectCellSize;
        [SerializeField] int iSwichCount;
        // Start is called before the first frame update
        void Start()
        {
            v2RectLeft = rect.offsetMin; //offsetMin 代表 Min 錨點到物體顯示區域左下角點的向量
            v2RectRight = rect.offsetMin;
            fCellSizeX = gridX.cellSize.x;
            colorRight.a = 0;
            colorLeft.a = 0;
            if (cameraCurrent==null)
            {
                cameraCurrent = camerasScreen[0];
            }

            btnTurnL.onClick.AddListener(() => { BtnTurnLR(-fCellSizeX); });
            btnTurnR.onClick.AddListener(() => { BtnTurnLR(fCellSizeX); });
            foreach (var item in btnsScreen)
            {
                item.onClick.AddListener(() => { CameraChange(System.Array.IndexOf(btnsScreen, item)); });
            }
        }

        // Update is called once per frame
        void Update()
        {
            RedPointDisplay();
            RectLRUpdate();

            if (GameManagerScript.instance.isGameOver)
            {
                canvasTextGamaOver.alpha = 1;
            }
        }
        
        /// <summary>
        /// 紅點顯示
        /// </summary>
        void RedPointDisplay()
        {
            outlineBtnTxtLeft.effectColor = colorLeft;
            outlineBtnTxtRight.effectColor = colorRight;
            
            if (cameraMonitors[0].isInScreen)
            {
                imageRedPoint[0].color = Color.red;
            }
            else
            {
                imageRedPoint[0].color = Color.clear;
            }
            if (cameraMonitors[1].isInScreen)
            {
                imageRedPoint[1].color = Color.red;
            }
            else
            {
                imageRedPoint[1].color = Color.clear;
            }
            if (cameraMonitors[2].isInScreen)
            {
                imageRedPoint[2].color = Color.red;
            }
            else
            {
                imageRedPoint[2].color = Color.clear;
            }
            if (cameraMonitors[3].isInScreen)
            {
                imageRedPoint[3].color = Color.red;
            }
            else
            {
                imageRedPoint[3].color = Color.clear;
            }
            if (cameraMonitors[4].isInScreen)
            {
                imageRedPoint[4].color = Color.red;
            }
            else
            {
                imageRedPoint[4].color = Color.clear;
            }

            if (iSwichCount == 0)
            {
                if (cameraMonitors[3].isInScreen || cameraMonitors[4].isInScreen)
                {
                    colorRight.a = 1;
                }
                else
                {
                    colorRight.a = 0;
                }
                if (cameraMonitors[0].isInScreen || cameraMonitors[1].isInScreen)
                {
                    colorLeft.a = 0;
                }
            }
            if (iSwichCount == 1)
            {
                if (cameraMonitors[0].isInScreen)
                {
                    colorLeft.a = 1;
                }
                else
                {
                    colorLeft.a = 0;
                }
                if (cameraMonitors[4].isInScreen)
                {
                    colorRight.a = 1;
                }
                else
                {
                    colorRight.a = 0;
                }
            }
            if (iSwichCount == 2)
            {
                if (cameraMonitors[0].isInScreen || cameraMonitors[1].isInScreen)
                {
                    colorLeft.a = 1;
                }
                else if (!cameraMonitors[0].isInScreen)
                {
                    colorLeft.a = 0;
                }
                if (cameraMonitors[3].isInScreen || cameraMonitors[4].isInScreen)
                {
                    colorRight.a = 0;
                }
            }
        }
        #region 監視器操作
        /// <summary>
        /// 相機切換
        /// </summary>
        /// <param name="i"></param>
        void CameraChange(int i)
        {
            for (int j = 0; j < btnsScreen.Length; j++)
            {
                camerasScreen[j].enabled = false;
                if (i == j)
                {
                    camerasScreen[i].enabled = true;
                    cameraCurrent = camerasScreen[i];
                }
            }
        }
        void BtnTurnLR(float f)
        {
            v2RectCellSize = rect.offsetMin; 
            if (f > 0)
            {
                Debug.Log($" rect.offsetMin : {rect.offsetMin}");
                v2RectCellSize.x -= fCellSizeX; //向右
                rect.offsetMin = v2RectCellSize;
                iSwichCount++;
            }
            else if (f < 0)
            {
                Debug.Log($" rect.offsetMin : {rect.offsetMin}");
                v2RectCellSize.x += fCellSizeX; //向左
                rect.offsetMin = v2RectCellSize;
                iSwichCount--;
            }
            if (iSwichCount>gridX.gameObject.transform.childCount-3)
            {
                iSwichCount = gridX.gameObject.transform.childCount - 3;
            }
            else if (iSwichCount<0)
            {
                iSwichCount = 0;
            }
        }
        void RectLRUpdate()
        {
            //最左rect值
            if (rect.offsetMin.x > 0) 
            {
                rect.offsetMin = v2RectLeft; //(0,0)
            }
            //最右rect值
            if (rect.offsetMin.x < (gridX.gameObject.transform.childCount - 3) * -fCellSizeX) 
            {
                v2RectRight.x = (gridX.gameObject.transform.childCount - 3) * -fCellSizeX;
                rect.offsetMin = v2RectRight;
            }
        }
        #endregion

    }
}

