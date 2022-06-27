using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    Animator animator;
    public Collider weaponCollider;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
        hideWeaponCollider();

    }

    void Update()
    {
        agent.destination = target.position;
        animator.SetFloat("Distance", agent.remainingDistance);
    }

    // 武器の判定を無効にする
    public void hideWeaponCollider()
    {
        weaponCollider.enabled = false;
    }
    // 武器の判定を有効にする
    public void showWeaponCollider()
    {
        weaponCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Damager damager = other.GetComponent<Damager>();
        if (damager != null) {
            // ダメージを持っているものにぶつかった場合の処理
            animator.SetTrigger("Hurt");
        }
    }
}
