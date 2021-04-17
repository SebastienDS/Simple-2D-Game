using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public float invicibilityTimeAfterHit = 2f;
    public float invicivilityFlashDelay = 0.2f;
    public bool isInvicible = false;

    public SpriteRenderer spriteRenderer;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        if (isInvicible) return;

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        isInvicible = true;
        StartCoroutine(InvincibilityFlash());
        StartCoroutine(HandleInvincibilityDelay());
    }

    public IEnumerator InvincibilityFlash()
    {
        while (isInvicible)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invicivilityFlashDelay);
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invicivilityFlashDelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invicibilityTimeAfterHit);
        isInvicible = false;
    }
}
