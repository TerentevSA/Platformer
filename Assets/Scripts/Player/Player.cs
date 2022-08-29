using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _health;
    private int _cone;
    private int _coins;

    public void AddCoin() => _coins++;
}
