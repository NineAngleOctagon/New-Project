using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Timer : NetworkBehaviour
{

    public Rigidbody rb;
    private float tmp;

    private float timerfast;
    private float timerslow;
    private float timerghost;
    private float timerwalls;

    private float timersafe;

    private GUIStyle stylefast = null;
    private GUIStyle styleslow = null;
    private GUIStyle styleghost = null;
    private GUIStyle stylewalls = null;

    private GUIStyle stylesafe = null;

    private void Start()
    {
        tmp = Time.time;
    }

    void Update()
    {
        timerfast = rb.GetComponent<PlayerController>().tpsBonus1 - Time.time + 7;
        timerslow = rb.GetComponent<PlayerController>().tpsBonus2 - Time.time + 7;
        timerghost = rb.GetComponent<PlayerController>().tpsBonus3 - Time.time + 7;
        timerwalls = rb.GetComponent<PlayerController>().tpsBonus4 - Time.time + 7;

        timersafe = rb.GetComponent<WallCreater>().tpsSafe - Time.time + 5;
    }

    private void OnGUI()
    {
        InitStyles();

        if (Time.time > tmp + 7.0f)
        {
            if (timerfast >= 0.0f)
            {
                GUI.skin.box.fontSize = 25;
                GUI.Box(new Rect(Screen.width - 100, 10, 75, 37.5f), timerfast.ToString("0"), stylefast);
            }
            if (timerslow >= 0.0f)
            {
                GUI.skin.box.fontSize = 25;
                GUI.Box(new Rect(Screen.width - 100, 30, 75, 37.5f), timerslow.ToString("0"), styleslow);
            }
            if (timerghost >= 0.0f)
            {
                GUI.skin.box.fontSize = 25;
                GUI.Box(new Rect(Screen.width - 100, 50, 75, 37.5f), timerghost.ToString("0"), styleghost);
            }
            if (timerwalls >= 0.0f)
            {
                GUI.skin.box.fontSize = 25;
                GUI.Box(new Rect(Screen.width - 100, 70, 75, 37.5f), timerwalls.ToString("0"), stylewalls);
            }
        }

        if (timersafe >= 0.0f && rb.GetComponent<WallCreater>().isSafe)
        {
            GUI.skin.box.fontSize = 25;
            GUI.Box(new Rect(Screen.width - 200, 10, 75, 37.5f), timersafe.ToString("0"));
        }
    }

    private void InitStyles()
    {
        if (stylefast == null)
        {
            stylefast = new GUIStyle(GUI.skin.box);
            stylefast.normal.background = MakeTex(2, 2, new Color(255f, 0f, 0f, 0.5f));
        }
        if (styleslow == null)
        {
            styleslow = new GUIStyle(GUI.skin.box);
            styleslow.normal.background = MakeTex(2, 2, new Color(0f, 255f, 255f, 0.5f));
        }
        if (styleghost == null)
        {
            styleghost = new GUIStyle(GUI.skin.box);
            styleghost.normal.background = MakeTex(2, 2, new Color(0f, 255f, 0, 0.5f));
        }
        if (stylewalls == null)
        {
            stylewalls = new GUIStyle(GUI.skin.box);
            stylewalls.normal.background = MakeTex(2, 2, new Color(255f, 255f, 0, 0.5f));
        }
    }

    private Texture2D MakeTex(int width, int height, Color col)
    {
        Color[] pix = new Color[width * height];
        for (int i = 0; i < pix.Length; ++i)
        {
            pix[i] = col;
        }
        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();
        return result;
    }
}
