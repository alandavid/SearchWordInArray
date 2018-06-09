using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CheckDown : IDirection
    {
        private IDirection next;

        public CheckDown(IDirection direccion)
        {
            this.next = direccion;
        }
        public int[,] CheckDireccion(char[,] matriz, string word, int row, int col)
        {
            int[,] result = new int[word.Count(), 2];
            if (row + word.Count() <= matriz.GetLongLength(0))
            {
                for (int offset = 0; offset < word.Count(); offset++)
                {
                    if (matriz[offset, col] != word.ElementAt(offset))
                    {
                        return next.CheckDireccion(matriz, word, row, col);
                    }
                    ConvertToResponseExamen(ref result, row, col, offset);
                }
                return result;
            }
            else
            {
                return next.CheckDireccion(matriz, word, row, col);
            }
        }



        public void ConvertToResponseExamen(ref int[,] array, int rowResponse, int colResponse, int offSetResponse)
        {
            array[offSetResponse, 0] = offSetResponse + 1;
            array[offSetResponse, 1] = colResponse + 1;

        }
    }
}
