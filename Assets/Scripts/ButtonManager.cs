using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [System.Serializable]
    public class Button
    {
        private bool isActive;
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
    private List<Button> buttons;

    // Start is called before the first frame update
    void Start()
    {
        if (buttons != null && buttons.Count > 0)
            buttons[0].IsActive = true;
        else
            Debug.LogError("Missing buttons");
    }
    
    public void ShowButton(int index)
    {
        foreach(Button button in buttons)
            button.canvas.SetActive(false);
        
        buttons[index].canvas.SetActive(true);
    }
    
}
