using UnityEngine;

public class InterfaceSolo : MonoBehaviour
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
        timerfast = rb.GetComponent<PlayerControllerSolo>().tpsBonus1 - Time.time + 7;
        timerslow = rb.GetComponent<PlayerControllerSolo>().tpsBonus2 - Time.time + 7;
        timerghost = rb.GetComponent<PlayerControllerSolo>().tpsBonus3 - Time.time + 7;
        timerwalls = rb.GetComponent<PlayerControllerSolo>().tpsBonus4 - Time.time + 7;

        timersafe = rb.GetComponent<WallCreaterSolo>().tpsSafe - Time.time + 5;
        timerstart = rb.GetComponent<PlayerControllerSolo>().tpsStart - Time.time + 5;
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

                GUI.Box(new Rect((Screen.width - (Screen.height / 4) - 10), 0, Screen.height / 4, Screen.height / 4), robot);
                if (!Istalkingbigwalls && !Istalkingghost && !Istalkingslow)
                {
                    Istalkingspeed = true;
                    GUI.skin.box = Normalskin.box;
                    GUI.Box(new Rect(Screen.width / 6, 0, Screen.width - (Screen.height / 4) - (Screen.width / 6) - 50, Screen.height / 8), "You will never be as fast as I am ! \n \n  Because I, and only I am the best !");
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


                GUI.Box(new Rect((Screen.width - (Screen.height / 4) - 10), 0, Screen.height / 4, Screen.height / 4), robot);
                if (!Istalkingbigwalls && !Istalkingghost && !Istalkingspeed)
                {
                    Istalkingslow = true;
                    GUI.skin.box = Normalskin.box;
                    GUI.Box(new Rect(Screen.width / 6, 0, Screen.width - (Screen.height / 4) - (Screen.width / 6) - 50, Screen.height / 8), "Super secret Snail Jutsu !");
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

                GUI.Box(new Rect((Screen.width - (Screen.height / 4) - 10), 0, Screen.height / 4, Screen.height / 4), robot);

                if (!Istalkingbigwalls && !Istalkingslow && !Istalkingspeed)
                {
                    Istalkingghost = true;
                    GUI.skin.box = Normalskin.box;
                    GUI.Box(new Rect(Screen.width / 6, 0, Screen.width - (Screen.height / 4) - (Screen.width / 6) - 50, Screen.height / 8), "YOU SHALL NOT ... \n \n  Oh well okay you got me...");
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


                GUI.Box(new Rect((Screen.width - (Screen.height / 4) - 10), 0, Screen.height / 4, Screen.height / 4), robot);

                if (!Istalkingghost && !Istalkingslow && !Istalkingspeed)
                {
                    Istalkingbigwalls = true;
                    GUI.skin.box = Normalskin.box;
                    GUI.Box(new Rect(Screen.width / 6, 0, Screen.width - (Screen.height / 4) - (Screen.width / 6) - 50, Screen.height / 8), "THEY SHALL NOT PASS !!");
                }
            }
            else
            {
                Istalkingbigwalls = false;
            }
        }

        if (timersafe >= 0.0f && rb.GetComponent<WallCreaterSolo>().isSafe)
        {
            GUI.skin.box = SafeZoneskin.box;

            GUI.Box(new Rect(Screen.width - 100, (Screen.height / 2) - 245, 75, 75), timersafe.ToString("0"));
        }

        if (timerstart >= 0.0f && rb.GetComponent<PlayerControllerSolo>().isStopped)
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

