using System.Collections.Generic;
using UnityEngine;

public class UiGamePanel : MonoBehaviour
{
    [SerializeField] private RectTransform content; // �������� ���� ��� recttransofrm
    [SerializeField] private UIItem prefab; // �������� ���� ��� �������� ���������� UI
    Dictionary<string, UIItem> items = new Dictionary<string, UIItem>(); // ������ ��������� UI

    public void Initialize(Level level) // ������������� ������
    {
        foreach (var key in items.Keys) // ��� ������� key � items.Keys
        {
            Destroy(items[key].gameObject); // ���������� items �� �������� key ��� ������������
        }
        items.Clear(); // �� �����

        GenerateList(level.GetItemDictionary()); // ���������� �����?

        level.OnItemListChanged += OnItemListChanged; // ������������� �� ������� ��������� �����
    }

    private void OnItemListChanged(string name) // ����� ��������� �����
    {
        if (items.ContainsKey(name)) // ���� � items ���� ���� name ��, �������� items �����������
        {
            items[name].Decrease(); // ������������� items
        }
    }

    private void GenerateList(Dictionary<string, GameItemData> itemsData) // ����� ��������� �����
    {
        foreach (var key in itemsData.Keys) // ����� ������� ��� ���� ����������
        {
            UIItem item = Instantiate(prefab, content);
            item.SetSprite(itemsData[key].Sprite);
            item.SetCount(itemsData[key].Amount);
            items.Add(key, item);
        }
    }
}