using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabloController : MonoBehaviour {

    public Image level;
    public Image rolls;

    public Image level0;

    public Image score0;
    public Image score1;
    public Image score2;


    public Sprite sc0;
    public Sprite sc1;
    public Sprite sc2;
    public Sprite sc3;
    public Sprite sc4;
    public Sprite sc5;
    public Sprite sc6;
    public Sprite sc7;
    public Sprite sc8;
    public Sprite sc9;

    public Sprite lv1;
    public Sprite lv2;
    public Sprite lv3;
    public Sprite lv4;
    public Sprite lv5;
    public Sprite lv6;
    public Sprite lv7;

    public Sprite nr3;
    public Sprite nr4;
    public Sprite nr5;

    public void SetScore(int value)
    {
        value %= 1000;
        int int000 = value / 100;
        int int00 = (value - (int000 * 100)) / 10;
        int int0 = value % 10;

        if (value < 0)
        {
            score0.enabled = false;
            score1.enabled = false;
            score2.enabled = false;
        }
        else
        {
            score0.enabled = true;
            score1.enabled = true;
            score2.enabled = true;

            switch (int000)
            {
                case 0: score0.sprite = sc0; break;
                case 1: score0.sprite = sc1; break;
                case 2: score0.sprite = sc2; break;
                case 3: score0.sprite = sc3; break;
                case 4: score0.sprite = sc4; break;
                case 5: score0.sprite = sc5; break;
                case 6: score0.sprite = sc6; break;
                case 7: score0.sprite = sc7; break;
                case 8: score0.sprite = sc8; break;
                case 9: score0.sprite = sc9; break;
                default: score0.enabled = false; break;
            }

            switch (int00)
            {
                case 0: score1.sprite = sc0; break;
                case 1: score1.sprite = sc1; break;
                case 2: score1.sprite = sc2; break;
                case 3: score1.sprite = sc3; break;
                case 4: score1.sprite = sc4; break;
                case 5: score1.sprite = sc5; break;
                case 6: score1.sprite = sc6; break;
                case 7: score1.sprite = sc7; break;
                case 8: score1.sprite = sc8; break;
                case 9: score1.sprite = sc9; break;
                default: score1.enabled = false; break;
            }

            switch (int0)
            {
                case 0: score2.sprite = sc0; break;
                case 1: score2.sprite = sc1; break;
                case 2: score2.sprite = sc2; break;
                case 3: score2.sprite = sc3; break;
                case 4: score2.sprite = sc4; break;
                case 5: score2.sprite = sc5; break;
                case 6: score2.sprite = sc6; break;
                case 7: score2.sprite = sc7; break;
                case 8: score2.sprite = sc8; break;
                case 9: score2.sprite = sc9; break;
                default: score2.enabled = false; break;
            }
        }
    }

    public void SetLevel(int l)
    {
        switch (l)
        {
            case 1: level.sprite = lv1; level0.sprite = sc1; break;
            case 2: level.sprite = lv2; level0.sprite = sc2; break;
            case 3: level.sprite = lv3; level0.sprite = sc3; break;
            case 4: level.sprite = lv4; level0.sprite = sc4; break;
            case 5: level.sprite = lv5; level0.sprite = sc5; break;
            case 6: level.sprite = lv6; level0.sprite = sc6; break;
            case 7: level.sprite = lv7; level0.sprite = sc7; break;
        }
    }

    public void SetRollers(int r)
    {
        switch (r)
        {
            case 3: rolls.sprite = nr3; break;
            case 4: rolls.sprite = nr4; break;
            case 5: rolls.sprite = nr5; break;
        }
    }
}
