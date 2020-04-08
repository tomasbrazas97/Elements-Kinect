using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrbManager : MonoBehaviour
{
    public GameObject[] orbs;


    private List<Orb> mAllOrbs = new List<Orb>();
    private Vector2 mBottomLeft = Vector2.zero;
    private Vector2 mTopRight = Vector2.zero;

    //public SpriteRenderer spriteRenderer;
   // public Sprite[] spriteArray;
  //  public int currentSprite;

    private void Awake()
    {
        //Bounding values
        mBottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.farClipPlane));
        mTopRight = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight / 2, Camera.main.farClipPlane));
    }

    // Start is called before the first frame update
    private void Start()
    {

        StartCoroutine(CreateOrbs());
    }

   /* void ChangeSprite()
    {
        spriteRenderer.sprite = spriteArray[currentSprite];
        currentSprite++;

        if (currentSprite >= spriteArray.Length)
        {
            currentSprite = 0;
        }
    }*/

    public Vector3 GetPlanePosition()
    {
        // Random Position
        float targetX = Random.Range(mBottomLeft.x, mTopRight.x);
        float targetY = Random.Range(mBottomLeft.y, mTopRight.y);

        return new Vector3(targetX, targetY, 0);

    }

    private IEnumerator CreateOrbs()
    {
        while (mAllOrbs.Count < 10)
        {
            // Create and add
            // ChangeSprite();
            GameObject newOrbObject = Instantiate(orbs[UnityEngine.Random.Range(0, 4)], GetPlanePosition(), Quaternion.identity, transform);
            Orb newOrb = newOrbObject.GetComponent<Orb>();

            // Setup orb
            newOrb.mOrbManager = this;
            mAllOrbs.Add(newOrb);

            yield return new WaitForSeconds(0.5f);
        }


    }
    
}
