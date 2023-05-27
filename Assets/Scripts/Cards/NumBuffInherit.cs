using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �X�e�[�^�X�����p�̐e�X�N���v�g
/// </summary>
public class NumBuffInherit : MonoBehaviour
{
    public GameObject _cardParent;
    public GameObject _cardPanel;
    protected Text _descriptionText;
    public GameObject _playerData;
    protected PlayerMoveScripts _playerScript;
    protected int _playerHp;

    protected int _descHpReduce;
    protected int _preHpReduce;

    protected string _description;

    protected bool isSelected = false;

    protected Image _panelImage;

    protected int _inputKeyCord;

    void Start()
    {
        SetComponent();
        _preHpReduce = (int)_playerScript._currentHP;
    }

    // Update is called once per frame
    protected void Selection()
    {
        if (Input.GetKeyDown((KeyCode)_inputKeyCord) && !isSelected)
        {
            Selected();
        }
        else if (Input.GetKeyDown((KeyCode)_inputKeyCord) && isSelected)
        {
            UnSelected();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Execute();
        }
    }

    /// <summary>
    /// �ϐ��ɃA�^�b�`����֐�
    /// </summary>
    protected void SetComponent()
    {
        // _cardPanel = GetComponent<GameObject>();
        _playerData = GameObject.FindWithTag("Player");
        _descriptionText = GetComponent<Text>();
        _playerScript = _playerData.GetComponent<PlayerMoveScripts>();
        _panelImage = _cardPanel.GetComponent<Image>();
        _descriptionText.color = Color.white;
        //_buffCardCanvas = GameObject.Find("BuffCardCanvas");
    }

    /// <summary>
    /// �J�[�h���I�����ꂽ�Ƃ��ɌĂ΂��
    /// </summary>
    protected void Selected()
    {
        _preHpReduce += _descHpReduce;
        _panelImage.color = new Color(1.0f, 1.0f, 0.0f, 0.5f);
        _descriptionText.color = new Color(1.0f, 1.0f, 0.0f, 0.5f);
        isSelected = true;
    }

    /// <summary>
    /// �J�[�h�I�����������ꂽ�Ƃ��ɌĂ΂��
    /// </summary>
    protected void UnSelected()
    {
        _preHpReduce -= _descHpReduce;
        _panelImage.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        _descriptionText.color = Color.white;
        isSelected = !isSelected;
    }

    /// <summary>
    /// �J�[�h���I�����ꂽ�㌈�肳���ƌĂ΂��
    /// </summary>
    protected void Execute()
    {
        _playerScript._currentHP -= _preHpReduce;
        Destroy(_cardParent);
    }

    protected void DisplayDescription()
    {
        _descriptionText.text
            = _description + "\n(" + (_playerScript._currentHP - _descHpReduce) + "hp Remain)";
    }

    public void SetKeyInput()
    {

    }
}