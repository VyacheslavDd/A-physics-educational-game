using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrepareForBackwardActivity : MonoBehaviour
{
    [SerializeField] private MagnetController controller;

    private void Start()
    {
        controller.EnablePossibilityToHold();
    }
}
