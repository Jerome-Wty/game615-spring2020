using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : ReactiveObj
{
    Animator m_animator;
    private void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    public override void ReactStart()
    {
        m_animator.SetTrigger("Open");
    }


}
