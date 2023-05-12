using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 20; // 動く速さ
    public Text scoreText;//スコアUI
    public Text winText;//リザルトUI

    private Rigidbody rb; // Rididbody
    private int score;//スコア

    // Start is called before the first frame update
    void Start()
    {
        // Rigidbody を取得
        rb = GetComponent<Rigidbody>();

        //UIの初期化
        score = 0;
        SetCountText();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        // カーソルキーの入力を取得
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        // カーソルキーの入力に合わせて移動方向を設定
        var movement = new Vector3(moveHorizontal, 0, moveVertical);

        // Ridigbody に力を与えて玉を動かす
        rb.AddForce(movement * speed);

        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameOver");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //ぶつかったオブジェクトが収集アイテムだった場合
        if (other.gameObject.CompareTag("Pick Up"))
        {
            //そのアイテムを非表示にする
            other.gameObject.SetActive(false);

            //スコアを加算
            score = score + 1;

            //UIを更新
            SetCountText();
        }
    }

    //UIを更新
    void SetCountText()
    {
        //スコアを更新
        scoreText.text = "Count:" + score.ToString();

        //すべてのアイテムを獲得した場合
        if (score >= 12)
        {
            //リザルトを更新
            winText.text = "You win!";
        }
    }
}
