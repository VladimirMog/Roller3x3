using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour {

    #region constants

    private const int NUMBER_ROLLS = 3;
    private static int NUMBER_STEPS = 4;

    private const int A = 0;
    private const int B = 1;
    private const int C = 2;
    private const int D = 3;
    private const int E = 4;

    private AudioSource audio;
    #endregion

    #region public vars
    public TabloController tabloController;
    //public Animator animPanel;
    public Toggle IsSoundOn;
    public FormController formCtrl;

    public GameObject go1;
    public GameObject go2;

    #region audioclips
    public AudioClip audioClipRoll;
    public AudioClip audioClipNext;
    public AudioClip audioClipOver;
    public AudioClip audioClipWin;
    #endregion

    #region animators 1 level

    public Animator animatorSpinnerA1;
    public Animator animatorSpinnerA2;
    public Animator animatorSpinnerA3;

    public Animator animatorSpinnerB1;
    public Animator animatorSpinnerB2;
    public Animator animatorSpinnerB3;


    public Animator animatorSpinnerC1;
    public Animator animatorSpinnerC2;
    public Animator animatorSpinnerC3;

    #endregion
    #region animators 2 level

    public Animator animator2SpinnerA1;
    public Animator animator2SpinnerA2;
    public Animator animator2SpinnerA3;

    public Animator animator2SpinnerB1;
    public Animator animator2SpinnerB2;
    public Animator animator2SpinnerB3;

    public Animator animator2SpinnerC1;
    public Animator animator2SpinnerC2;
    public Animator animator2SpinnerC3;

    #endregion

    #endregion
    private static Animator[,] anims;
    private static int[,] steps;
    private static System.Random rnd;
    private static int score = 0;
    private static int level = 1;


    void Start()
    {
        audio = GetComponent<AudioSource>();
        anims = new Animator[NUMBER_ROLLS, NUMBER_ROLLS + 1];
        score = 0;
        #region assign animators
        anims[A, 0] = null;
        anims[B, 0] = null;
        anims[C, 0] = null;

        #endregion

        steps = new int[NUMBER_ROLLS, NUMBER_ROLLS + 1];
        Reset();
    }
    public void Reset()
    {

        if (level == 1)
        {
            go1.SetActive(true);
            go2.SetActive(false);
            anims[A, 1] = animatorSpinnerA1;
            anims[A, 2] = animatorSpinnerA2;
            anims[A, 3] = animatorSpinnerA3;

            anims[B, 1] = animatorSpinnerB1;
            anims[B, 2] = animatorSpinnerB2;
            anims[B, 3] = animatorSpinnerB3;

            anims[C, 1] = animatorSpinnerC1;
            anims[C, 2] = animatorSpinnerC2;
            anims[C, 3] = animatorSpinnerC3;
        }
        else
        {
            go1.SetActive(false);
            go2.SetActive(true);
            anims[A, 1] = animator2SpinnerA1;
            anims[A, 2] = animator2SpinnerA2;
            anims[A, 3] = animator2SpinnerA3;

            anims[B, 1] = animator2SpinnerB1;
            anims[B, 2] = animator2SpinnerB2;
            anims[B, 3] = animator2SpinnerB3;

            anims[C, 1] = animator2SpinnerC1;
            anims[C, 2] = animator2SpinnerC2;
            anims[C, 3] = animator2SpinnerC3;
        }


        switch (level)
        {
            case 1: NUMBER_STEPS = 4; break;
            case 2: NUMBER_STEPS = 3; break;
            case 3: NUMBER_STEPS = 4; break;
            case 4: NUMBER_STEPS = 5; break;
            case 5: NUMBER_STEPS = 6; break;
            case 6: NUMBER_STEPS = 7; break;
            case 7: NUMBER_STEPS = 8; break;
        }
        rnd = new System.Random();
        for (int c = 0; c < NUMBER_ROLLS; c++)
            for (int d = 1; d <= NUMBER_ROLLS; d++)
            {
                steps[c, d] = rnd.Next(NUMBER_STEPS - 1);
            }
        for (int d = 1; d <= NUMBER_ROLLS; d++)
            for (int c = 0; c < NUMBER_ROLLS; c++)
            {
                Roll(c, d, true);
            }

        score = 5 * score + 20 * level;
        tabloController.SetScore(score);
        tabloController.SetLevel(level);
    }

    public void GotoToNextLevel()
    {
        level++;
        Reset();
    }

    void GameOver()
    {
        go1.SetActive(false);
        go2.SetActive(false);
        formCtrl.OnGameOver();
        if (IsSoundOn.isOn)
        {            
            audio.clip = audioClipOver;
            audio.Play();
        }
    }

    void PlayerWin()
    {
        go1.SetActive(false);
        go2.SetActive(false);

        formCtrl.OnNextLevel();
        if (IsSoundOn.isOn)
        {
            audio.clip = audioClipNext;
            audio.Play();
        }
    }

    void DecCount()
    {
        score--;

        int state = CheckGameState();

        if (state < 0) GameOver();
        if (state > 0) PlayerWin();

        tabloController.SetScore(score);
    }

    public void OnButtonClickA()
    {
        for (int d = 1; d <= NUMBER_ROLLS; d++) Roll(A, d);
        DecCount();
    }
    public void OnButtonClickB()
    {
        for (int d = 1; d <= NUMBER_ROLLS; d++) Roll(B, d);
        DecCount();
    }
    public void OnButtonClickC()
    {
        for (int d = 1; d <= NUMBER_ROLLS; d++) Roll(C, d);
        DecCount();
    }
    public void OnButtonClickL()
    {
        for (int d = 1; d <= NUMBER_ROLLS; d++) Roll(d - 1, d);
        DecCount();
    }
    public void OnButtonClickR()
    {
        for (int d = 1; d <= NUMBER_ROLLS; d++) Roll(NUMBER_ROLLS - d, d);
        DecCount();
    }



    private void Roll(int c, int d, bool silent = false)
    {
        Animator anim = anims[c, d];

        if (!silent && IsSoundOn.isOn)
        {
            audio = GetComponent<AudioSource>();
            audio.clip = audioClipRoll;
            audio.Play();
        }

        int step = steps[c, d];

        if (step < NUMBER_STEPS - 1) step++; else step = 0;
        if (level == 1)
        {
            switch (step)
            {
                case 0:
                    anim.Play("SpinAnim3");
                    break;
                case 1:
                    anim.Play("SpinAnim0");
                    break;
                case 2:
                    anim.Play("SpinAnim1");
                    break;
                case 3:
                    anim.Play("SpinAnim2");
                    break;
            }
        }
        else if (level == 2)
        {
            switch (step)
            {
                case 0:
                    anim.Play("Spin2Anim2");
                    break;
                case 1:
                    anim.Play("Spin2Anim0");
                    break;
                case 2:
                    anim.Play("Spin2Anim1");
                    break;
            }
        }
        else if (level == 3)
        {
            switch (step)
            {
                case 0:
                    anim.Play("Spin3Anim3");
                    break;
                case 1:
                    anim.Play("Spin3Anim0");
                    break;
                case 2:
                    anim.Play("Spin3Anim1"); Debug.Log("L3.Step: 2");
                    break;
                case 3:
                    anim.Play("Spin3Anim2"); Debug.Log("L3.Step: 3");
                    break;
            }
        }
        else if (level == 4)
        {
            switch (step)
            {
                case 0:
                    anim.Play("Spin4Anim4");
                    break;
                case 1:
                    anim.Play("Spin4Anim0");
                    break;
                case 2:
                    anim.Play("Spin4Anim1");
                    break;
                case 3:
                    anim.Play("Spin4Anim2"); Debug.Log("L4.Step: 3");
                    break;
                case 4:
                    anim.Play("Spin4Anim3"); Debug.Log("L4.Step: 4");
                    break;
            }
        }
        steps[c, d] = step;
    }


    public void OnButtonClick1()
    {
        for (int c = 0; c < NUMBER_ROLLS; c++) Roll(c, 1);
        DecCount();
    }
    public void OnButtonClick2()
    {
        for (int c = 0; c < NUMBER_ROLLS; c++) Roll(c, 2);
        DecCount();
    }
    public void OnButtonClick3()
    {
        for (int c = 0; c < NUMBER_ROLLS; c++) Roll(c, 3);
        DecCount();
    }
    public void OnButtonClick4()
    {
        for (int c = 0; c < NUMBER_ROLLS; c++) Roll(c, 4);
        DecCount();
    }
    public void OnButtonClick5()
    {
        for (int c = 0; c < NUMBER_ROLLS; c++) Roll(c, 5);
        DecCount();
    }


    private int CheckGameState()
    {
        int s_prev = -1;
        int s_next = 0;
        int s_deny = NUMBER_STEPS - 1;
        int cnt = 1;

        if (score <= 0) return -1;
        for (int c = 0; c < NUMBER_ROLLS; c++)
            for (int d = 1; d <= NUMBER_ROLLS; d++)
            {
                s_next = steps[c, d];
                if(level == 1)
                {
                    if (s_next % 2 == s_prev % 2) cnt++;
                }
                else
                {
                    if (s_next == s_prev) cnt++;
                }
                s_prev = s_next;
            }

        if ((cnt == NUMBER_ROLLS * NUMBER_ROLLS) && s_next != s_deny) return 1;
        return 0;
    }


    private void SetToFirstAll()
    {
        for (int c = 0; c < NUMBER_ROLLS; c++)
            for (int d = 1; d <= NUMBER_ROLLS; d++)
            {
                int i = steps[c, d];
                int j = NUMBER_STEPS - i;
                if (i > 0) 
                {
                    while(j > 0)
                    {
                        Roll(c, d, true);
                        j--;
                    }
                }
            }
    }

    public void OnButtonLoad()
    {
        steps[A, 1] = PlayerPrefs.GetInt("A1");
        steps[A, 2] = PlayerPrefs.GetInt("A2");
        steps[A, 3] = PlayerPrefs.GetInt("A3");

        steps[B, 1] = PlayerPrefs.GetInt("B1");
        steps[B, 2] = PlayerPrefs.GetInt("B2");
        steps[B, 3] = PlayerPrefs.GetInt("B3");

        steps[C, 1] = PlayerPrefs.GetInt("C1");
        steps[C, 2] = PlayerPrefs.GetInt("C2");
        steps[C, 3] = PlayerPrefs.GetInt("C3");

        IsSoundOn.isOn = (bool)(PlayerPrefs.GetInt("Sound") > 0);

        score = PlayerPrefs.GetInt("Score");
        level = PlayerPrefs.GetInt("Level");

        tabloController.SetLevel(level);
        tabloController.SetScore(score);

        SetToFirstAll();
        for (int c = 0; c < NUMBER_ROLLS; c++)
            for (int d = 1; d <= NUMBER_ROLLS; d++)
            {
                int i = steps[c, d];
                while (i > 0 )
                {
                    Roll(c, d, true);
                    i--;
                }
            }
    }
    public void OnButtonSave()
    {
        Debug.Log("OnButtonSave");
        PlayerPrefs.SetInt("A1", steps[A, 1]);
        PlayerPrefs.SetInt("A2", steps[A, 2]);
        PlayerPrefs.SetInt("A3", steps[A, 3]);

        PlayerPrefs.SetInt("B1", steps[B, 1]);
        PlayerPrefs.SetInt("B2", steps[B, 2]);
        PlayerPrefs.SetInt("B3", steps[B, 3]);

        PlayerPrefs.SetInt("C1", steps[C, 1]);
        PlayerPrefs.SetInt("C2", steps[C, 2]);
        PlayerPrefs.SetInt("C3", steps[C, 3]);

        PlayerPrefs.SetInt("Sound", IsSoundOn.isOn ? 1 : 0);
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("Level", level);

        PlayerPrefs.Save();
    }
    public void OnButtonNewGame()
    {
        //SceneManager.LoadScene("Win");
        // SetToFirstAll();
        //GameWin();

        level++;
        Reset();

    }

    public void OnButtonHelp()
    {
        
    }
    public void OnButtonQuit()
    {
        Application.Quit();
    }

    public void OnToggleSound()
    {

    }
}
