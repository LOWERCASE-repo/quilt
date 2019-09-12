using UnityEngine;
using System.Collections.Generic;

internal class MapHull {
  
  internal float width;
  internal Vector2[] vertices;
  internal int[] triangles;
  internal Vector2[] edges;
  internal Mesh mesh;
  
  internal MapHull(NavGraph graph, float width) {
    this.width = width;
    this.vertices = new Vector2[graph.positions.Length * 2];
    this.triangles = new int[(vertices.Length - 2) * 3];
    this.edges = new Vector2[vertices.Count + 1];
  }
}
