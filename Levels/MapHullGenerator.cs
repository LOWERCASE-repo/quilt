using UnityEngine;
using System.Collections.Generic;

internal class MapHullGenerator {
  
  private static Quaternion shift = Quaternion.AngleAxis(60f, Vector3.forward);
  
  private static List<Vector2> GenVertices(MapHull hull, NavNode node, HashSet<NavNode> visited) {
    Vector2 left = Vector2.zero;
    foreach (NavNode link in node.links.Keys) {
      left += link.pos - node.pos;
    }
    if (node.links.Keys.Length == 1) {
      left = new Vector2(left.y, -left.x);
    }
    left = left.normalized * hull.width;
    Vector2 right = -left;
    hull.vertices.Add(node.pos + left);
    hull.vertices.Add(node.pos + right);
    visited.Add(node);
    foreach (NavNode link in node.links.Keys) {
      if (!visited.Contains(link)) {
        GenHullPoints(hull, link, visited);
      }
    }
  }
  
  internal static MapHull GenHull(NavGraph graph) {
    MapHull hull = new MapHull(graph.width);
    GenVertices(hull, graph.start, new HashSet<NavNode>());
    hull.triangles = new int[hull.vertices.Count - 2];
    for (int i = 0; i < triangles.Count - 3; i += 3) {
      for (int j = 0; j < 3; j++) {
        if (i % 2 == 0) {
          triangles[i] = i + j;
        } else {
          triangles[i] = i + (2 - j);
        }
      }
    }
    hull.mesh = new Mesh();
    hull.mesh.vertices = System.Array.ConvertAll<Vector2, Vector3>((hull.vertices.ToArray(), v => v));
    hull.mesh.triangles = hull.triangles;
    return hull;
  }
}
