using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Constants
{
    public static class Messages
    {
        public static string EntityNameExists = "Entity name is already exists. Cannot be duplicate!";
        public static string EntityNotExists = "Entity is not exists. Cannot be null when requested!";
        public static string EmailExists = "Given email is already exists!";

    }
}
