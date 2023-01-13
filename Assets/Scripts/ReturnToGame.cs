using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Restart", 2f);
    }
    
    void Restart()
    {
        SceneManager.LoadScene("Level1");
    }
}
