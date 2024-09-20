const int ChessSize = 4; // 棋盤大小

var ResultCount = 0; // 解法
int[,] Chess = new int[ChessSize, ChessSize]; // 棋局分布

EightQueen(0, Chess);

// 八皇后邏輯
void EightQueen(int row, int[,] chess)
{
    // 將空白棋盤塞入上一次皇后位置
    int[,] tempChess = (int[,])chess.Clone();

    // 判斷是否已經到達最後一列
    if (ChessSize == row)
    {
        // 到達最後一列表示完成此局
        ResultCount++;

        Console.WriteLine();
        Console.WriteLine($"Solution {ResultCount}");

        // 印出棋盤
        for (int i = 0; i < ChessSize; i++)
        {
            for (int j = 0; j < ChessSize; j++)
            {
                if (tempChess[i, j] == 1)
                {
                    Console.Write(" Q");
                }
                else
                {
                    Console.Write(" .");
                }
            }

            Console.WriteLine();
        }
    }
    else
    {
        for (int j = 0; j < ChessSize; j++)
        {
            // 判斷位置是否無法下棋
            if (IsPutOnQueen(row, j, chess))
            {
                for (int i = 0; i < ChessSize; i++)
                {
                    tempChess[row, i] = 0;
                }
                tempChess[row, j] = 1;

                EightQueen(row + 1, tempChess);
            }
        }
    }

}

// 判斷位置是否無法下棋
bool IsPutOnQueen(int row, int j, int[,] chess)
{
    var i = 0;
    var k = 0;

    //判斷列方向
    for (i = 0; i < ChessSize; i++)
    {
        if (chess[i, j] != 0)
        {
            return false;
        }
    }

    //判斷左上方
    for (i = row - 1, k = j - 1; i > -1 && k > -1; --i, --k)
    {
        if (chess[i, k] != 0)
        {
            return false;
        }
    }

    //判斷右上方
    for (i = row - 1, k = j + 1; i > -1 && k < ChessSize; --i, ++k)
    {
        if (chess[i, k] != 0)
        {
            return false;
        }
    }

    //判斷左下方
    for (i = row + 1, k = j - 1; i < ChessSize && k > -1; ++i, --k)
    {
        if (chess[i, k] != 0)
        {
            return false;
        }
    }

    //判斷右下方
    for (i = row + 1, k = j + 1; i < ChessSize && k < ChessSize; ++i, ++k)
    {
        if (chess[i, k] != 0)
        {
            return false;
        }
    }

    return true;
}