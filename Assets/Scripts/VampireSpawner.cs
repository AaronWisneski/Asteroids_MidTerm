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
            Vector3 spawnPoint = player.transform.position + spawnDirection;
            
            float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            Vampire vampire = Instantiate(this.vampirePrefab, spawnPoint, rotation);
            // vampire.SetTrajectory(rotation * -spawnDirection); //randome trajectory
            //not random trajectory
            // vampire.SetTrajectory(direction * -spawnDirection);
            Quaternion angle = Quaternion.RotateTowards(vampire.transform.rotation, this.player.transform.rotation, 0);
            vampire.SetTrajectory(-spawnDirection);

            // vampire.Move(vampire.transform);

        }
    }
}
