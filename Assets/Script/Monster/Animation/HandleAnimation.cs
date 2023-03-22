using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandleAnimation : MonoBehaviour
{
    [SerializeField] private AudioSource PosisionEffect;  
    
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void monsterHitted() 
    {
        // start animation
        animator.SetTrigger("startHit");
        PosisionEffect.Play();
    }


}
