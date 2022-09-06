using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;

    public float speed = 7.5f;
    public float gravityModifier = 2;
    public bool isOnGround = true;
    public bool isGameOver = false;
    public bool isDead = false;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip crashSound;
    public AudioClip jumpSound;
    // Start is called before the first frame update
    void Start()
    {

        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        //playerRb.AddForce(Vector3.up * 1000);

    }




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            playerAnim.SetTrigger("Jump_trig");
            playerRb.AddForce(Vector3.up * speed , ForceMode.Impulse);
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            isOnGround = false;

        }

        if(isDead == true)
        {
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            speed = 0;
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over Boy!");
            isGameOver = true;
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            isDead = true;
        }


       
    }
}
