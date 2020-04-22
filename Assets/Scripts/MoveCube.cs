using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCube : MonoBehaviour
{
    [SerializeField]
    private Text debugText;

    private CubeControls cubeControls;
    private Vector2 move;
    
    // Start is called before the first frame update
    void Awake()
    {
        cubeControls = new CubeControls();
        cubeControls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        cubeControls.Gameplay.Move.canceled += ctx => move = Vector2.zero;
    }

    private void OnEnable() => cubeControls.Enable();
    private void OnDisable() => cubeControls.Disable();

    // Update is called once per frame
    void Update()
    {
        //Move the cube around
        Vector2 movePosition = new Vector2(move.x, move.y) * Time.deltaTime;
        transform.Translate(movePosition, Space.World);
        
        //Display Input
        if (debugText)
        {
            debugText.text = string.Format("Debug inputs:\n-XAxis: {0}\n-YAxis: {1}", move.x, move.y);
        }
    }
}
