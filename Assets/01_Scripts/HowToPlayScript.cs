using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayScript : MonoBehaviour
{
    public GameObject _howToPlayPanel;
    public GameObject _backButton;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HowToPlay()
    {
        _howToPlayPanel.SetActive(true);
        _backButton.SetActive(true);

    }
    public void Back()
    {
        _howToPlayPanel.SetActive(false);
        _backButton.SetActive(false);
    }
}
