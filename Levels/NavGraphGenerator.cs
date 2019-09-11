using UnityEngine;
using System;

internal class NavGraphGenerator {
  
  private static void GenGraphRec(Func<float, Vector2> eval, NavGraph graph, NavNode prev, NavNode next, float prevTime, float nextTime) {
    float midTime = (prevTime + nextTime) / 2f;
    Vector2 midPos = eval(midTime);
    
    NavNode mid = new NavNode(midPos);
    prev.Unlink(next);
    mid.Link(prev);
    mid.Link(next);
    graph.positions.Add(mid.pos);
    
    float prevDist = (midPos - prev.pos).magnitude;
    if (prevDist > graph.tolerance) {
      GenGraphRec(eval, graph, prev, mid, prevTime, midTime);
    }
    
    float nextDist = (midPos - next.pos).magnitude;
    if (nextDist > graph.tolerance) {
      GenGraphRec(eval, graph, mid, next, midTime, nextTime);
    }
  }
  
  internal static NavGraph GenGraph(Func<float, Vector2> eval, float tolerance) {
    NavNode start = new NavNode(eval(0f));
    NavNode end = new NavNode(eval(1f));
    start.Link(end);
    NavGraph graph = new NavGraph(start, tolerance);
    graph.positions.Add(start.pos);
    graph.positions.Add(end.pos);
    GenGraphRec(eval, graph, start, end, 0f, 1f);
    start.EvalWeights();
    return graph;
  }
}
