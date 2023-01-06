using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackroundScroller : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Material myMaterial;
    Vector2 offset;


    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        offset = new Vector2(moveSpeed, 0f);


    }

    // Update is called once per frame
    void Update()
    {
        myMaterial.mainTextureOffset += offset * Time.deltaTime;
    }


    public void SetOffset(float moveSpeed)
    {
        offset = new Vector2(moveSpeed, 0f);
    }








}
