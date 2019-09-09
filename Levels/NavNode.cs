using UnityEngine;
using System.Collections.Generic;

internal class NavNode {
  
  internal Vector2 pos;
  internal Dictionary<NavNode, float> links;
  
  internal void Link(NavNode node) {
    float dist = (pos - node.pos).magnitude; // TODO cpu hog
    links.Add(node, dist);
    node.links.Add(this, dist);
  }
  
  internal void Unlink(NavNode node) {
    links.Remove(node);
    node.links.Remove(this);
  }
  
  internal void EvalWeights() {
    return; // 
  }
  
  internal NavNode(Vector2 pos) {
    this.pos = pos;
    links = new Dictionary<NavNode, float>();
  }
}
