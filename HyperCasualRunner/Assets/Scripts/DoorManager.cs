using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public enum BonusType{
    ADDITION,
    SUBSTRACTION,
    MULTIPLICATION,
    DIVISION
}
public class DoorManager : MonoBehaviour
{
    [SerializeField]
    private Collider colliader;
    [Header("Right Door Config")]
    [SerializeField]
    SpriteRenderer _rightDoorRenderer;
    [SerializeField]
    TextMeshPro _rightDoorTMP;
    [SerializeField]
    BonusType _rightDoorBonusType;
    [SerializeField]
    int _rightDoorBonusAmount;

    [Header("Left Door Config")]
    [SerializeField]
    SpriteRenderer _leftDoorRenderer;
    [SerializeField]
    TextMeshPro _leftDoorTMP;
    [SerializeField]
    BonusType _leftDoorBonusType;
    [SerializeField]
    int _leftDoorBonusAmount;

    [Header ("Door Colour")]
    [SerializeField]
    Color _bonusColour;
    [SerializeField]
    Color _penaltyColour;

    void Start()
    {
        ConfigureDoors();
    }

    private void ConfigureDoors()
    {
        switch(_rightDoorBonusType)
        {
            case BonusType.ADDITION:
                _rightDoorRenderer.color = _bonusColour;
                _rightDoorTMP.text = "+" + _rightDoorBonusAmount;
                break;

            case BonusType.SUBSTRACTION:
                _rightDoorRenderer.color = _penaltyColour;
                _rightDoorTMP.text = "-" + _rightDoorBonusAmount;
                break;

            case BonusType.MULTIPLICATION:
                _rightDoorRenderer.color = _bonusColour;
                _rightDoorTMP.text = "x" + _rightDoorBonusAmount;
                break;

            case BonusType.DIVISION:
                _rightDoorRenderer.color = _penaltyColour;
                _rightDoorTMP.text = "/" + _rightDoorBonusAmount;
                break;
        }

        switch(_leftDoorBonusType)
        {
            case BonusType.ADDITION:
                _leftDoorRenderer.color = _bonusColour;
                _leftDoorTMP.text = "+" + _leftDoorBonusAmount;
                break;

            case BonusType.SUBSTRACTION:
                _leftDoorRenderer.color = _penaltyColour;
                _leftDoorTMP.text = "-" + _leftDoorBonusAmount;
                break;

            case BonusType.MULTIPLICATION:
                _leftDoorRenderer.color = _bonusColour;
                _leftDoorTMP.text = "x" + _leftDoorBonusAmount;
                break;

            case BonusType.DIVISION:
                _leftDoorRenderer.color = _penaltyColour;
                _leftDoorTMP.text = "/" + _leftDoorBonusAmount;
                break;
        }
    }

    public int GetBonusAmount(float xPos)
    {
        if(xPos > 0)
            return _rightDoorBonusAmount;
        else
            return _leftDoorBonusAmount;

    }

    public BonusType GetBonusType(float xPos)
    {
        if(xPos > 0)
            return _rightDoorBonusType;
        else
            return _leftDoorBonusType;
    }

    public void Disable()
    {
        colliader.enabled = false;
    }
}
