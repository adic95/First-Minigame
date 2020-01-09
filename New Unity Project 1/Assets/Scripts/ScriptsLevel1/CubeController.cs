using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float m_Speed = 0.5f;
    public float m_Gravity = -9.81f;
    public float m_JumpPower = 2;
    public Text m_countText;
    public Text m_winText;

    public AudioClip m_PickUpSound;
    public AudioClip m_GameOverSound;
    public AudioClip m_WinSound;




    
    private CharacterController m_cubeCon;
    private float m_ySpeed;
    private int m_count;
    private AudioSource m_AudioSource;

    // Use this for initialization

    void Awake()
    {
        m_cubeCon = GetComponent<CharacterController>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        m_count = 0;
        CountText();
        m_winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //Bewegungsmechanik

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        move = transform.TransformDirection(move);
        move = move.normalized * Time.deltaTime * m_Speed;
        transform.Translate(move * Time.deltaTime * m_Speed);






        //Sprungmechanik
        // Gravity
        if (m_cubeCon.isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                m_ySpeed = m_JumpPower;
            }
            else
            {
                m_ySpeed = -0.01f;
            }
        }
        else
        {
            m_ySpeed += m_Gravity * Time.deltaTime;
        }
        move.y = m_ySpeed;
        m_cubeCon.Move(move);




    }

        //PickUp Mechanik des Players, wenn er ein Pick Up berührt
    void OnTriggerEnter(Collider _col2)
    {
        if (_col2.gameObject.CompareTag("Pick Up") )
        {
            _col2.gameObject.SetActive(false);
            m_count = m_count+ 1;
            CountText();
            m_AudioSource.PlayOneShot(m_PickUpSound);
            SetCountText();
           // AudioManager.Instance.PlaySelectedSound(1);


        }
        else if (_col2.gameObject.CompareTag("MP"))
        {
            transform.parent = _col2.transform;
        }

        else  if(_col2.gameObject.CompareTag("KB"))
        {
            m_AudioSource.PlayOneShot(m_GameOverSound);
            Debug.Log(m_GameOverSound);
        }

         else if(_col2.gameObject.CompareTag("WinZone"))
         {
            m_AudioSource.PlayOneShot(m_WinSound);
         }
       
    }

    void OnDestroy( )
    {
        AudioManager.Instance.PlaySelectedSound(0);
    }
    void OnTriggerExit (Collider _col2)
    {
       

        if (_col2.gameObject.CompareTag("MP"))
        {
            transform.parent = null;
        }

        
    }

    void CountText()
    {
        m_countText.text = "Count : " + m_count.ToString();
    }

    void SetCountText()
    {
        m_countText.text = "Count: " + m_count.ToString();
        if (m_count >= 12)
        {
            m_winText.text = "You Win!";

            
        }
    }


}
