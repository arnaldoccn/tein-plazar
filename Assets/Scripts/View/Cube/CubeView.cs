using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zappar;
using TMPro;
using FiniteStateMachine.Machine;
using System;

namespace PlazAR.View
{
    [RequireComponent(typeof(Animation))]
    [RequireComponent(typeof(AudioSource))]
    public class CubeView : MonoBehaviour, ICubeView
    {
        [SerializeField]
        private List<Texture2D> eyeList = new();
        [SerializeField]
        private Material eyeMaterial;
        [SerializeField]
        private GameObject hand;
        [SerializeField]
        private AudioSource sfxSource, hoverSource;
        [SerializeField]
        private List<AudioClip> sfxList = new();
        [SerializeField]
        private List<AudioClip> talkAudios = new();
        [SerializeField]
        private AudioClip hoverClip;
        public StateMachine stateMachine;
        public Animation animationController { get; private set; }
        public AudioSource audioSource { get; private set; }
        private ZapparInstantTrackingTarget zapparInstantTrackingTarget;

        public delegate void LetsGoClickedEventHandler();
        public event LetsGoClickedEventHandler OnLetsGoClickedEvent;

        public delegate void CollaborationClickedEventHandler();
        public event CollaborationClickedEventHandler OnCollaborationClickedEvent;

        public delegate void PresentationExitEventHandler();
        public event PresentationExitEventHandler OnPresentationExitEventHandler;

        public delegate void ShowMenuEvent();
        public event ShowMenuEvent OnShowMenu;
        
        private int talkAudioIndex = 0;
        private string animationName = "";

        private string currentAnimationName = "";
        private int currentFrame;
        private bool alreadySet = false;

        void Awake()
        {
            animationController = GetComponent<Animation>();
            audioSource = GetComponent<AudioSource>();
            if (!alreadySet)
            {
                alreadySet = true;
                InvokeRepeating("GetAnimationInfo", 0f,  0.000015f);
            }
        }

        public void ShowHand()
        {
            hand.gameObject.SetActive(true);
        }

        public void HideHand()
        {
            hand.gameObject.SetActive(false);
        }


        void GetAnimationInfo()
        {
            Debug.Log("GetAnimationInfo");
            if (animationName != "")
            {
                AnimationState currentAnimationState = animationController[animationName];
            currentAnimationName = currentAnimationState.name;
            float currentTimeInSeconds = currentAnimationState.time;
            float framesPerSecond = 30f;
            currentFrame = Mathf.FloorToInt(currentTimeInSeconds * framesPerSecond);

            Debug.Log(currentAnimationName);

            switch (currentAnimationName)
            {
                case "Tremilique":
                    if (currentFrame == 9)
                    {
                        PlaySFX(sfxList[1]);
                    }
                break;
                case "Montagem_1":
                    if (currentFrame == 2)
                    {
                        PlaySFX(sfxList[2]);
                    }
                break;
                case "Montagem_2":
                    if (currentFrame == 3)
                    {
                        PlaySFX(sfxList[3]);
                    }
                break;
                case "Montagem_3":
                    if (currentFrame == 2)
                    {
                        PlaySFX(sfxList[4]);
                    }
                break;
                case "Explosao":
                    if (currentFrame == 2)
                    {
                        StopHover();
                        PlaySFX(sfxList[5]);
                    }
                    if (currentFrame == 170)
                    {
                        eyeMaterial.mainTexture = eyeList[0];
                    }
                    else if (currentFrame == 171)
                    {
                        PlayHover();
                        eyeMaterial.mainTexture = eyeList[5];
                    }
                    else if (currentFrame == 172)
                    {
                        eyeMaterial.mainTexture = eyeList[4];
                    }
                    else if (currentFrame == 173)
                    {
                        eyeMaterial.mainTexture = eyeList[3];
                    }
                    else if (currentFrame == 181)
                    {
                        eyeMaterial.mainTexture = eyeList[3];
                    }
                    else if (currentFrame == 182)
                    {
                        eyeMaterial.mainTexture = eyeList[5];
                    }
                    else if (currentFrame == 183)
                    {
                        eyeMaterial.mainTexture = eyeList[0];
                    }
                    else if (currentFrame == 184)
                    {
                        eyeMaterial.mainTexture = eyeList[4];
                    }
                    else if (currentFrame == 185)
                    {
                        eyeMaterial.mainTexture = eyeList[3];
                    }
                    else if (currentFrame == 186)
                    {
                        eyeMaterial.mainTexture = eyeList[4];
                    }
                    else if (currentFrame == 187)
                    {
                        eyeMaterial.mainTexture = eyeList[5];
                    }
                    else if (currentFrame == 188)
                    {
                        eyeMaterial.mainTexture = eyeList[3];
                    }
                    else if (currentFrame == 189)
                    {
                        eyeMaterial.mainTexture = eyeList[2];
                    }
                    else if (currentFrame == 190)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                    else if (currentFrame == 210)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                break;
                case "Chacoalha":
                    if (currentFrame == 27)
                    {
                        PlaySFX(sfxList[6]);
                    }
                    if (currentFrame == 1)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                    else if (currentFrame == 6)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                    else if (currentFrame == 7)
                    {
                        eyeMaterial.mainTexture = eyeList[3];
                    }
                    else if (currentFrame == 8)
                    {
                        eyeMaterial.mainTexture = eyeList[0];
                    }
                    else if (currentFrame == 9)
                    {
                        eyeMaterial.mainTexture = eyeList[5]; 
                    }
                    else if (currentFrame == 10)
                    {
                        eyeMaterial.mainTexture = eyeList[2];
                    }
                    else if (currentFrame == 11)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                    else if (currentFrame == 24)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                    else if (currentFrame == 25)
                    {
                        eyeMaterial.mainTexture = eyeList[9];
                    }
                    else if (currentFrame == 26)
                    {
                        eyeMaterial.mainTexture = eyeList[10];
                    }
                    else if (currentFrame == 27)
                    {
                        eyeMaterial.mainTexture = eyeList[0];
                    }
                    else if (currentFrame == 52)
                    {
                        eyeMaterial.mainTexture = eyeList[0];
                    }
                    else if (currentFrame == 53)
                    {
                        eyeMaterial.mainTexture = eyeList[10];
                    }
                    else if (currentFrame == 54)
                    {
                        eyeMaterial.mainTexture = eyeList[9];
                    }
                    else if (currentFrame == 55)
                    {
                        eyeMaterial.mainTexture = eyeList[8];
                    }
                    else if (currentFrame == 56)
                    {
                        eyeMaterial.mainTexture = eyeList[7];
                    }
                    else if (currentFrame == 57)
                    {
                        eyeMaterial.mainTexture = eyeList[6];
                    }
                    else if (currentFrame == 58)
                    {
                        eyeMaterial.mainTexture = eyeList[6];
                    }
                    else if (currentFrame == 70)
                    {
                        eyeMaterial.mainTexture = eyeList[6];
                    }
                break;
                case "Curious":
                    if (currentFrame == 4)
                    {
                        PlaySFX(sfxList[7]);
                    }

                    if (currentFrame == 1)
                    {
                        eyeMaterial.mainTexture = eyeList[6];
                    }
                    else if (currentFrame == 7)
                    {
                        eyeMaterial.mainTexture = eyeList[6];
                    }
                    else if (currentFrame == 8)
                    {
                        eyeMaterial.mainTexture = eyeList[8];
                    }
                    else if (currentFrame == 9)
                    {
                        eyeMaterial.mainTexture = eyeList[9];
                    }
                    else if (currentFrame == 10)
                    {
                        eyeMaterial.mainTexture = eyeList[10]; 
                    }
                    else if (currentFrame == 11)
                    {
                        eyeMaterial.mainTexture = eyeList[0];
                    }
                    else if (currentFrame == 16)
                    {
                        eyeMaterial.mainTexture = eyeList[0];
                    }
                    else if (currentFrame == 17)
                    {
                        eyeMaterial.mainTexture = eyeList[10];
                    }
                    else if (currentFrame == 18)
                    {
                        eyeMaterial.mainTexture = eyeList[8];
                    }
                    else if (currentFrame == 19)
                    {
                        eyeMaterial.mainTexture = eyeList[7];
                    }
                    else if (currentFrame == 20)
                    {
                        eyeMaterial.mainTexture = eyeList[6];
                    }
                    else if (currentFrame == 69)
                    {
                        eyeMaterial.mainTexture = eyeList[6];
                    }
                    else if (currentFrame == 70)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                    else if (currentFrame == 71)
                    {
                        eyeMaterial.mainTexture = eyeList[3];
                    }
                    else if (currentFrame == 72)
                    {
                        eyeMaterial.mainTexture = eyeList[0];
                    }
                    else if (currentFrame == 73)
                    {
                        eyeMaterial.mainTexture = eyeList[5];
                    }
                    else if (currentFrame == 74)
                    {
                        eyeMaterial.mainTexture = eyeList[2];
                    }
                    else if (currentFrame == 75)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                    else if (currentFrame == 96)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                break;
                case "Excited":
                    if (currentFrame == 25)
                    {
                        PlaySFX(sfxList[8]);
                    }

                    if (currentFrame == 1)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                    else if (currentFrame == 18)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                    else if (currentFrame == 19)
                    {
                        eyeMaterial.mainTexture = eyeList[2];
                    }
                    else if (currentFrame == 20)
                    {
                        eyeMaterial.mainTexture = eyeList[3];
                    }
                    else if (currentFrame == 21)
                    {
                        eyeMaterial.mainTexture = eyeList[3]; 
                    }
                    else if (currentFrame == 22)
                    {
                        eyeMaterial.mainTexture = eyeList[2];
                    }
                    else if (currentFrame == 23)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                    else if (currentFrame == 27)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                    else if (currentFrame == 28)
                    {
                        eyeMaterial.mainTexture = eyeList[2];
                    }
                    else if (currentFrame == 29)
                    {
                        eyeMaterial.mainTexture = eyeList[3];
                    }
                    else if (currentFrame == 30)
                    {
                        eyeMaterial.mainTexture = eyeList[4];
                    }
                    else if (currentFrame == 31)
                    {
                        eyeMaterial.mainTexture = eyeList[5];
                    }
                    else if (currentFrame == 32)
                    {
                        eyeMaterial.mainTexture = eyeList[0];
                    }
                    else if (currentFrame == 110)
                    {
                        eyeMaterial.mainTexture = eyeList[0];
                    }
                    else if (currentFrame == 111)
                    {
                        eyeMaterial.mainTexture = eyeList[5];
                    }
                    else if (currentFrame == 112)
                    {
                        eyeMaterial.mainTexture = eyeList[10];
                    }
                    else if (currentFrame == 113)
                    {
                        eyeMaterial.mainTexture = eyeList[9];
                    }
                    else if (currentFrame == 114)
                    {
                        eyeMaterial.mainTexture = eyeList[8];
                    }
                    else if (currentFrame == 115)
                    {
                        eyeMaterial.mainTexture = eyeList[7];
                    }
                    else if (currentFrame == 116)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                    else if (currentFrame == 117)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                break;
                case "Happy":
                    if (currentFrame == 6)
                    {
                        PlaySFX(sfxList[9]);
                    }

                    if (currentFrame == 1)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                    else if (currentFrame == 3)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                    else if (currentFrame == 4)
                    {
                        eyeMaterial.mainTexture = eyeList[2];
                    }
                    else if (currentFrame == 5)
                    {
                        eyeMaterial.mainTexture = eyeList[4];
                    }
                    else if (currentFrame == 6)
                    {
                        eyeMaterial.mainTexture = eyeList[0]; 
                    }
                    else if (currentFrame == 7)
                    {
                        eyeMaterial.mainTexture = eyeList[0];
                    }
                    else if (currentFrame == 8)
                    {
                        eyeMaterial.mainTexture = eyeList[10];
                    }
                    else if (currentFrame == 9)
                    {
                        eyeMaterial.mainTexture = eyeList[9];
                    }
                    else if (currentFrame == 10)
                    {
                        eyeMaterial.mainTexture = eyeList[8];
                    }
                    else if (currentFrame == 16)
                    {
                        eyeMaterial.mainTexture = eyeList[8];
                    }
                    else if (currentFrame == 17)
                    {
                        eyeMaterial.mainTexture = eyeList[9];
                    }
                    else if (currentFrame == 18)
                    {
                        eyeMaterial.mainTexture = eyeList[10];
                    }
                    else if (currentFrame == 23)
                    {
                        eyeMaterial.mainTexture = eyeList[10];
                    }
                    else if (currentFrame == 24)
                    {
                        eyeMaterial.mainTexture = eyeList[5];
                    }
                    else if (currentFrame == 25)
                    {
                        eyeMaterial.mainTexture = eyeList[0];
                    }
                    else if (currentFrame == 26)
                    {
                        eyeMaterial.mainTexture = eyeList[0];
                    }
                    else if (currentFrame == 27)
                    {
                        eyeMaterial.mainTexture = eyeList[5];
                    }
                    else if (currentFrame == 28)
                    {
                        eyeMaterial.mainTexture = eyeList[10];
                    }
                    else if (currentFrame == 29)
                    {
                        eyeMaterial.mainTexture = eyeList[9];
                    }
                    else if (currentFrame == 30)
                    {
                        eyeMaterial.mainTexture = eyeList[8];
                    }
                    else if (currentFrame == 31)
                    {
                        eyeMaterial.mainTexture = eyeList[7];
                    }
                    else if (currentFrame == 35)
                    {
                        eyeMaterial.mainTexture = eyeList[7];
                    }
                    else if (currentFrame == 36)
                    {
                        eyeMaterial.mainTexture = eyeList[8];
                    }
                    else if (currentFrame == 37)
                    {
                        eyeMaterial.mainTexture = eyeList[9];
                    }
                    else if (currentFrame == 38)
                    {
                        eyeMaterial.mainTexture = eyeList[10];
                    }
                    else if (currentFrame == 39)
                    {
                        eyeMaterial.mainTexture = eyeList[10]; 
                    }
                    else if (currentFrame == 44)
                    {
                        eyeMaterial.mainTexture = eyeList[10];
                    }
                    else if (currentFrame == 45)
                    {
                        eyeMaterial.mainTexture = eyeList[5];
                    }
                    else if (currentFrame == 46)
                    {
                        eyeMaterial.mainTexture = eyeList[5];
                    }
                    else if (currentFrame == 47)
                    {
                        eyeMaterial.mainTexture = eyeList[10];
                    }
                    else if (currentFrame == 48)
                    {
                        eyeMaterial.mainTexture = eyeList[9];
                    }
                    else if (currentFrame == 49)
                    {
                        eyeMaterial.mainTexture = eyeList[8];
                    }
                    else if (currentFrame == 50)
                    {
                        eyeMaterial.mainTexture = eyeList[7];
                    }
                    else if (currentFrame == 51)
                    {
                        eyeMaterial.mainTexture = eyeList[6];
                    }
                    else if (currentFrame == 53)
                    {
                        eyeMaterial.mainTexture = eyeList[6];
                    }
                    else if (currentFrame == 54)
                    {
                        eyeMaterial.mainTexture = eyeList[7];
                    }
                    else if (currentFrame == 55)
                    {
                        eyeMaterial.mainTexture = eyeList[8];
                    }
                    else if (currentFrame == 56)
                    {
                        eyeMaterial.mainTexture = eyeList[9];
                    }
                    else if (currentFrame == 57)
                    {
                        eyeMaterial.mainTexture = eyeList[10];
                    }
                    else if (currentFrame == 58)
                    {
                        eyeMaterial.mainTexture = eyeList[4];
                    }
                    else if (currentFrame == 59)
                    {
                        eyeMaterial.mainTexture = eyeList[5];
                    }
                    else if (currentFrame == 60)
                    {
                        eyeMaterial.mainTexture = eyeList[0];
                    }
                    else if (currentFrame == 77)
                    {
                        eyeMaterial.mainTexture = eyeList[0];
                    }
                    else if (currentFrame == 78)
                    {
                        eyeMaterial.mainTexture = eyeList[5];
                    }
                    else if (currentFrame == 79)
                    {
                        eyeMaterial.mainTexture = eyeList[10];
                    }
                    else if (currentFrame == 80)
                    {
                        eyeMaterial.mainTexture = eyeList[9];
                    }
                    else if (currentFrame == 81)
                    {
                        eyeMaterial.mainTexture = eyeList[8];
                    }
                    else if (currentFrame == 82)
                    {
                        eyeMaterial.mainTexture = eyeList[7];
                    }
                    else if (currentFrame == 83)
                    {
                        eyeMaterial.mainTexture = eyeList[6];
                    }
                    else if (currentFrame == 94)
                    {
                        eyeMaterial.mainTexture = eyeList[6];
                    }
                break;
                case "Idle_Hover":
                    if (currentFrame == 69)
                    {
                        PlaySFX(sfxList[10]);
                    }

                    if (currentFrame == 1)
                    {
                        eyeMaterial.mainTexture = eyeList[6];
                    }
                    else if (currentFrame == 19)
                    {
                        eyeMaterial.mainTexture = eyeList[6];
                    }
                    else if (currentFrame == 20)
                    {
                        eyeMaterial.mainTexture = eyeList[3];
                    }
                    else if (currentFrame == 21)
                    {
                        eyeMaterial.mainTexture = eyeList[0];
                    }
                    else if (currentFrame == 22)
                    {
                        eyeMaterial.mainTexture = eyeList[5];
                    }
                    else if (currentFrame == 23)
                    {
                        eyeMaterial.mainTexture = eyeList[2];
                    }
                    else if (currentFrame == 24)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                    else if (currentFrame == 129)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                    else if (currentFrame == 130)
                    {
                        eyeMaterial.mainTexture = eyeList[3];
                    }
                    else if (currentFrame == 131)
                    {
                        eyeMaterial.mainTexture = eyeList[0];
                    }
                    else if (currentFrame == 132)
                    {
                        eyeMaterial.mainTexture = eyeList[5];
                    }
                    else if (currentFrame == 133)
                    {
                        eyeMaterial.mainTexture = eyeList[2];
                    }
                    else if (currentFrame == 134)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                    else if (currentFrame == 192)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                break;
                case "Talk":
                    if (currentFrame == 1)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                    else if (currentFrame == 2)
                    {
                        eyeMaterial.mainTexture = eyeList[7];
                    }
                    else if (currentFrame == 3)
                    {
                        eyeMaterial.mainTexture = eyeList[8];
                    }
                    else if (currentFrame == 13)
                    {
                        eyeMaterial.mainTexture = eyeList[9];
                    }
                    else if (currentFrame == 14)
                    {
                        eyeMaterial.mainTexture = eyeList[10];
                    }
                    else if (currentFrame == 19)
                    {
                        eyeMaterial.mainTexture = eyeList[9];
                    }
                    else if (currentFrame == 20)
                    {
                        eyeMaterial.mainTexture = eyeList[8];
                    }
                    else if (currentFrame == 21)
                    {
                        eyeMaterial.mainTexture = eyeList[7];
                    }
                    else if (currentFrame == 22)
                    {
                        eyeMaterial.mainTexture = eyeList[6];
                    }
                    else if (currentFrame == 35)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                    else if (currentFrame == 36)
                    {
                        eyeMaterial.mainTexture = eyeList[3];
                    }
                    else if (currentFrame == 37)
                    {
                        eyeMaterial.mainTexture = eyeList[0];
                    }
                    else if (currentFrame == 38)
                    {
                        eyeMaterial.mainTexture = eyeList[5];
                    }
                    else if (currentFrame == 39)
                    {
                        eyeMaterial.mainTexture = eyeList[2];
                    }
                    else if (currentFrame == 40)
                    {
                        eyeMaterial.mainTexture = eyeList[6];
                    }
                    else if (currentFrame == 48)
                    {
                        eyeMaterial.mainTexture = eyeList[8];
                    }
                    else if (currentFrame == 49)
                    {
                        eyeMaterial.mainTexture = eyeList[10];
                    }
                    else if (currentFrame == 50)
                    {
                        eyeMaterial.mainTexture = eyeList[5];
                    }
                    else if (currentFrame == 51)
                    {
                        eyeMaterial.mainTexture = eyeList[0];
                    }
                    else if (currentFrame == 61)
                    {
                        eyeMaterial.mainTexture = eyeList[5];
                    }
                    else if (currentFrame == 62)
                    {
                        eyeMaterial.mainTexture = eyeList[9];
                    }
                    else if (currentFrame == 63)
                    {
                        eyeMaterial.mainTexture = eyeList[8];
                    }
                    else if (currentFrame == 64)
                    {
                        eyeMaterial.mainTexture = eyeList[7];
                    }
                    else if (currentFrame == 87)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                    else if (currentFrame == 88)
                    {
                        eyeMaterial.mainTexture = eyeList[3];
                    }
                    else if (currentFrame == 89)
                    {
                        eyeMaterial.mainTexture = eyeList[0];
                    }
                    else if (currentFrame == 90)
                    {
                        eyeMaterial.mainTexture = eyeList[5];
                    }
                    else if (currentFrame == 91)
                    {
                        eyeMaterial.mainTexture = eyeList[2];
                    }
                    else if (currentFrame == 102)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                    else if (currentFrame == 103)
                    {
                        eyeMaterial.mainTexture = eyeList[8];
                    }
                    else if (currentFrame == 104)
                    {
                        eyeMaterial.mainTexture = eyeList[9];
                    }
                    else if (currentFrame == 115)
                    {
                        eyeMaterial.mainTexture = eyeList[9];
                    }
                    else if (currentFrame == 116)
                    {
                        eyeMaterial.mainTexture = eyeList[10];
                    }
                    else if (currentFrame == 117)
                    {
                        eyeMaterial.mainTexture = eyeList[5];
                    }
                    else if (currentFrame == 118)
                    {
                        eyeMaterial.mainTexture = eyeList[4];
                    }
                    else if (currentFrame == 119)
                    {
                        eyeMaterial.mainTexture = eyeList[10];
                    }
                    else if (currentFrame == 120)
                    {
                        eyeMaterial.mainTexture = eyeList[8];
                    }
                    else if (currentFrame == 132)
                    {
                        eyeMaterial.mainTexture = eyeList[7];
                    }
                    else if (currentFrame == 133)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                    else if (currentFrame == 139)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                    else if (currentFrame == 140)
                    {
                        eyeMaterial.mainTexture = eyeList[3];
                    }
                    else if (currentFrame == 141)
                    {
                        eyeMaterial.mainTexture = eyeList[0];
                    }
                    else if (currentFrame == 142)
                    {
                        eyeMaterial.mainTexture = eyeList[5];
                    }
                    else if (currentFrame == 143)
                    {
                        eyeMaterial.mainTexture = eyeList[2];
                    }
                    else if (currentFrame == 144)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                break;
                case "Talk_Loop_1":
                    if (currentFrame == 1)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                    else if (currentFrame == 35)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                    else if (currentFrame == 36)
                    {
                        eyeMaterial.mainTexture = eyeList[3];
                    }
                    else if (currentFrame == 37)
                    {
                        eyeMaterial.mainTexture = eyeList[0];
                    }
                    else if (currentFrame == 38)
                    {
                        eyeMaterial.mainTexture = eyeList[5];
                    }
                    else if (currentFrame == 39)
                    {
                        eyeMaterial.mainTexture = eyeList[2];
                    }
                    else if (currentFrame == 40)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                break;
                case "Talk_Loop_2":
                    if (currentFrame == 1)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                    else if (currentFrame == 17)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                    else if (currentFrame == 18)
                    {
                        eyeMaterial.mainTexture = eyeList[3];
                    }
                    else if (currentFrame == 19)
                    {
                        eyeMaterial.mainTexture = eyeList[0];
                    }
                    else if (currentFrame == 20)
                    {
                        eyeMaterial.mainTexture = eyeList[5];
                    }
                    else if (currentFrame == 21)
                    {
                        eyeMaterial.mainTexture = eyeList[2];
                    }
                    else if (currentFrame == 22)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                     else if (currentFrame == 34)
                    {
                        eyeMaterial.mainTexture = eyeList[8];
                    }
                     else if (currentFrame == 35)
                    {
                        eyeMaterial.mainTexture = eyeList[9];
                    }
                     else if (currentFrame == 47)
                    {
                        eyeMaterial.mainTexture = eyeList[10];
                    }
                     else if (currentFrame == 48)
                    {
                        eyeMaterial.mainTexture = eyeList[5];
                    }
                     else if (currentFrame == 49)
                    {
                        eyeMaterial.mainTexture = eyeList[4];
                    }
                     else if (currentFrame == 50)
                    {
                        eyeMaterial.mainTexture = eyeList[10];
                    }
                     else if (currentFrame == 51)
                    {
                        eyeMaterial.mainTexture = eyeList[8];
                    }
                     else if (currentFrame == 63)
                    {
                        eyeMaterial.mainTexture = eyeList[7];
                    }
                    else if (currentFrame == 69)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                    else if (currentFrame == 70)
                    {
                        eyeMaterial.mainTexture = eyeList[3];
                    }
                    else if (currentFrame == 71)
                    {
                        eyeMaterial.mainTexture = eyeList[0];
                    }
                    else if (currentFrame == 72)
                    {
                        eyeMaterial.mainTexture = eyeList[5];
                    }
                    else if (currentFrame == 73)
                    {
                        eyeMaterial.mainTexture = eyeList[2];
                    }
                    else if (currentFrame == 74)
                    {
                        eyeMaterial.mainTexture = eyeList[1];
                    }
                break;
                case "Hover_Simples":
                PlayHover();
                break;
                default:
                break;
            }
            }
        }

        public void PlayAnimation(string name)
        {
            animationName = name;
            animationController.CrossFade(name);
        }

        public void PlayNextTalkAudio()
        {
            Debug.Log(talkAudioIndex);
            audioSource.PlayOneShot(talkAudios[talkAudioIndex]);
            talkAudioIndex++;
        }

        void Update()
        {
            stateMachine?.Update();
        }

        public void SetZapparInstantTrackingTarget(ZapparInstantTrackingTarget zapparInstantTrackingTarget)
        {
            stateMachine = new StateMachine(zapparInstantTrackingTarget, this);
            stateMachine.OnPresentationExitEventHandler += HandlePresentationExit;
        }

        private void HandlePresentationExit()
        {
            OnPresentationExitEventHandler();
        }

        public void LetsGoClicked()
        {
            OnLetsGoClickedEvent();
        }

        public void CollaborationClicked()
        {
            OnCollaborationClickedEvent();
        }

        public void PlayQueue(string name)
        {
            animationController.PlayQueued(name);
        }

        public void ShowMenu()
        {
            OnShowMenu();
        }

        public void SetCubeIndexTalkToMenu()
        {
            talkAudioIndex = 11;
        }

        public void PlaySFX(AudioClip audioClip)
        {
            Debug.Log("PlaYSFX: " + name);
            sfxSource.PlayOneShot(audioClip);
        }

        public void PlayHover()
        {
            hoverSource.PlayOneShot(hoverClip);
        }
        public void StopHover()
        {
            hoverSource.Stop();
        }
    }
}