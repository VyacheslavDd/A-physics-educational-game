using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    [SerializeField] private string infoText;
    [SerializeField] private Color textColor;

    private HitInfo info;

    private void Start()
    {
        info = GameObject.FindWithTag("infoHit").GetComponent<HitInfo>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Cleaner>() != null)
        {
            Destroy(gameObject);
        }

        if (collision.GetComponent<ShootingPaper>() != null)
        {
            var health = collision.transform.GetChild(0);
            health.GetComponent<EntityCharacteristicBehaviour>().TakeValue();
            info.ShowHitInfo(infoText, textColor);
            Destroy(gameObject);
        }
    }
}
