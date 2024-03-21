using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TowerExpolsion : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] ExplosionParticles;
    [SerializeField] private float ExplosionDelay;
    [SerializeField] private float DestroyDelay;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            PlayEffect();
    }

    [ContextMenu("Effect")]
    public void PlayEffect()
    {
        StartCoroutine(PlayExplosionParticles());
    }

    private IEnumerator PlayExplosionParticles()
    {
        foreach (var s in ExplosionParticles)
        {
            s.Play();
            yield return new WaitForSeconds(ExplosionDelay);
        }

        yield return new WaitForSeconds(DestroyDelay);
        Destroy(gameObject);
    }
}
