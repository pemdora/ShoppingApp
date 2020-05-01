using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientToggleManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Text amount;
    [SerializeField]
    private Text amountType;
    [SerializeField]
    private Text label;
    private Color defaultColor;
    [SerializeField]
    private Color checkedColor;

    // Start is called before the first frame update
    void Start()
    {
        defaultColor = label.color;
    }

    public void FillText(float _amount,string _amountType, string text)
    {
        amount.text = _amount.ToString();
        amountType.text = _amountType;
        label.text = text;
    }

    // Update is called once per frame
    public void Onchecked(Toggle toggle)
    {
        if (toggle.isOn)
        {
            amount.color = checkedColor;
            label.color = checkedColor;
            amountType.color = checkedColor;
        }
        else
        {
            amount.color = defaultColor;
            label.color = defaultColor;
            amountType.color = defaultColor;
        }
    }
}
