using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float acceleration;
    [SerializeField] private float brakeValue;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float fuelConsumption;
    [SerializeField] private DisplayBar FuelBar;
    [SerializeField] private DisplayBar HealthBar;
    [SerializeField] private TextMeshProUGUI HeightText;
    [SerializeField] private TextMeshProUGUI CoinsText;
    [SerializeField] private GameObject Exhaust;
    [SerializeField] private GameObject MagnetCircle;
    private RocketVisuals rv;
    [SerializeField] private LayerMask CollidableMask;
    [SerializeField] SpriteRenderer FinsRenderer;
    public float fuel {get; set;}
    private int maxFuel;
    public float health {get; set;}
    private int maxHealth;
    public int heightScore {get; set;}
    public int coinsCollected {get; set;}
    private bool speedBoost;
    private bool shieldActive;
    private bool rocketEngineer;
    private int passiveRepairValue;
    private Vector2 speed;
    private Rigidbody2D rb2d;
    private float defaultDampening;

    void Start()
    {
        InitializeValues();
        InvokeRepeating("RepairPassive", 1f, 1f);
        rb2d = GetComponent<Rigidbody2D>();
        defaultDampening = rb2d.linearDamping;
        rv = new BaseRocket(gameObject);
        rv.Display();
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
            ActivateSpeedBoost(2, 1);
        heightScore = Math.Max(heightScore, (int)rb2d.position.y);
        HeightText.text = ((int) rb2d.position.y).ToString() + " m";
        CoinsText.text = coinsCollected.ToString();
    }

    public void Move() {
        Exhaust.SetActive(false);
        float horizontalInput = Input.GetAxis ("Horizontal");
        float verticalInput = Input.GetAxis ("Vertical");

        if (Time.timeScale != 0)
            rb2d.transform.Rotate(0f, 0f, -horizontalInput * rotationSpeed, Space.Self);
        //rb2d.SetRotation(rb2d.rotation - horizontalInput * rotationSpeed);
        //rb2d.MoveRotation(-horizontalInput * rotationSpeed);
        float braking = verticalInput < 0? brakeValue : 0;
        float forward = verticalInput > 0? verticalInput : 0;
        speed = rb2d.linearVelocity;
        Vector3 rotation = transform.rotation * new Vector3(0,1,0);
        // if (speed.magnitude < maxSpeed && fuel >= 0.00001) {
        //     speed.x += forward * acceleration / 100 * rotation.x;
        //     speed.y += forward * acceleration / 100 * rotation.y;
        // }
        if (fuel >= 0.00001) {
            speed.x += forward * acceleration / 100 * rotation.x;
            speed.y += forward * acceleration / 100 * rotation.y;
        }
        // speed.x += forward * acceleration * rotation.x;
        // speed.y += forward * acceleration * rotation.y;
        speed.x = Mathf.Clamp(speed.x, -maxSpeed, maxSpeed);
        speed.y = Mathf.Clamp(speed.y, -maxSpeed, maxSpeed);

        rb2d.linearDamping = defaultDampening + braking;
        rb2d.linearVelocity = new Vector2(speed.x, speed.y);

        if(verticalInput > 0 && fuel >= 0.00001) {
            Exhaust.SetActive(true);
            if (Time.timeScale != 0)
                RestoreFuel(-fuelConsumption / 1000);
        }
        
        //rb2d.linearVelocity = new Vector2 (verticalInput * speed * movement.x, verticalInput * speed * movement.y);
    }

    private void InitializeValues() {
        // maxHealth = 100;
        // health = 100;
        // maxFuel = 100;
        // fuel = 100;
        // speedBoost = false;
        // heightScore = 0;
        // coinsCollected = 0;
        // shieldActive = false;
        RocketStartingProfile p = RocketStartingProfile.Instance;
        maxHealth = p.healthValue;
        health = maxHealth;
        maxFuel = p.fuelValue;
        brakeValue = p.flapValue;
        maxSpeed = p.headValue;
        fuel = maxFuel;
        passiveRepairValue = p.passiveRepairValue;
        rocketEngineer = p.hasEngineer;
        speedBoost = false;
        heightScore = 0;
        coinsCollected = 0;
        shieldActive = false;
        FinsRenderer.color = p.rocketColor;
        MagnetCircle.SetActive(false);
        Exhaust.SetActive(false);
    }

    public void RestoreHealth(float amount) {
        if (amount < 0 && shieldActive) {
            amount = 0;
            shieldActive = false;
            GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.white);
        }
        health += amount;
        health = Mathf.Clamp(health, 0, maxHealth);
        HealthBar.SetValue(health, maxHealth);
    }

    public void RestoreFuel(float amount) {
        fuel += amount;
        fuel = Mathf.Clamp(fuel, 0, maxFuel);
        FuelBar.SetValue(fuel, maxFuel);
    }

    public void RepairPassive () {
        if (rocketEngineer) {
            RestoreHealth(passiveRepairValue);
        }
    }

    public void AddCoins(int amount) {
        coinsCollected += amount;
    }

    public void ActivateMagnet(float duration, float radius) {
        StartCoroutine(Magnet(duration, radius));
    }

    public void ActivateShadowForm(float duration) {
        StartCoroutine(ShadowForm(duration));
    }

    public void ActivateForcefield(float duration) {
        //GetComponent<CollisionController>().SetHitCooldown(duration);
        StartCoroutine(Forcefield(duration));
    }

    private void ActivateSpeedBoost(float duration, float multiplier) {
        
        if (speedBoost) {
            speedBoost = false;
            StartCoroutine(SpeedBoost(duration, multiplier));
        }
    }

    public void AddSpeedBoost() {
        speedBoost = true;
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
        rv = new ForcefieldDecorator(rv, Exhaust);
        shieldActive = true;
        GetComponent<SpriteRenderer>().material.SetColor("_Color", new Color(0.5f, 0.5f, 1f, 1f));
        yield return new WaitForSeconds(duration);
        shieldActive = false;
        GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.white);
        rv.Remove();
    }

    IEnumerator SpeedBoost(float duration, float multiplier) {
        float currentTime = 0;
        maxSpeed *= 2;
        while (currentTime <= duration)
        {
            //rb2d.linearVelocity = rb2d.linearVelocity * multiplier;
            Vector3 rotation = transform.rotation * new Vector3(0,1,0);
            rb2d.AddForceX(multiplier * rotation.x);
            rb2d.AddForceY(multiplier * rotation.y);
            currentTime += Time.deltaTime;
            yield return null;
        }
        maxSpeed /= 2;
    }

    IEnumerator Magnet(float duration, float radius) {
        rv = new MagnetDecorator(rv, MagnetCircle);
        GetComponent<Collector>().SetRadius(radius);
        MagnetCircle.SetActive(true);
        float scale = radius * 12;
        MagnetCircle.GetComponent<Transform>().localScale = new Vector3(scale, scale, scale);
        yield return new WaitForSeconds(duration);
        GetComponent<Collector>().ResetRadius();
        MagnetCircle.SetActive(false);
        rv.Remove();
    }
}
