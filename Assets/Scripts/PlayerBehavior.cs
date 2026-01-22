using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    //Determine hoe fast the player moves
    public float speed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed){
            Debug.Log("Left arrow  OR A key was pressed.");
            Vector3 newPos = transform.position;
            newPos.x = newPos.x - speed;
            transform.position = newPos;

        } else if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed){
            Debug.Log("Right arrow OR D Key was pressed.");
            Vector3 newPos = transform.position;
            newPos.x = newPos.x + speed;
            transform.position = newPos;
        } 
    }
}
