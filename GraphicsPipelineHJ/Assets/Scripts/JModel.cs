using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JModel : MonoBehaviour
{
    List<Vector3> Verticies = new List<Vector3>();

    List<Vector3Int> Faces = new List<Vector3Int>();

    List<Vector2> _texture_coordinates = new List<Vector2>();

    List<Vector3Int>_texture_index_list = new List<Vector3Int>();

    List<Vector3> normals = new List<Vector3>();

    public GameObject CreateUnityGameObject()
    {

        AddAllVerticies();
        AddAllFaces();
        AddToNormals(); 

        Mesh mesh = new Mesh();

        GameObject newGO = new GameObject();

        MeshFilter mesh_filter = newGO.AddComponent<MeshFilter>();

        MeshRenderer mesh_renderer = newGO.AddComponent<MeshRenderer>();


        List<Vector3> coords = new List<Vector3>();

        List<int> dummy_indices = new List<int>();

        List<Vector2> text_coords = new List<Vector2>();

        List<Vector3> normalz = new List<Vector3>();



        for (int i = 0; i < Faces.Count; i++)
        {

            Vector3 normal_for_face = normals[i / 3];

            normal_for_face = new Vector3(normal_for_face.x, normal_for_face.y, -normal_for_face.z);

            coords.Add(Verticies[Faces[i].x]); dummy_indices.Add(i * 3); text_coords.Add(_texture_coordinates[_texture_index_list[i].x]); normalz.Add(normal_for_face);

            coords.Add(Verticies[Faces[i].y]); dummy_indices.Add(i * 3 + 1); text_coords.Add(_texture_coordinates[_texture_index_list[i].y]); normalz.Add(normal_for_face);

            coords.Add(Verticies[Faces[i].z]); dummy_indices.Add(i * 3 + 2); text_coords.Add(_texture_coordinates[_texture_index_list[i].z]); normalz.Add(normal_for_face);

        }



        mesh.vertices = coords.ToArray();

        mesh.triangles = dummy_indices.ToArray();

        mesh.uv = text_coords.ToArray();

        mesh.normals = normalz.ToArray(); ;



        mesh_filter.mesh = mesh;

        return newGO;



    }


    public void Start()
    {
        CreateUnityGameObject();
    }

    void AddAllVerticies()
    {
        Verticies.Add(new Vector3(0, 0, 1));
        Verticies.Add(new Vector3(-1, -1, 1));
        Verticies.Add(new Vector3(-2, -1, 1));
        Verticies.Add(new Vector3(-3, 0, 1));
        Verticies.Add(new Vector3(-4, -1, 1));
        Verticies.Add(new Vector3(-3, -2, 1));
        Verticies.Add(new Vector3(-2, -2, 1));
        Verticies.Add(new Vector3(-1, -2, 1));
        Verticies.Add(new Vector3(0, -2, 1));
        Verticies.Add(new Vector3(1, -1, 1));
        Verticies.Add(new Vector3(1, 3, 1));
        Verticies.Add(new Vector3(3, 3, 1));
        Verticies.Add(new Vector3(3, 4, 1));
        Verticies.Add(new Vector3(-2, 4, 1));
        Verticies.Add(new Vector3(-2, 3, 1));
        Verticies.Add(new Vector3(0, 3, 1));
        Verticies.Add(new Vector3(0, 0, -1));
        Verticies.Add(new Vector3(-1, -1, -1));
        Verticies.Add(new Vector3(-2, -1, -1));
        Verticies.Add(new Vector3(-3, 0, -1));
        Verticies.Add(new Vector3(-4, -1, -1));
        Verticies.Add(new Vector3(-3, -2, -1));
        Verticies.Add(new Vector3(-2, -2, -1));
        Verticies.Add(new Vector3(-1, -2, -1));
        Verticies.Add(new Vector3(0, -2, -1));
        Verticies.Add(new Vector3(1, -1, -1));
        Verticies.Add(new Vector3(1, 3, -1));
        Verticies.Add(new Vector3(3, 3, -1));
        Verticies.Add(new Vector3(3, 4, -1));
        Verticies.Add(new Vector3(-2, 4, -1));
        Verticies.Add(new Vector3(-2, 3, -1));
        Verticies.Add(new Vector3(0, 3, -1));
    }

    void AddAllFaces()
    {
        //Front
        
        Faces.Add(new Vector3Int(11,12,14));
        Faces.Add(new Vector3Int(12,13,14));
        Faces.Add(new Vector3Int(0,9,10));
        Faces.Add(new Vector3Int(0,10,15));
        Faces.Add(new Vector3Int(0,8,9));
        Faces.Add(new Vector3Int(0,1,8));
        Faces.Add(new Vector3Int(1,5,8));
        Faces.Add(new Vector3Int(1,2,5));
        Faces.Add(new Vector3Int(2,3,5));
        Faces.Add(new Vector3Int(3,4,5));
        Faces.Add(new Vector3Int(30,28,29));
        Faces.Add(new Vector3Int(27,28,30));
        Faces.Add(new Vector3Int(16,26,31));
        Faces.Add(new Vector3Int(16,25,26));
        Faces.Add(new Vector3Int(16,17,25));
        Faces.Add(new Vector3Int(17,24,25));
        Faces.Add(new Vector3Int(17,18,21));
        Faces.Add(new Vector3Int(17,21,24));
        Faces.Add(new Vector3Int(18,19,20));
        Faces.Add(new Vector3Int(18,20,21));

        //Right

        Faces.Add(new Vector3Int(9,25,26));
        Faces.Add(new Vector3Int(9,26,10));
        Faces.Add(new Vector3Int(11,27,28));
        Faces.Add(new Vector3Int(11,28,12));

        //Left

        Faces.Add(new Vector3Int(0,25,26));
        Faces.Add(new Vector3Int(16,15,31));
        Faces.Add(new Vector3Int(13,30,14));
        Faces.Add(new Vector3Int(13,29,30));

        //Top

        Faces.Add(new Vector3Int(13,12,28));
        Faces.Add(new Vector3Int(13,28,29));
        Faces.Add(new Vector3Int(4,3,19));
        Faces.Add(new Vector3Int(4,19,20));
        Faces.Add(new Vector3Int(0,17,1));
        Faces.Add(new Vector3Int(0,16,17));
        Faces.Add(new Vector3Int(1,17,2));
        Faces.Add(new Vector3Int(2,17,18));
        Faces.Add(new Vector3Int(2,18,3));
        Faces.Add(new Vector3Int(3,18,19));

        //Bottom

        Faces.Add(new Vector3Int(15,30,31));
        Faces.Add(new Vector3Int(15,14,30));
        Faces.Add(new Vector3Int(11,26,27));
        Faces.Add(new Vector3Int(11,10,26));
        Faces.Add(new Vector3Int(4,20,5));
        Faces.Add(new Vector3Int(20,21,5));
        Faces.Add(new Vector3Int(5,21,8));
        Faces.Add(new Vector3Int(21,8,24));
        Faces.Add(new Vector3Int(8,25,9));
        Faces.Add(new Vector3Int(8,24,25));
    }

    void AddToNormals()
    {
        normals.Add(new Vector3(0,0,1));
        normals.Add(new Vector3(0, 0, -1));
        normals.Add(new Vector3(1, 0, 0));
        normals.Add(new Vector3(-1, 0, 0));
        normals.Add(new Vector3(0, 1, 0));
        normals.Add(new Vector3(0, -1, 0));
    }
}
