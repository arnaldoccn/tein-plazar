using UnityEngine;
using UnityCommunity.UnitySingleton;

namespace PlazAR.Tools
{
    public class SwipeDetector : PersistentMonoSingleton<SwipeDetector>
    {
        private Vector2 fingerDownPosition;
        private Vector2 fingerUpPosition;

        [SerializeField]
        private bool detectSwipeOnlyAfterRelease = false;
        [SerializeField]
        private float minDistanceForSwipe = 20f;

        public static event System.Action OnSwipeUp;
        public static event System.Action OnSwipeDown;
        public static event System.Action OnSwipeLeft;
        public static event System.Action OnSwipeRight;

        void Update()
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    fingerUpPosition = touch.position;
                    fingerDownPosition = touch.position;
                }

                if (!detectSwipeOnlyAfterRelease && touch.phase == TouchPhase.Moved)
                {
                    fingerDownPosition = touch.position;
                    DetectSwipe();
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    fingerDownPosition = touch.position;
                    DetectSwipe();
                }
            }
        }

        private void DetectSwipe()
        {
            if (SwipeDistanceCheckMet())
            {
                if (IsVerticalSwipe())
                {
                    if (IsSwipeDirectionUp())
                        OnSwipeUp?.Invoke();
                    else
                        OnSwipeDown?.Invoke();
                }
                else
                {
                    if (IsSwipeDirectionRight())
                        OnSwipeRight?.Invoke();
                    else
                        OnSwipeLeft?.Invoke();
                }

                fingerDownPosition = fingerUpPosition;
            }
        }

        private bool SwipeDistanceCheckMet()
        {
            return Vector2.Distance(fingerDownPosition, fingerUpPosition) > minDistanceForSwipe;
        }

        private bool IsVerticalSwipe()
        {
            return Mathf.Abs(fingerDownPosition.y - fingerUpPosition.y) > Mathf.Abs(fingerDownPosition.x - fingerUpPosition.x);
        }

        private bool IsSwipeDirectionUp()
        {
            return (fingerDownPosition.y - fingerUpPosition.y) > 0;
        }

        private bool IsSwipeDirectionRight()
        {
            return (fingerDownPosition.x - fingerUpPosition.x) < 0;
        }
    }
}
