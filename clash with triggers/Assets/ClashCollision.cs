using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClashCollision : MonoBehaviour
{
    public BoxCollider2D box;
    public float offset;
    public GameObject fxAnim;

    Vector2 midPoint;
    float xMin;
    float yMin;
    float xMax;
    float yMax;

    private void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (box.enabled)
        {
            Vector2 position = new Vector2(transform.position.x + offset, transform.position.y);
            LayerMask hitboxLayer = LayerMask.GetMask("Other Hitbox");
            Collider2D col = Physics2D.OverlapBox(position, box.size, 0f, hitboxLayer);

            if (col != null)
            {
				if ((Vector2)col.bounds.size == box.size)
				{
					midPoint = GetLine(col.bounds);
					fxAnim.SetActive(true);
					fxAnim.transform.position = midPoint;
				}
				else
				{
					midPoint = FindOtherRectangle(col.bounds);
					fxAnim.SetActive(true);
					fxAnim.transform.position = midPoint;
				}
            }
        }
    }
    
    Vector2 GetLine(Bounds collidingBox)
    {
        Vector3 boxCenter = box.bounds.center;
        
        Vector2 collisionLine = new Vector2(collidingBox.center.x - box.bounds.center.x,
            collidingBox.center.y - box.bounds.center.y);
        Debug.DrawLine(box.bounds.center, collidingBox.center, Color.cyan);
        Vector2 midpoint = new Vector2((boxCenter.x + collidingBox.center.x) / 2,
            (boxCenter.y + collidingBox.center.y) / 2);
        //Debug.DrawLine(collisionLine, collisionLine, Color.yellow);
        //Debug.Log("line components: " + (collidingBox.center - box.bounds.center));
        //Debug.Log("line: " + collisionLine);

        return midpoint;
    }
	
    Vector2 FindOtherRectangle(Bounds collidingBox)//, Vector2 line)
    {
        Vector3 boxCenter = box.bounds.center;
        
		Vector2 collisionLine = new Vector2(collidingBox.center.x - boxCenter.x,
            collidingBox.center.y - boxCenter.y);
		Debug.DrawLine(box.bounds.center, collidingBox.center, Color.cyan);
		
        Vector3 maxBounds = box.bounds.max;
        Vector3 minBounds = box.bounds.min;

        //Debug.Log("max: " +  maxBounds);
        //Debug.Log("min: " + minBounds);

        //Debug.Log("center of other: " + collidingBox.center);

        if (boxCenter.x < collidingBox.center.x)
        {
            xMax = maxBounds.x;
            xMin = collidingBox.min.x;
        }
        else if (boxCenter.x > collidingBox.center.x)
        {
            xMax = collidingBox.max.x;
            xMin = minBounds.x;
        }

        if (boxCenter.y < collidingBox.center.y)
        {
            yMax = maxBounds.y;
            yMin = collidingBox.min.y;
        }
        else if (boxCenter.y > collidingBox.center.y)
        {
            yMax = collidingBox.max.y;
            yMin = minBounds.y;
        }

		Vector2 midpoint = new Vector2((xMin + xMax) / 2, (yMin + yMax) / 2);
		
		// Bounds other = new Bounds();
        Debug.DrawLine(new Vector2(xMin, yMin), new Vector2(xMax, yMax), Color.magenta);
        return midpoint;
    }

    private void OnDrawGizmos()
    {
        if (box.enabled)
        {
            Vector2 position = new Vector2(transform.position.x + offset, transform.position.y);
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(position, box.size);
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(midPoint, 0.1f);
    }
}

public interface ICollidable
{
    Vector2 GetLine();
    Vector2 FindMidpoint();
}
