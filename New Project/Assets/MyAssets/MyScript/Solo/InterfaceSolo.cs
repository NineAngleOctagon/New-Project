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
    }

    public Texture robot;
    private string robottalk = "";

    public GUISkin SafeZoneskin;
    public GUISkin Normalskin;
    public GUISkin Speedskin;
    public GUISkin Slowskin;
    public GUISkin Gohstskin;
    public GUISkin BigWallskin;

    private void OnGUI()
    {
        if (Time.time > tmp + 7.0f)
        {

            if (timerfast >= 0.0f)
            {
                GUI.skin.box = Speedskin.box;

                robottalk = "You will never be as fast as I am ! \n \n  Because I, and only I am the best !";

                GUI.Box(new Rect(Screen.width - 100, (Screen.height / 2) + 10, 75, 75), timerfast.ToString("0"));
                GUI.skin.box = Normalskin.box;
                GUI.Box(new Rect(Screen.width / 6, 0, Screen.width - (Screen.height / 4) - (Screen.width / 6) - 50, Screen.height / 8), robottalk);
                GUI.Box(new Rect((Screen.width - (Screen.height / 4) - 10), 0, Screen.height / 4, Screen.height / 4), robot);
            }

            if (timerslow >= 0.0f)
            {
                GUI.skin.box = Slowskin.box;
                robottalk = "Super secret Snail Jutstu !";
                GUI.Box(new Rect(Screen.width - 100, (Screen.height / 2) - 75, 75, 75), timerslow.ToString("0"));
                GUI.skin.box = Normalskin.box;
                GUI.Box(new Rect(Screen.width / 6, 0, Screen.width - (Screen.height / 4) - (Screen.width / 6) - 50, Screen.height / 8), robottalk);
                GUI.Box(new Rect((Screen.width - (Screen.height / 4) - 10), 0, Screen.height / 4, Screen.height / 4), robot);
            }

            if (timerghost >= 0.0f)
            {
                GUI.skin.box = Gohstskin.box;
                robottalk = "YOU SHALL NOT ... \n \n  Oh well okay you got me...";
                GUI.Box(new Rect(Screen.width - 100, (Screen.height / 2) + 95, 75, 75), timerghost.ToString("0"));
                GUI.skin.box = Normalskin.box;
                GUI.Box(new Rect(Screen.width / 6, 0, Screen.width - (Screen.height / 4) - (Screen.width / 6) - 50, Screen.height / 8), robottalk);
                GUI.Box(new Rect((Screen.width - (Screen.height / 4) - 10), 0, Screen.height / 4, Screen.height / 4), robot);
            }

            if (timerwalls >= 0.0f)
            {
                GUI.skin.box = BigWallskin.box;
                robottalk = "THEY SHALL NOT PASS !!";
                GUI.Box(new Rect(Screen.width - 100, (Screen.height / 2) - 160, 75, 75), timerwalls.ToString("0"));
                GUI.skin.box = Normalskin.box;
                GUI.Box(new Rect(Screen.width / 6, 0, Screen.width - (Screen.height / 4) - (Screen.width / 6) - 50, Screen.height / 8), robottalk);
                GUI.Box(new Rect((Screen.width - (Screen.height / 4) - 10), 0, Screen.height / 4, Screen.height / 4), robot);
            }
        }

        if (timersafe >= 0.0f && rb.GetComponent<WallCreaterSolo>().isSafe)
        {
            GUI.skin.box = SafeZoneskin.box;

            GUI.Box(new Rect(Screen.width - 100, (Screen.height / 2) - 245, 75, 75), timersafe.ToString("0"));
        }
    }
}

