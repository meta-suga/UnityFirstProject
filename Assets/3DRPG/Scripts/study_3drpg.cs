using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class study_3drpg: MonoBehaviour
{
    /**
     * 
     * ・新規プロジェクト作成
     * ・モデルインポート 
     * ・キャラクター配置 
     * ・地面作成
     * ・キャラクターの移動
     * 　キーボード入力で移動させる
     * 　publicで変数を定義することで、inspectorから変更可能
     * 　
     * ・アニメーションの設定
     * 　animator controllerを新規作成して、使用するanimation clipを定義
     * 　animator controllerでアニメーションの遷移を紐付ける
     * 　　（デフォルト状態から歩く状態）
     * 　アニメーションの遷移条件を設定する
     * ・アニメーションの切り替え
     * 　コードからアニメーションの遷移条件のパラメータを更新する。
     * 　　（キーボード入力があったらspeedパラメータを増やす等）
     * 　　 例）
     * 　　   rb.velocity = new Vector3(x, 0, z) * moveSpeed;
     * 　　   animator.SetFloat("Speed", rb.velocity.magnitude); 
     * 　　   
     * ・キャラクターの方向転換を行う
     * 　キャラクターが方向キーの方を向く
     * 　LookAt(xx) : 位置xxの方を向く
     * 
     * ・キャラクターの攻撃の実装
     * 　・スペースボタンを押したら攻撃をするようにする
     * 　　・まずはスペースを押したら攻撃ログを出す
     * 　　・できたら攻撃アニメーションの設定を行う
     * 　　　triggerで遷移するようにする。
     * 　　・スペースボタンを押したらtriggerを実行する。
     * 　　　例）
     * 　　　animator.SetTrigger("Attack");
     * 
     * ・攻撃しながら方向転換したり移動が出来るので、修正する
     * 　・攻撃アニメーション中は移動しているスピードを0にして、動きを止める
     * 　・攻撃アニメーションを抜ける時に元にスピードを元に戻す
     * 　・攻撃のanimation clipのinspectorからBehaviourをaddする
     * 　　・OnStateEnter  : アニメーション開始時に実行される
     * 　　・OnStateUpdate : アニメーション中に実行される
     * 　　・OnStateExit   : アニメーションを抜ける時に実行される
     * 　例）
     * 　// 攻撃するときに速度を0にする
     *   animator.GetComponent<PlayerManager>().moveSpeed = 0;
     * 
     * ・敵キャラクター配置
     * ・なんか適当にstoreからモデルインポートして配置
     * ・敵を自動で動かしてみる
     * 　・navMeshAgentを使ってみる
     * 　　inspectorからadd componentで選択
     * 　　window→AI→navigation
     * 　　地面などのオブジェクトをstaticで認識させてあげる
     * 　　
     * ・EnemyManagerを作成して、コードから追跡対象を設定する
     * 　プレイヤーを追跡
     * 　NavMeshAgentに追跡対象を連携する。
     * 　例）　※詳細はEnemyManager参照
     * 　agent.destination = target.position;
     * 　
     * 　近づきすぎとか速さは、inspectorで設定可能
     * 　NavMeshAgentのspeedとかstopping Distance
     * 　
     * ・敵キャラクターのアニメーション設定
     * 　・基本はプレイヤーと一緒で、条件遷移は距離を対象にする
     * 　以下でいけそう
     * 　animator.SetFloat("Distance", agent.remainingDistance);
     * 
     * ・ずっと追いかけてくるので、修正
     * 　（アイドル状態でも、攻撃しながらも追いかけてくる）
     * 　アイドル状態の時と、攻撃の時はスピードを0にする
     * 　移動する時はスピードを2くらいにする
     * 　Behaviourで対応
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
