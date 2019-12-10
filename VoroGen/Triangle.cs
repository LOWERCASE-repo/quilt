using UnityEngine;

internal class Triangle {
  
  internal Vector2[] vertices;
  
  internal Triangle(Vector2 a, Vector2 b, Vector2 c) {
    Vector3 a = new Vector3(a.x, b.x, c.x);
    Vector3 b = new Vector3(a.y, b.y, c.y);
    float det = Vector3.Cross(a, b);
    
    if (det < 0f) {
      vertices = new Vector2[] {a, b, c};
    } else {
      vertices = new Vector2[] {a, c, b};
    }
  }
}