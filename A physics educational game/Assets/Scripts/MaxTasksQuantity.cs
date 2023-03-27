using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxTasksQuantity : MonoBehaviour
{
    [SerializeField] private int MaxTasks;

    private Dictionary<int, string> stringInterpretation;

    private void Start()
    {
        stringInterpretation = new Dictionary<int, string>()
        {
            { 1, "one" },
            { 2, "two" },
            {3, "three" },
            {4, "four" },
            {5, "five" }
        };
    }

    public int GetAmountOfMaxTasks()
    {
        return MaxTasks;
    }

    public string GetStringInterpretation()
    {
        var value = "";
        var res = stringInterpretation.TryGetValue(MaxTasks, out value);
        return res ? value : "???";
    }
}
