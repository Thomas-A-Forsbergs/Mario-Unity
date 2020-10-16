using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyStationary : MonoBehaviour
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
    
    void OnTriggerEnter2D(Collider2D other) {
        SceneManager.LoadScene("Defeat");
    }
}
