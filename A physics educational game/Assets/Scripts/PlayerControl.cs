using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float speed;
    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 direction;
    private readonly string horizontal = "Horizontal";
    private readonly string vertical = "Vertical";
    private readonly string speedStr = "Speed";

    public void AddSpeedEffect(float speedAdd)
    {
        speed += speedAdd;
    }

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        direction = new Vector2(Input.GetAxisRaw(horizontal), Input.GetAxisRaw(vertical));

        animator.SetFloat(horizontal, direction.x);
        animator.SetFloat(vertical, direction.y);
        animator.SetFloat(speedStr, direction.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + speed * direction * Time.deltaTime);
    }

    public void ResetAnimations()
    {
        animator.SetFloat(horizontal, 0);
        animator.SetFloat(vertical, 0);
        animator.SetFloat(speedStr, 0);
    }

    public void RotateToSpeaker(Transform speaker=null)
    {
        if (speaker == null) transform.rotation = new Quaternion(0, 0, 0, 0);
        else
        {
            if (speaker.transform.position.x < transform.position.x)
            {
                transform.rotation = new Quaternion(0, 180, 0, 0);
            }
        }
    }
}
