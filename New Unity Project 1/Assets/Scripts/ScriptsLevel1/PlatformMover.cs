using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    public Transform[] m_Targets;
    public float m_Speed = 3;
    private int m_currentWaypoint;
    public bool m_Reverse;
    public static float m_SpeedMultiplier = 1;

    // Use this for initialization
    void Start ()
    {
        m_Speed = m_Speed * m_SpeedMultiplier;
	}

    // Update is called once per frame
    void Update()
    {
        if (m_Targets.Length == 0)
        {
            Debug.LogError("Mindestens ein Waypoint notwendig");
            return;
        }
        Transform curTarget = m_Targets[m_currentWaypoint];

        Vector3 move = curTarget.position - transform.position;

        // Normalisierung ändert die Länge eines Vektors auf 1
        // Die Richtung wird nicht beeinflusst
        move = move.normalized;


        if (move.sqrMagnitude > (transform.position - curTarget.position).sqrMagnitude)
        {
            transform.position = curTarget.position;

            if (m_Reverse)
            {
                m_currentWaypoint = (m_currentWaypoint - 1 + m_Targets.Length) % m_Targets.Length;
            }
            else
            {
                m_currentWaypoint = (m_currentWaypoint + 1) % m_Targets.Length;
            }
        }

        else
        {
            transform.Translate(move * Time.deltaTime * m_Speed);
        }
    }







}

  