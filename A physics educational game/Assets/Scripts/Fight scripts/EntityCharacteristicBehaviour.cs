using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityCharacteristicBehaviour : MonoBehaviour
{
    private Slider slider;
    private float passedTimeSinceRecover;

    [SerializeField] private float takeValue;
    [SerializeField] private float recoverTime;

    [SerializeField] private bool needsAwaitTime;

    private bool awaiting;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    private void CheckPassedTime()
    {
        if (passedTimeSinceRecover >= recoverTime)
        {
            passedTimeSinceRecover = 0;
            slider.value += 1;
        }
    }

    private IEnumerator AwaitTime()
    {
        awaiting = true;
        yield return new WaitForSeconds(2f);
        awaiting = false;
    }

    private void Update()
    {
        passedTimeSinceRecover += Time.deltaTime;

        if (!needsAwaitTime || (needsAwaitTime && !awaiting))
        {
            CheckPassedTime();
        }

        if (slider.value == 0 && needsAwaitTime && !awaiting)
        {
            StartCoroutine(AwaitTime());
        }
    }

    public void TakeValue()
    {
        slider.value -= takeValue;
    }

    public bool IsAwaiting()
    {
        return awaiting;
    }
}
