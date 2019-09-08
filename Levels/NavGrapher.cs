using UnityEngine;
using System.Collections.Generic;
using System;

internal class NavGrapher {
  
  private static void GraphRec(Func<float, Vector2> eval, float width, NavNode prev, NavNode next, float prevTime, float nextTime) {
    float midTime = (prevTime + nextTime) / 2f;
    Vector2 midPos = eval(midTime);
  
    NavNode mid = new NavNode(midPos);
    prev.Unlink(next);
    mid.Link(prev);
    mid.Link(next);
  
    float prevDist = (midPos - prev.pos).magnitude;
    if (prevDist >= width) {
      GraphRec(eval, width, prev, mid, prevTime, midTime);
    }
    
    float nextDist = (midPos - next.pos).magnitude;
    if (nextDist >= width) {
      GraphRec(eval, width, mid, next, midTime, nextTime);
    }
  }
  
  internal static NavNode Graph(Func<float, Vector2> eval, float width) {
    NavNode start = new NavNode(eval(0f));
    NavNode end = new NavNode(eval(1f));
    start.Link(end);
    GraphRec(eval, width, start, end, 0f, 1f);
    return start;
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
