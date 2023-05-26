using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layingCard : MonoBehaviour
{
    //public GameObject _card01, _card02, _card03, _card04, _card05
    //    , _card06, _card07, _card08, _card09;
    public GameObject _ancherPoint01, _ancherPoint02, _ancherPoint03;
    private GameObject[] _ancherAlly = new GameObject[3];
    private GameObject[] _displayCards = new GameObject[3];

    public List<GameObject> _cards = new List<GameObject>();

    public GameObject _buffCardCamvas;

    private const int _LAYING_MAX = 3;
    private const int _CARDS_MAX = 6;

    private int _rand;
    private int _randCountRemain = 0;

    // Start is called before the first frame update
    void Start()
    {
        //_cards.Add(_card01);
        //_cards.Add(_card02);
        //_cards.Add(_card03);
        //_cards.Add(_card04);
        //_cards.Add(_card05);
        //_cards.Add(_card06);
        //_cards.Add(_card07);
        //_cards.Add(_card08);
        //_cards.Add(_card09);
        _ancherAlly[0] = _ancherPoint01;
        _ancherAlly[1] = _ancherPoint02;
        _ancherAlly[2] = _ancherPoint03;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && _ancherAlly[0].transform.childCount == 0/*!_buffCardCamvas.activeSelf*/)
        {
            //_buffCardCamvas.SetActive(true);
            DoLaying();
        }
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
                    _randCountRemain++;
                    _cards.RemoveAt(diceResult);
                }
            }
            nullCheckCount++;
            if (nullCheckCount >= 10)
            {
                break;
            }
        }
        _randCountRemain = 0;
    }

    private int DiceRoll()
    {
        return Random.Range(0, 2);
    }
}