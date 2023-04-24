using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Position = Positioning.Positions;

public class NPCBehaviour : MonoBehaviour
{

    [SerializeField] private List<Transform> pointsToGo;
    [SerializeField] private Transform player;
    [SerializeField] private float speed;

    private Animator animator;
    private int currentPoint;
    private int addBy = 1;

    private bool isStanding;
    private bool isTalking;

    private string horizontal = "Horizontal";
    private string vertical = "Vertical";
    private string speedStr = "Speed";

    private Dictionary<Position, (string axis, float value)> movements = new Dictionary<Position, (string axis, float value)>()
    {
        {Position.Left, ("Horizontal", -1) },
        {Position.Right, ("Horizontal", 1) },
        {Position.Up, ("Vertical", 1) },
        {Position.Down, ("Vertical", -1) }
    };

    private Position GetCorrectPositioning(Transform point, bool frontToPlayer=true)
    {
        if (!frontToPlayer)
        {
            var yDif = transform.position.y - point.position.y;
            if (yDif >= 0 && yDif > 1) return Position.Down;
            if (yDif < 0 && Mathf.Abs(yDif) > 1) return Position.Up;
        }
        if (point.position.x >= transform.position.x) return Position.Right;
        else return Position.Left;
    }

    private void StopAllAnimations()
    {
        animator.SetFloat(speedStr, 0);
        animator.SetFloat(vertical, 0);
        animator.SetFloat(horizontal, 0);
        animator.SetBool("standLeft", false);
    }

    private void SetAnimation((string axis, float value) data)
    {
        animator.SetFloat(data.axis, data.value);
        animator.SetFloat(speedStr, 1);
    }

    private void GetCorrectAnimation()
    {
        StopAllAnimations();
        if (pointsToGo.Count == 0) return;
        var pos = GetCorrectPositioning(pointsToGo[currentPoint], frontToPlayer:false);
        SetAnimation(movements[pos]);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (pointsToGo.Count > 0)
        {
            GetCorrectAnimation();
        }
    }

    private IEnumerator Stand()
    {
        StopAllAnimations();
        animator.SetFloat(horizontal, 1);
        isStanding = true;
        yield return new WaitForSeconds(pointsToGo.Count > 1 ? 0.05f : 1000f);
        isStanding = false;
        GetCorrectAnimation();
    }

    private void UpdateStandingPos()
    {
        var pos = GetCorrectPositioning(player);
        StopAllAnimations();
        if (pos != Position.Left) animator.SetFloat(horizontal, 1);
        if (pos == Position.Left) animator.SetBool("standLeft", true);
    }

    private void Update()
    {
        if (isTalking) UpdateStandingPos();
        if (pointsToGo.Count > 0 && !isStanding && !isTalking)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointsToGo[currentPoint].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, pointsToGo[currentPoint].position) < 0.2f)
            {
                if (pointsToGo.Count > 1)
                {
                    if (currentPoint + addBy == pointsToGo.Count || currentPoint + addBy < 0) addBy *= -1;
                    currentPoint = currentPoint + addBy;
                }
                StartCoroutine(Stand());
            }
        }
    }

    public void GetReadyForDialogue()
    {
        isTalking = true;
        StopAllAnimations();
        UpdateStandingPos();
    }

    public void FinishDialogue()
    {
        isTalking = false;
        GetCorrectAnimation();
    }

    public void ContinueWhenEnabledAgain()
    {
        StartCoroutine(Stand());
        GetCorrectAnimation();
    }

    public void UpdatePointsToGo(List<Transform> points)
    {
        currentPoint = 0;
        pointsToGo = points;
        GetCorrectAnimation();
    }
}
