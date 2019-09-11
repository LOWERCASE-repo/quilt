using UnityEngine;
using System.Collections.Generic;

internal class MapHull {
  
  internal float width;
  internal List<Vector2> vertices;
  internal int[] triangles;
  internal Mesh mesh;
  internal Vector2[] edges;
  
  internal MapHull(float width) {
    this.width = width;
    vertices = new List<Vector2>();
  }
}
