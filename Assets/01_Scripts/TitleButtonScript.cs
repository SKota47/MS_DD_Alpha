using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonScript : MonoBehaviour
{
    public GameObject _doubleCheckCanvas;
    public void OnClickStartButton()
    {
        _doubleCheckCanvas.SetActive(true);
    }
}