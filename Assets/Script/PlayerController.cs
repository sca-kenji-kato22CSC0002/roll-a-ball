using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 20; // ��������
    public Text scoreText;//�X�R�AUI
    public Text winText;//���U���gUI

    private Rigidbody rb; // Rididbody
    private int score;//�X�R�A

    // Start is called before the first frame update
    void Start()
    {
        // Rigidbody ���擾
        rb = GetComponent<Rigidbody>();

        //UI�̏�����
        score = 0;
        SetCountText();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        // �J�[�\���L�[�̓��͂��擾
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        // �J�[�\���L�[�̓��͂ɍ��킹�Ĉړ�������ݒ�
        var movement = new Vector3(moveHorizontal, 0, moveVertical);

        // Ridigbody �ɗ͂�^���ċʂ𓮂���
        rb.AddForce(movement * speed);

        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameOver");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //�Ԃ������I�u�W�F�N�g�����W�A�C�e���������ꍇ
        if (other.gameObject.CompareTag("Pick Up"))
        {
            //���̃A�C�e�����\���ɂ���
            other.gameObject.SetActive(false);

            //�X�R�A�����Z
            score = score + 1;

            //UI���X�V
            SetCountText();
        }
    }

    //UI���X�V
    void SetCountText()
    {
        //�X�R�A���X�V
        scoreText.text = "Count:" + score.ToString();

        //���ׂẴA�C�e�����l�������ꍇ
        if (score >= 12)
        {
            //���U���g���X�V
            winText.text = "You win!";
        }
    }
}