using UnityEngine;

/// <summary>
/// それぞれの障害物の設定クラス
/// </summary>

public class ObstacleOption : MonoBehaviour
{
    enum ShotType
    {
        Left,
        ToPlayer,
        Order,
    }

    [SerializeField] ShotType _shotType;
    [SerializeField] float _useTime;
    [SerializeField] float _fadeInSpeed = 1;
    [SerializeField] float _speed = 1;
    [SerializeField] Vector2 _orderDir = Vector2.zero;

    SpriteRenderer _render;

    Vector2 _dir = Vector2.zero;
    float _timer;
    bool _isShot = false;
    public bool IsUse { get; private set; } = false;

    void Update()
    {
        if (IsUse) return;

        _timer += Time.deltaTime;
        if (_timer > _useTime)
        {
            IsUse = true;
        }

        if (_isShot) return;

        float alfa = Mathf.Lerp(0, 1, _timer * _fadeInSpeed);
        Color color = _render.color;
        color.a = alfa;
        _render.color = color;

        if (alfa == 1) Shot();
    }

    void Shot()
    {
        _isShot = true;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(_dir * _speed, ForceMode2D.Impulse);
    }

    public void Use()
    {
        _render = GetComponent<SpriteRenderer>();

        Color color = _render.color;
        color.a = 0;
        _render.color = color;

        switch (_shotType)
        {
            case ShotType.Left:
                _dir = Vector2.left;
                break;
            case ShotType.ToPlayer:
                Transform player = GameObject.FindWithTag("Player").transform;
                _dir = (transform.position - player.position).normalized;
                break;
            case ShotType.Order:
                _dir = _orderDir.normalized;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
