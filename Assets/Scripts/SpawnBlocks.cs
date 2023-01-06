using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour
{


    [SerializeField] BiomeChange biomeChange;
    [SerializeField] GameObject tileToSpawn;
    [SerializeField] float offset = 0.1f;



    GameObject instantiatedBlock;
    GameObject instantiatedBlock2;
    GameObject instantiatedBlock3;
    GameObject instantiatedBlock4;
    bool canStart = false;
    float nextSpawn = 11.6f;
    float positionOffset = 1f;
    bool canDestroy = false;
    float stopDestroying;
    bool canSetNextPosition = true;
    float initialOffset;
    bool canSetHeight = true;

    private void Start()
    {
        initialOffset = offset;
    }


    void Update()
    {

        if (tileToSpawn.GetComponent<BlockSpawner>().GetStartSpawning())
        {
            canStart = true;
            if (canSetNextPosition)
            {
                nextSpawn = transform.position.x + 0.6f;
                canSetNextPosition = false;
            }
        }
        if (canStart && transform.position.x >= nextSpawn)
        {
            nextSpawn++;
            canSetHeight = false;
            instantiatedBlock = Instantiate(tileToSpawn.GetComponent<BlockSpawner>().GetGrassTile(), new Vector2(transform.position.x - offset, transform.position.y), Quaternion.identity) as GameObject;
            instantiatedBlock2 = Instantiate(tileToSpawn.GetComponent<BlockSpawner>().GetDirtTile(), new Vector2(transform.position.x - offset, transform.position.y - 1), Quaternion.identity) as GameObject;
            instantiatedBlock3 = Instantiate(tileToSpawn.GetComponent<BlockSpawner>().GetDirtTile(), new Vector2(transform.position.x - offset, transform.position.y - 2), Quaternion.identity) as GameObject;
            instantiatedBlock4 = Instantiate(tileToSpawn.GetComponent<BlockSpawner>().GetDirtTile(), new Vector2(transform.position.x - offset, transform.position.y - 3), Quaternion.identity) as GameObject;
            instantiatedBlock.gameObject.tag = "Instantiated Block";
            instantiatedBlock2.gameObject.tag = "Instantiated Block";
            instantiatedBlock3.gameObject.tag = "Instantiated Block";
            instantiatedBlock4.gameObject.tag = "Instantiated Block";
            offset += initialOffset;
            positionOffset++;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tileToSpawn.GetComponent<BlockSpawner>().GetStartSpawning() && collision.gameObject.tag == "Grass")
        {
            stopDestroying = transform.position.x;
            Debug.Log(stopDestroying);
            canDestroy = true;
            canStart = false;
            tileToSpawn.GetComponent<BlockSpawner>().SetStartSpawning(false);
            positionOffset = 1f;
            canSetNextPosition = true;
            offset = initialOffset;
            canSetHeight = true;
        }





    }

    private void OnTriggerStay2D(Collider2D collision)
    {


        if (canDestroy && collision.gameObject.tag != "Instantiated Block")
        {
            Destroy(collision.gameObject);

            if (transform.position.x > stopDestroying + 0.5f)
            {
                canDestroy = false;
            }

        }
    }
    

    public bool GetCanSetHeight()
    {
        return canSetHeight;
    }

}
