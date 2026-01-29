using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    //Determine hoe fast the player moves
    public float speed;
    //Object in player's hands
    public GameObject HeldObject;
    //Current prefab of the object
    private GameObject CurrentHeldObject;

    public float OffY = -0.6f;
    public float OffX = 0.5f;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If we are holding something put in player's hand
        if(CurrentHeldObject != null){
            //current player position
            //Only need transform.posiiton
            Vector3 playerPos = transform.position;
            Vector3 ObjectOffset = new Vector3(OffX, OffY, 0.0f);
            CurrentHeldObject.transform.position  = playerPos + ObjectOffset;
        }
        else
        {
            CurrentHeldObject = Instantiate(HeldObject, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        }
        //Drop item
        if (Keyboard.current.spaceKey.wasPressedThisFrame){
            //if holding something drop it...
            if (CurrentHeldObject != null)
            {
                Rigidbody2D body = CurrentHeldObject.GetComponent<Rigidbody2D>();

                body.gravityScale = 1.0f;

                Collider2D collider = CurrentHeldObject.GetComponent<Collider2D>();
            
                collider.enabled = true;

                CurrentHeldObject = null;
            }

        }
        
        //Keyboard movement of player
        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed){
            //Debug.Log("Left arrow  OR A key was pressed.");
            Vector3 newPos = transform.position;
            newPos.x -= speed;
            transform.position = newPos;

        } else if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed){
            //Debug.Log("Right arrow OR D Key was pressed.");
            Vector3 newPos = transform.position;
            newPos.x += speed;
            transform.position = newPos;
        } 
    }
}
