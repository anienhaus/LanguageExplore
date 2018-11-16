' N QUEENS PROBLEM
' Author: Anna Nienhaus

Module Module1

    ' Global variables
    Dim numSolutions As Integer = 0

    ' Main subroutine
    Sub Main()
        Console.WriteLine("Welcome to N Queens!")
        Dim n As Integer
        n = InputBox("What is your N?: ", "Enter N")
        Console.WriteLine("All solutions:")

        ' Create the integer matrix (jagged array)
        Dim board(n - 1)() As Integer
        For rowIndex = 0 To n - 1
            board(rowIndex) = New Integer(n - 1) {}
        Next
        For rowIndex = 0 To n - 1
            For colIndex = 0 To n - 1
                board(rowIndex)(colIndex) = 0
            Next
        Next

        ' Run function to solve problem
        SolveNQueens(board, 0)

    End Sub

    ' Subroutine to print a matrix to the console
    Sub PrintMatrix(matrix As Integer()())
        For Each row As Integer() In matrix
            Dim rowString As String = String.Join(" ", row)
            Console.WriteLine(rowString)
        Next
    End Sub

    ' Function to check if a queen can be placed in a spot.
    ' Returns true if it can, false if it can't.
    Function CanPlace(board As Integer()(), row As Integer, col As Integer) As Boolean
        ' Check the row
        For index = 0 To board.Length - 1
            If board(index)(col) = 1 Then
                Return False
            End If
        Next
        ' Check the column
        For index = 0 To board(0).Length - 1
            If board(row)(index) = 1 Then
                Return False
            End If
        Next
        ' Check the diagonals
        For diff = -(board.Length - 1) To board.Length - 1
            ' Downward Diagonal - board(row + diff)(col + diff)
            If (row + diff >= 0) And (col + diff >= 0) And (row + diff < board.Length) And (col + diff < board.Length) Then
                If board(row + diff)(col + diff) = 1 Then
                    Return False
                End If
            End If
            ' Upward Diagonal - board(row - diff)(col + diff)
            If (row - diff >= 0) And (col + diff >= 0) And (row - diff < board.Length) And (col + diff < board.Length) Then
                If board(row - diff)(col + diff) = 1 Then
                    Return False
                End If
            End If
        Next
        ' Return true if everything was safe
        Return True
    End Function

    ' Function to recursively solve the problem
    ' Returns true if this is a solution, false if it is not
    Sub SolveNQueens(board As Integer()(), col As Integer)
        ' Base case
        If col > board.Length - 1 Then
            numSolutions = numSolutions + 1
            Console.WriteLine("")
            Console.WriteLine("Solution " & numSolutions & ":")
            PrintMatrix(board)
        Else
            ' Try other solutions
            For index = 0 To board.Length - 1
                If CanPlace(board, index, col) Then
                    board(index)(col) = 1
                    SolveNQueens(board, col + 1)
                    board(index)(col) = 0
                End If
            Next
        End If
    End Sub

End Module