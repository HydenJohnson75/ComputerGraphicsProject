using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Pipeline : MonoBehaviour
{
    Texture2D newTexture;
    List<Vector3> verts;
    JModel MyModel;
    Renderer ourScreen;

    // Start is called before the first frame update
    void Start()
    {
        //Rotation
        ourScreen = FindObjectOfType<Renderer>();
        MyModel = new JModel();
       // MyModel.CreateUnityGameObject();

/*        string path = "Assets/Output.txt";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);

        


        verts = MyModel.Verticies;


        print_verts(verts, writer);

        // Quaternion.AngleAxis(90, Vector3.up)
        Matrix4x4 rotation_matrix = create_RotationMatrix();

        print_matrix(rotation_matrix, writer);

        List<Vector3> image_after_rotation = get_image(verts, rotation_matrix);

        print_verts(image_after_rotation, writer);

        writer.Close();


        //Scale


        string path2 = "Assets/Scale.txt";
        //Write some text to the test.txt file
        StreamWriter writer2 = new StreamWriter(path2, true);

        Matrix4x4 scale_matrix = create_ScaleMatrix();


        print_matrix(scale_matrix, writer2);


        List<Vector3> image_after_scale = get_image(image_after_rotation, scale_matrix);

        print_verts(image_after_scale, writer2);

        writer2.Close();


        //Translation


        string path3 = "Assets/Translation.txt";
        //Write some text to the test.txt file
        StreamWriter writer3 = new StreamWriter(path3, true);


        // Quaternion.AngleAxis(90, Vector3.up)
        Matrix4x4 translation_matrix = create_TranslationMatrix();


        print_matrix(translation_matrix, writer3);


        List<Vector3> image_after_translation = get_image(image_after_scale, translation_matrix);

        print_verts(image_after_translation, writer3);

        writer3.Close();


        string path4 = "Assets/SingleMatrix.txt";
        //Write some text to the test.txt file
        StreamWriter writer4 = new StreamWriter(path4, true);


        Matrix4x4 rotationMatrix = create_RotationMatrix();
        Matrix4x4 scaleMatrix = create_ScaleMatrix();
        Matrix4x4 translationMatrix = create_TranslationMatrix();

        Matrix4x4 single_matrix = translationMatrix * scaleMatrix * rotationMatrix;


        print_matrix(single_matrix, writer4);


        List<Vector3> image_after_single = get_image(verts, single_matrix);

        print_verts(image_after_single, writer4);

        writer4.Close();


        string path5 = "Assets/Viewing.txt";
        //Write some text to the test.txt file
        StreamWriter writer5 = new StreamWriter(path5, true);


        Vector3 camPos = new Vector3(19, -1, 46);
        Vector3 camLookAt = new Vector3(-4, 17, -4);
        Vector3 camUp = new Vector3(-3, -4, 17);

        camLookAt.Normalize();
        camUp.Normalize();

        Matrix4x4 viewing_matrix = Matrix4x4.LookAt(camPos, camLookAt, Vector3.up);


        print_matrix(viewing_matrix, writer5);


        List<Vector3> image_after_viewing = get_image(image_after_single, viewing_matrix);

        print_verts(image_after_viewing, writer5);

        writer5.Close();


        string path6 = "Assets/projection.txt";
        //Write some text to the test.txt file
        StreamWriter writer6 = new StreamWriter(path6, true);

        Matrix4x4 projection_matrix = Matrix4x4.Perspective(90,1,1,1000);


        print_matrix(projection_matrix, writer6);


        List<Vector3> image_after_Projection = get_image(image_after_viewing, projection_matrix);

        print_verts(image_after_Projection, writer6);

        writer6.Close();


        string path7 = "Assets/AfterEverything.txt";
        //Write some text to the test.txt file
        StreamWriter writer7 = new StreamWriter(path7, true);

        Matrix4x4 afterEverything_matrix = projection_matrix* viewing_matrix * single_matrix;


        print_matrix(afterEverything_matrix, writer7);


        List<Vector3> image_after_Everything = get_image(image_after_viewing, projection_matrix);

        print_verts(image_after_Everything, writer7);

        writer7.Close();


        string path8 = "Assets/2D.txt";
        //Write some text to the test.txt file
        StreamWriter writer8 = new StreamWriter(path8, true);

        List<Vector2> projectionByHand = new List<Vector2>();
        foreach(Vector3 MyVector in image_after_viewing)
        {
            projectionByHand.Add(new Vector2(MyVector.x / MyVector.z, MyVector.y / MyVector.z));
        }

        print_2D(projectionByHand, writer8);

        writer8.Close();*/


        //print_All_Verts_Matrix();
        //print_Scale_Matrix_Image();
        //print_Translation_Matrix_Image();
        //print_Viewing_Matrix_Image();
        //print_Single_Matrix_Of_Transformation();

        Vector2 startPoint =new Vector2(0.5f, -0.1f);

        Vector2 endPoint = new Vector2(1,-1);

        Outcode start = new Outcode(startPoint);

        Outcode end = new Outcode(endPoint);

        
           


        //Line_Clip();

    }

    private bool Line_Clip(ref Vector2 Start, ref Vector2 End)
    {
        Outcode startOutcode = new Outcode(Start);
        Outcode endOutcode = new Outcode(End);

        Outcode inScrean = new Outcode();

        if((startOutcode + endOutcode) == inScrean)
        {
            return true;
        }

        if((startOutcode * endOutcode) != inScrean)
        {
            return false;
        }

        if(startOutcode == inScrean)
        {
            return Line_Clip(ref End, ref Start);
        }

        List<Vector2> StartIntersections = intersectEdge(Start, End, startOutcode);


        foreach (Vector2 vp in StartIntersections)
        {
            Outcode TempOut = new Outcode(vp);
            if (TempOut == new Outcode())
            {
                Start = vp;
                return Line_Clip(ref Start, ref End);
            }
        }

        return false;
    }

    private List<Vector3> get_image(List<Vector3> list_verts, Matrix4x4 transform_matrix)
    {
        List<Vector3> hold = new List<Vector3>();

        foreach (Vector3 v in list_verts)
        {
            Vector4 V2 = new Vector4(v.x, v.y, v.z, 1);

            hold.Add(transform_matrix * V2);
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

        // Quaternion.AngleAxis(90, Vector3.up)
        Matrix4x4 rotation_matrix = create_RotationMatrix();

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

        Matrix4x4 scale_matrix = create_ScaleMatrix();


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

        // Quaternion.AngleAxis(90, Vector3.up)
        Matrix4x4 translation_matrix = create_TranslationMatrix();


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

    private Matrix4x4 create_RotationMatrix()
    {
        Vector3 axis = new Vector3(17, -4, -4);
        axis.Normalize();
        // Quaternion.AngleAxis(90, Vector3.up)
        Matrix4x4 rotation_matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.AngleAxis(32, axis), Vector3.one);

        return rotation_matrix;
    }

    private Matrix4x4 create_ScaleMatrix()
    {
        Vector3 GivenScale = new Vector3(5, 4, 4);

        // Quaternion.AngleAxis(90, Vector3.up)
        Matrix4x4 scale_matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, GivenScale);

        return scale_matrix;
    }

    private Matrix4x4 create_TranslationMatrix()
    {
        Vector3 GivenTranslation = new Vector3(-3, 3, -3);

        // Quaternion.AngleAxis(90, Vector3.up)
        Matrix4x4 translation_matrix = Matrix4x4.TRS(GivenTranslation, Quaternion.identity, Vector3.one);

        return translation_matrix;
    }

    private void print_Single_Matrix_Of_Transformation()
    {
        string path = "Assets/SingleMatrix.txt";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);

        MyModel = new JModel();
        MyModel.CreateUnityGameObject();


        verts = MyModel.Verticies;

        Matrix4x4 rotationMatrix = create_RotationMatrix();
        Matrix4x4 scaleMatrix = create_ScaleMatrix();
        Matrix4x4 translationMatrix = create_TranslationMatrix();

        Matrix4x4 single_matrix = translationMatrix * scaleMatrix * rotationMatrix;


        print_matrix(single_matrix, writer);


        List<Vector3> image_after_single = get_image(verts, single_matrix);

        print_verts(image_after_single, writer);

        writer.Close();
    }


    private void print_2D(List<Vector2> v_list, StreamWriter writer)
    {
        foreach (Vector2 v in v_list)
        {
            writer.WriteLine(v.x.ToString() + "   ,   " + v.y.ToString());

        }
    }

    List<Vector2> intersectEdge(Vector2 start, Vector2 end, Outcode pointOutCode)
    {
        float m = (end.y - start.y) / (end.x - start.x);
        List<Vector2> Intersections = new List<Vector2>();


        if(pointOutCode.up)
        {
            Intersections.Add(new Vector2(start.x + (1 / m) * (1 - start.y), 1));
        }

        if (pointOutCode.down)
        {
            Intersections.Add(new Vector2(start.x + (1 / m) * (-1 - start.y), -1));

        }

        if (pointOutCode.left)
        {
            Intersections.Add(new Vector2(-1, start.y + m*(-1 -start.x)));
        }

        if (pointOutCode.right)
        {
            Intersections.Add(new Vector2(1, start.y + m * (1 - start.x)));
        }

        return Intersections;

    }

    List<Vector2Int> bresh(Vector2Int start, Vector2Int end)
    {
        List<Vector2Int> outputList = new List<Vector2Int>();

        int dx = end.x - start.x;

        if (dx < 0) return bresh(end, start);

        int dy = end.y - start.y;

        if (dy < 0)
            return NegY(bresh(NegY(start), NegY(end)));

        int two_dy = dy * 2;  // positive

        if (dy > dx)
            return SwapXY(bresh(SwapXY(start), SwapXY(end)));


        int twody_dx = 2 * (dy - dx);  // negative

        int p = 2 * dy - dx;

        int y = start.y;

        for (int x = start.x; x<= end.x; x++)
        {
            outputList.Add(new Vector2Int(x, y));

            if (p < 0)
                p += two_dy;
            else
            {
                y ++;
                p += twody_dx;

            }
        }

        return outputList;




    }

    private List<Vector2Int> SwapXY(List<Vector2Int> pointList)
    {
        List<Vector2Int> outputList = new List<Vector2Int>();

        foreach (Vector2Int point in pointList)
            outputList.Add(SwapXY(point));

        return outputList;
    }

    private Vector2Int SwapXY(Vector2Int point)
    {
        return new Vector2Int(point.y, point.x);
    }

    private List<Vector2Int> NegY(List<Vector2Int> pointList)
    {
        List<Vector2Int> outputList = new List<Vector2Int>();

        foreach (Vector2Int point in pointList)
            outputList.Add(NegY(point));

        return outputList;

    }

    private Vector2Int NegY(Vector2Int point)
    {
        return new Vector2Int(point.x, -point.y);
    }

    // Update is called once per frame
    void Update()
    {   if (newTexture)
            Destroy(newTexture);


        newTexture = new Texture2D(512, 512);
       
        ourScreen.material.mainTexture = newTexture;

       List<Vector3> verts  =  MyModel.Verticies;
        Matrix4x4 translate = Matrix4x4.TRS(new Vector3(0, 0, 100), Quaternion.identity, Vector3.one);
        Matrix4x4 viewing_matrix = Matrix4x4.LookAt(Vector3.zero,  new Vector3(0, 0, 10), Vector3.up);
        Matrix4x4 projection_matrix = Matrix4x4.Perspective(90, 1, 1, 1000);
        Matrix4x4 superMatrix = projection_matrix *  viewing_matrix * translate ;
        verts = get_image(verts, superMatrix);


        foreach (Vector3Int faceVerts in MyModel.Faces)
        {
            drawline(verts[faceVerts.x], verts[faceVerts.y]);
            drawline(verts[faceVerts.y], verts[faceVerts.z]);
            drawline(verts[faceVerts.z], verts[faceVerts.x]);


        }


        newTexture.Apply();






        //

    }

    private void drawline(Vector3 start, Vector3 end)
    {

        Vector2 startR = new Vector2(start.x/start.z, start.y/start.z), endR = new Vector2(end.x/end.z, end.y/end.z);
        if (Line_Clip(ref startR, ref endR))
        {
            List<Vector2Int> pixels = bresh(Convert(start), Convert(end));
            foreach (Vector2Int pixel in pixels)
                newTexture.SetPixel(pixel.x, pixel.y, Color.black);

     
        }
    }

    private Vector2Int Convert(Vector2 point)
    {
        return new Vector2Int((int)(511 * (point.x + 1) / 2), (int)(511 * (point.y + 1) / 2));
    }
}
