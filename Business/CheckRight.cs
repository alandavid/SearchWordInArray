using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CheckRight : IDirection
    {
        private IDirection next;

        public CheckRight(IDirection direccion)
        {
            this.next = direccion;
        }
        public int[,] checkDireccion(char[,] matriz, string word, int row, int col)
        {
            int[,] result = new int[word.Count(), 2];
            if (col + word.Count() <= matriz.GetUpperBound(0))
            {
                for (int offset = 0; offset < word.Count(); offset++)
                {
                    if (matriz[row, offset] != word.ElementAt(offset))
                    {
                        return next.checkDireccion(matriz, word, row, col);
                    }
                    ConvertToResponseExamen(ref result, row, col, offset);
                }
                return result;
            }
            else
            {
                return next.checkDireccion(matriz, word, row, col);
            }
        }



        public void ConvertToResponseExamen(ref int[,] array, int rowResponse, int colResponse, int offSetResponse)
        {
            array[offSetResponse, 0] = rowResponse + 1;
            array[offSetResponse, 1] = offSetResponse + 1;

        }
    }
}
