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
     * ・攻撃時にダメージを与える実装
     * 　・武器に当たり判定を入れる
     * 　　・武器にmesh colliderをaddする
     * 　　　convexとis triggerにチェック入れる
     * 　・相手にも当たり判定を入れる
     * 　　・相手自身にCapsule colliderをaddする
     * 　　・当たり判定の大きさを決める
     * 　　・is triggerにチェック入れる
     * 　　
     * 　・OnTriggerEnterで当たり判定を入れる
     * 　　武器にかかわらず、当たったらログ出るまでできた
     * 　
     * ・武器に当たったらダメージを与える
     * 　Scriptを新規作成して、publicの変数を定義して武器にaddする
     * 　プレイヤーのonTriggerに以下を記載
     *       private void OnTriggerEnter(Collider other)
     *       {
     *           Damager damager = other.GetComponent<Damager>();
     *           if (damager != null) {
     *               // ダメージを持っているものにぶつかった場合の処理
     *               Debug.Log("ダメージを受けた");
     *           }
     *       }
     * 　other.GetComponentで当たり判定を行いたいobjectを選択できる
     * 
     * ・ダメージを受けた時のアニメーションをつける
     * 　ダメージを受けるのは、いつでも遷移したいので、Any Stateからトランザクションを紐づける
     * 　triggerでダメージを受けたら遷移するように設定
     * 
     * ・武器に当たるだけでダメージを受けてしまう（構えている状態でも）修正
     * 　animation clipを触る
     * 　攻撃の振り始めにadd event
     * 　攻撃の振り切ったところでadd event
     * 　　振り始めのタイミングで、武器のcolliderを無効化する
     * 　　例）
     * 　　weaponCollider.enabled = false;
     * 　　
     * 　　publicでcolliderの変数を定義して、
     * 　　add eventで使用する関数で有効、無効を切り替える
     * 　グローバル変数で定義した後はそのゲームオブジェクトの変数に対象の武器colliderを忘れずに設定しておく
     * 
     * ・ダメージを受けている時も移動できてしまうので、修正
     * 　攻撃の時と同じでbehaviorでスピードを0にしてあげる
     * 　
     * ・ダメージ受けている時に再度攻撃を受けると、またダメージを受けるアニメーションをするので修正
     * 　ダメージを受けるアニメーションのbehaviorでanimator.ResetTriggerを行う
     * 
     * ・HPの実装
     *  プレイヤーにhp変数を持たせる
     *  start関数で初期化
     *  ローカル関数を作成し、hpを減らす処理を実装
     *  武器の当たり判定の処理の中にで、上で作成したローカル関数を実行し攻撃を与える
     *  すでに実装したdamagerがdamage変数を持っており、攻撃力が格納されているので、そちらを使用
     * 
     * ・HPのUIを実装
     * 　ゲームオブジェクトの追加→UI→Canvas
     * 　作成後に右クリック→UI→Slider
     * 　つまみとか色々削除
     * 　バックグランドはダメージ負ってる風に赤とかにする
     * 　後は大きさとか変更してあげればそれっぽくなった
     * 　
     * 　slider管理するScript作成
     * 　　コードからHPの変更
     * 　　　※詳細はPlayerUIManager.cs
     * 　　引数のhpを受け取ったら、sliderのvalueを更新する関数を作成
     * 　　作成したらCanvasにaddして、パブリックのsliderを選択
     * 　　できたらプレイヤーのScriptから前に作成したHP減算処理でslider更新関数を呼び出す。
     * 
     * ・HPを頭の上に表示させてみる
     * 　Canvasの値を変更する
     * 　EnemyUICanvas（ゲームオブジェクト）をEnemy（ゲームオブジェクト）にドラッグで入れる
     * 　　CanvasのRender ModeをWorld spaceに変更
     * 　　スライダーのサイズなどを修正して良い感じにする
     * 　　
     * ・HPがキャラの向きによって一緒に変わってしまうので、前を向くようにする
     * 　コードからカメラの向きを常に前、フロント側を向くようにしてあげるとよい
     * 　例）
     * 　transform.LookAt(Camera.main.transform);
     * 　詳細はLookAtCamera.cs
     * 　
     * 　HPが逆向きに減ってしまうので、sliderの向きを180度変えるとかで対応する
     * 
     * ・Hpが0になったら倒れる動きをつける
     * 　・アニメーションの設定
     * 　　アニメーションは攻撃を受けたアニメーションからtriggerで遷移させる
     * 　・コードから実行
     * 　　PlayerManagerでhpが0になった場合の処理の中にアニメーション遷移のtriggerを起動させる
     * 　　死んだ後も攻撃を受け付けてしまうので、hpを判定して0なら攻撃を受け付けないようにするなどして対応
     * 　　死んだ後も移動できてしまうので、死んだらキーボード入力を受け付けないように対応
     * 
     * ・ゲームクリアとゲームオーバー作ってみる
     * 　UI→canvas
     * 　canvas→Text
     * 　任意文字を入れて、場所とかサイズ決める
     * 　
     * 　画面表示に関しては、簡単な方法で実装
     * 　プレイヤーのhpが0になったら、ゲームオーバーテキスト（ゲームオブジェクト）をアクティブにする。
     * 　敵のhpが0になったら、ゲームクリアテキスト（ゲームオブジェクト）をアクティブにする
     * 　　プレイヤーのスクリプトでゲームオーバーのオブジェクトを管理するのは微妙なとこ。。
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
