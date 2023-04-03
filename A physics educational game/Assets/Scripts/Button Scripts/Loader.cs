using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    [SerializeField] private GameObject loadCanvas;
    [SerializeField] private TextMeshProUGUI titleLoading;
    [SerializeField] private TextMeshProUGUI progress;

    public GameObject canvasToOff;

    private StringBuilder builder;
    private int pointCounter = 0;

    private void Start()
    {
        builder = new StringBuilder();
    }

    public async void LoadScene(string sceneName)
    {
        builder.Clear();
        builder.Append(titleLoading.text);
        canvasToOff.SetActive(false);
        loadCanvas.SetActive(true);
        StartCoroutine(UpdateTitle());

        var loader = SceneManager.LoadSceneAsync(sceneName);
        loader.allowSceneActivation = false;

        do
        {
            await Task.Delay(150);
            progress.text = (int)(loader.progress * 100) + "%";
            progress.color = new Color(255, 255, 255 - 2.55f * (loader.progress*100), 255);
        }
        while (loader.progress < 0.9f);

        await Task.Delay(500);
        loader.allowSceneActivation = true;
        StopAllCoroutines();
        loadCanvas.SetActive(false);
        Time.timeScale = 1.0f;
    }

    private IEnumerator UpdateTitle()
    {
        while (true)
        {
            if (pointCounter == 3) { builder.Replace("...", ""); pointCounter = 0; }
            else { builder.Append("."); pointCounter++; }
            titleLoading.text = builder.ToString();
            yield return new WaitForSeconds(0.9f);
        }
    }
}
