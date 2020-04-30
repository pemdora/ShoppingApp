using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static JsonParser;

public class DishToggleManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Text label;
    [SerializeField]
    private Text amount;
    [SerializeField]
    private Image amountImage;

    private Color defaultColor;
    [SerializeField]
    private Color checkedColor;
    [HideInInspector]
    public Recipe recipe;

    // Start is called before the first frame update
    void Start()
    {
        defaultColor = label.color;
    }

    public void FillRecipe(Recipe rec)
    {
        recipe = rec;
        label.text = recipe.title;
        amount.text = recipe.numberOfPeople.ToString();
    }

    // Update is called once per frame
    public void Onchecked(Toggle toggle)
    {
        if (toggle.isOn)
        {
            amount.color = checkedColor;
            label.color = checkedColor;
            amountImage.color = checkedColor;
            foreach (var ingredient in recipe.ingredients)
            {
                MainManager.Instance.ingredientList.ingredients[ingredient.databaseId].Amount += ingredient.amount;
            }
        }
        else
        {
            amount.color = defaultColor;
            label.color = defaultColor;
            amountImage.color = defaultColor;
            foreach (var ingredient in recipe.ingredients)
            {
                MainManager.Instance.ingredientList.ingredients[ingredient.databaseId].Amount -= ingredient.amount;
            }
        }
        MainManager.Instance.RefreshDataView();
    }
}
