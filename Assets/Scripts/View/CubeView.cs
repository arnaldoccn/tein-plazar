using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zappar;
using TMPro;

namespace PlazAR.View
{
    [RequireComponent(typeof(Animation))]
    public class CubeView : MonoBehaviour, ICubeView
    {
        private Animation animationController;
        private ZapparInstantTrackingTarget zapparInstantTrackingTarget;
        
        private bool alreadyFell = false;

        void Awake()
        {
            animationController = GetComponent<Animation>();
        }

        public void PlayAnimation(string name)
        {
            animationController.Play(name);
        }

        void Update()
        {
            if (zapparInstantTrackingTarget != null)
            {
                if (zapparInstantTrackingTarget.UserHasPlaced && !alreadyFell)
                {
                    alreadyFell = true;
                    PlayAnimation("Entrada");
                }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                PlayAnimation("Entrada");   
            }
        }

        public void SetZapparInstantTrackingTarget(ZapparInstantTrackingTarget zapparInstantTrackingTarget)
        {
            Debug.Log("SetZapparInstantTrackingTarget");
            this.zapparInstantTrackingTarget = zapparInstantTrackingTarget;
        }
    }
}

