using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public Button buttonSave;
    public Button buttonNewGame;
    public Toggle toggleSound;

    public GameObject Place1H;
    public GameObject Place2H;
    public GameObject Place3H;

    public GameObject Place1V;
    public GameObject Place2V;
    public GameObject Place3V;

    private Vector3 offset;

    void OnGUI()
    {

        float ratio = (float)Screen.width / (float)Screen.height;
        Camera MainCamera = GetComponent<Camera>();
        MainCamera.orthographicSize = 22.0f / Mathf.Pow(ratio, 1.0f / 3.0f);

        if (ratio < 1.0f)
        {
            buttonSave.transform.position = Place1H.transform.position;
            buttonNewGame.transform.position = Place2H.transform.position;
            toggleSound.transform.position = Place3H.transform.position;
        }
        else
        {
            buttonSave.transform.position = Place1V.transform.position;
            buttonNewGame.transform.position = Place2V.transform.position;
            toggleSound.transform.position = Place3V.transform.position;

        }
    }

    // Use this for initialization
    void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position + offset;

    }
}
