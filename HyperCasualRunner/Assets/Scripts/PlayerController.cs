using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController _instance;
    private PlayerAnimator playerAnimator;
    private CrowdController crowdController;
    [SerializeField]
    float _moveSpeed;
    [SerializeField]
    float _sideSpeed;
    [SerializeField]
    float _roadWidth = 10f;
    Vector3 _clickedScreenPos;
    Vector3 _clickedPlayerPos;
    bool _canMove;

    void Awake()
    {
        if(_instance != null)
            Destroy(gameObject);
        else
            _instance = this;
    }
    void Start()
    {
        crowdController = GetComponent<CrowdController>();
        playerAnimator = GetComponent<PlayerAnimator>();
        GameManager.onGameStateChanged += GameStateChangedCallBack;
    }

    void OnDestroy()
    {
        GameManager.onGameStateChanged -= GameStateChangedCallBack;
    }
    void Update()
    {
        if(_canMove)
        {
            MoveFwd();
            ManageControl();
        }

    }

    private void GameStateChangedCallBack(GameManager.GameState gameState)
    {
        if(gameState == GameManager.GameState.GAME)
            StartMoving();
        else if(gameState == GameManager.GameState.GAMEOVER || gameState == GameManager.GameState.LEVELCOMPLETE)
            StopMoving();
    }



    private void StartMoving()
    {
        _canMove = true;
        playerAnimator.Run();
    }

    private void StopMoving()
    {
        _canMove = false;
        playerAnimator.Idle();
    }

    private void MoveFwd()
    {
        transform.position += Vector3.forward * Time.deltaTime *_moveSpeed;
    }

    private void ManageControl(){
        if(Input.GetMouseButtonDown(0))
        {
            // Get touch position
            _clickedScreenPos = Input.mousePosition;
            // Get player position when clicked
            _clickedPlayerPos = transform.position;
        }
        else if(Input.GetMouseButton(0))
        {
            // difference between touch position and finger slided position 
            float xScreenDifference = Input.mousePosition.x - _clickedScreenPos.x;
            // control move distance
            xScreenDifference /= Screen.width;
            // control move speed
            xScreenDifference *= _sideSpeed;

            // use a variable to avoid altering fwd 
            Vector3 pos = transform.position;
            //  move player sideways
            pos.x = _clickedPlayerPos.x + xScreenDifference;
            pos.x = Mathf.Clamp(pos.x, -_roadWidth/2 + crowdController.CrowdRadius(), _roadWidth/2 - crowdController.CrowdRadius());
            transform.position = pos;
        }
    }
}
