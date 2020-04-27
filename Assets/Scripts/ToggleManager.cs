using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleManager : MonoBehaviour
{
    [SerializeField]
    private Text amount;
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

    public void FillText(float _amount,string text)
    {
        amount.text = _amount.ToString();
        label.text = text;
    }

    // Update is called once per frame
    public void Onchecked(Toggle toggle)
    {
        if (toggle.isOn)
        {
            amount.color = checkedColor;
            label.color = checkedColor;
        }
        else
        {
            amount.color = defaultColor;
            label.color = defaultColor;
        }
    }
}
