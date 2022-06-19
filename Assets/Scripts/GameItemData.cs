using UnityEngine;

public class GameItemData // �����, ������� ������ � ���� ���������� � �������
{
    public Sprite Sprite; // ����������� �������� �������
    public int Amount; // ������ ���������� Amount

    public GameItemData(Sprite sprite) // ����������� ???
    {
        Sprite = sprite; // ���������� Sprite �������� ��������
        Amount = 1; // ����������� ���������� ��������
    }

    public void IncreaseAmount() // �����, ������� ����������� �������� ����������
    {
        Amount++; // +1 � ����������
    }

    public bool DecreaseAmount() // �����, ������� ��������� �������� ����������, ���� ���������� �� ����� ���� ��� ������
    {
        Amount--; // -1 � ����������
        if (Amount <= 0) // if � �������
        {
            return false; // ���� ����������� �������, �� �����������???
        }

        return true; // ���� �� ����������� �������, �� �� �����������??
    }
}