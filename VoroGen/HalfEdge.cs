using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class HalfEdge {
  
  //The vertex the edge points to
  internal Vertex vertex;
  //The face this edge is a part of
  internal Triangle triangle;
  //The next edge
  internal HalfEdge nextEdge;
  //The previous
  internal HalfEdge prevEdge;
  //The edge going in the opposite direction
  internal HalfEdge oppositeEdge;
  
  //This structure assumes we have a vertex class with a reference to a half edge going from that vertex
  //and a face (triangle) class with a reference to a half edge which is a part of this face 
  internal HalfEdge(Vertex vertex) {
    this.vertex = vertex;
  }
}