using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominium_Manager
{
    public class Photo
    {
        public Photo(string FileName, long size, string path)
        {
            this.FileName = FileName;
            this.size = size;
            this.path = path;
        }

        public string FileName { get; set; }
        public long size { get; set; }
        public string path { get; set; }

        public string sizeKB
        {
            get
            {
                return SizeSuffix(3);
            }
        }

        private static readonly string[] SizeSuffixes =
                  { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        private string SizeSuffix(int decimalPlaces = 1)
        {
            if (size < 0) { return "-" + SizeSuffix(-(int)size); }

            int i = 0;
            decimal dValue = (decimal)size;
            while (Math.Round(dValue, decimalPlaces) >= 10000)
            {
                dValue /= 1024;
                i++;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}", dValue/10, SizeSuffixes[i]);
        }
        
        public string save(string type, int Id)
        {
            
            string ext = System.IO.Path.GetExtension(this.path);
            ImageFormat format;
            switch (ext)
            {
                case ".jpg":
                    format = ImageFormat.Jpeg;
                    break;
                case ".bmp":
                    format = ImageFormat.Bmp;
                    break;
                case ".gif":
                    format = ImageFormat.Gif;
                    break;
                case ".jpeg":
                    format = ImageFormat.Jpeg;
                    break;
                case ".tiff":
                    format = ImageFormat.Tiff;
                    break;
                case ".wmf":
                    format = ImageFormat.Wmf;
                    break;
                case ".png":
                    format = ImageFormat.Png;
                    break;
                default:
                    return "";
            }

            Image im = Image.FromFile(this.path);

            // Create Directories
            string path = ConfigurationManager.AppSettings["ImagePath"] + "/"+ type +"_" + Id + "/" + FileName;

            if (File.Exists(path))
            {
                return path;
            }

            new FileInfo(path).Directory.Create();
            
            im.Save(path, format);

            return path;
        }
        
        /*
        public static void delete(int PredioID)
        {
            
            string[] fileEntries = Directory.GetFiles(ConfigurationManager.AppSettings["ImagePath"] + "/Predio_" + PredioID);
            foreach (string fileName in fileEntries)
            {
                if (File.Exists(fileName))
                     File.Delete(fileName);
            }
            
        }
    */

    }
}
