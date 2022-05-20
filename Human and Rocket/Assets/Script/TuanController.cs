using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TuanController : MonoBehaviour
{
    public float moveX;
    public float moveY;
    private float speed = 10f;

    [SerializeField]                // Để sửa trong Ispector
    private Rigidbody2D myBody;     // Tường
    
    private SpriteRenderer sr;      // Hình ảnh 2D
    private Animator anim;         // Hoạt động
    private string WALK_ANIMATION = "Walk";

    // Start is called before the first frame update
    private void Awake(){           // Hàm khởi tạo
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Debug.Log("Start");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        AnimationPlayer();
    }

    void PlayerMove(){
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        
        transform.position += new Vector3(moveX, moveY, 0f) * Time.deltaTime * speed;

    }

    void AnimationPlayer(){
        anim.SetBool(WALK_ANIMATION, true);
        if(moveX < 0){
            sr.flipX = true;
        }
        else if (moveX > 0){
            sr.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Enemy")){
            Destroy(gameObject);
            SceneManager.LoadScene("Menu");
        }
    }
}
