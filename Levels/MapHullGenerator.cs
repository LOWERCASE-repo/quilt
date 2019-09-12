using UnityEngine;
using System.Collections.Generic;

internal class MapHullGenerator {
  
  private static MapHull hull;
  
  private static void GenVertices(Vector2[] positions) {
    for (int i = 1; i < positions.Length - 1; i++) {
      Vector2 pos = positions[i];
      Vector2 prev = (positions[i - 1] - pos).normalized;
      Vector next = (positions[i + 1] - pos).normalized;
      Vector2 perp = (prev + next).normalized * width;
      hull.vertices[i * 2] = pos + perp;
      hull.vertices[i * 2 + 1] = pos - perp;
    }
  }
  private static void GenEndVertices(bool starting, Vector2 end, Vector2 dir) {
    Vector2 perp = end + dir;
    perp = new Vector2(perp.y, -perp.x);
    if (starting) {
      hull.vertices[0] = end + perp;
      hull.vertices[1] = end - perp;
    } else {
      int endIndex = hull.vertices.Length;
      hull.vertices[endIndex - 2] = end - perp;
      hull.vertices[endIndex - 1] = end + perp;
    }
  }
  
  internal static MapHull GenHull(NavGraph graph, float width) {
    hull = new MapHull(graph, width);
    hull.vertices = new Vector2[graph.positions.Length * 2];
    GenVertices(graph.positions);
    int endIndex = positions.Length - 1;
    GenEndVertices(true, positions[0], positions[1]);
    GenEndVertices(false, positions[endIndex], positions[endIndex - 1]);
    
    int triangleIndex = 0;
    for (int i = 0; i < hull.vertices.Length - 2; i++) {
      for (int j = 0; j < 3; j++) {
        hull.triangles[triangleIndex] = i + j;
        triangleIndex++;
      }
    }
    Mesh mesh = new Mesh();
    mesh.vertices = System.Array.ConvertAll<Vector2, Vector3>(hull.vertices, v => v);
    mesh.triangles = hull.triangles;
    hull.mesh = mesh;
    
    int edgeIndex = 0;
    for (int i = 0; i < hull.vertices.Count; i += 2) {
      edges[edgeIndex] = hull.vertices[i];
      edgeIndex++;
    }
    for (int i = hull.vertices.Count - 1; i > 0; i -= 2) {
      edges[edgeIndex] = hull.vertices[i];
      edgeIndex++;
    }
    edges[edgeIndex] = hull.vertices[0];
    
    MapHull hull = new MapHull
    return hull;
  }
}
