using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonMove : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public static ButtonMove buttonMove;
    Vector2 begin;
    float range = 40;
    private void Awake()
    {
        buttonMove = this;
        begin = transform.position;
    }
    public void OnDrag(PointerEventData other)
    {
        transform.position = other.position;
        float myrange = Vector3.Distance(transform.position, begin);
        if (myrange > range)
        {
            transform.position = begin + (other.position - begin).normalized * range;
        }
        else
        {
            transform.position = other.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = begin;
    }
    public float x
    {
        get { return ((Vector2)transform.position - begin).normalized.x; }
    }
    public float y
    {
        get { return ((Vector2)transform.position - begin).normalized.y; }
    }
}
