using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameLogic : MonoBehaviour
{
    public float interval = 1f;
    private float lastInterval = 0f;

    public Slider t1HealthBar;
    public Slider t2HealthBar;
    
    public GameObject t1Target;
    public GameObject t2Target;

    public float t1Health = 100f;
    public float t2Health = 100f;

    public Animator t1Animator;
    public Animator t2Animator;

    public ParticleSystem t1ParticleSystem;
    public ParticleSystem t2ParticleSystem;
    

    public float attackDistance = 0.14f;
    
    void Start()
    {
        t1Animator = t1Target.GetComponent<Animator>();
        t2Animator = t2Target.GetComponent<Animator>();

        t1ParticleSystem = t1Target.GetComponentInChildren<ParticleSystem>();
        t2ParticleSystem = t2Target.GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        lastInterval += Time.deltaTime;

        if (t1Health <= 0)
        {
            t1Animator.SetBool("Died", true);
        }

        if (t2Health <= 0)
        {
            t2Animator.SetBool("Died", true);
        }
        
        if (Vector3.Distance(t1Target.transform.position, t2Target.transform.position) < attackDistance)
        {
            t1Animator.SetBool("InRange", true);
            if(!t1ParticleSystem.isPlaying) t1ParticleSystem.Play();
            if(!t2ParticleSystem.isPlaying) t2ParticleSystem.Play();
            t2Animator.SetBool("InRange", true);

            if (lastInterval >= interval)
            {
                if (t1Health == 0 || t2Health == 0)
                {
                    t1Animator.SetBool("InRange", false);
                    t2Animator.SetBool("InRange", false);
                    return;
                }
                
                float attackDamageT1 = Random.Range(2, 10);
                float attackDamageT2 = Random.Range(2, 10);

                if(t1Health > 0)
                    t1Health -= attackDamageT2;
                
                if(t2Health > 0)
                    t2Health -= attackDamageT1;

                t1HealthBar.value = 1 - t1Health / 100f;
                t2HealthBar.value = 1 - t2Health / 100f;

                lastInterval = 0f;
            }
        }
        else
        {
            t1Animator.SetBool("InRange", false);
            t2Animator.SetBool("InRange", false);

        }
    }
}
