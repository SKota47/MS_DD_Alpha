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
    }
    public void CheckTitleYes()
    {
        SceneManager.LoadScene("00Title");
    }
    public void CheckTitleNo()
    {
        _titleCheck.SetActive(false);
    }

    public void Quit()
    {
        _quitCheck.SetActive(true);
    }
    public void CheckQuitYes()
    {
        Application.Quit();
    }
    public void CheckQuitNo()
    {
        _quitCheck.SetActive(false);
    }

    public void Resume()
    {
        this.gameObject.SetActive(false);
    }
}