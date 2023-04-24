using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [Header("Movement")]
    private CharacterController _controller;
    public GameBehavior gameManager;
    private Rigidbody rb;
    private CapsuleCollider _col;
    private GameBehavior _gameManager;
    public GameObject bullet;
    public float bulletSpeed = 100f;
    private Vector3 movementDirection = Vector3.zero;
    public LayerMask groundLayer;
    [SerializeField]
    public float _moveSpeed = 25f;
    public float jumpSpeed = 10f;
    [SerializeField]
    public float _rotSpeed = 10f;
    public float gravity = 20f;
    public Camera _followCamera;
    public AudioClip hitsaudio;
    public AudioClip Honk;


    private void Start()
    {
            _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Movement();
    }

    void Movement()
    {
            float hInput = Input.GetAxis("Horizontal");
            float vInput = Input.GetAxis("Vertical");
            rb = GetComponent<Rigidbody>();
            _col = GetComponent<CapsuleCollider>();
            gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
            _gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();


            if (_controller.isGrounded)
            {
                Vector3 movementInput = Quaternion.Euler(0, _followCamera.transform.eulerAngles.y, 0) * new Vector3(hInput, 0 , vInput);
                movementDirection = movementInput.normalized;
                movementDirection *= _moveSpeed;
            

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    movementDirection.y = jumpSpeed;    
                }
            }

            if(movementDirection != Vector3.zero)
            {
                Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, _rotSpeed * Time.deltaTime);
            }
            movementDirection.y -= gravity * Time.deltaTime;
            _controller.Move(movementDirection * _moveSpeed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bullet, this.transform.position + new Vector3(1, 0, 0), this.transform.rotation) as GameObject;
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = this.transform.forward * bulletSpeed;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = Honk;
            audio.Play(); 
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Enemy")
        {
            Hit();
            _gameManager.HP -= 1;
        }
    }    
    void Hit()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = hitsaudio;
        audio.Play();   
    }
}