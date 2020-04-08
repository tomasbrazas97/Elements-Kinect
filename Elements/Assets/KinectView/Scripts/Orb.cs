using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Orb : MonoBehaviour
{
    public Sprite mOrbSprite;
    public Sprite mPopSprite;

    [HideInInspector]
    public OrbManager mOrbManager = null;

    private Vector3 mMovementDirection = Vector3.zero;
    private SpriteRenderer mSpriteRenderer = null;
    private Coroutine mCurrentChanger = null;

    private void Awake()
    {
        mSpriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void Start()
    {
        mCurrentChanger = StartCoroutine(DirectionChanger());
    }

    private void OnBecameInvisible()
    {
        transform.position = mOrbManager.GetPlanePosition();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += mMovementDirection * Time.deltaTime * 0.5f;

        transform.Rotate(Vector3.forward * Time.deltaTime * mMovementDirection.x * 20, Space.Self);
    }

    public IEnumerator Pop()
    {
        mSpriteRenderer.sprite = mPopSprite;
        StopCoroutine(mCurrentChanger);
        mMovementDirection = Vector3.zero;
        ScoreScript.scoreValue += 1;

        yield return new WaitForSeconds(0.5f);

        transform.position = mOrbManager.GetPlanePosition();

        mSpriteRenderer.sprite = mOrbSprite;
        mCurrentChanger = StartCoroutine(DirectionChanger());

    }
    private IEnumerator DirectionChanger()
    {
        while (gameObject.activeSelf)
        {
            mMovementDirection = new Vector2(Random.Range(-100, 100) * 0.01f, Random.Range(0, 100) * 0.01f);

            yield return new WaitForSeconds(5.0f);
        }
    }
}
