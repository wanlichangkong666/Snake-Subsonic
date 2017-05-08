using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SnakeMove : MonoBehaviour
{
    
    public GameObject SnakeBody;
    private GameObject firstBody;
    private GameObject lastBody;
    private GameObject CreatedBody;

   
    private float foodMax_X = 9f;
    private float foodMin_X = -9f;
    private float foodMax_Z = 9f;
    private float foodMin_Z = -9f;
    
    private float timer = 0f;
    private float time = 0.3f;
    public GameObject Food;
    private GameObject newFood;
    public static int scores=0;
    private int flag = 0;
    public AudioSource audio;
    public AudioClip eat;

    void RandomFood()
    {
        
        float cube_food_PositionX = Random.Range(foodMin_X, foodMax_X);
        float cube_food_PositionZ = Random.Range(foodMin_Z, foodMax_Z);
        newFood = Instantiate(Food, new Vector3(cube_food_PositionX, 0, cube_food_PositionZ), Quaternion.identity) as GameObject;
    }

    void Start()
    {
        
        RandomFood();
    }


  

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (flag == 0)
            {
                Time.timeScale = 0;
                flag = 1;
            }
           else if (flag == 1)
            {
                Time.timeScale = 1;
                flag = 0;
            }
        }

        if (timer > time)
        {
            Vector3 old = this.transform.position;

            this.transform.position += transform.forward;
            if (firstBody != null)
            {

                  
                firstBody.GetComponent<CreateBody>().moveTo(old);
            }
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
       
        if (Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.W) && Vector3.Angle(Vector3.forward, this.transform.forward) < 160f)
        {
           
            this.transform.forward = Vector3.forward * 1;

        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) && Vector3.Angle(Vector3.back, this.transform.forward) < 160f)
        {
            this.transform.forward = Vector3.back * 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) && Vector3.Angle(Vector3.left, this.transform.forward) < 160f)
        {
            this.transform.forward = Vector3.left * 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) && Vector3.Angle(Vector3.right, this.transform.forward) < 160f)
        {
            this.transform.forward = Vector3.right * 1;
        }
 
    }
    void Move()
    {
        GameObject CreatedBodys = Instantiate(SnakeBody, new Vector3(100f, 100f, 100f), Quaternion.identity) as GameObject;
        if (lastBody != null)
        {
            lastBody.GetComponent<CreateBody>().next = CreatedBodys;
        }
        if (firstBody == null)
        {

            firstBody = CreatedBodys;
           
        }

        lastBody = CreatedBodys;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Food")
        {

            audio.PlayOneShot(eat);
            Destroy(newFood);

            RandomFood();
            Move();
            scores++;
        }
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "SnakeBody")
      

            SceneManager.LoadScene(2);
            


    }
}
