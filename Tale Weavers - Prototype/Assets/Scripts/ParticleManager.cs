using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem step;
    [SerializeField] private ParticleSystem bonk;
    [SerializeField] private ParticleSystem alert;
    [SerializeField] private ParticleSystem blind3;
    [SerializeField] private ParticleSystem blind2;
    [SerializeField] private ParticleSystem blind1;
    [SerializeField] private ParticleSystem oilStep;

    private void OnEnable()
    {
        Player.attack += BonkParticle;
        Player.step += StepParticle;
        Player.oilStep += OilStepParticle;
        GameManager.alert += Alert;
        MoveableEnemy.blinded += BlindedParticle;
        StaticEnemy.blinded += BlindedParticle;
    }

    private void OnDisable()
    {
        Player.attack -= BonkParticle;
        Player.step -= StepParticle;
        Player.oilStep -= OilStepParticle;
        GameManager.alert -= Alert;
        MoveableEnemy.blinded -= BlindedParticle;
        StaticEnemy.blinded -= BlindedParticle;
    }

    private void StepParticle(Vector3 pos, Quaternion rot)
    {
        Instantiate(step, pos, rot);
    }
    private void BonkParticle(Vector3 pos)
    {
        Instantiate(bonk, pos, new Quaternion());
    }
    private void OilStepParticle(Player parent)
    {
        Instantiate(oilStep, parent.transform);
    }
    private void Alert(Enemy parent)
    {
        Instantiate(alert, parent.transform);
    }
    private void BlindedParticle(Enemy parent, int stage)
    {
        switch (stage)
        {
            case 1:
                Instantiate(blind1, parent.transform);
                break;
            case 2:
                Instantiate(blind2, parent.transform);
                break;
            case 3:
                Instantiate(blind3, parent.transform);
                break;
            default:
                break;
        }
    }
}
