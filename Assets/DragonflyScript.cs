using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UIElements;

public class DragonflyScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool isAlive;
    public GameObject flap;
    public GameObject hover;
    private int screenTime = 0;
    public AudioSource src;
    public AudioClip flap0, flap1, flap2;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
            flap.SetActive(true);
            hover.SetActive(false);
            PlaySound();
        }
        else if (screenTime < 25)
        {
            screenTime++;
        }
        else
        {
            hover.SetActive(true);
            flap.SetActive(false);
            screenTime = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    public void Die()
    {
        isAlive = false;
        logic.GameOver();
    }

    public void PlaySound()
    {
        int rnd = Random.Range(0, 3);
        if (rnd == 0)
        {
            src.clip = flap0;
            src.Play();
        }
        else if (rnd == 1)
        {
            src.clip = flap1;
            src.Play();
        }
        else
        {
            src.clip = flap2;
            src.Play();
        }
    }
}
