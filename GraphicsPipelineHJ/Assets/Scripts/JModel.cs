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
        AddToTextures();

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

            Vector3 normal_for_face = normals[i ];

            normal_for_face = new Vector3(normal_for_face.x, normal_for_face.y, -normal_for_face.z);

            coords.Add(Verticies[Faces[i].x]); dummy_indices.Add(i * 3); //text_coords.Add(_texture_coordinates[_texture_index_list[i].x]);
            normalz.Add(normal_for_face);

            coords.Add(Verticies[Faces[i].y]); dummy_indices.Add(i * 3 + 2); //text_coords.Add(_texture_coordinates[_texture_index_list[i].y]);
            normalz.Add(normal_for_face);

            coords.Add(Verticies[Faces[i].z]); dummy_indices.Add(i * 3 + 1);// text_coords.Add(_texture_coordinates[_texture_index_list[i].z]);
            normalz.Add(normal_for_face);

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

        Faces.Add(new Vector3Int(11, 12, 14));  normals.Add(new Vector3(0, 0, 1));
        Faces.Add(new Vector3Int(12, 13, 14)); normals.Add(new Vector3(0, 0, 1));
        Faces.Add(new Vector3Int(0, 9, 10)); normals.Add(new Vector3(0, 0, 1));
        Faces.Add(new Vector3Int(0, 10, 15)); normals.Add(new Vector3(0, 0, 1));
        Faces.Add(new Vector3Int(0, 8, 9)); normals.Add(new Vector3(0, 0, 1));
        Faces.Add(new Vector3Int(0, 1, 8)); normals.Add(new Vector3(0, 0, 1));
        Faces.Add(new Vector3Int(1, 5, 8)); normals.Add(new Vector3(0, 0, 1));
        Faces.Add(new Vector3Int(1, 2, 5)); normals.Add(new Vector3(0, 0, 1));
        Faces.Add(new Vector3Int(2, 3, 5)); normals.Add(new Vector3(0, 0, 1));
        Faces.Add(new Vector3Int(3, 4, 5)); normals.Add(new Vector3(0, 0, 1));

        //Back

        Faces.Add(new Vector3Int(30,29,28)); normals.Add(new Vector3(0, 0, -1));
        Faces.Add(new Vector3Int(27,30,28)); normals.Add(new Vector3(0, 0, -1));
        Faces.Add(new Vector3Int(16,31,26)); normals.Add(new Vector3(0, 0, -1));
        Faces.Add(new Vector3Int(16,26,25)); normals.Add(new Vector3(0, 0, -1));
        Faces.Add(new Vector3Int(16,25,17)); normals.Add(new Vector3(0, 0, -1));
        Faces.Add(new Vector3Int(17,25,24)); normals.Add(new Vector3(0, 0, -1));
        Faces.Add(new Vector3Int(17,21,18)); normals.Add(new Vector3(0, 0, -1));
        Faces.Add(new Vector3Int(17,24,21)); normals.Add(new Vector3(0, 0, -1));
        Faces.Add(new Vector3Int(18,20,19)); normals.Add(new Vector3(0, 0, -1));
        Faces.Add(new Vector3Int(18,21,20)); normals.Add(new Vector3(0, 0, -1));

        //Right

        Faces.Add(new Vector3Int(9,25,26)); normals.Add(new Vector3(1, 0, 0));
        Faces.Add(new Vector3Int(9,26,10)); normals.Add(new Vector3(1, 0, 0));
        Faces.Add(new Vector3Int(11,27,28)); normals.Add(new Vector3(1, 0, 0));
        Faces.Add(new Vector3Int(11,28,12)); normals.Add(new Vector3(1, 0, 0));

        //Left

        Faces.Add(new Vector3Int(0,15,16)); normals.Add(new Vector3(-1, 0, 0));
        Faces.Add(new Vector3Int(16,15,31)); normals.Add(new Vector3(-1, 0, 0));
        Faces.Add(new Vector3Int(13,30,14)); normals.Add(new Vector3(-1, 0, 0));
        Faces.Add(new Vector3Int(13,29,30)); normals.Add(new Vector3(-1, 0, 0));

        //Top

        Faces.Add(new Vector3Int(13,12,28)); normals.Add(new Vector3(0, 1, 0));
        Faces.Add(new Vector3Int(13,28,29)); normals.Add(new Vector3(0, 1, 0));
        Faces.Add(new Vector3Int(4,3,19)); normals.Add(new Vector3(-0.5f, 1, 0));
        Faces.Add(new Vector3Int(4,19,20)); normals.Add(new Vector3(-0.5f, 1, 0));
        Faces.Add(new Vector3Int(0,17,1)); normals.Add(new Vector3(-0.5f, 1, 0));
        Faces.Add(new Vector3Int(0,16,17)); normals.Add(new Vector3(-0.5f, 1, 0));
        Faces.Add(new Vector3Int(1,17,2)); normals.Add(new Vector3(0, 1, 0));
        Faces.Add(new Vector3Int(2,17,18)); normals.Add(new Vector3(0, 1, 0));
        Faces.Add(new Vector3Int(2,18,3)); normals.Add(new Vector3(0.5f, 1, 0));
        Faces.Add(new Vector3Int(3,18,19)); normals.Add(new Vector3(0.5f, 1, 0));

        //Bottom

        Faces.Add(new Vector3Int(15,30,31)); normals.Add(new Vector3(0, -1, 0));
        Faces.Add(new Vector3Int(15,14,30)); normals.Add(new Vector3(0, -1, 0));
        Faces.Add(new Vector3Int(11,26,27)); normals.Add(new Vector3(0, -1, 0));
        Faces.Add(new Vector3Int(11,10,26)); normals.Add(new Vector3(0, -1, 0));
        Faces.Add(new Vector3Int(4,20,5)); normals.Add(new Vector3(-0.5f, -1, 0));
        Faces.Add(new Vector3Int(20,21,5)); normals.Add(new Vector3(-0.5f, -1, 0));
        Faces.Add(new Vector3Int(5,21,8)); normals.Add(new Vector3(0, -1, 0));
        Faces.Add(new Vector3Int(21,24,8)); normals.Add(new Vector3(0, -1, 0));
        Faces.Add(new Vector3Int(8,25,9)); normals.Add(new Vector3(0.5f, -1, 0));
        Faces.Add(new Vector3Int(8,24,25)); normals.Add(new Vector3(0.5f, -1, 0));
    }

    void AddToTextures()
    {
        _texture_coordinates.Add(new Vector2(0.5625f, 0.5f));   _texture_index_list.Add(new Vector3Int(0, 0, 1));
        _texture_coordinates.Add(new Vector2(0.53125f, 0.53125f)); _texture_index_list.Add(new Vector3Int(-1, -1, 1));
        _texture_coordinates.Add(new Vector2(0.530273438f, 0.561523438f)); _texture_index_list.Add(new Vector3Int(-2, -1, 1));
        _texture_coordinates.Add(new Vector2(0.5625f, 0.59375f)); _texture_index_list.Add(new Vector3Int(-3, 0, 1));
        _texture_coordinates.Add(new Vector2(0.53125f, 0.625f)); _texture_index_list.Add(new Vector3Int(-4, -1, 1));
        _texture_coordinates.Add(new Vector2(0.5f, 0.59375f)); _texture_index_list.Add(new Vector3Int(-3, -2, 1));
        _texture_coordinates.Add(new Vector2(0.5f, 0.561523438f)); _texture_index_list.Add(new Vector3Int(-2, -2, 1));
        _texture_coordinates.Add(new Vector2(0.5f, 0.53125f)); _texture_index_list.Add(new Vector3Int(-1, -2, 1));
        _texture_coordinates.Add(new Vector2(0.5f, 0.5f)); _texture_index_list.Add(new Vector3Int(0, -2, 1));
        _texture_coordinates.Add(new Vector2(0.530273438f, 0.46875f)); _texture_index_list.Add(new Vector3Int(1, -1, 1));
        _texture_coordinates.Add(new Vector2(0.655273438f, 0.46875f)); _texture_index_list.Add(new Vector3Int(1, 3, 1));
        _texture_coordinates.Add(new Vector2(0.655273438f, 0.40625f)); _texture_index_list.Add(new Vector3Int(3, 3, 1));
        _texture_coordinates.Add(new Vector2(0.6875f, 0.40625f)); _texture_index_list.Add(new Vector3Int(3, 4, 1));
        _texture_coordinates.Add(new Vector2(0.6875f, 0.561523438f)); _texture_index_list.Add(new Vector3Int(-2, 4, 1));
        _texture_coordinates.Add(new Vector2(0.655273438f, 0.561523438f)); _texture_index_list.Add(new Vector3Int(-2, 3, 1));
        _texture_coordinates.Add(new Vector2(0.655273438f, 0.5f)); _texture_index_list.Add(new Vector3Int(0, 3, 1));
        _texture_coordinates.Add(new Vector2(0.375f, 0.5f)); _texture_index_list.Add(new Vector3Int(0,0,-1));
        _texture_coordinates.Add(new Vector2(0.40625f, 0.53125f)); _texture_index_list.Add(new Vector3Int(-1, -1, -1));
        _texture_coordinates.Add(new Vector2(0.40625f, 0.561523438f)); _texture_index_list.Add(new Vector3Int(-2, -1, -1));
        _texture_coordinates.Add(new Vector2(0.375f, 0.59375f)); _texture_index_list.Add(new Vector3Int(-3, 0, -1));
        _texture_coordinates.Add(new Vector2(0.40625f, 0.625f)); _texture_index_list.Add(new Vector3Int(-4, -1, -1));
        _texture_coordinates.Add(new Vector2(0.4375f, 0.59375f)); _texture_index_list.Add(new Vector3Int(-3, -2, -1));
        _texture_coordinates.Add(new Vector2(0.4375f, 0.561523438f)); _texture_index_list.Add(new Vector3Int(-2, -2, -1));
        _texture_coordinates.Add(new Vector2(0.4375f, 0.53125f)); _texture_index_list.Add(new Vector3Int(-1, -2, -1));
        _texture_coordinates.Add(new Vector2(0.22265625f, 0.5f)); _texture_index_list.Add(new Vector3Int(0, -2, -1));
        _texture_coordinates.Add(new Vector2(0.40625f, 0.46875f)); _texture_index_list.Add(new Vector3Int(1, -1, -1));
        _texture_coordinates.Add(new Vector2(0.28125f, 0.46875f)); _texture_index_list.Add(new Vector3Int(1, 3, -1)); 
        _texture_coordinates.Add(new Vector2(0.28125f, 0.40625f)); _texture_index_list.Add(new Vector3Int(3, 3, -1));
        _texture_coordinates.Add(new Vector2(0.249023438f, 0.40625f)); _texture_index_list.Add(new Vector3Int(3, 4, -1));
        _texture_coordinates.Add(new Vector2(0.249023438f, 0.561523438f)); _texture_index_list.Add(new Vector3Int(-2, 4, -1));
        _texture_coordinates.Add(new Vector2(0.28125f, 0.561523438f)); _texture_index_list.Add(new Vector3Int(-2, 3, -1));
        _texture_coordinates.Add(new Vector2(0.28125f, 0.5f)); _texture_index_list.Add(new Vector3Int(0, 3, -1));


    }

}
