using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject _gameMnager;
    private CheckEnemyCount _enemyCountS;
    public GameObject _gate;
    private int _nowSceneNum;

    // Start is called before the first frame update
    void Start()
    {
        //_enemyCountS = _gameMnager.GetComponent<CheckEnemyCount>();
        //_gate.GetComponent<GameObject>().SetActive(false);
        _nowSceneNum = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(_nowSceneNum++);
        }
    }
}