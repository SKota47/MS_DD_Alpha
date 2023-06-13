using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ステータス強化用の親スクリプト
/// </summary>
public class NumBuffInherit : MonoBehaviour
{
    public GameObject _cardParent;
    public GameObject _cardPanel;
    protected TextMeshProUGUI _descriptionTextMesh;
    public GameObject _playerData;
    protected PlayerMoveScripts _playerScript;
    protected int _playerHp;

    protected int _descHpReduce;
    protected int _preHpReduce;
    protected int _displayPreHpResuce;

    protected string _description;

    protected bool isSelected = false;

    //protected Image _panelImage;

    protected int _inputKeyCord;

    public GameObject _gameManager;
    private LayingCard _layingCardScript;
    protected List<GameObject> _cards = new List<GameObject>();

    public GameObject _preHpBar;
    protected Slider _preHpBarSlider;

    //public GameObject _bgPanelPrefab;
    public GameObject _bgPanelObj;
    private Image _backGroundImage;

    protected float _preAttackDamage;
    protected float _preBulletDamage;
    protected float _prePlayerSpeed;

    void Start()
    {
        SetComponent();
        _preHpReduce = (int)_playerScript._currentHP;
    }

    // Update is called once per frame
    protected void Selection()
    {
        if (Input.GetKeyDown((KeyCode)_inputKeyCord) && !isSelected) Selected();
        else if (Input.GetKeyDown((KeyCode)_inputKeyCord) && isSelected) UnSelected();
        if (Input.GetKeyDown(KeyCode.Return)) Execute();
    }

    /// <summary>
    /// 変数にアタッチする関数
    /// </summary>
    protected void SetComponent()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager");
        //_layingCardScript = _gameManager.GetComponent<layingCard>();
        //_cards = _layingCardScript._cards;
        // _cardPanel = GetComponent<GameObject>();
        _playerData = GameObject.FindWithTag("Player");
        _descriptionTextMesh = GetComponent<TextMeshProUGUI>();
        _playerScript = _playerData.GetComponent<PlayerMoveScripts>();
        _preHpBar = GameObject.FindWithTag("PreHpBar");
        _preHpBarSlider = _preHpBar.GetComponent<Slider>();
        _preHpBarSlider.value = _playerScript._currentHP;
        //_panelImage = _cardParent.GetComponent<Image>();
        //_panelImage.color = Color.white;
        _descriptionTextMesh.color = new Color(0.7f, 0.7f, 0.7f, 1.0f);

        if (_bgPanelObj == null) _bgPanelObj = GameObject.Find("BackGroundPanel");
        if (!_bgPanelObj.activeSelf) _bgPanelObj.SetActive(true);
        _backGroundImage = _bgPanelObj.GetComponent<Image>();
        _backGroundImage.color = new Color(0.0f, 0.0f, 0.0f, 0.75f);

        switch (transform.parent.parent.name)
        {
            case "AncherPoint01":
                _inputKeyCord = (int)KeyCode.Alpha1;
                break;
            case "AncherPoint02":
                _inputKeyCord = (int)KeyCode.Alpha2;
                break;
            case "AncherPoint03":
                _inputKeyCord = (int)KeyCode.Alpha3;
                break;
            default:
                Debug.LogError("アンカーポイントが未指定です\n");
                break;
        }
    }

    /// <summary>
    /// カードが選択されたときに呼ばれる
    /// </summary>
    protected void Selected()
    {
        _preHpReduce += _descHpReduce;
        _displayPreHpResuce += _descHpReduce;
        _descriptionTextMesh.color = new Color(0.7f, 0.2f, 0.2f, 1.0f);
        isSelected = true;
        _preHpBarSlider.value -= _displayPreHpResuce;
    }

    /// <summary>
    /// カード選択が解除されたときに呼ばれる
    /// </summary>
    protected void UnSelected()
    {
        _preHpReduce -= _descHpReduce;
        _displayPreHpResuce -= _descHpReduce;
        _descriptionTextMesh.color = new Color(0.7f, 0.7f, 0.7f, 1.0f);
        isSelected = !isSelected;
        _preHpBarSlider.value += _displayPreHpResuce;
    }

    /// <summary>
    /// カードが選択された後決定されると呼ばれる
    /// </summary>
    protected void Execute()
    {
        _playerScript._currentHP -= _preHpReduce;
        _playerScript._playerAttackScript._ATTACK_DAMAGE_MAX += (int)_preAttackDamage;
        _playerScript._bulletDamage += _preBulletDamage;
        _playerScript._maxSpeed += _prePlayerSpeed;
        if (_preHpBar.activeSelf) _preHpBar.SetActive(false);
        if (_bgPanelObj.activeSelf) _bgPanelObj.SetActive(false);
        Destroy(_cardParent);
    }

    protected void DisplayDescription()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _cardParent.transform.localPosition
                = new Vector3(_cardParent.transform.localPosition.x,
                 -250,
                _cardParent.transform.localPosition.z);

            _preHpBar.transform.localPosition
                = new Vector3(_preHpBar.transform.localPosition.x,
                200, _preHpBar.transform.localPosition.z);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _cardParent.transform.localPosition
                = new Vector3(_cardParent.transform.localPosition.x,
                 0,
                _cardParent.transform.localPosition.z);
            _preHpBar.transform.localPosition
                = new Vector3(_preHpBar.transform.localPosition.x,
                95, _preHpBar.transform.localPosition.z);
        }
        _descriptionTextMesh.text
            = _description + "\n"/* + (_playerScript._currentHP - _descHpReduce) + "hp Remain)"*/;
    }
}