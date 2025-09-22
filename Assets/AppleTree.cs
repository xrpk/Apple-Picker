using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    // Prefab for instantiating apples
    public GameObject applePrefab;
    // Prefab for instantiating branches
    public GameObject branchPrefab;
    // Speed at witch the apple tree moves
    public float speed = 1f;
    // Distance where apple tree turns around
    public float leftAndRightEdge = 10f;
    // Chance that the Apple Tree will change directions
    public float changeDirChance = 0.1f;
    // seconds between apple insantiations
    public float appleDropDelay = 0.1f;
    // seconds between branch drops (much longer delay)
    public float branchDropDelay = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        // start dropping apples
        Invoke("DropApple", 2f);
        // start dropping branches (less frequently)
        Invoke("DropBranch", Random.Range(5f, 10f)); // Random delay between 5-10 seconds
    }
    
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
    }
    
    void DropBranch()
    {
        GameObject branch = Instantiate<GameObject>(branchPrefab);
        branch.transform.position = transform.position;
        
        // Optional: Make branches fall slightly differently
        Rigidbody rb = branch.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Add some downward velocity to make branches fall faster
            rb.velocity = new Vector3(0, -2f, 0);
        }
        
        // Schedule next branch drop with random delay (much less frequent than apples)
        float nextBranchDelay = Random.Range(branchDropDelay * 3f, branchDropDelay * 8f);
        Invoke("DropBranch", nextBranchDelay);
    }
    
    // Update is called once per frame
    void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        // Changing Direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // move left
        }
        // else if (Random.value < changeDirChance)
        // {
        //    speed *= -1; // change direction
        // }
    }
    
    void FixedUpdate()
    {
        // random direction changes are now time based
        if (Random.value < changeDirChance)
        {
            speed *= -1; // change direction
        }
    }
}