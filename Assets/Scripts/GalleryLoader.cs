using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class GalleryLoader : MonoBehaviour
{
    public RawImage rawImage;

    /// <summary>
    /// the Method to assign UI Button
    /// , It work Load Image frome GalleryImage
    /// </summary>
    public void GetImageFromGallery()
    {

        var dataBin = NativeGallery.GetImageFromGallery((file) =>
        //callback
        {
            //selected File's Info DataContainer
            FileInfo seleced = new FileInfo(file);

            //Check the File Volume, if It is over 50MB, Cancel Load Image
            if(seleced.Length > 500000000)
            {
                return;
            }

            //Loading
            //Check the file string is not null or empty
            if(!string.IsNullOrEmpty(file))
            {
                StartCoroutine(Co_LoadImage(file));
            }


        }
        );
    }


    IEnumerator Co_LoadImage(string path)
    {
        yield return null;

        byte[] fileBinData = File.ReadAllBytes(path);
        //ex) test.txt => test (., txt remove) 
        string fileName = Path.GetFileName(path).Split('.')[0];
        //if Success Load File, It will be remember file within restart
        string savePath = Application.persistentDataPath + "/Image";

        //Exception : if Save Directory doesn't exist, Create Save Folder Directory
        if(!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }

        //Save the loaded Image
        File.WriteAllBytes(savePath + fileName + ".png", fileBinData);


        var temp = File.ReadAllBytes(savePath + fileName + ".png");
         

        //Cast byte[] to texture, and assign it texture
        if(rawImage != null)
        {
            Texture2D texture = new Texture2D(0, 0);
            texture.LoadImage(temp);
            rawImage.texture = texture;
        }

    }
}
