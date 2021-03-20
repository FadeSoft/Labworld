using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{

    public PlayerMovementLab movement;
    void OnCollisionEnter(Collision collisionınfo)
    {
        if (collisionınfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            Time.timeScale = 0;

            Destroy(collisionınfo.gameObject);

        }
        else if (collisionınfo.collider.tag == "End")
        {
            SceneManager.LoadScene(2);
        }
    }

   


}
