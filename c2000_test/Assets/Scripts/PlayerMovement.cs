using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float dashSpeed = 15f;
        [SerializeField] private float dashDuration = 0.2f;
        [SerializeField] private float dashCooldown = 1f;
        [SerializeField] private Transform target;
        [SerializeField] private Sprite upSprite;
        [SerializeField] private Sprite upRightSprite;
        [SerializeField] private Sprite rightSprite;
        [SerializeField] private Sprite downRightSprite;
        [SerializeField] private Sprite downSprite;
        [SerializeField] private Sprite downLeftSprite;
        [SerializeField] private Sprite leftSprite;
        [SerializeField] private Sprite upLeftSprite;

        private Rigidbody2D rb;
        private SpriteRenderer spriteRenderer;
        private bool isDashing = false;
        private float lastDashTime;

        private void Start()
        {
                rb = GetComponent<Rigidbody2D>();
                spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
                Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
                Vector2 velocity = movementInput * (isDashing ? dashSpeed : moveSpeed);
                rb.velocity = velocity;

                if (Input.GetKeyDown(KeyCode.Space) && !isDashing && Time.time > lastDashTime + dashCooldown)
                {
                        StartCoroutine(Dash());
                }

                // calculate direction from player to target
                Vector2 direction = target.position - transform.position;
                direction.Normalize();

                // change sprite based on direction
                if (direction.magnitude == 0)
                {
                        // use default sprite when not moving
                        spriteRenderer.sprite = downSprite;
                }
                else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
                {
                        if (direction.y > 0)
                        {
                                spriteRenderer.sprite = upSprite;
                        }
                        else
                        {
                                spriteRenderer.sprite = downSprite;
                        }
                }
                else
                {
                        if (direction.x > 0)
                        {
                                spriteRenderer.flipX = false;
                                if (direction.y > 0)
                                {
                                        spriteRenderer.sprite = upRightSprite;
                                }
                                else if (direction.y < 0)
                                {
                                        spriteRenderer.sprite = downRightSprite;
                                }
                                else
                                {
                                        spriteRenderer.sprite = rightSprite;
                                }
                        }
                        else
                        {
                                spriteRenderer.flipX = true;
                                if (direction.y > 0)
                                {
                                        spriteRenderer.sprite = upLeftSprite;
                                }
                                else if (direction.y < 0)
                                {
                                        spriteRenderer.sprite = downLeftSprite;
                                }
                                else
                                {
                                        spriteRenderer.sprite = leftSprite;
                                }
                        }
                }
        }

        private IEnumerator Dash()
        {
                isDashing = true;
                lastDashTime = Time.time;
                yield return new WaitForSeconds(dashDuration);
                isDashing = false;
        }
}
