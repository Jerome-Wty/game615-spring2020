using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveObj : MonoBehaviour
{
    public Direction moveDirection;
    
    protected Rigidbody2D m_rigidbody;

    private void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_rigidbody.bodyType = RigidbodyType2D.Kinematic;
    }

    //Start Trap
    public virtual void ReactStart()
    {
        
    }

    public Vector2 GetDirVec()
    {
        Vector2 dirVec = Vector2.zero;
        switch (moveDirection)
        {
            case Direction.Left:
                dirVec = Vector2.left;
                break;
            case Direction.Right:
                dirVec = Vector2.right;
                break;
            case Direction.Up:
                dirVec = Vector2.up;
                break;
            case Direction.Down:
                dirVec = Vector2.down;
                break;
        }
        return dirVec;
    }
}
public enum Direction
{
    Left,
    Right,
    Up,
    Down
}