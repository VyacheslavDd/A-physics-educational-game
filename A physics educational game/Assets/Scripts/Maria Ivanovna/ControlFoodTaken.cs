using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ControlFoodTaken : MonoBehaviour
{
    [SerializeField] private GameObject foodLine;
    [SerializeField] private GameObject nextScript;

    private List<GameObject> foods;

    private void Start()
    {
        foods = new List<GameObject>();
        foodLine.SetActive(true);
        for (int i = 0; i < foodLine.transform.childCount; i++)
        {
            foods.Add(foodLine.transform.GetChild(i).gameObject);
        }
    }

    private void Update()
    {
        if (foods.All(gobj => gobj.activeSelf))
        {
            nextScript.SetActive(true);
            enabled = false;
        }
    }
}
