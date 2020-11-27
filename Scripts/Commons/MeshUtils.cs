using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshUtils
{
    /// <summary>
    ///
    /// Normal is Vector3.up
    /// Origin is LeftUp Corner
    /// 
    /// example
    /// ```
    ///   meshFilter.sharedMesh = MeshUtils.BuildPlaneMesh(...);
    /// ```
    /// </summary>
    /// <param name="offset"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="vertexWidthNum"></param>
    /// <param name="vertexHeightNum"></param>
    /// <returns></returns>
    public static Mesh CreatePlaneMesh(Vector3 offset, float width, float height,
                                int vertexWidthNum, int vertexHeightNum)
    {
        Func<int[], bool, List<int>> divideSq2Tri = (square, isInv) =>
        {
            if(!isInv)
            {
                return new List<int>() {square[0], square[2], square[3], square[0], square[3], square[1]};
            }
            else
            {
                return new List<int>() { square[0], square[3], square[2], square[0], square[1], square[3] };
            }
        };


        var mesh = new Mesh();

        var vertices = new List<Vector3>();
        var triangles = new List<int>();
        var uv0s = new List<Vector2>();
        var normals = new List<Vector3>();

        var normal = Vector3.up;
        var stepW = width / vertexWidthNum;
        var stepH = height / vertexHeightNum;

        for(var h = 0; h < vertexHeightNum; h++)
        {
            for(var w = 0; w < vertexWidthNum; w++)
            {
                vertices.Add(new Vector3(w * stepW, 0.0f, -h * stepH) + offset);
                uv0s.Add(new Vector2(w, h));
                normals.Add(normal);

                if(h >= vertexHeightNum - 1 || w >= vertexWidthNum - 1)
                {
                    continue;
                }
                var i = h * vertexWidthNum + w;
                triangles.AddRange(divideSq2Tri(new int[] { i, i + 1, i + vertexWidthNum, i + vertexWidthNum + 1 },
                                                true));
            }
        }

        mesh.SetVertices(vertices);
        mesh.SetIndices(triangles.ToArray(), MeshTopology.Triangles, 0);
        mesh.SetUVs(0, uv0s);
        mesh.SetNormals(normals);
        return mesh;
    }
}
