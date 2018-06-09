using Business.Interfaces;
using System;
using System.Linq;

namespace Business.Managers
{
    public class ManagerSearch : IManagerSearch
    {
        private IAuditManager _Manager;
        private IDirection checkUp;
        public ManagerSearch()
        {
            IDirection end = new EndPattern();
            IDirection checkDiagonallyInverse = new CheckDiagonallyInverse(end);
            IDirection checkDiagonally = new CheckDiagonally(checkDiagonallyInverse);
            IDirection checkLeft = new CheckLeft(checkDiagonally);
            IDirection checkRight = new CheckRight(checkLeft);
            IDirection checkDown = new CheckDown(checkRight);
            checkUp = new CheckUp(checkDown);
            _Manager = new AuditManager();
        }

        public string findWord(char[,] matriz, String word)
        {
            int[,] result = null;
            long countRow = matriz.GetLongLength(0);
            long countCol = matriz.GetUpperBound(0);
            for (int row = 0; row < countRow; row++)
            {
                for (int col = 0; col < countCol; col++)
                {
                    var letter = matriz[row, col].ToString();
                    if (letter.Equals(word.ElementAt(0).ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        result = findWordArray(matriz, word, row, col);
                        if (result != null)
                        {
                            goto end_of_loop;

                        }
                    }
                }
            }
            end_of_loop: { };
            var response = BuildResponse(result);
            _Manager.SaveAudit(BuildResponse(result), "Usuario de la App", word);
            return response;
        }

        private int[,] findWordArray(char[,] matriz, String word, int row, int col)
        {
            return checkUp.CheckDireccion(matriz, word, row, col);
        }

        private string BuildResponse(int[,] matriz)
        {
            string aux = string.Empty;
            if (matriz == null) return "Palabra no Encontrada";
            long countRow = matriz.GetLongLength(0);

            for (int row = 0; row < countRow; row++)
            {
                aux += "[";
                for (int col = 0; col < 2; col++)
                {
                    aux += matriz[row, col] + ",";
                }
                aux.Remove(aux.Count() - 1);
                aux += "]";
            }

            return aux;

        }


    }
}

