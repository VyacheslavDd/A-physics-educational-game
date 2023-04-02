using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadResolutions : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionsDropdown;
    private ClassForSharing shareClass;

    private void Start()
    {
        shareClass = GetComponent<ClassForSharing>();
        var builder = new StringBuilder();
        var resolutions = Screen.resolutions;
        var parsedResolutions = new List<string>();

        var currentRes = PlayerPrefs.GetString("resolution", shareClass.basicResolution);
        var setCounter = 0;
        var counter = 0;

        foreach (var resolution in resolutions.OrderBy(x => x.width))
        {
            var parsed = ParseResolution(resolution, builder);

            if (parsed == currentRes)
                setCounter = counter;

            parsedResolutions.Add(parsed);
            builder.Clear();
            counter++;
        }
        resolutionsDropdown.AddOptions(parsedResolutions);
        resolutionsDropdown.value = setCounter;
    }

    private string ParseResolution(Resolution resolution, StringBuilder builder)
    {
        builder.Append(resolution.width);
        builder.Append("x");
        builder.Append(resolution.height);
        var result = builder.ToString();
        return result;
    }
}
