using UnityEngine;
using System.Collections.Generic;

internal class NavNode {
  
  internal Vector2 pos;
  internal Dictionary<NavNode, float> links;
  
  internal void Link(NavNode node) {
    links.Add(node, -1f);
    node.links.Add(this, -1f);
  }
  
  internal void Unlink(NavNode node) {
    links.Remove(node);
    node.links.Remove(this);
  }
  
  internal void EvalWeights() {
    // foreach (KeyValuePair<NavNode, float> link in links) {
    //   NavNode node = link.Key;
    //   if (link.Value == -1f) {
    //     float dist = (pos - node.pos).magnitude;
    //     links[node] = dist;
    //     node.links[this] = dist;
    //     node.EvalWeights();
    //   }
    // }
  }
  
  internal NavNode(Vector2 pos) {
    this.pos = pos;
    links = new Dictionary<NavNode, float>();
  }
}
