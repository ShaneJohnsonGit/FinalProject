using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            
            if (SceneManager.GetActiveScene().name == "level 1")
            {
                
                PlayerPrefs.SetInt("Health", player.GetComponent<Player>().health);
                PlayerPrefs.Save();
                SceneManager.LoadScene("Level 2");
                
            }
            else
            {
                
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
