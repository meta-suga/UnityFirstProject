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
    public EnemyUIManager enemyUIManager;
    public GameObject gameClearText;

    public int maxHp = 100;
    int hp;
    bool isDie;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
        HideWeaponCollider();
        hp = maxHp;
        enemyUIManager.Init(this);

    }

    void Update()
    {
        if (isDie) { return; }

        agent.destination = target.position;
        animator.SetFloat("Distance", agent.remainingDistance);
    }

    // 対象に体の向きを合わせる
    public void LookAtTarget()
    {
        transform.LookAt(target);
    }

    // 武器の判定を無効にする
    public void HideWeaponCollider()
    {
        weaponCollider.enabled = false;
    }
    // 武器の判定を有効にする
    public void ShowWeaponCollider()
    {
        weaponCollider.enabled = true;
    }

    void Damage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
            isDie = true;
            animator.SetTrigger("Die");
            // Destroy(gameObject, 2f); // 2秒後に削除
            gameClearText.SetActive(true); // ゲームクリアテキスト表示
        }
        enemyUIManager.UpdateHp(hp);
        Debug.Log("敵の残りHP : " + hp);
    }

    private void OnTriggerEnter(Collider other)
    {
        Damager damager = other.GetComponent<Damager>();
        if (damager != null) {
            // ダメージを持っているものにぶつかった場合の処理
            animator.SetTrigger("Hurt");
            Damage(damager.damage);
        }
    }
}
