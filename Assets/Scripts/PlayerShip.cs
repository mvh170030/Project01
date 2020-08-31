using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerShip : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 12f;
    [SerializeField] float _turnSpeed = 3f;

    Rigidbody _rb = null;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveShip();
        TurnShip();
    }

    void MoveShip()
    {
        // S/Down = -1; None = 0; W/Up = 1. Scale with movespeed
        float moveAmountThisFrame = Input.GetAxisRaw("Vertical") * _moveSpeed;
        // combine direction with calculated amount
        Vector3 moveDirection = transform.forward * moveAmountThisFrame;
        // apply movement to game object
        _rb.AddForce(moveDirection);
    }

    void TurnShip()
    {
        // A/Left = -1; None = 0; D/Right = 1. Scale with turnspeed
        float turnAmountThisFrame = Input.GetAxisRaw("Horizontal") * _turnSpeed;
        // specify axis to apply the turn amount
        Quaternion turnOffset = Quaternion.Euler(0, turnAmountThisFrame, 0);
        // spin rigidbody
        _rb.MoveRotation(_rb.rotation * turnOffset);
    }

    public void Kill()
    {
        Debug.Log("Player has been killed!");
        this.gameObject.SetActive(false);
    }
}
