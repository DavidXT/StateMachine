using AITournament.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : AAI
{
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private float _maxAngle;

    private const float _rotationAccuracy = 1;
    private const float _fullAngle = 360;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //on récupère l'input de l'espace pour le test
        {
            Vector3 tempDirection = _target.position - transform.position; //on calcule la direction de la target

            if (Vector3.Angle(transform.forward, tempDirection) < _maxAngle) //Si la target est dans l'angle de visée
            {
                GameObject tempObj = SpawnBullet(Quaternion.identity);//on tire
                tempObj?.transform.LookAt(_target.position);//on demande à la bullet de regarder la target
            }
            else//sinon
            {
                StartCoroutine(CoroutineRotation());//on effectue une rotation
            }
        }
    }

    private IEnumerator CoroutineRotation()
    {
        //on calcule la différence d'angle à appliquer
        Vector3 tempFakePosition = _target.position;
        tempFakePosition.y = transform.position.y;
        float tempAngle = Vector3.SignedAngle(transform.forward, tempFakePosition - transform.position, Vector3.up);

        //on l'applique ensuite sur la rotation pour obtenir la rotation finale
        Vector3 tempRotation = transform.eulerAngles;
        Vector3 tempEndRotation = tempRotation;
        tempEndRotation.y += tempAngle;
        float tempIndex = 0;

        while (Mathf.Abs((transform.eulerAngles.y - tempEndRotation.y) % _fullAngle) > _rotationAccuracy)
        {//tant que la rotation finale n'est pas atteinte

            //on fait tourner l'IA sur elle même
            transform.eulerAngles = Vector3.Slerp(tempRotation, tempEndRotation, tempIndex);

            //grâce à son indice de temps et sa vitesse de rotation
            tempIndex += Time.deltaTime * _angularSpeed;
            yield return null;//en attendant chaque nouvelle frame
        }
    }
}