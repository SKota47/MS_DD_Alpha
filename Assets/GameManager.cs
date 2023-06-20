using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject _menu;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1280, 720, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_menu.activeSelf) _menu.SetActive(true);
        else if (Input.GetKeyDown(KeyCode.Escape) && _menu.activeSelf) _menu.SetActive(false);
        //if (Input.GetKeyDown(KeyCode.Tab))
        //{
        //    SceneManager.LoadScene("Stage02");
        //}
    }
}