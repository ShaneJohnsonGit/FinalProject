using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LossScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public void tryAgain()
    {
        SceneManager.LoadScene("menu");
    }
    
}
