using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingCanvasManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    Transform contentParent;
    [SerializeField]
    GameObject togglePrefab;
    [SerializeField]
    GameObject categoryPrefab;

    public GameObject InstanciateCategoryPrefab(string title)
    {
        GameObject go = Instantiate(categoryPrefab, contentParent);
        go.GetComponent<Text>().text = title;
        return go;
    }

    public GameObject InstanciatetogglePrefab(float amount, string title)
    {
       GameObject go = Instantiate(togglePrefab, contentParent);
        go.GetComponent<IngredientToggleManager>().FillText(amount,title);
        return go;
    }
}
