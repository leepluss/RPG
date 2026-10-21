using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    // Tham số "amount": Số lượng máu thay đổi (Số dương = Hồi máu, Số âm = Chịu sát thương)
    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}