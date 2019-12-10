using UnityEngine;
using System.Collections.Generic;

internal class Triangulator {
  
  [SerializeField]
  private int vertexCount;
  
  private HashSet<Vector2> vertices;
  private HashSet<Edge> edges;
  
  private void Triangulate() {
    
    // add a vertex
    // for each vertex, make edge from this to that vertex
    // if doesnt intersect with any existing edges, it passes
    
    
    for (int i = 0; i < vertexCount; i++) {
      Vector2 vertex = Random.insideUnitCircle * vertexCount;
      foreach (Vector2 vertex in vertices) {
        // if unblocked, connect
        
      }
    }
  }
}