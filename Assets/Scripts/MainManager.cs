using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static JsonParser;
using static JsonParser.IngredientData;

public class MainManager : MonoBehaviour
{
    // Check to see if we're about to be destroyed.
    private static bool m_ShuttingDown = false;
    private static object m_Lock = new object();
    private static MainManager m_Instance;

    [HideInInspector]
    public IngredientDatabase ingredientList;
    [SerializeField]
    private ShoppingCanvasManager shoppingCanvasManager;
    [SerializeField]
    private JsonParser jsonParser;


    private void Start()
    {
        jsonParser.Init();
        // TODO check ingredientList not null

        int countEnum = IngredientData.CategoryEnum.GetNames(typeof(IngredientData.CategoryEnum)).Length;
        IngredientData[] temp;
        for (int i =0;i< countEnum; i++)
        {
            temp = Array.FindAll(ingredientList.ingredients, ele => ele.category == i && ele.Amount > 0);
            //Debug.Log("temp " + temp.Length + " cate " + i);
            if (temp!=null&& temp.Length > 0)
            {
                shoppingCanvasManager.InstanciateCategoryPrefab(((CategoryEnum)i).ToString());
                foreach (IngredientData ingrdient in temp)
                {
                    if (ingrdient.Amount > 0)
                        shoppingCanvasManager.InstanciatetogglePrefab(ingrdient.Amount, ingrdient.id);
                }
            }
        }

    }


    /// <summary>
    /// Access singleton instance through this propriety.
    /// </summary>
    public static MainManager Instance
    {
        get
        {
            if (m_ShuttingDown)
            {
                Debug.LogWarning("[Singleton] Instance '" + typeof(MainManager) + "' already destroyed. Returning null.");
                return null;
            }

            lock (m_Lock)
            {
                if (m_Instance == null)
                {
                    // Search for existing instance.
                    m_Instance = (MainManager)FindObjectOfType(typeof(MainManager));

                    // Create new instance if one doesn't already exist.
                    if (m_Instance == null)
                    {
                        // Need to create a new GameObject to attach the singleton to.
                        var singletonObject = new GameObject();
                        m_Instance = singletonObject.AddComponent<MainManager>();
                        singletonObject.name = typeof(MainManager).ToString() + " (Singleton)";

                        // Make instance persistent.
                        DontDestroyOnLoad(singletonObject);
                    }
                }

                return m_Instance;
            }
        }
    }


    private void OnApplicationQuit()
    {
        m_ShuttingDown = true;
    }


    private void OnDestroy()
    {
        m_ShuttingDown = true;
    }
    
}
