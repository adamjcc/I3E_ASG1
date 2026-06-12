using System.Collections;
using UnityEngine;

public class BoulderScript : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private float secondsTillReset = 4f;
    [SerializeField] private float damagePerHit = 20f;
    [SerializeField] private float damageCooldown = 1f;
    private float nextDamageTime = 0f;

    private Vector3 _initialPosition;
    private Quaternion _initialRotation;
    private Rigidbody _rigidBody;

    private void Start() // save initial position, rotation + rigid body for when boulder resets
    {
        _initialPosition = transform.position;
        _initialRotation = transform.rotation;
        _rigidBody = GetComponent<Rigidbody>();

        StartCoroutine(ResetAfterDelay());

        audioSource = GetComponent<AudioSource>();
    }

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
