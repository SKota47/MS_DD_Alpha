using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject _titleCheck;
    public GameObject _quitCheck;
    public void Title()
    {
        _titleCheck.SetActive(true);
        gameObject.SetActive(false);
    }
    public void CheckTitleYes()
    {
        SceneManager.LoadScene("00Title");
    }
    public void CheckTitleNo()
    {
        _titleCheck.SetActive(false);
        gameObject.SetActive(true);
    }

    public void Quit()
    {
        _quitCheck.SetActive(true);
        gameObject.SetActive(false);
    }
    public void CheckQuitYes()
    {
        Application.Quit();
    }
    public void CheckQuitNo()
    {
        _quitCheck.SetActive(false);
        gameObject.SetActive(true);
    }

    public void Resume()
    {
        this.gameObject.SetActive(false);
    }
}