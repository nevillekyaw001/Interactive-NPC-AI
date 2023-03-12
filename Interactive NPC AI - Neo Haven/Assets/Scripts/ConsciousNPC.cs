using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenAI;

public class ConsciousNPC : ChatGPT
{
    [SerializeField] private Animator anim;

    private void awake()
    {
        anim = GetComponent<Animator>();
    }

    public override void Exit()
    {
        anim.SetTrigger("Exit");
        base.Exit();

    }

}
