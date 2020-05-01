using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

// https://stackoverflow.com/questions/36239705/serialize-and-deserialize-json-and-json-array-in-unity
public class JsonParser : MonoBehaviour
{
#pragma warning disable 0649

    // Read
    public void ReadAndImportJsonDataFiles()
    {
        // IngredientDatabase
        TextAsset jsonTextFile = Resources.Load<TextAsset>("IngredientDatabase");
        MainManager.Instance.ingredientList = IngredientDatabase.CreateFromJSON(jsonTextFile.ToString());


        // Reading recipes
        TextAsset[] jsonTextFiles = Resources.LoadAll<TextAsset>("Recipes"); // in folder Resource/Recipes/
        if (jsonTextFiles.Length > 0)
        {
            MainManager.Instance.recipes = new List<Recipe>();

            foreach (TextAsset jsonText in jsonTextFiles)
            {
                Recipe rec = Recipe.CreateFromJSON(jsonText.ToString(), MainManager.Instance.ingredientList.ingredients);
                MainManager.Instance.recipes.Add(rec);
                
            }
        }
    }

    [System.Serializable]
    public struct Recipe
    {
        public string title;
        public int numberOfPeople;
        public Ingredient[] ingredients;
        public string description;
        private int category;
        public enum CategoryEnum { Petit_Dejeuner, Goûter , Dessert, Entrée_Apéritif, Plat};

        public CategoryEnum Category
        {
            get
            {
                return (CategoryEnum)category;
            }
        }


        // TODO INVALID JSON
        public static Recipe CreateFromJSON(string jsonString, IngredientData[] ingredientDBList)
        {
            Recipe recetteParsed;
            try
            {
                recetteParsed = JsonUtility.FromJson<Recipe>(jsonString);
                for(int i=0; i< recetteParsed.ingredients.Length;i++)
                {
                    int id = Array.FindIndex(ingredientDBList, element => element.id == recetteParsed.ingredients[i].title);
                    if (id < 0) // index not found
                    {
                        Debug.Log("Missing ingredient " + recetteParsed.ingredients[i].title);
                    }
                    else
                    {
                        recetteParsed.ingredients[i].databaseId = id;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return recetteParsed;
        }
    }

    [System.Serializable]
    public class Ingredient
    {
        public string title;
        public float amount;
        private int typeAmount;
        public enum TypeAmountEnum { Unité, Cuillere_a_soupe, Cuillere_a_cafe, Gramme};
        public int databaseId;

        public TypeAmountEnum TypeAmount
        {
            get
            {
                return (TypeAmountEnum)amount;
            }
        }
    }

    [System.Serializable]
    public class IngredientDatabase
    {
        public IngredientData[] ingredients;

        public static IngredientDatabase CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<IngredientDatabase>(jsonString);
        }
    }

    [System.Serializable]
    public class IngredientData 
    {
        public string id;
        public int category;
        public enum CategoryEnum { Légumes, Fruits, Huile, Pate_a_dérouler,Condiments,Poisson};
        private bool isChecked;
        private float amount;
        public string amountType;

        public CategoryEnum Category
        {
            get
            {
                return (CategoryEnum)category;
            }
        }

        public float Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }

        public static IngredientData CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<IngredientData>(jsonString);
        }
        
    }

}
