using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public int m_PlayerNumber = 1;
    public float m_Speed = 12f;

    public AudioSource m_MovementAudio;
    public AudioClip m_EngineIdling;
    public AudioClip m_EngineDriving;
    public float m_PitchRange = 0.2f;


    private string m_MovementXAxisName;
    private string m_MovementYAxisName;
    private string m_Fire1Name;

    private Rigidbody m_Rigidbody;

    private float m_XMovementInputValue;
    private float m_YMovementInputValue;
    private bool m_IsFire;

    private float m_OriginalPitch;

    public GameObject projectile;
    public float fireDelta = 0.5F;

    private float nextFire = 0.5F;
    private GameObject newProjectile;
    private float myTime = 0.0F;


    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }


    private void OnEnable()
    {
        m_Rigidbody.isKinematic = false;
        m_XMovementInputValue = 0f;
        m_YMovementInputValue = 0f;
    }


    private void OnDisable()
    {
        m_Rigidbody.isKinematic = true;
    }


    private void Start()
    {
        //So that in the project properties->input we get mapped to Vertical1 and Verical2 axis
        m_MovementXAxisName = "Vertical" + m_PlayerNumber;
        m_MovementYAxisName = "Horizontal" + m_PlayerNumber;
        m_Fire1Name = "Fire1" + m_PlayerNumber;

        m_OriginalPitch = m_MovementAudio.pitch;
    }


    private void Update()
    {
        // Store the player's input and make sure the audio for the engine is playing.
        m_XMovementInputValue = Input.GetAxis(m_MovementXAxisName);
        m_YMovementInputValue = Input.GetAxis(m_MovementYAxisName);
        m_IsFire = Input.GetButton(m_Fire1Name);

        FireIfNeeded();
    }


    //private void EngineAudio()
    //{
    //    // Play the correct audio clip based on whether or not the tank is moving and what audio is currently playing.
    //    if (Mathf.Abs(m_MovementInputValue) < 0.1f
    //        && Mathf.Abs(m_TurnInputValue) < 0.1f)
    //    {
    //        if (m_MovementAudio.clip == m_EngineDriving)
    //        {
    //            m_MovementAudio.clip = m_EngineIdling;
    //            m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
    //            m_MovementAudio.Play();
    //        }
    //    }
    //    else
    //    {
    //        if (m_MovementAudio.clip == m_EngineIdling)
    //        {
    //            m_MovementAudio.clip = m_EngineDriving;
    //            m_MovementAudio.pitch = Random.Range(m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
    //            m_MovementAudio.Play();
    //        }
    //    }
    //}


    private void FixedUpdate()
    {
        // Move and turn the tank.
        Move();
    }


    private void Move()
    {
        // Adjust the position of the tank based on the player's input.
        Vector3 movement = new Vector3(m_XMovementInputValue, 0f, m_YMovementInputValue)
             //movement input (we got from update method)
            * m_Speed //scale
            * Time.deltaTime;//way to guarentee that you move at the speed/pace of time

        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }

    private void FireIfNeeded()
    {
        myTime = myTime + Time.deltaTime;

        if (m_IsFire && myTime > nextFire)
        {
            Debug.Log(m_Fire1Name + "FIRE!");
            nextFire = myTime + fireDelta;
            newProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            
            // create code here that animates the newProjectile

            nextFire = nextFire - myTime;
            myTime = 0.0F;
        }
       
    }


    //private void Turn()
    //{
    //    // Adjust the rotation of the tank based on the player's input.
    //    float turnDegrees = m_TurnInputValue
    //        * m_TurnSpeed
    //        * Time.deltaTime;

    //    Quaternion turnRotation = Quaternion.Euler(0f, turnDegrees, 0f);

    //    m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    //}
}
