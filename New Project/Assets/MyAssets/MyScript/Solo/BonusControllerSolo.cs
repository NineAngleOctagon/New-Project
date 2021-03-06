﻿using UnityEngine;

public class BonusControllerSolo : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject bonus1;
    public GameObject bonus2;
    public GameObject bonus3;
    public GameObject bonus4;

    public float gapBonus;
    private float tpsBonus;

    private void Start()
    {
        tpsBonus = Time.time + 0.5f;
    }

    void Update()
    {
        if (Time.time - tpsBonus >= gapBonus && !rb.GetComponent<GameOverSolo>().isOver)
        {
            float platform = Random.Range(0.0f, 3.0f);

            float posx;
            float posz;

            switch ((int)platform)
            {
                case 0:
                    posx = Random.Range(-75.0f, 75.0f);
                    posz = Random.Range(-75.0f, 75.0f);
                    break;
                case 1:
                    posx = Random.Range(-375.0f, -225.0f);
                    posz = Random.Range(-275.0f, -125.0f);
                    break;
                case 2:
                    posx = Random.Range(125.0f, 275.0f);
                    posz = Random.Range(-375.0f, -225.0f);
                    break;
                default:
                    posx = Random.Range(-70.0f, 70.0f);
                    posz = Random.Range(-70.0f, 70.0f);
                    break;
            }

            Vector3 position = new Vector3(posx, 1.0f, posz);

            int bonusType = (int)Random.Range(0f, 4.0f);
            switch (bonusType)
            {
                case 0:
                    Instantiate(bonus1, position, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(bonus2, position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(bonus3, position, Quaternion.identity);
                    break;
                default:
                    Instantiate(bonus4, position, Quaternion.identity);
                    break;
            }

            tpsBonus = Time.time;
        }
    }
}
