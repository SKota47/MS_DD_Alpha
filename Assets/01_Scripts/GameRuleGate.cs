using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRuleGate : MonoBehaviour
{
    public GameObject _gameRuleCanvas;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            _gameRuleCanvas.SetActive(true);
        }
    }
}