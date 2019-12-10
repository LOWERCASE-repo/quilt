using UnityEngine;

internal class Edge {
  
  internal Edge opp;
  internal Vector2 head;
  internal Vector2 tail;
  
  internal bool CheckIntersect(Edge other) {
    bool isIntersecting = false;
    
    float denominator = (other.head.y - other.tail.y) * (tail.x - head.x) - (other.head.x - other.tail.x) * (tail.y - head.y);
    
    // Make sure the denominator is > 0,
    // if not the lines are parallel
    if (denominator != 0f) {
      float a = ((other.head.x - other.tail.x) * (head.y - other.tail.y) - (other.head.y - other.tail.y) * (head.x - other.tail.x)) / denominator;
      float b = ((tail.x - head.x) * (head.y - other.tail.y) - (tail.y - head.y) * (head.x - other.tail.x)) / denominator;
      //Is intersecting if a and b are between 0 and 1 or exactly 0 or 1
      if (a >= 0f && a <= 1f && b >= 0f && b <= 1f) {
        isIntersecting = true;
      }
      
    }
    
    return isIntersecting;
  }
}