using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BlockSpawner : MonoBehaviour
{


    [SerializeField] GameObject grassTile;
    [SerializeField] GameObject dirtTile;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject enemyTrigger;
    [SerializeField] GameObject background;
    [SerializeField] GameObject player;
    [SerializeField] GameObject destroyer;
    [SerializeField] GameObject triggerer;
    [SerializeField] BiomeChange biomeChange;
    [SerializeField] GameObject spawnBlock;
    [SerializeField] GameObject snowParticle;
    [SerializeField] GameObject clouds;
    [SerializeField] GameObject windSpawnerLeft;
    [SerializeField] GameObject windSpawnerRight;
    [SerializeField] GameObject meteorSpawner;
    [SerializeField] GameObject scoreCounter;

    [SerializeField] GameObject[] green;
    [SerializeField] Material greenBackground;
    [SerializeField] GameObject[] snow;
    [SerializeField] Material snowBackground;
    [SerializeField] GameObject[] desert;
    [SerializeField] Material desertBackground;
    [SerializeField] GameObject[] planet;
    [SerializeField] Material planetBackground;
    [SerializeField] GameObject[] red;
    [SerializeField] Material redBackground;
    [SerializeField] GameObject[] stone;
    [SerializeField] Material stoneBackground;
    [SerializeField] GameObject[] blue;
    [SerializeField] Material blueBackground;

    [SerializeField] GameObject destroyBlocksOnBiome;
    [SerializeField] GameObject blocks;

    [SerializeField] float blocksInstantiateOffset = 3f;

    GameObject destroyerInstantiated;
    GameObject triggererInstantiated;
    GameObject blockDestroyer;


    int randomHeightOfPlatform;
    int currentBiomeNumber = 0;
    float heightOfPlatform;
    float heightOffset = 0.5f;
    int randomEmptySpace;
    int randomSizeOfPlatform;
    float instantiateAt;
    float instantiateAtPosition;
    float nextPos;
    int lastHeight = -3;
    int nextBiome;
    bool canStart = false;
    int randomLenghtOfBiome;
    int instantiateUntil;
    bool getInstantiateUntil = false;
    Vector2 cameraPosition;
    bool startSpawning = false;
    
    
    void Start()
    {

        destroyerInstantiated = null;

        randomLenghtOfBiome = UnityEngine.Random.Range(100, 160);


        randomEmptySpace = UnityEngine.Random.Range(2, 5);

        randomSizeOfPlatform = UnityEngine.Random.Range(4, 15);
        instantiateAt = 9.6f + transform.position.x;
        instantiateAtPosition = instantiateAt;
        nextPos = 0f;



    }

    
    void FixedUpdate()
    {




        if (transform.position.x >= nextPos)
        {
          if(spawnBlock.GetComponent<SpawnBlocks>().GetCanSetHeight())
            {
                randomSizeOfPlatform = UnityEngine.Random.Range(4, 15);
                randomEmptySpace = UnityEngine.Random.Range(2, 5);
            }
            else
            {
                randomSizeOfPlatform = 14;
                randomEmptySpace = 3;
            }




        instantiateAt = 9.6f + transform.position.x + randomEmptySpace;
            Instantiate(enemyTrigger, new Vector3(instantiateAt -0.4f, heightOfPlatform + 1.5f, 0), Quaternion.identity);
            Instantiate(enemyTrigger, new Vector3(instantiateAt - 0.6f + randomSizeOfPlatform, heightOfPlatform + 1.5f, 0), Quaternion.identity);
            SpawnTiles(randomSizeOfPlatform, instantiateAt, randomEmptySpace);
            if (getInstantiateUntil)
            {
                instantiateUntil = (int)Math.Floor(instantiateAt) + 4;
                getInstantiateUntil = false;
            }
        instantiateAtPosition = instantiateAt * 2 - randomEmptySpace;
        nextPos = nextPos + randomSizeOfPlatform + randomEmptySpace;
        }


        CheckForStop();

        if (triggererInstantiated != null)
        {
            if (triggererInstantiated.GetComponent<BiomeChange>().GetCanStart() && canStart)
            {
                Debug.Log("Started");
                canStart = false;
                BiomeChanger();
                blockDestroyer = Instantiate(destroyBlocksOnBiome, new Vector2(transform.position.x + 8, transform.position.y), Quaternion.identity);
                StartCoroutine(waitToStart(blockDestroyer, blocks));
                cameraPosition = transform.position;
                SpawnTiles((instantiateUntil - (int)Math.Floor(cameraPosition.x)), 10.6f, 1f) ;

            }
        }

    }




    IEnumerator waitToStart (GameObject destroy, GameObject blocks)
    {
        yield return new WaitForSeconds(0.06f);
        Destroy(destroy);
        //transform.position = new Vector3(transform.position.x - 9, transform.position.y, transform.position.z);
        Instantiate(blocks, new Vector3(transform.position.x + blocksInstantiateOffset, transform.position.y, transform.position.z + 5f), Quaternion.identity);
        getInstantiateUntil = true;
        startSpawning = true;
        yield return new WaitForSeconds(0.06f);

    }


     
    void SpawnTiles(int randomSizeOfPlatform, float instantiateAt, float emptySpace)
    {



        if (spawnBlock.GetComponent<SpawnBlocks>().GetCanSetHeight())
        {
            randomHeightOfPlatform = UnityEngine.Random.Range(-5, 0);
        }
        else
        {
            randomHeightOfPlatform = -5;
        }
        int randomHeightOfPlatformSaved = randomHeightOfPlatform;


        if (lastHeight + 2 <= randomHeightOfPlatform)
        {
            if (lastHeight + 3 <= randomHeightOfPlatform)
            {
                if (lastHeight + 4 <= randomHeightOfPlatform)
                {
                    randomHeightOfPlatform -= 3;
                }
                else
                {
                    randomHeightOfPlatform -= 2;
                }
            }

            else
            {
                randomHeightOfPlatform--;
            }

        }


        heightOfPlatform = randomHeightOfPlatform + heightOffset;


        lastHeight = randomHeightOfPlatform;

        for (int i = 0; i < randomSizeOfPlatform; i++)
        {
            Instantiate(grassTile, new Vector3(instantiateAt, heightOfPlatform, 0), Quaternion.identity);

            if(i == randomSizeOfPlatform/2)
            Instantiate(enemy, new Vector3(instantiateAt - 0.6f, heightOfPlatform + 1f, 0), Quaternion.identity);



            instantiateAt++;
        }


        instantiateAt = 9.6f + transform.position.x + emptySpace;
        heightOfPlatform--;


        for (int i= -5; i < randomHeightOfPlatform; i++)
        {
            for(int j = 0; j < randomSizeOfPlatform; j++)
            {
                Instantiate(dirtTile, new Vector3(instantiateAt, heightOfPlatform, 0), Quaternion.identity);
                instantiateAt++;
            }
            instantiateAt = 9.6f + transform.position.x + emptySpace;
            heightOfPlatform--;
        }
    }


    void SetBiome(GameObject[] objects, Material background)
    {

        for (int i = 0; i <3; i++)
        {
            grassTile = objects[0];
            dirtTile = objects[1];
            enemy = objects[2];
            blocks = objects[3];
            this.background.GetComponent<MeshRenderer>().material = background;

            
        }

    }

    void CheckForStop()
    {
        if (transform.position.x >= randomLenghtOfBiome)
        {
            Camera.main.GetComponent<CameraMover>().enabled = false;
            //scoreCounter.GetComponent<HighScoreCounter>().enabled = false;
            //background.GetComponent<BackroundScroller>().enabled = false;

            if(Camera.main.aspect > 1.8f)
            {
                destroyerInstantiated = Instantiate(destroyer, new Vector2(transform.position.x + 16, -4f), Quaternion.identity) as GameObject;
            }
            else
            {
                destroyerInstantiated = Instantiate(destroyer, new Vector2(transform.position.x + 14, -4f), Quaternion.identity) as GameObject;
            }
            
            Destroy(destroyerInstantiated, 0.5f);
            triggererInstantiated = Instantiate(triggerer, new Vector2(transform.position.x + 9, 0f), Quaternion.identity);
            randomLenghtOfBiome += UnityEngine.Random.Range(100, 160) + 18;
            canStart = true;
            Debug.Log("Stopped");

        }
    }




    public void BiomeChanger()
    {
        Camera.main.GetComponent<CameraMover>().MoveCamera(18f);

        snowParticle.SetActive(false);
        windSpawnerLeft.SetActive(false);
        windSpawnerRight.SetActive(false);
        meteorSpawner.SetActive(false);
        nextBiome = UnityEngine.Random.Range(0, 7);
        Camera.main.GetComponent<CameraMover>().MovingSpeedIs(6f);

        player.transform.position = new Vector2(transform.position.x -4, transform.position.y -1);

        Debug.Log(nextBiome);

            if(nextBiome == currentBiomeNumber)
            {
                if(nextBiome == 0)
                {
                    nextBiome += UnityEngine.Random.Range(1,7);
                }

                else if (nextBiome == 1)
                {
                    if(UnityEngine.Random.Range(0, 2) == 0)
                    {
                        nextBiome += UnityEngine.Random.Range(1, 6);
                    }
                    else
                    {
                        nextBiome -= 1;
                    }
                }
                else if(nextBiome == 2)
                {
                    if (UnityEngine.Random.Range(0, 2) == 0)
                    {
                        nextBiome -= UnityEngine.Random.Range(1, 3);
                    }
                    else
                    {
                        nextBiome += UnityEngine.Random.Range(1, 5);
                    }
                }

                else if(nextBiome == 3)
                {
                if (UnityEngine.Random.Range(0, 2) == 0)
                {
                    nextBiome -= UnityEngine.Random.Range(1, 4);
                }
                else
                {
                    nextBiome += UnityEngine.Random.Range(1, 4);
                }

                
                }

                else if(nextBiome == 4)
                {
                if (UnityEngine.Random.Range(0, 2) == 0)
                {
                    nextBiome -= UnityEngine.Random.Range(1, 5);
                }
                else
                {
                    nextBiome += UnityEngine.Random.Range(1, 3);
                }
                }

                else if (nextBiome == 5)
                {
                if (UnityEngine.Random.Range(0, 2) == 0)
                {
                    nextBiome -= UnityEngine.Random.Range(1, 6);
                }
                else
                {
                    nextBiome += 1;
                }
                }

                else if (nextBiome == 6)
                {
                    nextBiome -= UnityEngine.Random.Range(1, 7);
                }



        }

        currentBiomeNumber = nextBiome;

        Debug.Log(nextBiome);

        switch (nextBiome)
        {
            case 0:
                SetBiome(green, greenBackground);
                green[4].SetActive(true);
                snow[4].SetActive(false);
                desert[4].SetActive(false);
                planet[4].SetActive(false);
                red[4].SetActive(false);
                stone[4].SetActive(false);
                blue[4].SetActive(false);
                clouds.SetActive(true);
                break;
            case 1:
                SetBiome(snow, snowBackground);
                green[4].SetActive(false);
                snow[4].SetActive(true);
                desert[4].SetActive(false);
                planet[4].SetActive(false);
                red[4].SetActive(false);
                stone[4].SetActive(false);
                blue[4].SetActive(false);
                clouds.SetActive(true);
                Camera.main.GetComponent<CameraMover>().MovingSpeedIs(7f);
                snowParticle.SetActive(true);
                windSpawnerLeft.SetActive(true);
                break;
            case 2:
                SetBiome(desert, desertBackground);
                green[4].SetActive(false);
                snow[4].SetActive(false);
                desert[4].SetActive(true);
                planet[4].SetActive(false);
                red[4].SetActive(false);
                stone[4].SetActive(false);
                blue[4].SetActive(false);
                clouds.SetActive(false);
                windSpawnerRight.SetActive(true);
                break;
            case 3:
                SetBiome(planet, planetBackground);
                green[4].SetActive(false);
                snow[4].SetActive(false);
                desert[4].SetActive(false);
                planet[4].SetActive(true);
                red[4].SetActive(false);
                stone[4].SetActive(false);
                blue[4].SetActive(false);
                clouds.SetActive(false);
                break;
            case 4:
                SetBiome(red, redBackground);
                green[4].SetActive(false);
                snow[4].SetActive(false);
                desert[4].SetActive(false);
                planet[4].SetActive(false);
                red[4].SetActive(true);
                stone[4].SetActive(false);
                blue[4].SetActive(false);
                meteorSpawner.SetActive(true);
                clouds.SetActive(false);
                break;
            case 5:
                SetBiome(stone, stoneBackground);
                green[4].SetActive(false);
                snow[4].SetActive(false);
                desert[4].SetActive(false);
                planet[4].SetActive(false);
                red[4].SetActive(false);
                stone[4].SetActive(true);
                blue[4].SetActive(false);
                clouds.SetActive(true);
                break;
            case 6:
                SetBiome(blue, blueBackground);
                green[4].SetActive(false);
                snow[4].SetActive(false);
                desert[4].SetActive(false);
                planet[4].SetActive(false);
                red[4].SetActive(false);
                stone[4].SetActive(false);
                blue[4].SetActive(true);
                clouds.SetActive(false);
                break;
        }
        Camera.main.GetComponent<CameraMover>().enabled = true;
        scoreCounter.GetComponent<HighScoreCounter>().enabled = true;
        //background.GetComponent<BackroundScroller>().enabled = true;
        biomeChange.SetCanStart(false);
    }



    public GameObject GetGrassTile()
    {
        return grassTile;
    }


    public GameObject GetDirtTile()
    {
        return dirtTile;
    }

    public bool GetStartSpawning()
    {
        return startSpawning;
    }
    
    public void SetStartSpawning(bool newStartSpawning)
    {
        startSpawning = newStartSpawning;
    }
    
    public void SetRandomHeightOfPlatform(int newRandomHeightOfPlatform)
    {
        randomHeightOfPlatform = newRandomHeightOfPlatform;
    }

}
