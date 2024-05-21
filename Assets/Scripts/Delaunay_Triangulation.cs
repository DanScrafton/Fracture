using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delaunay_Triangulation : MonoBehaviour
{
   
    

        /// <summary>
        /// List of vertices that make up the triangulation
        /// </summary>
        public readonly List<Vector2> Vertices;

        /// <summary>
        /// List of triangles that make up the triangulation. The elements index
        /// the Vertices array. 
        /// </summary>
        public readonly List<int> Triangles;

        internal Delaunay_Triangulation()
        {
            Vertices = new List<Vector2>();
            Triangles = new List<int>();
        }

        internal void Clear()
        {
            Vertices.Clear();
            Triangles.Clear();
        }

        public override string ToString()
        {
            string rString = "";

            rString += "#Vertices\n";
            foreach (Vector2 vert in Vertices)
            {
                rString += $"X:{vert.x.ToString()}, Y:{vert.y.ToString()} \n";
            }

            rString += "#Edges of Triangles\n";
            for (int i = 0; i < this.Triangles.Count; i++)
            {
                rString += $"{i.ToString()}: {this.Triangles[i].ToString()}\n";

            }

            return rString;
        }

        /// <summary>
        /// Verify that this is an actual Delaunay triangulation
        /// </summary>
        public bool Verify()
        {
            try
            {
                for (int i = 0; i < Triangles.Count; i += 3)
                {
                    var c0 = Vertices[Triangles[i]];
                    var c1 = Vertices[Triangles[i + 1]];
                    var c2 = Vertices[Triangles[i + 2]];

                    for (int j = 0; j < Vertices.Count; j++)
                    {
                        var p = Vertices[j];
                        if (Geometry.Inside_Circumcircle(p, c0, c1, c2))
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }

