using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zappar;
using PlazAR.View;
using PlazAR.Model;

namespace PlazAR.Application
{
    public class Application : MonoBehaviour
    {
        [SerializeField]
        private CubeView cubeView;
        [SerializeField]
        private ZapparInstantTrackingTarget zapparInstantTrackingTarget;

        private CubePresenter cubePresenter;

        private void Awake()
        {
            cubePresenter = new CubePresenter(new CubeModel(), cubeView, zapparInstantTrackingTarget);
        }
    }
}