using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class InitiativeManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _infoSpawnable;
    [SerializeField]
    private TMP_InputField _nameField;
    [SerializeField]
    private TMP_InputField _numbField;
    [SerializeField]
    private RectTransform _container;
    [SerializeField]
    private const int _componentHeight = 110;
    [SerializeField]
    private List<CreatureInfo> _allCreatures = new List<CreatureInfo>();

    public void ConfirmButton()
    {
        if (_nameField.text == "" || _numbField.text == "" || _numbField.text == "-")
        {
            ClearCreationWindow();
            return;
        }

        SpawnInfo();
    }

    private void SpawnInfo()
    {
        _container.sizeDelta = new Vector2(_container.sizeDelta.x, _container.sizeDelta.y + _componentHeight);
        GameObject go = Instantiate(_infoSpawnable, _container);
        CreatureInfo info = new CreatureInfo(_nameField.text, int.Parse(_numbField.text), go);
        _allCreatures.Add(info);
        go.GetComponent<CharacterInfoAssigner>().ApplyCreatureInfo(info);
        UpdateList();
    }

    public void UpdateList()
    {
        List<CreatureInfo> newList = new List<CreatureInfo>();
        for (int i = 0; i < _allCreatures.Count; i++)
        {
            if (_allCreatures[i].Go != null)
            {
                newList.Add(_allCreatures[i]);
            }
            else
            {
                _container.sizeDelta = new Vector2(_container.sizeDelta.x, _container.sizeDelta.y - _componentHeight);
            }
        }
        var orderedList = newList.OrderBy(x => x.Initiative).ToList();
        _allCreatures = orderedList;

        for (int i = 0; i < _allCreatures.Count; i++)
        {
            _allCreatures[i].Go.transform.SetSiblingIndex(i);
        }
    }

    public void ResetPage()
    {
        for (int i = 0; i < _allCreatures.Count; i++)
        {
            _allCreatures[i].Go.GetComponent<CharacterInfoAssigner>().RemoveCreature();
        }
        _allCreatures = new List<CreatureInfo>();
        _container.sizeDelta = Vector2.zero;
    }

    private void ClearCreationWindow()
    {
        _nameField.text = "";
        _numbField.text = "";
    }
}
