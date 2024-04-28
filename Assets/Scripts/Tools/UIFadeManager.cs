using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityCommunity.UnitySingleton;

namespace PlazAR.Tools
{
    public class UIFadeManager : MonoBehaviour
    {
        public enum FadeType
        {
            FadeIn,
            FadeOut
        }

        [System.Serializable]
        public class FadeElement
        {
            public Graphic graphic;
            public bool startVisible;
            public int priority;
        }

        public List<FadeElement> elementsToFade;
        public bool useSequentialFade = false;
        public float fadeDuration = 1f;

        private void Start()
        {
        
            foreach (FadeElement element in elementsToFade)
            {
                element.graphic.CrossFadeAlpha(element.startVisible ? 1f : 0f, 0f, true);
            }
        }

        public void ExecuteFade(FadeType fadeType)
        {
            if (useSequentialFade)
            {
                StartCoroutine(PerformSequentialFade(fadeType));
            }
            else
            {
                StartCoroutine(PerformSimultaneousFade(fadeType));
            }
        }

        private IEnumerator PerformSequentialFade(FadeType fadeType)
        {
            List<FadeElement> sortedElements = elementsToFade.OrderBy(e => e.priority).ToList();

            foreach (FadeElement element in sortedElements)
            {
                float targetAlpha = (fadeType == FadeType.FadeIn) ? 1f : 0f;
                float startAlpha = element.graphic.color.a;

                float timer = 0f;

                while (timer < fadeDuration)
                {
                    timer += Time.deltaTime;
                    float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, timer / fadeDuration);

                    element.graphic.CrossFadeAlpha(newAlpha, 0f, true);

                    yield return null;
                }
            }

        }

        private IEnumerator PerformSimultaneousFade(FadeType fadeType)
        {
            float targetAlpha = (fadeType == FadeType.FadeIn) ? 1f : 0f;
            float startAlpha = (fadeType == FadeType.FadeIn) ? 0f : 1f;

            float timer = 0f;

            while (timer < fadeDuration)
            {
                timer += Time.deltaTime;
                float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, timer / fadeDuration);

                foreach (FadeElement element in elementsToFade)
                {
                    element.graphic.CrossFadeAlpha(newAlpha, 0f, true);
                }

                yield return null;
            }
        }
    }
}