using UnityEngine;
using UnityEngine.EventSystems;

public class Dpad : SingletonMonoBehaviour<Dpad>, IPointerUpHandler, IPointerDownHandler
{
    protected RectTransform Background;
    protected bool Pressed;
    protected int PointerId;
    public RectTransform Handle;
    [Range(0f, 2f)]
    public float HandleRange = 1f;

    [HideInInspector]
    public Vector2 InputVector = Vector2.zero;

    public Vector2 AxisNormalized { get { return InputVector.magnitude > 0.25f ? InputVector.normalized : (InputVector.magnitude < 0.01f ? Vector2.zero : InputVector * 4f); } }

    public float Angle
    {
        get
        {
            return Mathf.Atan2(AxisNormalized.x, AxisNormalized.y) * Mathf.Rad2Deg;
        }
    }

    public bool Up
    {
        get
        {
            return InputVector.y > 0.1f;
        }
    }

    public bool Down
    {
        get
        {
            return InputVector.y < -0.1f;
        }
    }

    public bool Left
    {
        get
        {
            return InputVector.x < -0.1f;
        }
    }

    public bool Right
    {
        get
        {
            return InputVector.x > 0.1f;
        }
    }

    public bool IsTouch
    {
        get
        {
            return Pressed;
        }
    }

    void Start()
    {
        if (Handle == null)
            Handle = transform.GetChild(0).GetComponent<RectTransform>();
        Background = GetComponent<RectTransform>();
        Background.pivot = new Vector2(0.5f, 0.5f);
        Pressed = false;
    }

    void Update()
    {
        if (Pressed)
        {
            Vector2 direction = (PointerId >= 0 && PointerId < Input.touches.Length)
                ? Input.touches[PointerId].position - new Vector2(Background.position.x, Background.position.y)
                : new Vector2(Input.mousePosition.x, Input.mousePosition.y) - new Vector2(Background.position.x, Background.position.y);

            InputVector = (direction.magnitude > Background.sizeDelta.x / 2f)
                ? direction.normalized
                : direction / (Background.sizeDelta.x / 2f);

            if (Mathf.Abs(InputVector.x) > Mathf.Abs(InputVector.y))
            {
                InputVector = new Vector2(InputVector.x, 0);
            }
            else
            {
                InputVector = new Vector2(0, InputVector.y);
            }

            Handle.anchoredPosition = (InputVector * Background.sizeDelta.x / 2f) * HandleRange;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
        PointerId = eventData.pointerId;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
        InputVector = Vector2.zero;
        Handle.anchoredPosition = Vector2.zero;
    }
}

