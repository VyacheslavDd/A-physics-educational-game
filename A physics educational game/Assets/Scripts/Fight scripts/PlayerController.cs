using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private RectTransform rectTransform;
    private Image img;
    private EntityCharacteristicBehaviour staminaBehaviour;
    private ShootingPaper shooting;

    private float initialSpeed;

    [SerializeField] private Sprite right;
    [SerializeField] private Sprite up;
    [SerializeField] private Sprite down;

    [SerializeField] private float speed;
    [SerializeField] private float speedMultiplier;
    [SerializeField] private float throwingSpeed;

    [SerializeField] private Slider health;
    [SerializeField] private Slider stamina;

    [SerializeField] private GameObject lostFightScript;

    public bool CanMoveUp;
    public bool CanMoveDown;

    public bool isMoving;


    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        img = GetComponent<Image>();
        staminaBehaviour = stamina.gameObject.GetComponent<EntityCharacteristicBehaviour>();
        shooting = GetComponent<ShootingPaper>();
        initialSpeed = speed;
    }

    private void MovePlayer(Sprite direction, float yMove)
    {
        isMoving = true;
        img.sprite = direction;
        rectTransform.localPosition += new Vector3(0, yMove, 0);
    }

    private void Update()
    {
        if (!Cursor.visible)
            Cursor.visible = true;

        if (health.value <= 0)
        {
            lostFightScript.SetActive(true);
            enabled = false;
        }

        if (Input.GetKey(KeyCode.LeftShift) && stamina.value > 0 && isMoving && !staminaBehaviour.IsAwaiting())
        {
            speed = initialSpeed * speedMultiplier;
            staminaBehaviour.TakeValue();
        }


        else speed = initialSpeed;

        if (Input.GetKey(KeyCode.W) && CanMoveUp)
        {
            MovePlayer(up, speed);
        }
        else if (Input.GetKey(KeyCode.S) && CanMoveDown)
        {
            MovePlayer(down, -speed);
        }
        else
        {
            isMoving = false;
            img.sprite = right;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (shooting.CanThrow)
                shooting.Shoot(throwingSpeed);
        }
    }
}
