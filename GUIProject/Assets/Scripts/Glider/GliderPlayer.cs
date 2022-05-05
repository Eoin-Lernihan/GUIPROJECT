using System;
using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
using UnityEngine;
//using UnityEngine.Windows.speech;
public class GliderPlayer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;
    /**
    private Dictionary<string, Action> wordActions = new Dictionary<string, Action>();
    private KeywordRecognizer speechTool;

    **/

    public float strength = 0.001f;
    public float gravity  = 0.0001f;
    public float tilt = 1f;
    //5f;
    public float number = 0f;
   GliderObstuckales obstacles = new GliderObstuckales();

    private Vector3 direction;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);

   /**     wordActions.Add("Jump", Up);
        wordActions.Add("Up", Up); 
        wordActions.Add("Flap", Up);
        wordActions.Add("Fly", Up);
        wordActions.Add("Flying", Up);

        wordActions.Add("Speed", speedUp);
        wordActions.Add("Fast", speedUp);
        wordActions.Add("Increase", speedUp);
        wordActions.Add("Go", speedUp);

        wordActions.Add("Slow", Up);
        wordActions.Add("Reduce", Up);

        wordActions.Add("Down", Down);
        wordActions.Add("Relax", Down);   
        wordActions.Add("Glide", Down);   
        wordActions.Add("Hover", Down);   


        speechTool = new KeywordRecognizer(wordActions.Keys.ToArray());
        speechTool.OnPhraseRecognized += VoiceCommand;
        speechTool.Start();
    **/
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Update()
    {
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = touch.position;
            bool v = touch.position.y > Screen.height / 2;
            if (v == true) {
                movementDown();
            }
            else {
                movementUp();
            }
        }
        // Input.GetMouseButtonDown(0)
        if (Input.GetKeyDown(KeyCode.Space) ) {
           movementUp();
        }
        
        number = 0f;
       //  Apply gravity and update the position
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
        
        // Tilt the bird based on the direction
        Vector3 rotation = transform.eulerAngles;
        rotation.z = direction.y * tilt;
        transform.eulerAngles = rotation;
    }

    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length) {
            spriteIndex = 0;
        }

        if (spriteIndex < sprites.Length && spriteIndex >= 0) {
            spriteRenderer.sprite = sprites[spriteIndex];
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle")) {
            FindObjectOfType<GliderGameHalder>().GameOver();
        }
        
        else if (other.gameObject.CompareTag("Goals")) {
            FindObjectOfType<GliderGameHalder>().Goal();
        }
    }
    /**
    private void VoiceCommand(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        wordActions[speech.text].Invoke();
    }
    **/
     private void Up()
    {
        movementUp();
    }

    private void Down()
    {
      movementDown();
    }
    private void speedUp()
    {
        obstacles.speedIncrease();      
    }  
    private void speedDown()
    {
      movementDown();
    }
    private void movementUp(){
        direction = Vector3.up * strength;
        StartCoroutine(waiter());
    }
    private void movementDown(){
      direction = -1 * Vector3.up * strength;
      StartCoroutine(waiter());
    }
   
     IEnumerator waiter()
    {
         yield return new WaitForSeconds(0.150f);
         direction = Vector3.up * 0;
    }
}
