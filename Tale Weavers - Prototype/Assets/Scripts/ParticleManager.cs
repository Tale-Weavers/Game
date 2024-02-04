using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem step;
    [SerializeField] private ParticleSystem bonk;

    private void OnEnable()
    {
        Player.attack += BonkParticle;
        Player.step += StepParticle;
    }

    private void OnDisable()
    {
        Player.attack -= BonkParticle;
        Player.step -= StepParticle;
    }

    private void StepParticle(Vector3 pos, Quaternion rot)
    {
        Instantiate(step, pos, rot);
    }
    private void BonkParticle(Vector3 pos)
    {
        Instantiate(bonk, pos, new Quaternion());
    }
}
