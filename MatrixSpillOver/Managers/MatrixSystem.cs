using MatrixSpillOver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixSpillOver.Managers
{
    public class MatrixSystem
    {
        private List<User> users = new List<User>();

        int[] PyramidLevelMaxBranchCount;
        int CurrentLevelEntries = 0;
        int NextMasterIndex = 0;
        int CurrentLevel = 1;

        public MatrixSystem()
        {
            PyramidLevelMaxBranchCount = new int[] { 1, 3, 9, 27, 81, 243, 729, 2187, 6561, 19683, 59049, 177147, 531441, 1594323, 4782969, 14348907 };

            GenesisUser();
        }

        private void GenesisUser()
        {
            users.Add(new User(0, -1));
        }

        public void AddNewUser()
        {

            var newmatrix = new User(CurrentLevel, NextMasterIndex);
            users.Add(newmatrix);

            CurrentLevelEntries++;
            IncreaseSubset(NextMasterIndex);

            if (CurrentLevelEntries == PyramidLevelMaxBranchCount[CurrentLevel])
            {
                CurrentLevel++;
                CurrentLevelEntries = 0;
            }


            NextMasterIndex = LowestIndexOnLevelWithLowestSubsets(CurrentLevel - 1);
        }

        private int LowestIndexOnLevelWithLowestSubsets(int level)
        {
            return users
                .Where(u => u.Level == level)
                .OrderBy(u => u.subsets)
                .ThenBy(u => u.MatrixID)
                .FirstOrDefault().MatrixID;
        }

        private void IncreaseSubset(int userid)
        {
            users.Where(it => it.MatrixID == userid).FirstOrDefault().subsets++;
            users.Where(it => it.MatrixID == userid).FirstOrDefault().Totalsubsets++;

            int nextaboveid = users.Where(it => it.MatrixID == userid).FirstOrDefault().Under;
            while (true)
            {
                var nextuser = users.Where(it => it.MatrixID == nextaboveid).FirstOrDefault();
                if (nextuser != null)
                {
                    nextuser.Totalsubsets++;
                    nextaboveid = nextuser.Under;
                }
                else { break; }
            }
        }

        public void PrintMatrix()
        {
            foreach (var user in users)
            {
                Console.WriteLine($"User ID: {user.MatrixID}, Level: {user.Level}, Under: {user.Under}, LocalSubset: {user.subsets}, Totalsubsets: {user.Totalsubsets}");
            }
        }
    }
}
