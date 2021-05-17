using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DefenderPlayer {
    public class TrapUIScript : MonoBehaviour
    {
        [SerializeField] private Vector3 screenOffset = new Vector3(0f, 30f, 0f);
        [SerializeField] Image imageCD;

        TrapScript targetTrap;
        //float fTargetTrapHeight;
        Transform targetTransform;
        Renderer targetRenderer;
        CanvasGroup _canvasGroup;
        Vector3 targetPosition;
        float fCD;
        private void Awake()
        {
            _canvasGroup = this.GetComponent<CanvasGroup>();
        }

        // Start is called before the first frame update
        void Start()
        {
            fCD = targetTrap.fTrapCD;
        }

        // Update is called once per frame
        void Update()
        {
            if (targetTrap==null)
            {
                Destroy(this.gameObject);
                return;
            }

            imageCD.fillAmount = targetTrap.fTrapCD/fCD;
        }
        private void LateUpdate()
        {
            if (targetRenderer != null)
            {
                this._canvasGroup.alpha = targetRenderer.isVisible ? 1f : 0f;
            }
            if (targetTransform != null)
            {
                //targetPosition = targetTransform.position;
                //targetPosition.y += fTargetTrapHeight;

                this.transform.position = Camera.main.WorldToScreenPoint(targetTransform.position) + screenOffset;
            }
        }
        public void SetTargetTrap(TrapScript _target)
        {
            if (_target == null)
            {
                Debug.LogError("<Color=Red><b>Missing</b></Color> PlayMakerManager target for PlayerUI.SetTarget.", this);
                return;
            }
            // Cache references for efficiency because we are going to reuse them.
            this.targetTrap = _target;
            targetTransform = this.targetTrap.GetComponent<Transform>();
            targetRenderer = this.targetTrap.GetComponentInChildren<Renderer>();

            //BoxCollider trapCollider = this.targetTrap.GetComponent<BoxCollider>();
            //// Get data from the Player that won't change during the lifetime of this Component
            //if (trapCollider != null)
            //{
            //    fTargetTrapHeight = trapCollider.center.y;
            //}
        }

    }
}

