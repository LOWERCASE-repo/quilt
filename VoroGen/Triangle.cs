using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Triangle {
  //Corners
  internal Vertex vertexOne;
  internal Vertex vertexTwo; // better way to store?
  internal Vertex vertexThree;
  
  //If we are using the half edge mesh structure, we just need one half edge
  internal HalfEdge halfEdge;
  
  internal Triangle(Vertex vertexOne, Vertex vertexTwo, Vertex vertexThree) {
    this.vertexOne = vertexOne;
    this.vertexTwo = vertexTwo;
    this.vertexThree = vertexThree;
  }
  
  internal Triangle(Vector2 vertexOne, Vector2 vertexTwo, Vector2 vertexThree) {
    this.vertexOne = new Vertex(vertexOne);
    this.vertexTwo = new Vertex(vertexTwo);
    this.vertexThree = new Vertex(vertexThree);
  }
  
  internal Triangle(HalfEdge halfEdge) {
    this.halfEdge = halfEdge;
  }
  
  //Change orientation of triangle from cw -> ccw or ccw -> cw
  internal void ChangeOrientation() {
    Vertex temp = this.vertexOne;
    this.vertexOne = this.vertexTwo;
    this.vertexTwo = temp;
  }
}