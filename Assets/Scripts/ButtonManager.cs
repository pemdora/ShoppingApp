using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
#pragma warning disable 0649
    [System.Serializable]
    public class ButtonData
    {
        private bool isActive;
        public Image buttonImage;
        public GameObject canvas;

        public bool IsActive
        {
            get => isActive;
            set
            {
                isActive = value;
            }
        }
    }

    [SerializeField]
    private List<ButtonData> buttons;
    [SerializeField]
    private Color defaultColor;
    [SerializeField]
    private Color selectedColor;

    // Start is called before the first frame update
    void Start()
    {
        if (buttons != null && buttons.Count > 0)
        {
            buttons[0].IsActive = true;
            foreach (ButtonData buttondata in buttons)
            {
                buttondata.buttonImage.color = defaultColor;
            }
            buttons[0].buttonImage.color = selectedColor;
            buttons[0].canvas.SetActive(true);
        }
        else
            Debug.LogError("Missing buttons");
    }
    
    public void ShowButton(int index)
    {
        foreach(ButtonData buttondata in buttons)
        {
            buttondata.buttonImage.color = defaultColor;
            buttondata.canvas.SetActive(false);
        }
        
        buttons[index].canvas.SetActive(true);
        buttons[index].buttonImage.color = selectedColor;
    }
    
}
