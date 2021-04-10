using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Win
    {
        char[] array;
        public int i = 0;
        public int j = 0;
        public int point;
        public Win(char[] _array)
        {
            for (i = 0; i < 9; i++)
            {
                this.array[i] = _array[i];
            }
        }

        public int Row()
        {
            for (i = 0; i < 3; i++)
            {
                for (j = 3 * i; j < 3 * i + 3; j++)
                {
                    if ((array[j] == 'O' && array[j + 1] == 'O') ||
                       (array[j] == 'O' && array[j + 2] == 'O') ||
                       (array[j + 1] == 'O' && array[j + 2] == 'O'))
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

        public int Col()
        {
            for (i = 0; i < 3; i++)
            {
                if ((array[i] == 'O' && array[i + 3] == 'O') ||
                       (array[i] == 'O' && array[i + 6] == 'O') ||
                       (array[i + 3] == 'O' && array[i + 6] == 'O'))
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
            if ((array[0] == 'O' && array[4] == 'O') ||
                       (array[4] == 'O' && array[8] == 'O') ||
                       (array[0] == 'O' && array[9] == 'O'))
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
            if ((array[2] == 'O' && array[4] == 'O') ||
                       (array[4] == 'O' && array[6] == 'O') ||
                       (array[0] == 'O' && array[6] == 'O'))
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
