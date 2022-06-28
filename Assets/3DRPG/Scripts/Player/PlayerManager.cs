using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    float x;
    float z;
    public float moveSpeed = 3; // inspectorから編集可能
    public Collider weaponCollider;
    public PlayerUIManager playerUIManager;
    public GameObject gameOverText;
    public int maxHp = 100;

    int hp;
    bool isDie;


    Rigidbody rb;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        HideWeaponCollider();
        hp = maxHp;
        playerUIManager.Init(this);
    }

    void Update()
    {
        if (isDie) { return; }

        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Attack");
        }
    }

    private void FixedUpdate()
    {
        if (isDie) { return; }

        // 向き変換
        Vector3 direction = transform.position + new Vector3(x, 0, z) * moveSpeed;
        transform.LookAt(direction);

        // 速度を設定
        rb.velocity = new Vector3(x, 0, z) * moveSpeed;
        animator.SetFloat("Speed", rb.velocity.magnitude); 
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
            gameOverText.SetActive(true); // ゲームオーバーテキスト表示
        }
        playerUIManager.UpdateHp(hp);
        Debug.Log("プレイヤー残りHP : " + hp);
    } 


    private void OnTriggerEnter(Collider other)
    {
        if (hp <= 0) { return; }

        Damager damager = other.GetComponent<Damager>();
        if (damager != null)
        {
            // ダメージを持っているものにぶつかった場合の処理
            animator.SetTrigger("Hurt");
            Damage(damager.damage);
        }
    }
}
