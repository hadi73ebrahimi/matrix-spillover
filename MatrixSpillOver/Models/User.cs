using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixSpillOver.Models
{
    public class User
    {
        private static int CurrentId = 0;
        public int Level { get; set; }
        public int Under { get; set; }
        public int MatrixID { get; set; }
        public int subsets { get; set; }
        public int Totalsubsets { get; set; }

        public User(int level, int under)
        {
            Level = level;
            Under = under;
            MatrixID = CurrentId;
            CurrentId++;
        }
    }
}
