using UnityEngine;
using System;
using System.Collections;
using UnityCommunity.UnitySingleton;
using Unity.VisualScripting;

namespace PlazAR.Tools
{
    public class CoroutineHandler : PersistentMonoSingleton<CoroutineHandler>
    {
        public Coroutine StartCoroutineOnHandler(IEnumerator routine)
        {
            return StartCoroutine(routine);
        }

        public void StopCoroutines()
        {
            StopAllCoroutines();
        }
    }
}
