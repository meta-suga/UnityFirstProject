using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/**
 * 当たり判定
 * ・必要なもの（衝突する対象物両方にcollider, Rigidbodyが必要）
 * ・IsTrigger
 * 
 */

public class CollisionChk : MonoBehaviour
{
    // 衝突した際に実行される関数
    // 硬さを持った衝突を行う。（当たったら跳ね返ったりする）
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter: ぶつかった！");
    }

    // 衝突した際に実行される関数（衝突しても通り抜ける）
    // 実行するには、box colliderをonにする
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter: ぶつかった！");
    }
    // 衝突が終わった際に実行される関数
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit: 離れたよ");
    }

    // 衝突している間に実行される関数
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay: 衝突中");
    }

}
