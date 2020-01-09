using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using  UnityEditor.PackageManager.UI;

public class LoadSceneOnClick : MonoBehaviour
{

    public void Load(float Speed)
    {
        SceneManager.LoadScene(1);


        PlatformMover.m_SpeedMultiplier = Speed;
        /*PlatformMover[] platforms = FindObjectsOfType<PlatformMover>();
        Debug.Log(platforms.Length);

        foreach (PlatformMover pm in platforms)
        {
            pm.m_Speed = Speed;
        }*/
    }
}