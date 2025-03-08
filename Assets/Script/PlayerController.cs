using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _jump;
    [SerializeField] LayerMask _groundLayer;//xác định đối tượng nào có thể tương tác
    [SerializeField] Transform _groundCheck;//thể hiện là đang đứng tại ground
    Animator _animator;
    bool isGrounded;
    Rigidbody2D _rigi;
    GameManager gameManager;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigi = GetComponent<Rigidbody2D>();
        gameManager = FindAnyObjectByType<GameManager>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsGameOver()) return;
        handleMovement();
        handleJump();
        updateAnimations();
    }
    private void handleMovement()
    {
        float _moveInput = Input.GetAxis("Horizontal");
        _rigi.linearVelocity = new Vector2(_moveInput * _speed, _rigi.linearVelocity.y);
        //xoay nhan vat khi qua trai - phai
        if(_moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(_moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    private void handleJump()
    {
        //giảm hiện tượng nhảy liên tục khi ở trên không
        isGrounded = Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
        if (Input.GetButtonDown("Jump")&&isGrounded)
        {
            _rigi.linearVelocity = new Vector2(_rigi.linearVelocity.x, _jump);
        }
    }
    //chuyển đổi trạng thái trong bảng animator
    private void updateAnimations()
    {
        bool isRunning = Mathf.Abs(_rigi.linearVelocity.x) > 0.1f;
        bool isJumping = !isGrounded;
        _animator.SetBool("isRunning", isRunning);
        _animator.SetBool("isJumping", isJumping);
    }
}
