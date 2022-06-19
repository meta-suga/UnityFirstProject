using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeyboard : MonoBehaviour
{
    // Start関数：Update関数が最初に呼び出される前に1回だけ呼び出される関数
    void Start()
    {
        Debug.Log("start");
    }

    // Update関数：1フレームに1回呼び出される関数
    // フレーム：60fpsの場合1フレーム=1/60秒
    void Update()
    {
        // Horizontal: キーボードの横方向の入力を受け取る
        // Vertical: キーボードの縦方向の入力を受け取る

        //// GetAxis: 入力を1 ~ -1の値で受け取る
        //float x = Input.GetAxis("Horizontal");
        //Debug.Log("x : " + x);
        //float z = Input.GetAxis("Vertical");
        //Debug.Log("z : " + z);

        //// GetAxisRaw: 1, 0, -1の値のみ受け取る      
        //float rawX = Input.GetAxisRaw("Horizontal");
        //Debug.Log("rawX : " + rawX);
        //float rawZ = Input.GetAxisRaw("Vertical");
        //Debug.Log("rawZ : " + rawZ);

        // ボタン入力
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Aを押した");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spaceを押した");
        }
    }
}
