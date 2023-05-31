using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShootingPaper : MonoBehaviour
{
    [SerializeField] private bool lookToPlayer = false;
    [SerializeField] private RectTransform player;
    [SerializeField] private Slider health;
    [SerializeField] private TextMeshProUGUI reloadTimer;

    [SerializeField] private float reloadTime;
    private float initialReloadTime;
    private float passedTime;

    private PlayerController controller;

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject paper;

    private System.Random random;

    private RectTransform rectTransform;

    private Vector3 lookDirection;
    private float lookAngle;

    public bool CanThrow;

    public float GetReloadingTime => reloadTime - passedTime;

    private void Start()
    {
        random = new System.Random();
        rectTransform = GetComponent<RectTransform>();
        if (player != null) controller = player.gameObject.GetComponent<PlayerController>();

        initialReloadTime = reloadTime;
    }

    private float CalculateSpread()
    {
        if (health.value >= 50) return -5 + (float)(random.NextDouble() * 10);
        else return 2;
    }

    private void Update()
    {
        if (lookToPlayer)
            reloadTime = initialReloadTime - (health.maxValue - health.value) / 20 * 0.5f;

        passedTime += Time.deltaTime;
        if (passedTime >= reloadTime && !CanThrow)
        {
            CanThrow = true;
            reloadTimer.enabled = false;
        }
        else CanThrow = false;

        if (!lookToPlayer)
        {
            lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(rectTransform.position.x, rectTransform.position.y);

            lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        }
        else
        {
            lookDirection = player.position - rectTransform.position;
            lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg
                - (controller.isMoving ? CalculateSpread() : 2);
        }

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);
    }

    public void Shoot(float bulletSpeed)
    {
        passedTime = 0;
        reloadTimer.enabled = true;

        GameObject bullet = Instantiate(paper, transform.parent);
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;

        bullet.GetComponent<Rigidbody2D>().velocity = firePoint.right * bulletSpeed;
    }
}
