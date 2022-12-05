using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JModel
{
    internal List<Vector3> Verticies;

    internal List<Vector3Int> Faces;

    List<Vector2> _texture_coordinates;

    List<Vector3Int> _texture_index_list;

    List<Vector3> normals;

    GameObject _gameObject;

    public GameObject CreateUnityGameObject()
    {


        //AddToTextures();

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

            Vector3 normal_for_face = normals[i];

            normal_for_face = new Vector3(normal_for_face.x, normal_for_face.y, -normal_for_face.z);

            coords.Add(Verticies[Faces[i].x]); dummy_indices.Add(i * 3); text_coords.Add(_texture_coordinates[_texture_index_list[i].x]);
            normalz.Add(normal_for_face);

            coords.Add(Verticies[Faces[i].y]); dummy_indices.Add(i * 3 + 2); text_coords.Add(_texture_coordinates[_texture_index_list[i].y]);
            normalz.Add(normal_for_face);

            coords.Add(Verticies[Faces[i].z]); dummy_indices.Add(i * 3 + 1); text_coords.Add(_texture_coordinates[_texture_index_list[i].z]);
            normalz.Add(normal_for_face);

        }



        mesh.vertices = coords.ToArray();

        mesh.triangles = dummy_indices.ToArray();

        mesh.uv = text_coords.ToArray();

        mesh.normals = normalz.ToArray(); ;



        mesh_filter.mesh = mesh;

        return newGO;



    }


    public JModel()
    {
        AddAllVerticies();
        AddAllFaces();
    }

    private void Update()
    {
        //_gameObject.transform.position += new Vector3(0, 0.5f, 0) * Time.deltaTime;
    }

    void AddAllVerticies()
    {
        _texture_coordinates = new List<Vector2>();
        Verticies = new List<Vector3>();

        //Front

        Verticies.Add(new Vector3(0, 0, 1)); _texture_coordinates.Add(new Vector2(511,383)); //0
        Verticies.Add(new Vector3(-1, -1, 1)); _texture_coordinates.Add(new Vector2(447, 448)); //1
        Verticies.Add(new Vector3(-2, -1, 1)); _texture_coordinates.Add(new Vector2(381, 448)); //2
        Verticies.Add(new Vector3(-3, 0, 1)); _texture_coordinates.Add(new Vector2(319, 384)); //3
        Verticies.Add(new Vector3(-4, -1, 1)); _texture_coordinates.Add(new Vector2(256, 447)); //4
        Verticies.Add(new Vector3(-3, -2, 1)); _texture_coordinates.Add(new Vector2(318, 510)); //5
        Verticies.Add(new Vector3(-2, -2, 1)); _texture_coordinates.Add(new Vector2(383, 512)); //6
        Verticies.Add(new Vector3(-1, -2, 1)); _texture_coordinates.Add(new Vector2(446, 512)); //7
        Verticies.Add(new Vector3(0, -2, 1)); _texture_coordinates.Add(new Vector2(511, 512)); //8
        Verticies.Add(new Vector3(1, -1, 1)); _texture_coordinates.Add(new Vector2(575, 448)); //9
        Verticies.Add(new Vector3(1, 3, 1)); _texture_coordinates.Add(new Vector2(576, 190)); //10
        Verticies.Add(new Vector3(3, 3, 1)); _texture_coordinates.Add(new Vector2(704, 190)); //11
        Verticies.Add(new Vector3(3, 4, 1)); _texture_coordinates.Add(new Vector2(704, 127)); //12
        Verticies.Add(new Vector3(-2, 4, 1)); _texture_coordinates.Add(new Vector2(383, 127)); //13
        Verticies.Add(new Vector3(-2, 3, 1)); _texture_coordinates.Add(new Vector2(383, 190)); //14
        Verticies.Add(new Vector3(0, 3, 1)); _texture_coordinates.Add(new Vector2(511, 190)); //15

        //Back

        Verticies.Add(new Vector3(0, 0, -1)); _texture_coordinates.Add(new Vector2(512, 703)); //16
        Verticies.Add(new Vector3(-1, -1, -1)); _texture_coordinates.Add(new Vector2(447, 639)); //17
        Verticies.Add(new Vector3(-2, -1, -1)); _texture_coordinates.Add(new Vector2(383, 638)); //18
        Verticies.Add(new Vector3(-3, 0, -1)); _texture_coordinates.Add(new Vector2(318, 703)); //19
        Verticies.Add(new Vector3(-4, -1, -1)); _texture_coordinates.Add(new Vector2(256, 650)); //20
        Verticies.Add(new Vector3(-3, -2, -1)); _texture_coordinates.Add(new Vector2(319, 577)); //21
        Verticies.Add(new Vector3(-2, -2, -1)); _texture_coordinates.Add(new Vector2(383, 577)); //22
        Verticies.Add(new Vector3(-1, -2, -1)); _texture_coordinates.Add(new Vector2(447, 577)); //23
        Verticies.Add(new Vector3(0, -2, -1)); _texture_coordinates.Add(new Vector2(512, 577)); //24
        Verticies.Add(new Vector3(1, -1, -1)); _texture_coordinates.Add(new Vector2(575, 639)); //25
        Verticies.Add(new Vector3(1, 3, -1)); _texture_coordinates.Add(new Vector2(574, 864)); //26
        Verticies.Add(new Vector3(3, 3, -1)); _texture_coordinates.Add(new Vector2(704, 865)); //27
        Verticies.Add(new Vector3(3, 4, -1)); _texture_coordinates.Add(new Vector2(704, 928)); //28
        Verticies.Add(new Vector3(-2, 4, -1)); _texture_coordinates.Add(new Vector2(383, 928)); //29
        Verticies.Add(new Vector3(-2, 3, -1)); _texture_coordinates.Add(new Vector2(383, 862)); //30
        Verticies.Add(new Vector3(0, 3, -1)); _texture_coordinates.Add(new Vector2(511, 861)); //31

        _texture_coordinates.Add(new Vector2(639, 255)); //32
        _texture_coordinates.Add(new Vector2(639, 448)); //33
        _texture_coordinates.Add(new Vector2(639, 511)); //34
        _texture_coordinates.Add(new Vector2(575, 571)); //35
        _texture_coordinates.Add(new Vector2(511, 575)); //36
        _texture_coordinates.Add(new Vector2(319, 576)); //37
        _texture_coordinates.Add(new Vector2(255, 575)); //38
        _texture_coordinates.Add(new Vector2(191, 512)); //39
        _texture_coordinates.Add(new Vector2(194, 384)); //40
        _texture_coordinates.Add(new Vector2(255, 322)); //41
        _texture_coordinates.Add(new Vector2(382, 320)); //42
        _texture_coordinates.Add(new Vector2(443, 383)); //43
        _texture_coordinates.Add(new Vector2(94, 736)); //44
        _texture_coordinates.Add(new Vector2(157, 736)); //45
        _texture_coordinates.Add(new Vector2(383, 703)); //46
        _texture_coordinates.Add(new Vector2(447, 765)); //47
        _texture_coordinates.Add(new Vector2(448, 384)); //48
        _texture_coordinates.Add(new Vector2(448, 256)); //49
        _texture_coordinates.Add(new Vector2(383, 255)); //50
        _texture_coordinates.Add(new Vector2(319, 191)); //51
        _texture_coordinates.Add(new Vector2(318, 126)); //52
        _texture_coordinates.Add(new Vector2(383, 65)); //53
        _texture_coordinates.Add(new Vector2(700, 63)); //54
        _texture_coordinates.Add(new Vector2(768, 129)); //55
        _texture_coordinates.Add(new Vector2(767, 191)); //56
        _texture_coordinates.Add(new Vector2(703, 256)); //57

        _texture_coordinates = GetValuesRel(1024, _texture_coordinates);
    }

    private List<Vector2> GetValuesRel(int resolution, List<Vector2> textCoords)
    {
        List<Vector2> values = new List<Vector2>();
        foreach(Vector2 v in textCoords)
        {
            values.Add(new Vector2(v.x / resolution, 1 - v.y / resolution));
        }

        return values;
    }

    void AddAllFaces()
    {
        //Front
        Faces = new List<Vector3Int>();
        _texture_index_list = new List<Vector3Int>();
        normals = new List<Vector3>();

        Faces.Add(new Vector3Int(11, 12, 14));  normals.Add(new Vector3(0, 0, 1)); _texture_index_list.Add(new Vector3Int(11, 12, 14));
        Faces.Add(new Vector3Int(12, 13, 14)); normals.Add(new Vector3(0, 0, 1)); _texture_index_list.Add(new Vector3Int(12, 13, 14));
        Faces.Add(new Vector3Int(0, 9, 10)); normals.Add(new Vector3(0, 0, 1)); _texture_index_list.Add(new Vector3Int(0, 9, 10));
        Faces.Add(new Vector3Int(0, 10, 15)); normals.Add(new Vector3(0, 0, 1)); _texture_index_list.Add(new Vector3Int(0, 10, 15));
        Faces.Add(new Vector3Int(0, 8, 9)); normals.Add(new Vector3(0, 0, 1)); _texture_index_list.Add(new Vector3Int(0, 8, 9));
        Faces.Add(new Vector3Int(0, 1, 8)); normals.Add(new Vector3(0, 0, 1)); _texture_index_list.Add(new Vector3Int(0, 1, 8));
        Faces.Add(new Vector3Int(1, 5, 8)); normals.Add(new Vector3(0, 0, 1)); _texture_index_list.Add(new Vector3Int(1, 5, 8));
        Faces.Add(new Vector3Int(1, 2, 5)); normals.Add(new Vector3(0, 0, 1)); _texture_index_list.Add(new Vector3Int(1, 2, 5));
        Faces.Add(new Vector3Int(2, 3, 5)); normals.Add(new Vector3(0, 0, 1)); _texture_index_list.Add(new Vector3Int(2, 3, 5));
        Faces.Add(new Vector3Int(3, 4, 5)); normals.Add(new Vector3(0, 0, 1)); _texture_index_list.Add(new Vector3Int(3, 4, 5));

        //Back

        Faces.Add(new Vector3Int(30,29,28)); normals.Add(new Vector3(0, 0, -1)); _texture_index_list.Add(new Vector3Int(30, 29, 28));
        Faces.Add(new Vector3Int(27,30,28)); normals.Add(new Vector3(0, 0, -1)); _texture_index_list.Add(new Vector3Int(27, 30, 28));
        Faces.Add(new Vector3Int(16,31,26)); normals.Add(new Vector3(0, 0, -1)); _texture_index_list.Add(new Vector3Int(16, 31, 26));
        Faces.Add(new Vector3Int(16,26,25)); normals.Add(new Vector3(0, 0, -1)); _texture_index_list.Add(new Vector3Int(16, 26, 25));
        Faces.Add(new Vector3Int(16,25,17)); normals.Add(new Vector3(0, 0, -1)); _texture_index_list.Add(new Vector3Int(16, 25, 17));
        Faces.Add(new Vector3Int(17,25,24)); normals.Add(new Vector3(0, 0, -1)); _texture_index_list.Add(new Vector3Int(17, 25, 24));
        Faces.Add(new Vector3Int(17,21,18)); normals.Add(new Vector3(0, 0, -1)); _texture_index_list.Add(new Vector3Int(17, 21, 18));
        Faces.Add(new Vector3Int(17,24,21)); normals.Add(new Vector3(0, 0, -1)); _texture_index_list.Add(new Vector3Int(17, 24, 21));
        Faces.Add(new Vector3Int(18,20,19)); normals.Add(new Vector3(0, 0, -1)); _texture_index_list.Add(new Vector3Int(18, 20, 19));
        Faces.Add(new Vector3Int(18,21,20)); normals.Add(new Vector3(0, 0, -1)); _texture_index_list.Add(new Vector3Int(18, 21, 20));

        //Right

        Faces.Add(new Vector3Int(9,25,26)); normals.Add(new Vector3(1, 0, 0)); _texture_index_list.Add(new Vector3Int(9, 25, 26));
        Faces.Add(new Vector3Int(9,26,10)); normals.Add(new Vector3(1, 0, 0)); _texture_index_list.Add(new Vector3Int(9, 26, 10));
        Faces.Add(new Vector3Int(11,27,28)); normals.Add(new Vector3(1, 0, 0)); _texture_index_list.Add(new Vector3Int(11, 27, 28));
        Faces.Add(new Vector3Int(11,28,12)); normals.Add(new Vector3(1, 0, 0)); _texture_index_list.Add(new Vector3Int(11, 28, 12));

        //Left

        Faces.Add(new Vector3Int(0,15,16)); normals.Add(new Vector3(-1, 0, 0)); _texture_index_list.Add(new Vector3Int(0, 15, 16));
        Faces.Add(new Vector3Int(16,15,31)); normals.Add(new Vector3(-1, 0, 0)); _texture_index_list.Add(new Vector3Int(16, 15, 31));
        Faces.Add(new Vector3Int(13,30,14)); normals.Add(new Vector3(-1, 0, 0)); _texture_index_list.Add(new Vector3Int(13, 30, 14));
        Faces.Add(new Vector3Int(13,29,30)); normals.Add(new Vector3(-1, 0, 0)); _texture_index_list.Add(new Vector3Int(13, 29, 30));

        //Top

        Faces.Add(new Vector3Int(13,12,28)); normals.Add(new Vector3(0, 1, 0)); _texture_index_list.Add(new Vector3Int(13, 12, 28));
        Faces.Add(new Vector3Int(13,28,29)); normals.Add(new Vector3(0, 1, 0)); _texture_index_list.Add(new Vector3Int(13, 28, 29));
        Faces.Add(new Vector3Int(4,3,19)); normals.Add(new Vector3(-0.5f, 1, 0)); _texture_index_list.Add(new Vector3Int(4, 3, 19));
        Faces.Add(new Vector3Int(4,19,20)); normals.Add(new Vector3(-0.5f, 1, 0)); _texture_index_list.Add(new Vector3Int(4, 19, 20));
        Faces.Add(new Vector3Int(0,17,1)); normals.Add(new Vector3(-0.5f, 1, 0)); _texture_index_list.Add(new Vector3Int(0, 17, 1));
        Faces.Add(new Vector3Int(0,16,17)); normals.Add(new Vector3(-0.5f, 1, 0)); _texture_index_list.Add(new Vector3Int(0, 16, 17));
        Faces.Add(new Vector3Int(1,17,2)); normals.Add(new Vector3(0, 1, 0)); _texture_index_list.Add(new Vector3Int(1, 17, 2));
        Faces.Add(new Vector3Int(2,17,18)); normals.Add(new Vector3(0, 1, 0)); _texture_index_list.Add(new Vector3Int(2, 17, 18));
        Faces.Add(new Vector3Int(2,18,3)); normals.Add(new Vector3(0.5f, 1, 0)); _texture_index_list.Add(new Vector3Int(2, 18, 3));
        Faces.Add(new Vector3Int(3,18,19)); normals.Add(new Vector3(0.5f, 1, 0)); _texture_index_list.Add(new Vector3Int(3, 18, 19));

        //Bottom

        Faces.Add(new Vector3Int(15,14,30)); normals.Add(new Vector3(0, -1, 0)); _texture_index_list.Add(new Vector3Int(15, 14, 30));
        Faces.Add(new Vector3Int(11,26,27)); normals.Add(new Vector3(0, -1, 0)); _texture_index_list.Add(new Vector3Int(11, 26, 27));
        Faces.Add(new Vector3Int(11,10,26)); normals.Add(new Vector3(0, -1, 0)); _texture_index_list.Add(new Vector3Int(11, 10, 26));
        Faces.Add(new Vector3Int(4,20,5)); normals.Add(new Vector3(-0.5f, -1, 0)); _texture_index_list.Add(new Vector3Int(4, 20, 5));
        Faces.Add(new Vector3Int(20,21,5)); normals.Add(new Vector3(-0.5f, -1, 0)); _texture_index_list.Add(new Vector3Int(20, 21, 5));
        Faces.Add(new Vector3Int(5,21,8)); normals.Add(new Vector3(0, -1, 0)); _texture_index_list.Add(new Vector3Int(5, 21, 8));
        Faces.Add(new Vector3Int(21,24,8)); normals.Add(new Vector3(0, -1, 0)); _texture_index_list.Add(new Vector3Int(21, 24, 8));
        Faces.Add(new Vector3Int(8,25,9)); normals.Add(new Vector3(0.5f, -1, 0)); _texture_index_list.Add(new Vector3Int(8, 25, 9));
        Faces.Add(new Vector3Int(8,24,25)); normals.Add(new Vector3(0.5f, -1, 0)); _texture_index_list.Add(new Vector3Int(8, 24, 25));
    }

    void AddToTextures()
    {

        _texture_index_list = new List<Vector3Int>();


        _texture_index_list.Add(new Vector3Int(0, 0, 1));
        _texture_index_list.Add(new Vector3Int(-1, -1, 1));
        _texture_index_list.Add(new Vector3Int(-2, -1, 1));
        _texture_index_list.Add(new Vector3Int(-3, 0, 1));
        _texture_index_list.Add(new Vector3Int(-4, -1, 1));
        _texture_index_list.Add(new Vector3Int(-3, -2, 1));
        _texture_index_list.Add(new Vector3Int(-2, -2, 1));
        _texture_index_list.Add(new Vector3Int(-1, -2, 1));
        _texture_index_list.Add(new Vector3Int(0, -2, 1));
        _texture_index_list.Add(new Vector3Int(1, -1, 1));
        _texture_index_list.Add(new Vector3Int(1, 3, 1));
        _texture_index_list.Add(new Vector3Int(3, 3, 1));
        _texture_index_list.Add(new Vector3Int(3, 4, 1));
        _texture_index_list.Add(new Vector3Int(-2, 4, 1));
        _texture_index_list.Add(new Vector3Int(-2, 3, 1));
        _texture_index_list.Add(new Vector3Int(0, 3, 1));
        _texture_index_list.Add(new Vector3Int(0, 0, -1));
        _texture_index_list.Add(new Vector3Int(-1, -1, -1));
        _texture_index_list.Add(new Vector3Int(-2, -1, -1));
        _texture_index_list.Add(new Vector3Int(-3, 0, -1));
        _texture_index_list.Add(new Vector3Int(-4, -1, -1));
        _texture_index_list.Add(new Vector3Int(-3, -2, -1));
        _texture_index_list.Add(new Vector3Int(-2, -2, -1));
        _texture_index_list.Add(new Vector3Int(-1, -2, -1));
        _texture_index_list.Add(new Vector3Int(0, -2, -1));
        _texture_index_list.Add(new Vector3Int(1, -1, -1));
        _texture_index_list.Add(new Vector3Int(1, 3, -1));
        _texture_index_list.Add(new Vector3Int(3, 3, -1));
        _texture_index_list.Add(new Vector3Int(3, 4, -1));
        _texture_index_list.Add(new Vector3Int(-2, 4, -1));
        _texture_index_list.Add(new Vector3Int(-2, 3, -1));
        _texture_index_list.Add(new Vector3Int(0, 3, -1));
    }

}
