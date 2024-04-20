using UnityEngine;
using Zappar;
using PlazAR.View;
using PlazAR.Model;

public class CubePresenter
{
    private CubeModel cubeModel;
    private CubeView cubeView;

    public CubePresenter(CubeModel cubeModel, CubeView cubeView, ZapparInstantTrackingTarget zapparInstantTrackingTarget)
    {
        this.cubeModel = cubeModel;
        this.cubeView = cubeView;
        cubeView.SetZapparInstantTrackingTarget(zapparInstantTrackingTarget);
    }

}