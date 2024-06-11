using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial_2_TP4_Pascual_Silvestri
{
    public class Archivo
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }

        public Archivo(string fileName, string filePath)
        {
            FileName = fileName;
            FilePath = filePath;
        }
    }
}