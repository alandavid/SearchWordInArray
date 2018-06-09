using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IDirection
    {
         int[,] checkDireccion(char[,] matriz, String word, int row, int col);
        void ConvertToResponseExamen(ref int[,] array, int rowResponse, int colResponse, int offSetResponse);
      
    }
}
