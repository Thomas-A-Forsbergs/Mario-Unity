using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMobile : MonoBehaviour
{
    bool isPlayerAlive = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        SceneManager.LoadScene("Defeat");
    }
}
