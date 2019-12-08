using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Vertex {
  
  internal Vector2 pos;
  
  //The outgoing halfedge (a halfedge that starts at this vertex)
  //Doesnt matter which edge we connect to it
  internal HalfEdge halfEdge;
  
  //Which triangle is this vertex a part of?
  internal Triangle triangle;
  
  //The previous and next vertex this vertex is attached to
  internal Vertex prevVertex;
  internal Vertex nextVertex;
  
  //Properties this vertex may have
  //Reflex is concave
  internal bool isReflex;
  internal bool isConvex;
  internal bool isEar;
  
  internal Vertex(Vector2 pos) {
    this.pos = pos;
  }
}