using UnityEngine;
using UnityEngine.SceneManagement;


public class EndTriggerLab : MonoBehaviour
{
    public int level_id;
    public Gamemanager gameManager;
    
    void Start()
    {
        level_id = PlayerPrefs.GetInt("levelid");
        
    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(2);

        if (level_id < 19){
            level_id++;

        }
        PlayerPrefs.SetInt("levelid", level_id);

        gameManager.CompleteLevel();
    }

   
}