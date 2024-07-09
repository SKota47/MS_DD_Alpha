using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�Q�[�����ɏo�郁�j���[�̊Ǘ�
public class MenuScript : MonoBehaviour
{
    public GameObject _titleCheck;
    public GameObject _quitCheck;

    [System.NonSerialized] public bool _desiSound = false;
    [System.NonSerialized] public bool _canselSound = false;

    //�^�C�g���I��--------------------------
    public void Title()
    {
        _titleCheck.SetActive(true);
        _canselSound = true;
    }
    public void CheckTitleYes()
    {
        _canselSound = true;
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("00Title");
    }
    public void CheckTitleNo()
    {
        _canselSound = true;
        _titleCheck.SetActive(false);
    }
    //---------------------------------------
    //Quit�I��-------------------------------
    public void Quit()
    {
        _canselSound = true;
        _quitCheck.SetActive(true);
    }
    public void CheckQuitYes()
    {
        _canselSound = true;
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
    public void CheckQuitNo()
    {
        _canselSound = true;
        _quitCheck.SetActive(false);
    }
    //----------------------------------------
    public void Resume()
    {
        _canselSound = true;
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void FromSave()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Stage01");
    }
}