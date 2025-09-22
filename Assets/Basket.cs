using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    // Start is called before the first frame update
    void Start()
    {
        //find a gameobject named scorecounter in the scene hiercy
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        //get the scorecounter script component of scoreGO
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        ///get the current screen pos of the mouse for input
        Vector3 mousePos2D = Input.mousePosition;

        //
        //
        //
        mousePos2D.z = -Camera.main.transform.position.z;

        //convert the point form 2d screen space into 3d game world sapce
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //move the x position of the basket 2 the x of the mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        // find out what hit this basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Apple"))
        {
            Destroy(collidedWith);
            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
        }// else if ne
        else if (collidedWith.CompareTag("Branch"))
        {
            // Branch caught - Game Over!
            Destroy(collidedWith);

            // Destroy all falling objects
            GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
            foreach (GameObject tempGO in appleArray)
            {
                Destroy(tempGO);
            }

            GameObject[] branchArray = GameObject.FindGameObjectsWithTag("Branch");
            foreach (GameObject tempGO in branchArray)
            {
                Destroy(tempGO);
            }

            // Save score and go to game over
            scoreCounter.SaveFinalScore();
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
