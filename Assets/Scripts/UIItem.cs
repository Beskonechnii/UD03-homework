using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    [SerializeField] private Image image; // �������� ���� Image ��� �������
    [SerializeField] private TextMeshProUGUI countText; // �������� ���� Count Text ��� ����������� ���-�� �������� �������

    private int _count; // ���������� ������� ����� ������� ���-�� ��������

    public void SetSprite(Sprite sprite) // ����� ��������������� ���������� sprite ��������
    {
        image.sprite = sprite;
    }

    public void SetCount(int count) // ����� ������������� ������, ������� �� ���������� � ���� Count Text, � ��������� �������� _count � ������� ��� � �����
    {
        _count = count; // ����� ��� ����������� _count = count? ��� ��� _count ����������, � count ��������� ����������?
        countText.text = _count.ToString();
    }

    public void Decrease() // ����� ����������� �������� _count, � � ������, ���� _count > 0 ���������� �������� � �����, � ������ ���� _count = 0 �������� ������ 
    {
        _count--;
        if (_count > 0)
        {
            countText.text = _count.ToString();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}