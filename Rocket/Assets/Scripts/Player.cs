using System;
using System.Collections;
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
    [SerializeField] private LayerMask CollidableMask;
    [SerializeField] SpriteRenderer FinsRenderer;
    private float fuel;
    private int maxFuel;
    private float health;
    private int maxHealth;
    private int heightScore;
    private int speedBoostCount;
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
        if (Input.GetKeyDown(KeyCode.Space))
            ActivateSpeedBoost(2, 1);
    }

    private void Move() {
        Exhaust.SetActive(false);
        float horizontalInput = Input.GetAxis ("Horizontal");
        float verticalInput = Input.GetAxis ("Vertical");

        rb2d.transform.Rotate(0f, 0f, -horizontalInput * rotationSpeed, Space.Self);
        //rb2d.SetRotation(rb2d.rotation - horizontalInput * rotationSpeed);
        //rb2d.MoveRotation(-horizontalInput * rotationSpeed);
        float braking = verticalInput < 0? brakeValue : 0;
        float forward = verticalInput > 0? verticalInput : 0;
        speed = rb2d.linearVelocity;
        Vector3 rotation = transform.rotation * new Vector3(0,1,0);
        if (speed.magnitude < maxSpeed) {
            speed.x += forward * acceleration / 100 * rotation.x;
            speed.y += forward * acceleration / 100 * rotation.y;
        }
        // speed.x += forward * acceleration * rotation.x;
        // speed.y += forward * acceleration * rotation.y;
        // speed.x = Mathf.Clamp(speed.x, -maxSpeed, maxSpeed);
        // speed.y = Mathf.Clamp(speed.y, -maxSpeed, maxSpeed);

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
        speedBoostCount = 0;
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

    public void ActivateMagnet(float duration, float radius) {
        StartCoroutine(Magnet(duration, radius));
    }

    public void ActivateShadowForm(float duration) {
        StartCoroutine(ShadowForm(duration));
    }

    public void ActivateForcefield(float duration) {
        GetComponent<CollisionController>().SetHitCooldown(duration);
        StartCoroutine(Forcefield(duration));
    }

    private void ActivateSpeedBoost(float duration, float multiplier) {
        
        if (speedBoostCount > 0) {
            speedBoostCount--;
            StartCoroutine(SpeedBoost(duration, multiplier));
        }
    }

    public void AddSpeedBoost() {
        speedBoostCount++;
    }

    public IEnumerator ShadowForm(float duration) {
        GetComponent<SpriteRenderer>().material.SetColor("_Color", new Color(0.5f, 0.5f, 0.5f, 0.5f));
        FinsRenderer.material.SetColor("_Color", new Color(0.5f, 0.5f, 0.5f, 0.5f));
        GetComponent<Rigidbody2D>().excludeLayers = CollidableMask;
        yield return new WaitForSeconds(duration);
        GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.white);
        FinsRenderer.material.SetColor("_Color", Color.red);
        GetComponent<Rigidbody2D>().excludeLayers = 0;
    }

    public IEnumerator Forcefield(float duration) {
        GetComponent<SpriteRenderer>().material.SetColor("_Color", new Color(0.5f, 0.5f, 1f, 1f));
        yield return new WaitForSeconds(duration);
        GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.white);
    }

    IEnumerator SpeedBoost(float duration, float multiplier) {
        float currentTime = 0;
        while (currentTime <= duration)
        {
            //rb2d.linearVelocity = rb2d.linearVelocity * multiplier;
            Vector3 rotation = transform.rotation * new Vector3(0,1,0);
            rb2d.AddForceX(multiplier * rotation.x);
            rb2d.AddForceY(multiplier * rotation.y);
            currentTime += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator Magnet(float duration, float radius) {
        GetComponent<Collector>().SetRadius(radius);
        yield return new WaitForSeconds(duration);
        GetComponent<Collector>().ResetRadius();
    }

}
