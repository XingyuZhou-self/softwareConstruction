// 如果矩阵上每一条由左上到右下的对角线上的元素都相同，那么这个矩阵是托普利茨矩阵 。给定一个 M x N 的矩阵，当且仅当它是托普利茨矩阵时返回 True。
using System;

class Program
{

    //static bool IsToeplitzMatrix(int[,]array)
    //{
    //    int rowCount = array.GetLength(0);
    //    int columnCount = array.GetLength(1);
    //    //First row
    //    for(int columnIndex=0;columnIndex<columnCount;columnIndex++)
    //    {
    //        int currentRow = 0;int currentColumn = columnIndex;
    //        while(currentRow<rowCount&&currentColumn<columnCount)
    //        {
    //            if (array[currentRow, currentColumn] != array[0, columnIndex])
    //                return false;
    //            currentRow++;currentColumn++;
    //        }
    //    }
    //    //First column
    //    for(int rowIndex=1;rowIndex<rowCount;rowIndex++)
    //    {
    //        int currentColumn = 0;int currentRow = rowIndex;
    //        while (currentColumn<columnCount&&currentRow<rowCount)
    //        {
    //            if (array[currentRow, currentColumn] != array[rowIndex, 0])
    //                return false;
    //            currentRow++;currentColumn++;
    //        }
    //    }
    //    return true;
    //}
    //一个更简单且直观的算法
    static bool IsToeplitzMatrix(int[,] matrix)
    {
        int m = matrix.GetLength(0);
        int n = matrix.GetLength(1);

        // 遍历除最后一行和最后一列外的所有元素
        for (int i = 0; i < m - 1; i++)
        {
            for (int j = 0; j < n - 1; j++)
            {
                // 检查当前元素是否与右下角的元素相等
                if (matrix[i, j] != matrix[i + 1, j + 1])
                    return false;
            }
        }
        return true;
    }

    static void Main()
    {
        int[,] array1 = {
            {1,2,3,4 },
            {5,1,2,3 },
            {9,5,1,2 }
        };
        int[,] array2 =
        {
            {1,2,3,4 },
            {5,1,2,3 },
            {1,2,1,2 },
            {1,2,2,1 }
        };
        if (IsToeplitzMatrix(array1))
            Console.Write("True");
        else
            Console.Write("False");
        
    }
  
}
