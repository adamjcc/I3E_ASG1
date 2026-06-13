/*
 * Author: Adam Clark
 * Date: 11 June 2026
 * Description: Manages playerHealth loss when boulder's touched, and resets boulder every few seconds using Coroutines
 */

using System.Collections;
using UnityEngine;

/// <summary>
/// Damages the player on collision, plays impact audio, and resets the boulder after a delay.
/// </summary>
public class BoulderScript : MonoBehaviour
{
    /// <summary>
    /// Audio source used to play boulder impact feedback.
    /// </summary>
    private AudioSource audioSource;

    /// <summary>
    /// Seconds between each boulder reset.
    /// </summary>
    [SerializeField] private float secondsTillReset = 4f;

    /// <summary>
    /// Damage dealt to the player when the boulder hits them.
    /// </summary>
    [SerializeField] private float damagePerHit = 20f;

    /// <summary>
    /// Minimum time between boulder damage hits.
    /// </summary>
    [SerializeField] private float damageCooldown = 1f;

    /// <summary>
    /// Next game time at which the boulder is allowed to damage the player.
    /// </summary>
    private float nextDamageTime = 0f;

    /// <summary>
    /// Starting position used when the boulder resets.
    /// </summary>
    private Vector3 _initialPosition;

    /// <summary>
    /// Starting rotation used when the boulder resets.
    /// </summary>
    private Quaternion _initialRotation;

    /// <summary>
    /// Rigidbody used to clear movement and spin during reset.
    /// </summary>
    private Rigidbody _rigidBody;

    /// <summary>
    /// Stores reset data, starts the reset loop, and caches the audio source.
    /// </summary>
    private void Start() // save initial position, rotation + rigid body for when boulder resets
    {
        _initialPosition = transform.position;
        _initialRotation = transform.rotation;
        _rigidBody = GetComponent<Rigidbody>();

        StartCoroutine(ResetAfterDelay());

        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Repeatedly waits for the reset delay, then returns the boulder to its starting transform and clears velocity.
    /// </summary>
    /// <returns>Coroutine delay instruction.</returns>
    IEnumerator ResetAfterDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(secondsTillReset);

            transform.position = _initialPosition;
            transform.rotation = _initialRotation;
            _rigidBody.linearVelocity = Vector3.zero;
            _rigidBody.angularVelocity = Vector3.zero;
        }
    }

    /// <summary>
    /// Damages the player when the boulder collides with them and the damage cooldown has expired.
    /// </summary>
    /// <param name="collision">Collision data for the object hit by the boulder.</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            if (Time.time >= nextDamageTime)
            {
                playerHealth.HealthLoss(damagePerHit);
                nextDamageTime = Time.time + damageCooldown;
                if (audioSource != null)
                {
                    audioSource.Play();
                }
            }
        }
    }
}
