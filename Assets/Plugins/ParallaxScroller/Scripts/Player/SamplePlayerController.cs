using UnityEngine;

namespace Plugins.ParallaxScroller.Scripts.Player{
    public class SamplePlayerController : MonoBehaviour{
    
        public float playerSpeed = 5f;
        
        void Update()
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0) * (playerSpeed * Time.deltaTime);
        }
    }
}
