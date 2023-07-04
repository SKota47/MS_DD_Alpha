using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject _menu;
    public GameObject _gameOverObj;

    public GameObject _playerObj;
    private PlayerMoveScripts _playerMoveScript;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        _playerMoveScript = _playerObj.GetComponent<PlayerMoveScripts>();
        _gameOverObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_menu.activeSelf) _menu.SetActive(true);
        else if (Input.GetKeyDown(KeyCode.Escape) && _menu.activeSelf) _menu.SetActive(false);

        if (_playerMoveScript._isDead)
        {
            _gameOverObj.SetActive(true);
        }
        //if (Input.GetKeyDown(KeyCode.Tab))
        //{
        //    SceneManager.LoadScene("Stage02");
        //}
    }
}