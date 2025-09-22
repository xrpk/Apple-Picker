using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 4;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    [Header("Round Display")]
    public TextMeshProUGUI roundText;
    public int currentRound = 1;
    public int maxRounds = 4;

    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i <= numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
        UpdateRoundDisplay();
    }
    
    void UpdateRoundDisplay()
    {
        if (roundText != null)
        {
            roundText.text = "Round " + currentRound;
        }
    }

    public void AppleMissed()
    {
        // destroy all the falling apples
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tempGO in appleArray)
        {
            Destroy(tempGO);
        }
        // also destroy all falling branches
        GameObject[] branchArray = GameObject.FindGameObjectsWithTag("Branch");
        foreach (GameObject tempGO in branchArray)
        {
            Destroy(tempGO);
        }

        //Destroy one basket
        //get index of last basket
        int basketIndex = basketList.Count - 1;
        //get a reference to that basket object
        GameObject basketGO = basketList[basketIndex];
        // remove the basket from the list and destroy
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);

        //if there are no baskets restart game
        if (basketList.Count == 0)
        {
            FindObjectOfType<ScoreCounter>().SaveFinalScore();
            SceneManager.LoadScene("GameOverScene");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
