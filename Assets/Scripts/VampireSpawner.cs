using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class VampireSpawner : MonoBehaviour
{
    public Vampire vampirePrefab;
    public PlayerMovement  player;
    public float spawnRate = 2.0f;
    public int spawnAmount = 1;
    public float spawnDistance = 15.0f;
    public float trajectoryVariance = 1.0f;
    private void Start()
    {
        //basically a fancy loop thatll keep activating on the spawnrate timer
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    private void Spawn()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;
            
            float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Vampire vampire = Instantiate(this.vampirePrefab, spawnPoint, rotation);
            // vampire.SetTrajectory(rotation * -spawnDirection); //randome trajectory
            ////not random trajectory
            //Vector2 distance = this.player.transform.position - this.vampirePrefab.transform.position;
            //float angle = Mathf.Atan2(distance.y, distance.x);
            //angle = Mathf.Rad2Deg;
            //Quaternion direction = Quaternion.AngleAxis(angle,Vector3.forward);
            //vampire.SetTrajectory(direction *-spawnDirection);
          
            
                vampire.Move(vampire.transform);
            
        }
    }
}
