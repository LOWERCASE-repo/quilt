using UnityEngine;
using System.Collections.Generic;

internal class MapHullGenerator {
  
  private static Quaternion shift = Quaternion.AngleAxis(60f, Vector3.forward);
  
  private static void GenVertices(MapHull hull, NavNode node, HashSet<NavNode> visited) {
    Vector2 left = Vector2.zero;
    foreach (NavNode link in node.links.Keys) {
      left += link.pos - node.pos;
    }
    if (node.links.Count == 1) {
      left = new Vector2(left.y, -left.x);
    }
    left = left.normalized * hull.width;
    Vector2 right = -left;
    hull.vertices.Add(node.pos + left);
    hull.vertices.Add(node.pos + right);
    visited.Add(node);
    foreach (NavNode link in node.links.Keys) {
      if (!visited.Contains(link)) {
        GenVertices(hull, link, visited);
      }
    }
  }
  
  internal static MapHull GenHull(NavGraph graph) {
    MapHull hull = new MapHull(graph.width);
    GenVertices(hull, graph.start, new HashSet<NavNode>());
    hull.triangles = new int[(hull.vertices.Count - 2) * 3];
    int triangleIndex = 0;
    for (int i = 0; i < hull.vertices.Count - 2; i++) {
      for (int j = 0; j < 3; j++) {
        Debug.Log(triangleIndex + " " + (i + j));
        hull.triangles[triangleIndex] = i + j;
        triangleIndex++;
        // if (i % 2 == 0) {
        //   hull.triangles[i] = i + j;
        // } else {
        //   hull.triangles[i] = i + (2 - j);
        // }
      }
    }
    for (int i = 0; i < hull.triangles.Length; i++) {
      // Debug.Log(i + " " + hull.triangles[i]);
    }
    hull.mesh = new Mesh();
    hull.mesh.vertices = System.Array.ConvertAll<Vector2, Vector3>(hull.vertices.ToArray(), v => v);
    hull.mesh.triangles = hull.triangles;
    return hull;
  }
  
  
  /*
  
  0 1 2
  1 2 3
  2 3 4
  3 4 5
  
  */
}
