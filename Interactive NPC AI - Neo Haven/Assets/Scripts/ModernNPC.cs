using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenAI;

public class ModernNPC : ChatGPT
{
    [SerializeField] private Animator anim;

    private void awake()
    {
        anim = GetComponent<Animator>();
    }

    public override void SpecialTrait()
    {
        base.SpecialTrait();
        anim.SetTrigger("Talking");
    }

    public override void Exit()
    {
        anim.SetTrigger("Exit");
        base.Exit();
        
    }
}
