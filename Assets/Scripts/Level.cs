using System;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour // ��� �������
{
    private GameItem[] _gameItems; // ������ GameItem � ������ ����������� _gameItems
    private int _itemsCount; // �������� ���������� ���������� �� ������� ���-�� ������� � �������

    public event Action OnCompleted; // �������������  ������ OnCompleted
    public event Action<string> OnItemListChanged; // �������������  ������ ��������� ���� OnItemListChanged

    public void Initialize() // ����� ������������� ��������
    {
        _gameItems = GetComponentsInChildren<GameItem>(); // ����������� ����������� _gameItems �������� �������

        for (int i = 0; i < _gameItems.Length; i++) // �� ���-�� �������(��� ������ Length), ��� ����������� � �������, ������������� �� ����� OnFindItem
        {
            _gameItems[i].OnFind += OnFindItem; // ������ ����� � ((OnFind??)) ������������� �� ����� OnFindItem
        }

        _itemsCount = _gameItems.Length; // ���-�� ��������� ����� ���-�� �������
    }

    private void OnFindItem(string name) // ����� ������� ��������� �������� _itemsCount 
    {
        _itemsCount--;

        if (_itemsCount > 0) // ���� ������ 0 , �� �������� ������ ����
        {
            OnItemListChanged.Invoke(name);
        }
        else
        {
            OnCompleted.Invoke(); // ���� �� ������ 0, �� ������� OnCompleted
        }
    }

    public Dictionary<string, GameItemData> GetItemDictionary() // ������� ��������� Dictionary 
    {
        Dictionary<string, GameItemData> itemsData = new Dictionary<string, GameItemData>();

        for (int i = 0; i < _gameItems.Length; i++)
        {
            string key = _gameItems[i].Name;
            if (itemsData.ContainsKey(key))
            {
                itemsData[key].IncreaseAmount();
            }
            else
            {
                itemsData.Add(key, new GameItemData(_gameItems[i].Sprite));
            }
        }

        return itemsData;
    }

}