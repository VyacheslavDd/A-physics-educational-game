using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    private enum Positioning
    {
        Left,
        Right
    }

    [SerializeField] private List<Transform> pointsToGo;
    [SerializeField] private Transform player;
    [SerializeField] private float speed;

    private Animator animator;
    private int currentPoint;

    private bool isStanding;
    private bool isTalking;

    private Positioning GetCorrectPositioning(Transform point)
    {
        if (point.position.x >= transform.position.x) return Positioning.Right;
        else return Positioning.Left;
    }

    private void StopAllAnimations()
    {
        animator.SetBool("standLeft", false);
        animator.SetBool("walkLeft", false);
        animator.SetBool("walkRight", false);
    }

    private void GetCorrectAnimation()
    {
        StopAllAnimations();
        if (pointsToGo.Count == 0) return;
        var pos = GetCorrectPositioning(pointsToGo[currentPoint]);
        if (pos == Positioning.Left) animator.SetBool("walkLeft", true);
        else animator.SetBool("walkRight", true);
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
        var wasWalkingLeft = animator.GetBool("walkLeft");
        StopAllAnimations();
        if (wasWalkingLeft) animator.SetBool("standLeft", true);
        isStanding = true;
        yield return new WaitForSeconds(1.5f);
        isStanding = false;
        GetCorrectAnimation();
    }

    private void UpdateStandingPos()
    {
        var pos = GetCorrectPositioning(player);
        if (pos == Positioning.Left) animator.SetBool("standLeft", true);
    }

    private void Update()
    {
        if (isTalking) UpdateStandingPos();
        if (pointsToGo.Count > 0 && !isStanding && !isTalking)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointsToGo[currentPoint].position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, pointsToGo[currentPoint].position) < 0.2f)
            {
                currentPoint = (currentPoint + 1) % pointsToGo.Count;
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
}
