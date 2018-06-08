using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceTraining : MonoBehaviour
{
   
        public Rigidbody rb;
        private float tmp;

        private float timerfast;
        private float timerslow;
        private float timerghost;
        private float timerwalls;

        private float timersafe;
        private float timerstart;

        private void Start()
        {
            tmp = Time.time;
        }

        void Update()
        {
            timerfast = rb.GetComponent<PlayerControllerTraining>().tpsBonus1 - Time.time + 7;
            timerslow = rb.GetComponent<PlayerControllerTraining>().tpsBonus2 - Time.time + 7;
            timerghost = rb.GetComponent<PlayerControllerTraining>().tpsBonus3 - Time.time + 7;
            timerwalls = rb.GetComponent<PlayerControllerTraining>().tpsBonus4 - Time.time + 7;

            timersafe = rb.GetComponent<WallCreaterTraining>().tpsSafe - Time.time + 5;
            timerstart = rb.GetComponent<PlayerControllerTraining>().tpsStart - Time.time + 5;
        }

        public Texture robot;


        public GUISkin SafeZoneskin;
        public GUISkin Normalskin;
        public GUISkin Speedskin;
        public GUISkin Slowskin;
        public GUISkin Gohstskin;
        public GUISkin BigWallskin;

        private bool Istalkingspeed = false;
        private bool Istalkingslow = false;
        private bool Istalkingghost = false;
        private bool Istalkingbigwalls = false;

        private void OnGUI()
        {
            if (Time.time > tmp + 7.0f)
            {

                if (timerfast >= 0.0f)
                {
                    GUI.skin.box = Speedskin.box;
                    GUI.Box(new Rect(Screen.width - 100, (Screen.height / 2) + 10, 75, 75), timerfast.ToString("0"));

                   
                    if (!Istalkingbigwalls && !Istalkingghost && !Istalkingslow)
                    {
                        Istalkingspeed = true;
                        GUI.skin.box = Normalskin.box;
                        GUI.Box(new Rect(Screen.width / 6, 0, Screen.width - (Screen.height / 4) - (Screen.width / 6) - 50, Screen.height / 8), "You go faaaaaaaaaast");
                    }
                }
                else
                {
                    Istalkingspeed = false;
                }

                if (timerslow >= 0.0f)
                {
                    GUI.skin.box = Slowskin.box;

                    GUI.Box(new Rect(Screen.width - 100, (Screen.height / 2) - 75, 75, 75), timerslow.ToString("0"));


                    
                    if (!Istalkingbigwalls && !Istalkingghost && !Istalkingspeed)
                    {
                        Istalkingslow = true;
                        GUI.skin.box = Normalskin.box;
                        GUI.Box(new Rect(Screen.width / 6, 0, Screen.width - (Screen.height / 4) - (Screen.width / 6) - 50, Screen.height / 8), "you speed is deacresed for more precision");
                    }
                }
                else
                {
                    Istalkingslow = false;
                }

                if (timerghost >= 0.0f)
                {

                    GUI.skin.box = Gohstskin.box;
                    GUI.Box(new Rect(Screen.width - 100, (Screen.height / 2) + 95, 75, 75), timerghost.ToString("0"));

                    

                    if (!Istalkingbigwalls && !Istalkingslow && !Istalkingspeed)
                    {
                        Istalkingghost = true;
                        GUI.skin.box = Normalskin.box;
                        GUI.Box(new Rect(Screen.width / 6, 0, Screen.width - (Screen.height / 4) - (Screen.width / 6) - 50, Screen.height / 8), "you can go through any wall");
                    }
                }
                else
                {
                    Istalkingghost = false;
                }

                if (timerwalls >= 0.0f)
                {
                    GUI.skin.box = BigWallskin.box;

                    GUI.Box(new Rect(Screen.width - 100, (Screen.height / 2) - 160, 75, 75), timerwalls.ToString("0"));


                    

                    if (!Istalkingghost && !Istalkingslow && !Istalkingspeed)
                    {
                        Istalkingbigwalls = true;
                        GUI.skin.box = Normalskin.box;
                        GUI.Box(new Rect(Screen.width / 6, 0, Screen.width - (Screen.height / 4) - (Screen.width / 6) - 50, Screen.height / 8), "This one makes you create \n huge walls that can t be jumed over");
                    }
                }
                else
                {
                    Istalkingbigwalls = false;
                }
            }

            if (timersafe >= 0.0f && rb.GetComponent<WallCreaterTraining>().isSafe)
            {
                GUI.skin.box = SafeZoneskin.box;

                GUI.Box(new Rect(Screen.width - 100, (Screen.height / 2) - 245, 75, 75), timersafe.ToString("0"));
            }

            if (timerstart >= 0.0f && rb.GetComponent<PlayerControllerTraining>().isStopped)
            {
                if (timerstart >= 3.0f)
                {
                    GUI.skin.box = Normalskin.box;
                    GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2, 300, 50), "GET READY");
                }
                else
                {
                    GUI.skin.box = Normalskin.box;
                    GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2, 300, 50), timerstart.ToString("0"));
                }
            }
        }
    }


	