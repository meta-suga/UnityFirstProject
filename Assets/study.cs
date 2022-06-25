using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stady : MonoBehaviour
{
    /**
     * 勉強メモ
     * 
     * Start関数  : Update関数が最初に呼び出される前に1回だけ呼び出される関数
     * Update関数 : 1フレームに1回呼び出される関数
     * フレーム    : 60fpsの場合1フレーム=1/60秒
     * 
     * キーボード入力：
     *  GetAxis    : 入力を1 ~ -1の値で受け取る
     *  GetAxisRaw : 1, 0, -1の値のみ受け取る
     *   例）
     *   Input.GetAxis("XXXXXX");
     *   Input.GetAxisRaw("XXXXXX");
     *    引数の"XXXXX"は受け取るベクトル
     *     "Horizontal" : キーボードの横方向の入力を受け取る
     *     "Vertical"   : キーボードの縦方向の入力を受け取る
     *      例）
     *      Input.GetAxis("Horizontal");
     * 　
     * 　GetKeyDown : キーボード入力を受けとる
     * 　 例）
     * 　 if (Input.GetKeyDown(KeyCode.Space)) { 
     * 　 　Debug.Log("Spaceを押した");
     * 　 }
     * 
     * Transform :
     *  ・位置、回転、倍率、GameObjectの親子関係をもつコンポーネント
     *  ・GameObjectには必ず必要なもの
     * 
     * Rigidbody :
     * ・物理演算を与えるもの
     * ・重力
     * ・速度
     * ・力
     * ・移動力の制御
     * ・摩擦/慣性
     * ・当たり判定に使用される
     *  
     * 自分自身のコンポーネントを取得
     *  GetComponent
     *  例）
     *  rd = GetComponent<Rigidbody>();
     *  自分自身に速度を与える
     *  rd.velocity = new Vector3(1, 0, 0);
     *  
     * 当たり判定 : 
     *  ・必要なもの（衝突する対象物両方にcollider, Rigidbodyが必要）
     *  ・IsTrigger（接触した時に硬さを持たない。通り抜ける感じにしたい時に使用する）
     *   参考ソース : CollisionChk.cs
     *   
     * アニメーション（コード不要） --------------
     *  ・設定方法
     *   ・Animator Controller : アニメーションの全体を管理？Animation clipの塊みたいなイメージ
     *   ・Animation Clip      : 1つ1つのアニメーション、動作
     *   Animator Controllerを新規作成して、
     *   GameObjectにadd componentで付与する
     *   Animation Clipは、DogKnightに入っているものを使用して動かしてみた
     *    path : Assets/DogKnight/Animations
     *  
     *  ・切り替え方法（アニメーションの遷移）
     *   ・Animator Controllerで矢印を繋げる
     *   ・遷移条件を作る
     *    ・パラメータを用意する
     *    ・条件を指定しなければ時間により遷移される
     *    例）
     *     HPが30以下になったら疲れたアニメーションに切り替える等
     *   ・Has exit timeは、今行っているアニメーションが終わったら遷移するか、すぐに遷移するかを制御できる
     *  
     * アニメーション（コード必要）----------------
     * ・Animatorコンポーネントを取得して、パラメータを変更させてアニメーションの切り替えを行う
     *  コンポーネント取得
     *  例）
     *   start関数でコンポーネント取得
     *   animator = GetComponent<Animator>();
     *  キーボード入力でtrigger起動
     *  例）
     *   if (Input.GetKeyDown(KeyCode.Space))
     *   {
     *       animator.SetTrigger("Attack");
     *   } 
     *   if (Input.GetKeyDown(KeyCode.M))
     *   {
     *       animator.SetFloat("MoveSpeed", 1.0f);
     *   }
     * 
     * 
     * ・アニメーションの途中で関数を実行する方法
     *  ・Animation Clipを活用する
     *   ・Animation Clipで関数を実行したいタイミングに、add eventで関数追加できる
     *     対象のobjectに紐づいているScriptにpublic関数を定義するとadd eventで選択可能
     * 
     * 
     *  
     *
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     */
}
