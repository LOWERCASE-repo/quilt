using UnityEngine;
using System.Collections.Generic;

internal class MapHullGenerator {
  
  private static Quaternion shift = Quaternion.AngleAxis(60f, Vector3.forward);
  
  private static void GenVertices(MapHull hull, NavNode node, HashSet<NavNode> visited) {
    Vector2 left = Vector2.zero;
    foreach (NavNode link in node.links.Keys) {
      if (!visited.Contains(link)) {
        left += (link.pos - node.pos).normalized;
      }
    }
    if (left.Equals(Vector2.zero)) return;
    left = new Vector2(left.y, -left.x);
    left = left.normalized * hull.width;
    hull.vertices.Add(node.pos + left);
    hull.vertices.Add(node.pos - left);
    visited.Add(node);
    foreach (NavNode link in node.links.Keys) {
      if (!visited.Contains(link)) {
        GenVertices(hull, link, visited);
      }
    }
  }
  
  internal static MapHull GenHull(NavGraph graph, float width) {
    MapHull hull = new MapHull(width);
    GenVertices(hull, graph.start, new HashSet<NavNode>());
    hull.triangles = new int[(hull.vertices.Count - 2) * 3];
    int triangleIndex = 0;
    for (int i = 0; i < hull.vertices.Count - 2; i++) {
      for (int j = 0; j < 3; j++) {
        hull.triangles[triangleIndex] = i + j;
        triangleIndex++;
      }
    }
    hull.mesh = new Mesh();
    hull.mesh.vertices = System.Array.ConvertAll<Vector2, Vector3>(hull.vertices.ToArray(), v => v);
    hull.mesh.triangles = hull.triangles;
    
    hull.edges = new Vector2[hull.vertices.Count * 2];
    for (int i = 0; i < hull.vertices.Count; i += 2) {
      hull.edges.Add(hull.vertices[i]);
    }
    for (int i = hull.vertices.Count - 2; i > 0; i -= 2) {
      hull.edges.Add(hull.vertices[i]);
    }
    
    return hull;
  }
}
