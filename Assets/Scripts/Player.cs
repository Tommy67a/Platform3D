using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rig;
    public float jumpForce;
    public Vector3 playerStartPos;

    public AudioSource gameOverSound;
    public AudioSource jumpSound;
    public AudioSource startSound;

    public UI ui;
    public int score;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] private IntSO scoreSO;

    private bool isGrounded;

    private void Awake()
    {
        startSound.Play();
        playerStartPos = transform.position;
    }

    private void Start()
    {
        scoreText.text = scoreSO.Value + "";
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        rig.velocity = new Vector3(x, rig.velocity.y, z);

        Vector3 vel = rig.velocity;
        vel.y = 0;

        if (vel.x !=0 || vel.z != 0)
        {
            transform.forward = vel;
        }  
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isGrounded = false;
            jumpSound.Play();
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (transform.position.y < -10)
        {
            GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal == Vector3.up)
        {
            isGrounded = true;
        }
    }

    public void GameOver ()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        transform.position = playerStartPos;
        gameOverSound.Play();
    }

    public void AddScore (int amount)
    {
        scoreSO.Value += amount;
        ui.SetScoreText(scoreSO.Value);
    }
}
