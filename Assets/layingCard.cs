using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layingCard : MonoBehaviour
{
    public GameObject _ancherPoint01, _ancherPoint02, _ancherPoint03;
    private GameObject[] _ancherAlly = new GameObject[3];
    private GameObject[] _displayCards = new GameObject[3];

    public List<GameObject> _cards = new List<GameObject>();

    //public GameObject _buffCardCamvas;

    private const int _LAYING_MAX = 3;
    private const int _CARDS_MAX = 6;

    private int _rand;
    private int _randCountRemain = 0;

    // Start is called before the first frame update
    void Start()
    {
        _ancherAlly[0] = _ancherPoint01;
        _ancherAlly[1] = _ancherPoint02;
        _ancherAlly[2] = _ancherPoint03;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && _ancherAlly[0].transform.childCount == 0/*!_buffCardCamvas.activeSelf*/)
        {
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
        return Random.Range(0, 2);
    }
}