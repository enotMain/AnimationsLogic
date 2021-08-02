using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animatorPlayer;      // Animator component
    public GameObject _weapon;                              // Weapon object
    public GameObject _sword;                               // Sword object

    /// <summary>
    /// Initialize the fields
    /// </summary>
    private void Awake()
    {
        _animatorPlayer = GetComponent<Animator>();
        _sword.transform.position = _weapon.transform.position;
    }

    /// <summary>
    /// Act
    /// </summary>
    private void Update()
    {
        ActionOnW();
        ActionOnS();
        ActionOnA();
        ActionOnD();
        AttackOnCondition();
    }

    /// <summary>
    /// Act when W is pressed
    /// </summary>
    private void ActionOnW()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _animatorPlayer.SetBool("IsMoveForward", true);
        }
        else
        {
            _animatorPlayer.SetBool("IsMoveForward", false);
        }
    }

    /// <summary>
    /// Act when S is pressed
    /// </summary>
    private void ActionOnS()
    {
        if (Input.GetKey(KeyCode.S))
        {
            _animatorPlayer.SetBool("IsMoveBack", true);
        }
        else
        {
            _animatorPlayer.SetBool("IsMoveBack", false);
        }
    }

    /// <summary>
    /// Act when A is pressed
    /// </summary>
    private void ActionOnA()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _animatorPlayer.SetBool("IsMoveLeft", true);
        }
        else
        {
            _animatorPlayer.SetBool("IsMoveLeft", false);
        }
    }

    /// <summary>
    /// Act when D is pressed
    /// </summary>
    private void ActionOnD()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _animatorPlayer.SetBool("IsMoveRight", true);
        }
        else
        {
            _animatorPlayer.SetBool("IsMoveRight", false);
        }
    }

    /// <summary>
    /// Act when attack condition is on
    /// </summary>
    private void AttackOnCondition()
    {
        if (PlayerScript.IsPossibleAttack && Input.GetKeyDown(KeyCode.Space))
        {
            _animatorPlayer.Rebind();
            _weapon.SetActive(false);
            _sword.SetActive(true);
            _animatorPlayer.SetBool("IsFinishing", true);
        }
        else
        {
            _animatorPlayer.SetBool("IsFinishing", false);
        }
    }
}
