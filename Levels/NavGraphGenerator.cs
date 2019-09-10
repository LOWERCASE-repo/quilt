using UnityEngine;
using System.Collections.Generic;
using System;

internal class NavGraphGenerator {
  
  // TODO make this not static probably
  
  private static void GenGraphRec(Func<float, Vector2> eval, NavGraph graph, NavNode prev, NavNode next, float prevTime, float nextTime) {
    float midTime = (prevTime + nextTime) / 2f;
    Vector2 midPos = eval(midTime);
    
    NavNode mid = new NavNode(midPos);
    prev.Unlink(next);
    mid.Link(prev);
    mid.Link(next);
    graph.positions.Add(mid.pos);
    
    float prevDist = (midPos - prev.pos).magnitude;
    if (prevDist >= graph.width) {
      GraphRec(eval, graph, prev, mid, prevTime, midTime);
    }
    
    float nextDist = (midPos - next.pos).magnitude;
    if (nextDist >= graph.width) {
      GraphRec(eval, graph, mid, next, midTime, nextTime);
    }
  }
  
  internal static NavGraph GenGraph(Func<float, Vector2> eval, float width) {
    NavNode start = new NavNode(eval(0f));
    NavNode end = new NavNode(eval(1f));
    NavGraph graph = new NavGraph(new HashSet<Vector2>(), start, width);
    start.Link(end);
    graph.positions.Add(start.pos);
    graph.positions.Add(end.pos);
    GenGraphRec(eval, graph, start, end, 0f, 1f);
    start.EvalWeights();
    return graph;
  }
  
  private static void DebugGraphRec(NavNode prev, NavNode current) {
    foreach (KeyValuePair<NavNode, float> link in current.links) {
      if (link.Key != prev) {
        Debug.DrawLine(current.pos, prev.pos);
        DebugGraphRec(current, link.Key);
      }
    }
  }
  
  internal static void DebugGraph(NavNode start) {
    foreach (KeyValuePair<NavNode, float> link in start.links) { // will break on loops
      DebugGraphRec(start, link.Key);
    }
  }
}
