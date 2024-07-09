using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �J�[�h����ׂ�X�N���v�g
/// </summary>
public class LayingCard : MonoBehaviour
{
    public GameObject _ancherPoint01, _ancherPoint02, _ancherPoint03;
    private GameObject[] _ancherAlly = new GameObject[3];
    private GameObject[] _displayCards = new GameObject[3];

    public List<GameObject> _cards = new List<GameObject>();
    public static List<GameObject> _cardsSaveBox = new List<GameObject>();

    private const int _LAYING_MAX = 3;
    private const int _CARDS_MAX = 6;

    private int _rand;
    private int _randCountRemain = 0;

    private int _randomWeight;
    private bool _isStageStart = true;

    void Start()
    {
        _ancherAlly[0] = _ancherPoint01;
        _ancherAlly[1] = _ancherPoint02;
        _ancherAlly[2] = _ancherPoint03;

        if (SceneManager.GetActiveScene().buildIndex == 1
            || SceneManager.GetActiveScene().buildIndex == 2)
        {
            _cardsSaveBox = _cards;
        }
        else
        {
            _cards = _cardsSaveBox;
        }

        _randomWeight = SceneManager.sceneCount;

        if (_ancherAlly[0].transform.childCount == 0 && _isStageStart)
        {
            DoLaying();
            _isStageStart = false;
        }
    }

    /// <summary>
    /// ���ׂ鏈��
    /// </summary>
    private void DoLaying()
    {
        int diceResult;
        RectTransform rt;
        while (_randCountRemain < _LAYING_MAX)
        {
            diceResult = DiceRoll();
            if (_cards[diceResult] != null)
            {
                _displayCards[_randCountRemain] = Instantiate(_cards[diceResult]);
                rt = _displayCards[_randCountRemain].GetComponent<RectTransform>();
                rt.transform.SetParent(_ancherAlly[_randCountRemain].transform);
                rt.transform.localPosition = new Vector3(0, 0, 0);

                if (_cards[diceResult].name != "SkillCard10")
                {
                    _cards.Add(_cards[diceResult]);
                }
                _cards.RemoveAt(diceResult);
                _randCountRemain++;
            }
        }
        _randCountRemain = 0;
    }

    private int DiceRoll()
    {
        return Random.Range(0, 4);
    }

}