using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyScript : MonoBehaviour
{
    [SerializeField] private Animator _animator;    // Animator component
    private Rigidbody[] _ragdollBodies;              // Rigidbody components of enemy's parts
    private Collider[] _ragdollColliders;            // Collider components of enemy's parts
    
    /// <summary>
    /// Initialize the fields
    /// </summary>
    private void Start()
    {
        _ragdollBodies = GetComponentsInChildren<Rigidbody>();
        _ragdollColliders = GetComponentsInChildren<Collider>();
        ToggleRagdoll(false);
    }

    /// <summary>
    /// Set the enemy to be a ragdoll
    /// </summary>
    /// <param name="state"> Is a ragdoll </param>
    private void ToggleRagdoll(bool state)
    {
        _animator.enabled = !state;

        foreach (Rigidbody rb in _ragdollBodies)
        {
            rb.isKinematic = !state;
        }

        foreach (Collider collider in _ragdollColliders)
        {
            collider.enabled = state;
        }
    }

    /// <summary>
    /// Wait for respawn an enemy after its death
    /// </summary>
    /// <returns></returns>
    private IEnumerator RespawnEnemy()
    {
        yield return new WaitForSeconds(5f);
        ToggleRagdoll(false);
        var newPosition = new Vector3(Random.Range(0f, 20f), 0,
            Random.Range(0f, 20f));
        transform.parent.transform.position = newPosition;
    }

    /// <summary>
    /// Wait the condition to act diyng
    /// </summary>
    private void Update()
    {
        if (PlayerScript.IsPossibleAttack && Input.GetKeyDown(KeyCode.Space))
        {
            ToggleRagdoll(true);
            StartCoroutine(RespawnEnemy());
        }
    }
}
