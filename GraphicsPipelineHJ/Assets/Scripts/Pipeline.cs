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
        //print_All_Verts_Matrix();
        //print_Scale_Matrix_Image();
        //print_Translation_Matrix_Image();
        print_Viewing_Matrix_Image();
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

    private void print_All_Verts_Matrix()
    {
        string path = "Assets/Output.txt";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);

        MyModel = new JModel();
        MyModel.CreateUnityGameObject();


        verts = MyModel.Verticies;


        print_verts(verts, writer);

        Vector3 axis = new Vector3(17, -4, -4);
        axis.Normalize();
        // Quaternion.AngleAxis(90, Vector3.up)
        Matrix4x4 rotation_matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.AngleAxis(32, axis), Vector3.one);


        print_matrix(rotation_matrix, writer);


        List<Vector3> image_after_rotation = get_image(verts, rotation_matrix);

        print_verts(image_after_rotation, writer);

        writer.Close();
    }

    private void print_Scale_Matrix_Image()
    {
        string path = "Assets/Scale.txt";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);

        MyModel = new JModel();
        MyModel.CreateUnityGameObject();


        verts = MyModel.Verticies;


        print_verts(verts, writer);

        Vector3 axis = new Vector3(17, -4, -4);
        axis.Normalize();

        Vector3 GivenScale = new Vector3(5, 4, 4);

        // Quaternion.AngleAxis(90, Vector3.up)
        Matrix4x4 scale_matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.AngleAxis(32, axis), GivenScale);


        print_matrix(scale_matrix, writer);


        List<Vector3> image_after_scale = get_image(verts, scale_matrix);

        print_verts(image_after_scale, writer);

        writer.Close();
    }

    private void print_Translation_Matrix_Image()
    {
        string path = "Assets/Translation.txt";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);

        MyModel = new JModel();
        MyModel.CreateUnityGameObject();


        verts = MyModel.Verticies;


        print_verts(verts, writer);

        Vector3 axis = new Vector3(17, -4, -4);
        axis.Normalize();

        Vector3 GivenTranslation = new Vector3(-3,3,-3);

        // Quaternion.AngleAxis(90, Vector3.up)
        Matrix4x4 translation_matrix = Matrix4x4.TRS(GivenTranslation, Quaternion.AngleAxis(32, axis), Vector3.one);


        print_matrix(translation_matrix, writer);


        List<Vector3> image_after_translation = get_image(verts, translation_matrix);

        print_verts(image_after_translation, writer);

        writer.Close();
    }

    private void print_Viewing_Matrix_Image()
    {
        string path = "Assets/Viewing.txt";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);

        MyModel = new JModel();
        MyModel.CreateUnityGameObject();


        verts = MyModel.Verticies;


        Vector3 camPos = new Vector3(19,-1,46);
        Vector3 camLookAt = new Vector3(-4,17,-4);
        Vector3 camUp = new Vector3(-3,-4,17);

        camLookAt.Normalize();
        camUp.Normalize();

        Matrix4x4 viewing_matrix = Matrix4x4.LookAt(camPos, camLookAt, camUp);


        print_matrix(viewing_matrix, writer);


        List<Vector3> image_after_viewing = get_image(verts, viewing_matrix);

        print_verts(image_after_viewing, writer);

        writer.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
