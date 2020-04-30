using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static JsonParser;

public class DishesCanvasManager : MonoBehaviour
{
    [SerializeField]
    Transform contentParent;
    [SerializeField]
    private GameObject dishToggle;

    // Start is called before the first frame update
    public void CreateRecipesButton(List<Recipe> recipes) 
    {
        foreach(Recipe rec in recipes)
        {
            GameObject go = Instantiate(dishToggle, contentParent);
            go.GetComponent<DishToggleManager>().FillRecipe(rec);
        }
    }
    
}
