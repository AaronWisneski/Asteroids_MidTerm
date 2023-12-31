using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public PlayerMovement player;
    public int lives = 3;
    public float respawnTime = 3.0f;
    public float InvulTime = 3.0f;
    public ParticleSystem explosion;
    public int score = 0;
    public TextMeshProUGUI scoredisplay;
    public TextMeshProUGUI livedisplay;

    public void AsteroidDestroyed(Asteroid asteroid)
    {
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();

        score++;
        scoredisplay.text = score.ToString();
    }
    public void VampireDestroyed(Vampire vampire)
    {
        this.explosion.transform.position = vampire.transform.position;
        this.explosion.Play();

        score=score+2;
        scoredisplay.text = score.ToString();
    }
    public void PlayerDied()
    {
        this.explosion.transform.position = this.player.transform.position;
        this.explosion.Play();
        this.lives--;
        livedisplay.text = lives.ToString();

        if (this.lives <= 0)
        {
            GameOver();
        }
        else
        {
            Invoke(nameof(Respawn), this.respawnTime);
        }
    }

    private void Respawn()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("Immunity");
        this.player.gameObject.SetActive(true);
        Invoke(nameof(TurnOnCollisions), InvulTime);
    }

    private void TurnOnCollisions()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }
    private void GameOver()
    {
        //take to game over screen
        Debug.Log("GameOver");
        SceneManager.LoadScene("GameOver");
    }
}
