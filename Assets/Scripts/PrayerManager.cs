using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/**
 * キューブにぶつかったらクリアのシンプルゲーム
 */

public class PrayerManager : MonoBehaviour
{
    void Start()
    {
        Debug.Log("スタート");
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // キーボード入力に合わせて移動させる
        transform.position += new Vector3(x, 0, z) * 0.1f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("終了");
        // ぶつかったら初期画面（初期表示）に戻す
        SceneManager.LoadScene("SampleScene");
    }
}
