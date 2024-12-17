using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Animator anim; // animator la thang dieu khien anim con animation la clip
    [SerializeField] protected HealthBar healthBar;
    [SerializeField] protected CombatText CombatTextPrefab;

    private float hp;
    private string currentAnimName;
    public bool IsDead => hp <= 0; // td la tuong minh hon

    private void Start()
    {
        OnInit();    
    }

    // object chua thong so thay doi can 2 ham nay
    public virtual void OnInit()
    {
        hp = 100;
        healthBar.OnInit(100, transform);
    }

    public virtual void OnDespawn()
    {

    }

    protected virtual void OnDeath()
    {
        ChangeAnim("die");
        Invoke(nameof(OnDespawn), 2f);
    }

    protected void ChangeAnim(string animName)
    {
        if (currentAnimName != animName)
        {
            anim.ResetTrigger(animName);

            currentAnimName = animName;

            anim.SetTrigger(currentAnimName);
        }
    }
    public void OnHit(float damage)
    {
        if(!IsDead)
        {
            hp -= damage;

            if(IsDead)
            {
                hp = 0;
                OnDeath();
            }

            healthBar.SetNewHp(hp);
            Instantiate(CombatTextPrefab, transform.position + Vector3.up, Quaternion.identity).OnInit(damage);
        }
    }

    
}
