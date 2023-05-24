using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Define
{
    public const int Input1 = (int)KeyCode.Alpha1;
}

public class NumBuffInherit : MonoBehaviour
{
    public GameObject _cardPanel;
    protected Text _descriptionText;
    public GameObject _playerData;
    protected PlayerMoveScripts _playerScript;
    protected int _playerHp;

    protected int _descHpReduce;
    protected int _preHpReduce;

    protected string _description;

    protected bool isSelected;

    public GameObject _panel;
    protected Image _panelImage;
    // Start is called before the first frame update
    void Start()
    {
        SetComponent();
        _preHpReduce = (int)_playerScript._currentHP;
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void SetComponent()
    {
        _descriptionText = GetComponent<Text>();
        _playerScript = _playerData.GetComponent<PlayerMoveScripts>();
        _panelImage = _panel.GetComponent<Image>();
    }

    /// <summary>
    /// カードが選択されたときに呼ばれる
    /// </summary>
    protected void Selected()
    {
        _preHpReduce += _descHpReduce;
    }

    protected void UnSelected()
    {
        _preHpReduce -= _descHpReduce;
    }

    /// <summary>
    /// カードが選択された後決定されると呼ばれる
    /// </summary>
    protected void Execute()
    {
        _playerScript._currentHP -= _preHpReduce;
    }

    protected void DisplayDescription()
    {
        _descriptionText.text
            = _description + "\n(" + (_playerScript._currentHP - _descHpReduce) + "hp Remain)";
    }

}