using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static MiniGestureRecognizer;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private LayerMask brickLayer;
    [SerializeField] private GameObject brickPrefab;
    [SerializeField] private float hightBrick;
    [SerializeField] private GameObject playerRender;
    
    [SerializeField] private Transform brickList;

    private bool isMoving = false;
    private Vector3 moveDir = Vector3.forward;
    private Vector3 targetPos;
    List<GameObject> playerBricks;
    private void Start()
    {
        playerBricks = new List<GameObject>();
        targetPos = transform.position;
        
    }
    private void Update()
    {
       if (Vector3.Distance(transform.position, targetPos) < 0.01f)
        {
          isMoving = false;         
          return;
        }

       isMoving = true;
       transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);        
    }

    private void OnEnable()
    {
        MiniGestureRecognizer.Swipe += Move;
    }

    private void OnDisable()
    {
        MiniGestureRecognizer.Swipe -= Move; 
    }

    private void FindTargetPos(Vector3 direction)
    {
        RaycastHit hit;
        Vector3 rayStart;
        Vector3 rayDir;
            
        for (int i = 1; i <= 40; i++)
        {
            rayStart = transform.position + (direction * i) + Vector3.up*0.5f;
            rayDir = Vector3.down;
            Debug.DrawRay(rayStart, rayDir, Color.red, 1f);
            if (Physics.Raycast(rayStart, rayDir, out hit,brickLayer))
            {
                targetPos = hit.collider.transform.position; /// lay tam cua thang va cham

                targetPos.y = transform.position.y; // position y cua target luon bang player
                                          
            }
            else
            {
                return;
            }
        }
    }

    private void Move(SwipeDirection dir)
    {
       
            if (isMoving) return;
            switch (dir)
            {
                case SwipeDirection.Up:
                    moveDir = Vector3.forward;
                    transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                    break;
                case SwipeDirection.Down:
                    moveDir = Vector3.back;
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    break;
                case SwipeDirection.Left:
                    moveDir = Vector3.left;
                    transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                    break;
                case SwipeDirection.Right:
                    moveDir = Vector3.right;
                    transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
                    break;

            }
            FindTargetPos(moveDir);
                    
    }

    private void AddBrick(GameObject brick)
    {
       
        brick = Instantiate(brickPrefab, brickList);
        playerBricks.Add(brick);
        playerRender.transform.position = new Vector3(transform.position.x, transform.position.y  + hightBrick, transform.position.z);
        brick.transform.position = new Vector3(transform.position.x, transform.position.y -.25f + hightBrick, transform.position.z);
        brick.transform.rotation = Quaternion.Euler(270,0,0);
        hightBrick += 0.25f;
        
        
    }

    private void RemoveBrick(GameObject brick)
    {     
      
        if (playerBricks.Count >0) 
        {
            playerBricks.Remove(brick);
            playerRender.transform.position -= Vector3.up * 0.25f;
            hightBrick -= 0.25f;
        }
        //playerRender.transform.position = new Vector3(transform.position.x, transform.position.y - hightBrick, transform.position.z);
        //brick.transform.position = new Vector3(transform.position.x, transform.position.y - .25f - hightBrick, transform.position.z);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("brickGround"))
        {
            Destroy(collider.gameObject);
            AddBrick(brickPrefab); 
            
        }
        else if (collider.gameObject.CompareTag("removeBrick"))
        {
            if (playerBricks.Count > 0)
            {
                GameObject brickToRemove = playerBricks[playerBricks.Count - 1];
                //Debug.Log("Bricks before removal: " + playerBricks.Count);
                RemoveBrick(brickToRemove);
                Destroy(brickToRemove);
                //Debug.Log("Bricks after removal: " + playerBricks.Count);

            }
        }


    
    }


     
    
}
