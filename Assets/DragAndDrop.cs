using UnityEngine;
using UnityEngine.SceneManagement;
public class DragAndDrop : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Vector3 originalPosition;
    int CardsMatched;
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Drag()
    {
        //GameObject.Find("image").transform.position = Input.mousePosition;
        gameObject.transform.position = Input.mousePosition;
    }
    public void Drop()
    {
        /*GameObject ph1 = GameObject.Find("PH1");
        GameObject img = GameObject.Find("image");
        float distance = Vector3.Distance(ph1.transform.position, img.transform.position);
        if (distance <= 50)
        {
            img.transform.position = ph1.transform.position;
        }
        */
        CheckMatch();
    }
    public void CheckMatch()
    {
        //GameObject ph1 = GameObject.Find("PH1");
        //GameObject img = GameObject.Find("image");
        GameObject img = this.gameObject;
        string tag = this.gameObject.tag;
        GameObject ph1 = GameObject.Find("PH" + tag);
        float distance = Vector3.Distance(ph1.transform.position, img.transform.position);
        if (distance <= 50)
        {
            Snap(img, ph1);

            var cardsMatched = GameObject.Find("managePuzzleGame");
            // print("matched: " + this.GetComponent<ManagePuzzleGame>().cardsMatched++);
            CardsMatched = cardsMatched.GetComponent<ManagePuzzleGame>().cardsMatched++;
            print("Matched Cards: " + CardsMatched);
            if (CardsMatched >= 24)
            {
                SceneManager.LoadScene("endScreen");
            }
        }
        else
        {
            MoveBack();
        }
    }
    public void MoveBack()
    {
        transform.position = originalPosition;
    }
    public void Snap(GameObject img, GameObject ph)
    {
        img.transform.position = ph.transform.position;
    }
    public void InitCardPosition()
    {
        originalPosition = transform.position;
    }
}
