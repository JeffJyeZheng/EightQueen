const int ChessCol = 5;

int ResultCount = 1;
int[,] Chess = new int[ChessCol, ChessCol];

EightQueen(0, ChessCol, Chess);

// 八皇后邏輯
void EightQueen(int row, int n, int[,] chess)
{
    // 將空白棋盤塞入上一次皇后位置
    int[,] tempChess = CreateTempChess(chess, ChessCol);

    // 判斷是否已經到達最後一列
    if (ChessCol == row)
    {
        // 到達最後一列表示完成此局
        Console.WriteLine();
        Console.WriteLine($"Solution {ResultCount}");
        Console.WriteLine();
        for (int i = 0; i < ChessCol; i++)
        {
            for (int j = 0; j < ChessCol; j++)
            {
                if (tempChess[i, j] == 1)
                {
                    Console.Write(" Q");
                }
                else
                {
                    Console.Write(" .");
                }

                //Console.Write($" {tempChess[i, j]}");
            }
            Console.WriteLine();
        }
        ResultCount++;
    }
    else
    {
        for (int j = 0; j < n; j++)
        {
            // 判斷位置是否無法下棋
            if (IsNotRange(row, j, chess))
            {
                for (int i = 0; i < ChessCol; i++)
                {
                    tempChess[row, i] = 0;
                }
                tempChess[row, j] = 1;

                EightQueen(row + 1, n, tempChess);
            }
        }
    }

}

// 建立空白棋盤
int[,] CreateTempChess(int[,] chess, int ChessCol)
{
    int[,] tempChess = new int[ChessCol, ChessCol];
    for (int i = 0; i < ChessCol; i++)
    {
        for (int j = 0; j < ChessCol; j++)
        {
            tempChess[i, j] = chess[i, j];
        }
    }

    return tempChess;
}

// 判斷位置是否無法下棋
bool IsNotRange(int row, int j, int[,] chess)
{
    int i = 0, k = 0;

    //判断列方向
    for (i = 0; i < ChessCol; i++)
    {
        if (chess[i, j] != 0)
        {
            return false;
        }
    }

    //判断左上方
    for (i = row - 1, k = j - 1; i > -1 && k > -1; --i, --k)
    {
        if (chess[i, k] != 0)
        {
            return false;
        }
    }

    //判断右上方
    for (i = row - 1, k = j + 1; i > -1 && k < ChessCol; --i, ++k)
    {
        if (chess[i, k] != 0)
        {
            return false;
        }
    }

    //判断左下方
    for (i = row + 1, k = j - 1; i < ChessCol && k > -1; ++i, --k)
    {
        if (chess[i, k] != 0)
        {
            return false;
        }
    }

    //判断右下方
    for (i = row + 1, k = j + 1; i < ChessCol && k < ChessCol; ++i, ++k)
    {
        if (chess[i, k] != 0)
        {
            return false;
        }
    }

    return true;
}