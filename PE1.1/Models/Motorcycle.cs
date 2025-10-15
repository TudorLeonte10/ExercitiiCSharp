using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE1._1.Models
{
    public class Motorcycle : Vehicle, IDriveable
    {
        public bool HasSidecar { get; set; }

        public void Drive()
        {
            Console.WriteLine("We drivin the motorcycle");
        }

        public override void StartEngine()
        {
            Console.WriteLine("The motorcycle engine starts with a button");
        }

        public override string ToString()
        {
            return base.ToString() + HasSidecar;
        }
    }
}
