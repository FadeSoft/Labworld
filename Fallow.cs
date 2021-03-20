using UnityEngine;

public class Fallow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void Update()
    {
        transform.position = player.position + offset;
    }

    public Camera cam1;
    public Camera cam2;
    private void Start()
    {
        cam2.enabled = false;
    }
    public void Cam2()
    {
        cam1.enabled = false;
        cam2.enabled = true;
    }

    public void Cam1()
    {
        cam1.enabled = true;
        cam2.enabled = false;
    }
    public void sss()
    {

        Time.timeScale = 0f;

    }


}

