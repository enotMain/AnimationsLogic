using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private float _speed = 5f;
    public Text _textAttack;
    public static bool IsPossibleAttack;

    private void Awake()
    {
        IsPossibleAttack = (transform.position - GameObject.FindGameObjectWithTag("Enemy").transform.position)
            .magnitude < 5f;
        if (IsPossibleAttack)
        {
            _textAttack.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        IsPossibleAttack = (transform.position - GameObject.FindGameObjectWithTag("Enemy").transform.position)
            .magnitude < 5f;

        ActOnA();
        ActOnD();
        ActOnS();
        ActOnW();
        
        TextUI();
        ActOnAttack();
    }

    /// <summary>
    /// Attack
    /// </summary>
    private void ActOnAttack()
    {
        if (IsPossibleAttack && Input.GetKeyDown(KeyCode.Space))
        {
            GameObject enemyGameObj = GameObject.FindGameObjectWithTag("Enemy");
            transform.position = enemyGameObj.transform.position -
                (enemyGameObj.transform.position - transform.position) * 0.4f;

            Vector3 difference = enemyGameObj.transform.position - transform.position;
            difference.Normalize();
            float rotationY = Mathf.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
        }
    }

    /// <summary>
    /// Text UI that show possibility of attack
    /// </summary>
    private void TextUI()
    {
        if (IsPossibleAttack)
        {
            _textAttack.gameObject.SetActive(true);
        }
        else
        {
            _textAttack.gameObject.SetActive(false);
        }

    }

    /// <summary>
    /// Act when W is pressed
    /// </summary>
    private void ActOnW()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * _speed * Time.deltaTime;
        }
    }

    /// <summary>
    /// Act when A is pressed
    /// </summary>
    private void ActOnA()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += -transform.right * _speed * Time.deltaTime;
        }
    }
    
    /// <summary>
    /// Act when D is pressed
    /// </summary>
    private void ActOnD()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * _speed * Time.deltaTime;
        }
    }

    /// <summary>
    /// Act when S is pressed
    /// </summary>
    private void ActOnS()
    {
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * _speed * Time.deltaTime;
        }
    }
}

