using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    // 상대가 2목이면 막는다.
    class Defense
    {
        public char[] array;
        public int i = 0;
        public int j = 0;
        public int point;

        public Defense(char[] _array)
        {
            for (i = 0; i < 9; i++)
            {
                this.array[i] = _array[i];
            }
        }


        // 가로 확인.
        public int Row()
        {
            for (i = 0; i < 3; i++)
            {
                for (j = 3 * i; j < 3 * i + 3; j++)
                {
                    if ((array[j] == 'X' && array[j + 1] == 'X') ||
                       (array[j] == 'X' && array[j + 2] == 'X') ||
                       (array[j + 1] == 'X' && array[j + 2] == 'X'))
                    {
                        if (array[j] != 'O')
                        {
                            point = j;
                        }

                        else if (array[j + 1] != 'O')
                        {
                            point = j + 1;
                        }

                        else
                        {
                            point = j + 2;
                        }

                    }

                }
            }
            return point;
        }


        // 세로 확인.
        public int Col()
        {
            for (i = 0; i < 3; i++)
            {
                if ((array[i] == 'X' && array[i + 3] == 'X') ||
                       (array[i] == 'X' && array[i + 6] == 'X') ||
                       (array[i + 3] == 'X' && array[i + 6] == 'X'))
                {
                    if (array[i] != 'O')
                    {
                        point = i;
                    }

                    else if (array[i + 3] != 'O')
                    {
                        point = i + 3;
                    }

                    else
                    {
                        point = i + 6;
                    }

                }
            }

            return point;
        }

        public int TopLeftToBottonRight()
        {
            if ((array[0] == 'X' && array[4] == 'X') ||
                       (array[4] == 'X' && array[8] == 'X') ||
                       (array[0] == 'X' && array[8] == 'X'))
            {
                if (array[0] != 'O')
                {
                    point = 1;
                }

                else if (array[4] != 'O')
                {
                    point = 5;
                }

                else
                {
                    point = 9;
                }
            }

            return point;
        }
        public int TopRightToBottonLeft()
        {
            if ((array[2] == 'X' && array[4] == 'X') ||
                       (array[4] == 'X' && array[6] == 'X') ||
                       (array[0] == 'X' && array[6] == 'X'))
            {
                if (array[2] != 'O')
                {
                    point = 3;
                }

                else if (array[4] != 'O')
                {
                    point = 5;
                }

                else
                {
                    point = 7;
                }
            }

            return point;
        }
    }

}

