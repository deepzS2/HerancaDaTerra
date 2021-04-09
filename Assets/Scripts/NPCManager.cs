using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{ 
    // Enums
    enum Directions {
        Up = 0,
        Right,
        Down,
        Left
    }

    [Header("Movement variables")]
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _walkTime;

    [SerializeField]
    private float _waitTime;

    [SerializeField]
    private Collider2D _walkZone;

    // Is walking
    private bool _isWalking;

    // Rigidbody
    private Rigidbody2D _rigidbody2D;

    // Walk and wait time
    private float _walkCounter;
    private float _waitCounter;

    // Walk direction check enum Directions
    private Directions _walkDirection;

    // Walkzone bound (Max and min movement area)
    private Vector3 _minWalkPoint;
    private Vector3 _maxWalkPoint;

    // If a walk zone exists
    private bool _walkZoneExist = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _waitCounter = _waitTime;
        _walkCounter = _walkTime;

        ChooseDirection();

        if (_walkZone != null)
        {
            _walkZoneExist = true;
            _minWalkPoint = _walkZone.bounds.min;
            _maxWalkPoint = _walkZone.bounds.max;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Walk();   
    }

    /// <summary>
    /// Script responsável por fazer o NPC andar
    /// </summary>
    void Walk()
    {
        // If is walking
        if (_isWalking)
        {
            // -walk counter
            _walkCounter -= Time.deltaTime;

            // walk
            WalkOnDirection();
            
            // If counter reaches 0
            if (_walkCounter < 0)
            {
                // Wait
                _isWalking = false;
                _waitCounter = _waitTime;
            }
        }
        else
        {
            // -wait counter
            _waitCounter -= Time.deltaTime;

            // Just to ensure that is not walking
            _rigidbody2D.velocity = Vector2.zero;

            // If counter reaches 0
            if (_waitCounter < 0)
            {
                // Choose a direction
                ChooseDirection();
            }
        }
    }

    /// <summary>
    /// Escolhe uma direção para andar
    /// </summary>
    void ChooseDirection()
    {
        // A direction between 0, 4 (Check enum Directions)
        // OBS: Never will reach 4, only 0, ..., 3

        _walkDirection = (Directions) Random.Range(0, 4);
        _isWalking = true;
        _walkCounter = _walkTime;
    }

    /// <summary>
    /// Switch case para andar na direção escolhida
    /// </summary>
    void WalkOnDirection()
    {
        // Switch case for each direction
        // If we have a walkzone it checks if we are getting out of the zone
        // so it'll stop walking
        switch(_walkDirection)
        {
            case Directions.Up:
                _rigidbody2D.velocity = new Vector2(0, _speed);
                if (_walkZoneExist && transform.position.y > _maxWalkPoint.y)
                {
                    _isWalking = false;
                    _waitCounter = _waitTime;
                }
                break;

            case Directions.Right:
                _rigidbody2D.velocity = new Vector2(_speed, 0);
                if (_walkZoneExist && transform.position.x > _maxWalkPoint.x)
                {
                    _isWalking = false;
                    _waitCounter = _waitTime;
                }
                break;

            case Directions.Down:
                _rigidbody2D.velocity = new Vector2(0, -_speed);
                if (_walkZoneExist && transform.position.y < _minWalkPoint.y)
                {
                    _isWalking = false;
                    _waitCounter = _waitTime;
                }
                break;

            case Directions.Left:
                _rigidbody2D.velocity = new Vector2(-_speed, 0);
                if (_walkZoneExist && transform.position.x < _minWalkPoint.y)
                {
                    _isWalking = false;
                    _waitCounter = _waitTime;
                }
                break;
        }
    }
}
