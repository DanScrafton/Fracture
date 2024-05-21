using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voronoi_Diagram : MonoBehaviour
{
    public readonly Delaunay_Triangulation Triangulation;

    public readonly List<Vector2> Sites;

    

    public readonly List<Edge> Edges;

    public readonly List<Vector2> Vertices;

    public readonly List<int> FirstEdgeBySite;

    internal Voronoi_Diagram()
    {
        Triangulation = new Delaunay_Triangulation();
        Sites = Triangulation.Vertices;
        Vertices = new List<Vector2>();
        Edges = new List<Edge>();
        FirstEdgeBySite = new List<int>();
    }

    internal void Clear()
    {
        Triangulation.Clear();
        Sites.Clear();
        Vertices.Clear();
        Edges.Clear();
        FirstEdgeBySite.Clear();
    }

    public enum EdgeType
    {
        Line,
        RayCCW,
        RayCW,
        Segment
    }

    public struct Edge
    {
        readonly public EdgeType Type;

        readonly public int Site;

        readonly public int Vert0;

        readonly public int Vert1;

        public Vector2 Direction;

        public Edge(EdgeType type, int site, int vert0, int vert1, Vector2 direction)
        {
            this.Type = type;
            this.Site = site;
            this.Vert0 = vert0;
            this.Vert1 = vert1;
            this.Direction = direction;
        }

        public override string ToString()
        {
            if (Type == EdgeType.Segment)
            {
                return string.Format("VoronoiEdge(Segment, {0}, {1}, {2})",
                        Site, Vert0, Vert1);
            }
            else if (Type == EdgeType.Segment)
            {
                return string.Format("VoronoiEdge(Line, {0}, {1}, {2})",
                        Site, Vert0, Direction);
            }
            else
            {
                return string.Format("VoronoiEdge(Ray, {0}, {1}, ({2}, {3}))",
                        Site, Vert0, Direction.x, Direction.y);
            }
        }
    }  
}
