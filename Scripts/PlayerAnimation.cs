using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;

    private string SLEEPENDANIMATION = "sleep_end";
    private string IDLEANIMATION = "idle";
    private string ATTACK1PARAMETR = "Attack1";
    private string ATTACK2PARAMETR = "Attack2";
    private string JUMPPARAMETR = "jump";

    //
    private string WALKPARAMENTR = "walk";//имя параметра

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

  public void PlayerWalk(bool walk)
    {
        anim.SetBool(WALKPARAMENTR, walk);
    }

    public void EndSleep()
    {
        //anim.Play(SLEEPENDANIMATION);//с помощью евента в анимации!
    }

    public void BeginIdle()
    {
        //anim.Play(IDLEANIMATION);//с помощью евента в анимации!
    }

    public void Attack1()
    {
        anim.SetBool(ATTACK1PARAMETR, true);
    }
    public void EndAttack1()
    {
        anim.SetBool(ATTACK1PARAMETR, false);
    }
    public void Attack2()
    {
        anim.SetBool(ATTACK2PARAMETR, true);
    }
    public void EndAttack2()
    {
        anim.SetBool(ATTACK2PARAMETR, false);
    }
    public void Jumped(bool hasJumped)
    {
        anim.SetBool(JUMPPARAMETR, hasJumped);
    }

}
