using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerController : MonoBehaviour
{

    private bool isMoving;
    private Vector2 input;
    private Animator animator;
    [SerializeField] private  LayerMask solidObjectLayer;
    [SerializeField] private LayerMask LongGrassLayer;
    [SerializeField] float moveSpeed;
    [SerializeField] protected InputAction moveVertical = new InputAction(type: InputActionType.Button);
    [SerializeField] protected InputAction moveHorizontal = new InputAction(type: InputActionType.Button);

    public void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void OnEnable()
    {
        moveHorizontal.Enable();
        moveVertical.Enable();
    }

    void OnDisable()
    {
        moveHorizontal.Disable();
        moveVertical.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        OnEnable();
    }

    //check for  wild pokemon in current position 
    private void CheckForEncounters()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, LongGrassLayer)!= null)
        {
            if (Random.Range(1, 101) <= 101)
            {
                Debug.Log("Encounter a wild pokemon!");
            }
        }
}

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {

            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
        CheckForEncounters();
    }
    // check if target pose is a valid position
    private bool IsWalkAble(Vector3 targetPos)
    {
        return Physics2D.OverlapCircle(targetPos, 0.1f, solidObjectLayer) == null;
    }

    // Update is called once per frame
    private void Update()
    {
      
        if (!isMoving)
        {

            input.x = moveHorizontal.ReadValue<float>();
            input.y = moveVertical.ReadValue<float>();



            if (input != Vector2.zero)
            {
                if (input.x != 0) input.y = 0;
                animator.SetFloat("Horizontal", input.x);
                animator.SetFloat("Vertical", input.y);
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;
                if (IsWalkAble(targetPos))
                {
                    StartCoroutine(Move(targetPos));
                }
            }
        }
        animator.SetBool("isMoving", isMoving);
  
    }

 
}
