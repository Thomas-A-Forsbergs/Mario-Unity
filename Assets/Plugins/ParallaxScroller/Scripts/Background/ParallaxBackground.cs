using UnityEngine;

namespace Plugins.ParallaxScroller.Scripts.Background{
    public class ParallaxBackground : MonoBehaviour{

        [SerializeField, Range(-1, 1)] float depthRelativeToPlayer;
        [SerializeField] bool repeatingBackgroundX;
        //[SerializeField] bool repeatingBackgroundY;
        [SerializeField] bool backgroundFollowCamera;

        Transform cameraTransform;
        Vector3 lastCameraPosition;
        Vector3 offset;
        float textureUnitSizeX;
        float textureUnitSizeY;
        float screenWidthUnits;
        
        public bool RepeatingBackgroundX{
            get => repeatingBackgroundX;
            set => repeatingBackgroundX = value;
        }
        /*   public bool RepeatingBackgroundY{
               get => repeatingBackgroundY;
               set => repeatingBackgroundY = value;
           }*/
        public bool BackgroundFollowCamera{
            get => backgroundFollowCamera;
            set => backgroundFollowCamera = value;
        }
        public float DepthRelativeToPlayer{
            get => depthRelativeToPlayer;
            set => depthRelativeToPlayer = value;
        }

        void Start(){
            cameraTransform = Camera.main.transform;
            lastCameraPosition = cameraTransform.position;
            var spriteRenderer = GetComponent<SpriteRenderer>();
            var sprite = spriteRenderer.sprite;
            var texture2D = sprite.texture;
            textureUnitSizeX = texture2D.width / sprite.pixelsPerUnit;
            textureUnitSizeY = texture2D.height / sprite.pixelsPerUnit;
            offset = cameraTransform.position - transform.position;
            screenWidthUnits = 2 * Camera.main.orthographicSize * Screen.width / Screen.height;

            #region Calculate Number of Repeats of Sprite
            if (BackgroundFollowCamera || (DepthRelativeToPlayer >= 1)){
                return;
            }

            var numberOfRepeats = Mathf.RoundToInt(4 * screenWidthUnits / textureUnitSizeX);
            if (numberOfRepeats < 3){
                numberOfRepeats = 3;
            }
            else{
                numberOfRepeats = numberOfRepeats % 2 == 0 ? numberOfRepeats + 1 : numberOfRepeats;
            }

            spriteRenderer.size *= new Vector2(numberOfRepeats, 1);
            #endregion
        }

        void LateUpdate(){
            if (backgroundFollowCamera){
                transform.position = cameraTransform.position - offset;
                return;
            }

            var deltaMovement = cameraTransform.position - lastCameraPosition;
            transform.position += new Vector3(deltaMovement.x * depthRelativeToPlayer,
                deltaMovement.y * depthRelativeToPlayer, 0);
            lastCameraPosition = cameraTransform.position;
            if (repeatingBackgroundX)
                if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX){
                    var offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
                    transform.position =
                        new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
                }

            /* if (repeatingBackgroundY)
                 if (Mathf.Abs(cameraTransform.position.y - transform.position.y) >= textureUnitSizeY){
                     var offsetPositionY = (cameraTransform.position.y - transform.position.y) % textureUnitSizeY;
                     transform.position = new Vector3(cameraTransform.position.x, transform.position.y + offsetPositionY);
                 }*/
        }
    }
}