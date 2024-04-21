using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zappar;
using PlazAR.View;
using PlazAR.Model;
using UnityCommunity.UnitySingleton;

namespace PlazAR.Application
{
    public class Application : PersistentMonoSingleton<Application>
    {
        [SerializeField]
        private CubeView cubeView;
        [SerializeField]
        private ZapparInstantTrackingTarget zapparInstantTrackingTarget;

        private CubePresenter cubePresenter;

        void Awake()
        {
            cubePresenter = new CubePresenter(new CubeModel(), cubeView, zapparInstantTrackingTarget);
        }
    }
}