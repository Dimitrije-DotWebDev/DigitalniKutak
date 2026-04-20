using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DigitalniKutak.Model
{
    public class ENUMs
    {
        public enum FileType
        {
            Image,
            Document
        }
        public enum UserType
        {
            Admin,
            Professor,
            Student
        }
    }
}
