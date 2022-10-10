using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Pipeline : MonoBehaviour
{

    List<Vector3> verts;
    JModel MyModel;

    // Start is called before the first frame update
    void Start()
    {
        string path = "Assets/Output.txt";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);

        MyModel = new JModel();
        MyModel.CreateUnityGameObject();


        verts = MyModel.Verticies;   


        print_verts(verts,writer);

        Vector3 axis = new Vector3(17, -4, -4);
        axis.Normalize();
        // Quaternion.AngleAxis(90, Vector3.up)
        Matrix4x4 rotation_matrix =  Matrix4x4.TRS(Vector3.zero, Quaternion.AngleAxis(32, axis), Vector3.one) ;


        print_matrix(rotation_matrix, writer);


        List<Vector3> image_after_rotation = get_image(verts, rotation_matrix);

        print_verts(image_after_rotation, writer);

        writer.Close();
    }

    private List<Vector3> get_image(List<Vector3> list_verts, Matrix4x4 transform_matrix)
    {
        List<Vector3> hold = new List<Vector3>();

        foreach (Vector3 v in list_verts)
        {
            hold.Add(transform_matrix * v);
        }
        return hold;

    }

    private void print_matrix(Matrix4x4 matrix, StreamWriter writer)
    {


        for (int i = 0; i < 4; i++)
        {
            Vector4 row = matrix.GetRow(i);
            writer.WriteLine(row.x.ToString() + "   ,   " + row.y.ToString() + "   ,   " + row.z.ToString() + "   ,   " + row.w.ToString());
        }


    }

    private void print_verts(List<Vector3> v_list, StreamWriter writer)
    {

        foreach (Vector3 v in v_list)
        {
            writer.WriteLine(v.x.ToString() + "   ,   " + v.y.ToString() + "   ,   " + v.z.ToString());

        }
  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
