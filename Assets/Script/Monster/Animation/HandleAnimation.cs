using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandleAnimation : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isHit", false);
    }

    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1.0f)
        {
            animator.SetBool("isHit", false);
            Debug.Log(animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        }
    }
    public void monsterHitted() 
    {
        animator.SetBool("isHit", true);
    }


}
