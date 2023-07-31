using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject _menu;
    public GameObject _gameOverObj;

    public GameObject _playerObj;

    public GameObject _buffCardCanvas;
    public GameObject _ruleCanvas;

    private PlayerMoveScripts _playerMoveScript;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        _playerMoveScript = _playerObj.GetComponent<PlayerMoveScripts>();
        _gameOverObj.SetActive(false);
        if ((SceneManager.GetActiveScene().buildIndex != 1))
        {
            Time.timeScale = 0;
        }
        else if ((SceneManager.GetActiveScene().buildIndex == 1))
        {
            Time.timeScale = 1;
        }
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //  if (Input.GetKeyDown(KeyCode.Escape) && !_menu.activeSelf) _menu.SetActive(true);
        //  else if (Input.GetKeyDown(KeyCode.Escape) && _menu.activeSelf) _menu.SetActive(false);
        if (Input.GetKeyDown(KeyCode.Escape) && !_menu.activeSelf)
        {
            _menu.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _menu.activeSelf)
        {
            _menu.SetActive(false);
            Time.timeScale = 1;
            Cursor.visible = false;
        }

        if (_playerMoveScript._isDead)
        {
            _gameOverObj.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
        }

        if (_buffCardCanvas != null)
        {
            if (_buffCardCanvas.activeSelf)
            {
                Cursor.visible = true;
            }
            if (!_buffCardCanvas.activeSelf)
            {
                Cursor.visible = false;
            }
        }
        if (_ruleCanvas != null)
        {
            if (_ruleCanvas.activeSelf)
            {
                Cursor.visible = true;
            }
            if (!_ruleCanvas.activeSelf)
            {
                Cursor.visible = false;
            }
        }

        Cursor.visible = true;
        //if (Input.GetKeyDown(KeyCode.Tab))
        //{
        //    SceneManager.LoadScene("Stage02");
        //}
    }
}