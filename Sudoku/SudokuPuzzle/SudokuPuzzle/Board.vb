Public Class Board
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ChooseDifficulty(sender As Object, e As EventArgs) Handles DiffChoose.Click
        'Checks which radio button is selected and loads the boards with the appropriate files
        'If button is chosen with no difficulty set, a warning will appear
        Select Case True
            Case EasyDiff.Checked
                HideDiff()
                LoadBoard(GlobalVariable.AnsBoard, ".\easyKey.csv")
                LoadBoard(GlobalVariable.GameBoard, ".\easyStart.csv")
                DrawToBoard(GlobalVariable.GameBoard)
            Case MedDiff.Checked
                HideDiff()
                LoadBoard(GlobalVariable.AnsBoard, ".\mediumKey.csv")
                LoadBoard(GlobalVariable.GameBoard, ".\mediumStart.csv")
                DrawToBoard(GlobalVariable.GameBoard)
            Case HardDiff.Checked
                HideDiff()
                LoadBoard(GlobalVariable.AnsBoard, ".\hardKey.csv")
                LoadBoard(GlobalVariable.GameBoard, ".\hardStart.csv")
                DrawToBoard(GlobalVariable.GameBoard)
            Case Else
                ChooseDiifWarning.Visible = True
        End Select
    End Sub

    Private Sub HideDiff()
        ' Sets the label, radio buttons, Choose button, and warning label to be invisible
        Label1.Visible = False
        EasyDiff.Visible = False
        MedDiff.Visible = False
        HardDiff.Visible = False
        DiffChoose.Visible = False
        ChooseDiifWarning.Visible = False
    End Sub

    Private Sub LoadBoard(ByVal board As Array, ByVal fileName As String)
        Dim rowCount As Integer = 0
        Dim colCount As Integer = 0

        'Reads the files and stores the values into the array
        Using FileReader As New Microsoft.VisualBasic.
                                    FileIO.TextFieldParser(fileName)
            FileReader.TextFieldType = FileIO.FieldType.Delimited
            FileReader.SetDelimiters(",")
            Dim currentRow As String()
            While Not FileReader.EndOfData
                Try
                    currentRow = FileReader.ReadFields()
                    Dim currentCol As String
                    For Each currentCol In currentRow
                        If (CInt(currentCol) > 0) Then
                            board(rowCount, colCount) = CInt(currentCol)
                        End If
                        'Increment colCount after each value
                        colCount += 1
                    Next
                    'Increment rowCount after it finished reading one row
                    'Also resets colCount to avoid error going out of bounds
                    rowCount += 1
                    colCount = 0
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
                End Try
            End While
        End Using
    End Sub

    Private Sub DrawToBoard(ByVal board As Array)
        Dim cells() As RichTextBox = New RichTextBox() {
            Cell1_1, Cell1_2, Cell1_3, Cell1_4, Cell1_5, Cell1_6, Cell1_7, Cell1_8, Cell1_9,
            Cell2_1, Cell2_2, Cell2_3, Cell2_4, Cell2_5, Cell2_6, Cell2_7, Cell2_8, Cell2_9,
            Cell3_1, Cell3_2, Cell3_3, Cell3_4, Cell3_5, Cell3_6, Cell3_7, Cell3_8, Cell3_9,
            Cell4_1, Cell4_2, Cell4_3, Cell4_4, Cell4_5, Cell4_6, Cell4_7, Cell4_8, Cell4_9,
            Cell5_1, Cell5_2, Cell5_3, Cell5_4, Cell5_5, Cell5_6, Cell5_7, Cell5_8, Cell5_9,
            Cell6_1, Cell6_2, Cell6_3, Cell6_4, Cell6_5, Cell6_6, Cell6_7, Cell6_8, Cell6_9,
            Cell7_1, Cell7_2, Cell7_3, Cell7_4, Cell7_5, Cell7_6, Cell7_7, Cell7_8, Cell7_9,
            Cell8_1, Cell8_2, Cell8_3, Cell8_4, Cell8_5, Cell8_6, Cell8_7, Cell8_8, Cell8_9,
            Cell9_1, Cell9_2, Cell9_3, Cell9_4, Cell9_5, Cell9_6, Cell9_7, Cell9_8, Cell9_9}
        Dim rowCount As Integer = 0
        Dim colCount As Integer = 0

        For Each cell As RichTextBox In cells
            'If value in array is not 0, then set the text of the board to be that value
            'Also sets other settings so that user can't change those values
            If (board(rowCount, colCount) <> 0) Then
                cell.Text = board(rowCount, colCount)
                cell.ReadOnly = True
                cell.Cursor = DefaultCursor
            End If
            colCount += 1
            'Basically checks if colCount reaches the max bound
            'If so, reset col counter and increment row counter
            If (colCount = board.GetUpperBound(0)) Then
                colCount = 0
                rowCount += 1
            End If
        Next
    End Sub

    Private Sub NumberInputted(sender As Object, e As EventArgs) Handles Cell1_1.TextChanged,
            Cell1_2.TextChanged, Cell1_3.TextChanged, Cell1_4.TextChanged, Cell1_5.TextChanged, Cell1_6.TextChanged, Cell1_7.TextChanged, Cell1_8.TextChanged, Cell1_9.TextChanged,
            Cell2_1.TextChanged, Cell2_2.TextChanged, Cell2_3.TextChanged, Cell2_4.TextChanged, Cell2_5.TextChanged, Cell2_6.TextChanged, Cell2_7.TextChanged, Cell2_8.TextChanged, Cell2_9.TextChanged,
            Cell3_1.TextChanged, Cell3_2.TextChanged, Cell3_3.TextChanged, Cell3_4.TextChanged, Cell3_5.TextChanged, Cell3_6.TextChanged, Cell3_7.TextChanged, Cell3_8.TextChanged, Cell3_9.TextChanged,
            Cell4_1.TextChanged, Cell4_2.TextChanged, Cell4_3.TextChanged, Cell4_4.TextChanged, Cell4_5.TextChanged, Cell4_6.TextChanged, Cell4_7.TextChanged, Cell4_8.TextChanged, Cell4_9.TextChanged,
            Cell5_1.TextChanged, Cell5_2.TextChanged, Cell5_3.TextChanged, Cell5_4.TextChanged, Cell5_5.TextChanged, Cell5_6.TextChanged, Cell5_7.TextChanged, Cell5_8.TextChanged, Cell5_9.TextChanged,
            Cell6_1.TextChanged, Cell6_2.TextChanged, Cell6_3.TextChanged, Cell6_4.TextChanged, Cell6_5.TextChanged, Cell6_6.TextChanged, Cell6_7.TextChanged, Cell6_8.TextChanged, Cell6_9.TextChanged,
            Cell7_1.TextChanged, Cell7_2.TextChanged, Cell7_3.TextChanged, Cell7_4.TextChanged, Cell7_5.TextChanged, Cell7_6.TextChanged, Cell7_7.TextChanged, Cell7_8.TextChanged, Cell7_9.TextChanged,
            Cell8_1.TextChanged, Cell8_2.TextChanged, Cell8_3.TextChanged, Cell8_4.TextChanged, Cell8_5.TextChanged, Cell8_6.TextChanged, Cell8_7.TextChanged, Cell8_8.TextChanged, Cell8_9.TextChanged,
            Cell9_1.TextChanged, Cell9_2.TextChanged, Cell9_3.TextChanged, Cell9_4.TextChanged, Cell9_5.TextChanged, Cell9_6.TextChanged, Cell9_7.TextChanged, Cell9_8.TextChanged, Cell9_9.TextChanged

        'TO DO: 
        'When user inputs a value, it must update the value in GameBoard array
        'Have a helper function that will first check if input is valid

        Dim cell As RichTextBox = CType(sender, RichTextBox)
        If (cell.Name = "Cell1_1" Or cell.Name = "Cell1_2" Or cell.Name = "Cell1_3" Or cell.Name = "Cell1_4" Or cell.Name = "Cell1_5" Or cell.Name = "Cell1_6" Or cell.Name = "Cell1_7" Or cell.Name = "Cell1_8" Or cell.Name = "Cell1_9") Then
            TextBox1.Visible = Not (TextBox1.Visible)
            TextBox1.Text = cell.Text
        End If
        'Select Case cell.Name
        '    Case "Cell1_1"

        '    Case "Cell1_2"

        '    Case "Cell1_3"

        '    Case "Cell1_4"

        '    Case "Cell1_5"

        '    Case "Cell1_6"

        '    Case "Cell1_7"

        '    Case "Cell1_8"

        '    Case "Cell1_9"

        '    Case "Cell2_1"
        '    Case "Cell2_2"
        '    Case "Cell2_3"
        '    Case "Cell2_4"
        '    Case "Cell2_5"
        '    Case "Cell2_6"
        '    Case "Cell2_7"
        '    Case "Cell2_8"
        '    Case "Cell2_9"
        '        TextBox2.Visible = True
        'End Select

        CheckWin()
    End Sub

    Private Sub CheckNum()

    End Sub

    Private Sub CheckWin()

    End Sub

End Class

Public Class GlobalVariable
    Public Shared AnsBoard(,) As Integer = New Integer(9, 9) {}
    Public Shared GameBoard(,) As Integer = New Integer(9, 9) {}
End Class
