using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexeme.Dal
{
    public class FragmentDal
    {
        private string connectionString = System.Configuration.ConfigurationSettings.AppSettings["DBConnection"].Replace("\\\\", "\\");

        public FragmentDal() { }

        public Fragment GetFragmentByWordId(int wordId)
        {


            return new Fragment();
        }
    }
}
