using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LayingCard : MonoBehaviour
{
    public GameObject _ancherPoint01, _ancherPoint02, _ancherPoint03;
    private GameObject[] _ancherAlly = new GameObject[3];
    private GameObject[] _displayCards = new GameObject[3];

    public List<GameObject> _cards = new List<GameObject>();
    public static List<GameObject> _cardsSaveBox = new List<GameObject>();

    //public GameObject _buffCardCamvas;

    private const int _LAYING_MAX = 3;
    private const int _CARDS_MAX = 6;

    private int _rand;
    private int _randCountRemain = 0;

    private int _randomWeight;
    private bool _isStageStart = true;


    // Start is called before the first frame update
    void Start()
    {
        _ancherAlly[0] = _ancherPoint01;
        _ancherAlly[1] = _ancherPoint02;
        _ancherAlly[2] = _ancherPoint03;

        if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2)
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

    // Update is called once per frame
    void Update()
    {
    }

    private void DoLaying()
    {
        int diceResult;
        RectTransform rt;
        int nullCheckCount = 0;
        while (_randCountRemain < _LAYING_MAX)
        {
            if (_randCountRemain < _LAYING_MAX)
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
            nullCheckCount++;
            //–³ŒÀƒ‹[ƒv‚·‚é‚Ì‚Å‹­§“I‚ÉŽ~‚ß‚é(Œã‚ÉÁ‚·‚â‚Â)
            if (nullCheckCount >= 10)
            {
                break;
            }
        }
        _randCountRemain = 0;
    }

    private int DiceRoll()
    {
        return Random.Range(0, 4);
    }

}