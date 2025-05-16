using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float rotationSpeed;
    public float acceleration;
    public float brakeValue;
    public float maxSpeed;
    public float fuelConsumption;
    [SerializeField] private DisplayBar FuelBar;
    [SerializeField] private DisplayBar HealthBar;
    [SerializeField] private GameObject Exhaust;
    private float fuel;
    private int maxFuel;
    private float health;
    private int maxHealth;
    private int heightScore;
    private Vector2 speed;
    public Vector3 rotationValue;
    private Rigidbody2D rb2d;
    private float defaultDampening;

    void Start()
    {
        InitializeValues();
        Exhaust.SetActive(false);
        rb2d = GetComponent<Rigidbody2D>();
        defaultDampening = rb2d.linearDamping;
    }

    void Update()
    {
        Move();
    }

    private void Move() {
        Exhaust.SetActive(false);
        float horizontalInput = Input.GetAxis ("Horizontal");
        float verticalInput = Input.GetAxis ("Vertical");

        rb2d.transform.Rotate(0f, 0f, -horizontalInput * rotationSpeed, Space.Self);
        float braking = verticalInput < 0? brakeValue : 0;
        float forward = verticalInput > 0? verticalInput : 0;
        speed = rb2d.linearVelocity;
        Vector3 rotation = transform.rotation * new Vector3(0,1,0);
        if (speed.magnitude < maxSpeed) {
            speed.x += forward * acceleration * rotation.x;
            speed.y += forward * acceleration * rotation.y;
        }
        rb2d.linearDamping = defaultDampening + braking;
        rb2d.linearVelocity = new Vector2(speed.x, speed.y);

        if(verticalInput > 0) {
            Exhaust.SetActive(true);
            RestoreFuel(-fuelConsumption / 1000);
        }
        
        //rb2d.linearVelocity = new Vector2 (verticalInput * speed * movement.x, verticalInput * speed * movement.y);
    }

    private void InitializeValues() {
        maxHealth = 100;
        health = 100;

        maxFuel = 100;
        fuel = 100;
        
        heightScore = 0;
    }

    public void RestoreHealth(float amount) {
        health += amount;
        health = Mathf.Clamp(health, 0, maxHealth);
        HealthBar.SetValue(health, maxHealth);
    }

    public void RestoreFuel(float amount) {
        fuel += amount;
        fuel = Mathf.Clamp(fuel, 0, maxFuel);
        FuelBar.SetValue(fuel, maxFuel);
    }
}
