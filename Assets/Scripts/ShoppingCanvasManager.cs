using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingCanvasManager : MonoBehaviour
{
    [SerializeField]
    Transform contentParent;
    [SerializeField]
    GameObject togglePrefab;
    [SerializeField]
    GameObject categoryPrefab;

    public void InstanciateCategoryPrefab(string title)
    {
        GameObject go = Instantiate(categoryPrefab, contentParent);
        go.GetComponent<Text>().text = title;
    }

    public void InstanciatetogglePrefab(float amount, string title)
    {
       GameObject go = Instantiate(togglePrefab, contentParent);
        go.GetComponent<ToggleManager>().FillText(amount,title);
    }
}
