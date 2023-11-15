using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPjController : MonoBehaviour
{
    public static AnimationPjController instance;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void setMovement(bool isMoving)
    {
        anim.SetBool("move", isMoving);
    }
}
