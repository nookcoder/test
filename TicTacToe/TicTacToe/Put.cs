using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Computer
{
    public class Point
    {
        public Point(char[] _array)
        {
            this.array = _array; 
        }

        public char[] array;
        public int point;
        public int i = 0;
        public int j = 0;
        public bool isGood = true;

        public int PutPoint()
        {
            while (isGood)
            {

                // 첫 수에 둬야하는 수

                // 상대가 코너에 둘 때 
                if (array[0] == 'X' || array[2] == 'X' ||
                     array[6] == 'X' || array[8] == 'X')
                {
                    if (array[4] != 'O')
                    {
                        point = 5;
                    }
                }

                // 상대가 변에 둘 때 
                else if (array[1] == 'X' || array[3] == 'X' ||
                        array[5] == 'X' || array[7] == 'X')
                {
                    if (array[4] != 'O')
                    {
                        point = 5;
                    }
                }

                else
                {
                    point = 0;
                }


                // 상대가 2목일 때 두는 수

                // 가로열 확인
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
                                isGood = false; 
                            }

                            else if (array[j + 1] != 'O')
                            {
                                point = j + 1;
                                isGood = false;
                            }

                            else
                            {
                                point = j + 2;
                                isGood = false;
                            }

                        }

                    }
                }

                // 세로열 확인
                for (i = 0; i < 3; i++)
                {
                    if ((array[i] == 'X' && array[i + 3] == 'X') ||
                           (array[i] == 'X' && array[i + 6] == 'X') ||
                           (array[i + 3] == 'X' && array[i + 6] == 'X'))
                    {
                        if (array[i] != 'O')
                        {
                            point = i;
                            isGood = false; 
                        }

                        else if (array[i + 3] != 'O')
                        {
                            point = i + 3;
                            isGood = false;
                        }

                        else
                        {
                            point = i + 6;
                            isGood = false;
                        }

                    }
                }

                // 대각선 확인
                if ((array[0] == 'X' && array[4] == 'X') ||
                       (array[4] == 'X' && array[8] == 'X') ||
                       (array[0] == 'X' && array[8] == 'X'))
                {
                    if (array[0] != 'O')
                    {
                        point = 1;
                        isGood = false; 
                    }

                    else if (array[4] != 'O')
                    {
                        point = 5;
                        isGood = false;
                    }

                    else
                    {
                        point = 9;
                        isGood = false;
                    }
                }

                else if ((array[2] == 'X' && array[4] == 'X') ||
                       (array[4] == 'X' && array[6] == 'X') ||
                       (array[0] == 'X' && array[6] == 'X'))
                {
                    if (array[2] != 'O')
                    {
                        point = 3;
                        isGood = false; 
                    }

                    else if (array[4] != 'O')
                    {
                        point = 5;
                        isGood = false;
                    }

                    else
                    {
                        point = 7;
                        isGood = false;
                    }
                }



                // 컴퓨터가 2일 때 두는 수

                // 가로열 확인
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
                                isGood = false;
                            }

                            else if (array[j + 1] != 'O')
                            {
                                point = j + 1;
                                isGood = false;
                            }

                            else
                            {
                                point = j + 2;
                                isGood = false;
                            }

                        }
                    }
                }

                // 세로열 확인
                for (i = 0; i < 3; i++)
                {
                    if ((array[i] == 'O' && array[i + 3] == 'O') ||
                           (array[i] == 'O' && array[i + 6] == 'O') ||
                           (array[i + 3] == 'O' && array[i + 6] == 'O'))
                    {
                        if (array[i] != 'O')
                        {
                            point = i;
                            isGood = false; 
                        }

                        else if (array[i + 3] != 'O')
                        {
                            point = i + 3;
                            isGood = false;
                        }

                        else
                        {
                            point = i + 6;
                            isGood = false;
                        }

                    }
                }

                // 대각선 확인
                if ((array[0] == 'O' && array[4] == 'O') ||
                       (array[4] == 'O' && array[8] == 'O') ||
                       (array[0] == 'O' && array[8] == 'O'))
                {
                    if (array[0] != 'O')
                    {
                        point = 1;
                        isGood = false; 
                    }

                    else if (array[4] != 'O')
                    {
                        point = 5;
                        isGood = false;
                    }

                    else
                    {
                        point = 9;
                        isGood = false;
                    }
                }

                else if ((array[2] == 'O' && array[4] == 'O') ||
                       (array[4] == 'O' && array[6] == 'O') ||
                       (array[0] == 'O' && array[6] == 'O'))
                {
                    if (array[2] != 'O')
                    {
                        point = 3;
                        isGood = false; 
                    }

                    else if (array[4] != 'O')
                    {
                        point = 5;
                        isGood = false;
                    }

                    else
                    {
                        point = 7;
                        isGood = false;
                    }
                }

            }
            return point;
        }
    }
}
