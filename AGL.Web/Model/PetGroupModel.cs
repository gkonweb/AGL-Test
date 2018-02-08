using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AGL.Entity;

namespace AGL.Web.Model
{
    public class PetGroupModel
    {
        public string Gender { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
