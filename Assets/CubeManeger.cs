using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Transformコンポーネントについて
 * ・位置、回転、倍率、GameObjectの親子関係をもつコンポーネント
 * ・GameObjectには必ず必要なもの
 */

/**
 * Rigidbodyについて
 * ・物理演算を与えるもの
 * ・重力
 * ・速度
 * ・力
 * ・移動力の制御
 * ・摩擦/慣性
 * ・当たり判定に使用される
 */

public class CubeManeger : MonoBehaviour
{
    Rigidbody rd;

    void Start()
    {
        // 自分自身のコンポーネントを取得するのはGetComponentを使用
        // ただし、Transformについては使用頻度が高いためGetComponentしなくても使用可能
        // Transform tf = GetComponent<Transform>();

        rd = GetComponent<Rigidbody>();
        // 速度を与える
        //rd.velocity = new Vector3(1, 0, 0);
        
    }

    // 1フレーム(0.02秒)に一回実行される
    void Update()
    {
        // 1フレーム毎に右に移動させてみる
        //transform.position += new Vector3(0.1f, 0, 0);
        //transform.Translate(new Vector3(0.1f, 0, 0));
        // 回転させてみる
        //transform.Rotate(new Vector3(0.1f, 0, 0));

        // 力を加えてみる
        rd.AddForce(new Vector3(1, 0, 0));
    }
}
