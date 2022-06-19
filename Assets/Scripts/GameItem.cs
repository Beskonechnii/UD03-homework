using System;
using UnityEngine;

public class GameItem : MonoBehaviour // ��������� ������� �������� �� ������� ������ ������� ����� �����
{
    public Sprite Sprite; // �������� �������
    public string Name; // ��� �������
    private SpriteRenderer _spriteRenderer; // ����������, ���������� �� ��������� ������� � ����
    public event Action<string> OnFind; // ��������� ����� OnFind

    private void Awake() // ����������� �����
    {
        _spriteRenderer = GetComponent<SpriteRenderer>(); // �������� ������ �� ���������, ������� �� �������
        Name = _spriteRenderer.sprite.name; // ����������� ���������� Name � ������������ � ���������, �������� � ��� (����� ���������� Name ������ �� �������� � �� ���, ���� � ��� ���� ���������� Sprite?)
        Sprite = _spriteRenderer.sprite; // �����������  ���������� Sprite ��������
    }

    private void OnMouseUpAsButton() // �����, ������� ��������� �� ���� ����� �� ������ � �����������
    {
        Find(); // ������ ������ � ����������� ����� �� ������� �� ������
    }

    private void Find() // �����, ����� ������ ������, �� ���� ����� �� �������� �� ���� � ������������� Find() �� ������ OnMouseAsButton()
    {
        Debug.Log($"Find object {gameObject.name}"); // ������� � ������� ���� � ������� � ��� �����, � ������ ��� ����������� ����� �������� �� ����� � �������
        OnFind.Invoke(Name); // (� �� ����� ��� �� Invoke) ���������� ������� OnFind �� 9-�� ������ � ������ ��� ���������� ������ ����� ��������� ���� �� ������� � �����������, �� ���� ��������� Find()
    }
}