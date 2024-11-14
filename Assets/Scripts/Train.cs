using System.Collections;
using UnityEngine;

public class Train : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Success", false);

    }

    public void PlaySuccessAnimation()
    {
        animator.SetBool("Success", true);
    }

}
