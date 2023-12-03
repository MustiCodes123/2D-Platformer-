using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] RuntimeAnimatorController animatorController;
    [SerializeField] AnimatorOverrideController animatorOverrideController;

    // Start is called before the first frame update
    void Start()
    {
        animator.runtimeAnimatorController = animatorController;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateSkin()
    {
        if (animator.runtimeAnimatorController == animatorController)
        {
            animator.runtimeAnimatorController = animatorOverrideController;
        }
        else
            animator.runtimeAnimatorController = animatorController;
    }
}
