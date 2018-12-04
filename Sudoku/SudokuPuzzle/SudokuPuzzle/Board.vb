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
        'Sets the label, radio buttons, Choose button, and warning label to be invisible
        Label1.Visible = False
        EasyDiff.Visible = False
        MedDiff.Visible = False
        HardDiff.Visible = False
        DiffChoose.Visible = False
        ChooseDiifWarning.Visible = False
        Mistake_Label.Visible = True
        Mistake_Value.Visible = True
    End Sub

    Private Sub ShowDiff()
        'Resets the values changed in HideDiff
        Label1.Visible = True
        EasyDiff.Visible = True
        MedDiff.Visible = True
        HardDiff.Visible = True
        DiffChoose.Visible = True
        ChooseDiifWarning.Visible = True
        Mistake_Label.Visible = False
        Mistake_Value.Visible = False
        EasyDiff.Checked = False
        MedDiff.Checked = False
        HardDiff.Checked = False
    End Sub

    ' Initial condtions for new board displayed 
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

    ' Sets up the board 
    Private Sub DrawToBoard(ByVal board As Array)
        Dim cells() As RichTextBox = New RichTextBox() {
            Cell0_0, Cell0_1, Cell0_2, Cell0_3, Cell0_4, Cell0_5, Cell0_6, Cell0_7, Cell0_8,
            Cell1_0, Cell1_1, Cell1_2, Cell1_3, Cell1_4, Cell1_5, Cell1_6, Cell1_7, Cell1_8,
            Cell2_0, Cell2_1, Cell2_2, Cell2_3, Cell2_4, Cell2_5, Cell2_6, Cell2_7, Cell2_8,
            Cell3_0, Cell3_1, Cell3_2, Cell3_3, Cell3_4, Cell3_5, Cell3_6, Cell3_7, Cell3_8,
            Cell4_0, Cell4_1, Cell4_2, Cell4_3, Cell4_4, Cell4_5, Cell4_6, Cell4_7, Cell4_8,
            Cell5_0, Cell5_1, Cell5_2, Cell5_3, Cell5_4, Cell5_5, Cell5_6, Cell5_7, Cell5_8,
            Cell6_0, Cell6_1, Cell6_2, Cell6_3, Cell6_4, Cell6_5, Cell6_6, Cell6_7, Cell6_8,
            Cell7_0, Cell7_1, Cell7_2, Cell7_3, Cell7_4, Cell7_5, Cell7_6, Cell7_7, Cell7_8,
            Cell8_0, Cell8_1, Cell8_2, Cell8_3, Cell8_4, Cell8_5, Cell8_6, Cell8_7, Cell8_8}
        Dim rowCount As Integer = 0
        Dim colCount As Integer = 0

        For Each cell As RichTextBox In cells
            'If value in array is not 0, then set the text of the board to be that value
            'Also sets other settings so that user can't change those values
            If (board(rowCount, colCount) <> 0) Then
                cell.Text = board(rowCount, colCount)
                cell.ReadOnly = True
                cell.Cursor = Cursors.Default
                cell.ForeColor = Color.PaleVioletRed
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

    ' Handles when an individual value is inputed 
    Private Sub NumberInputted(sender As Object, e As EventArgs) Handles Cell0_0.TextChanged,
            Cell0_1.TextChanged, Cell0_2.TextChanged, Cell0_3.TextChanged, Cell0_4.TextChanged, Cell0_5.TextChanged, Cell0_6.TextChanged, Cell0_7.TextChanged, Cell0_8.TextChanged,
            Cell1_0.TextChanged, Cell1_1.TextChanged, Cell1_2.TextChanged, Cell1_3.TextChanged, Cell1_4.TextChanged, Cell1_5.TextChanged, Cell1_6.TextChanged, Cell1_7.TextChanged, Cell1_8.TextChanged,
            Cell2_0.TextChanged, Cell2_1.TextChanged, Cell2_2.TextChanged, Cell2_3.TextChanged, Cell2_4.TextChanged, Cell2_5.TextChanged, Cell2_6.TextChanged, Cell2_7.TextChanged, Cell2_8.TextChanged,
            Cell3_0.TextChanged, Cell3_1.TextChanged, Cell3_2.TextChanged, Cell3_3.TextChanged, Cell3_4.TextChanged, Cell3_5.TextChanged, Cell3_6.TextChanged, Cell3_7.TextChanged, Cell3_8.TextChanged,
            Cell4_0.TextChanged, Cell4_1.TextChanged, Cell4_2.TextChanged, Cell4_3.TextChanged, Cell4_4.TextChanged, Cell4_5.TextChanged, Cell4_6.TextChanged, Cell4_7.TextChanged, Cell4_8.TextChanged,
            Cell5_0.TextChanged, Cell5_1.TextChanged, Cell5_2.TextChanged, Cell5_3.TextChanged, Cell5_4.TextChanged, Cell5_5.TextChanged, Cell5_6.TextChanged, Cell5_7.TextChanged, Cell5_8.TextChanged,
            Cell6_0.TextChanged, Cell6_1.TextChanged, Cell6_2.TextChanged, Cell6_3.TextChanged, Cell6_4.TextChanged, Cell6_5.TextChanged, Cell6_6.TextChanged, Cell6_7.TextChanged, Cell6_8.TextChanged,
            Cell7_0.TextChanged, Cell7_1.TextChanged, Cell7_2.TextChanged, Cell7_3.TextChanged, Cell7_4.TextChanged, Cell7_5.TextChanged, Cell7_6.TextChanged, Cell7_7.TextChanged, Cell7_8.TextChanged,
            Cell8_0.TextChanged, Cell8_1.TextChanged, Cell8_2.TextChanged, Cell8_3.TextChanged, Cell8_4.TextChanged, Cell8_5.TextChanged, Cell8_6.TextChanged, Cell8_7.TextChanged, Cell8_8.TextChanged

        Dim cell As RichTextBox = CType(sender, RichTextBox)
        Dim rowNum As Integer = CInt(cell.Name.Substring(4, 1))
        Dim colNum As Integer = CInt(cell.Name.Substring(6, 1))
        Dim value As String = cell.Text

        'Checks if user inputs a valid number
        If (IsNumeric(value)) Then
            CheckNum(rowNum, colNum, CInt(value))
        ElseIf (value = "") Then
            'Handles conversion of "" to Integer error
            cell.Text = ""
        Else
            MsgBox("You must input a valid number.")
            cell.Text = ""
        End If

        'Checks if it is win condition after each textbox change
        If (CheckWin()) Then
            Dim tryAgain As Integer = MessageBox.Show("You solved the puzzle with only " + Mistake_Value.Text + " mistakes. Would you like to try again?", "Congrats!", MessageBoxButtons.YesNo)
            If (tryAgain = DialogResult.Yes) Then
                ResetGame()
            ElseIf (tryAgain = DialogResult.No) Then
                Close()
            End If
        End If
    End Sub

    ' Compares inputted value to the answer key
    ' If the user inputs an incorrect value a window appears 
    Private Sub CheckNum(ByVal rowNum As Integer, ByVal colNum As Integer, ByVal val As Integer)
        If (GlobalVariable.AnsBoard(rowNum, colNum) <> val) Then
            'Increment mistakes textbox
            Mistake_Value.Text = Mistake_Value.Text + 1
            'Display error message
            'MsgBox("You got the wrong number bich")
            MsgBox("Value does not match answer key.")
        Else
            GlobalVariable.GameBoard(rowNum, colNum) = val
        End If

    End Sub

    ' Checks if the game is completed by comparing each cell 
    Function CheckWin() As Boolean
        Dim counter As Integer = 0
        Dim cells() As RichTextBox = New RichTextBox() {
            Cell0_0, Cell0_1, Cell0_2, Cell0_3, Cell0_4, Cell0_5, Cell0_6, Cell0_7, Cell0_8,
            Cell1_0, Cell1_1, Cell1_2, Cell1_3, Cell1_4, Cell1_5, Cell1_6, Cell1_7, Cell1_8,
            Cell2_0, Cell2_1, Cell2_2, Cell2_3, Cell2_4, Cell2_5, Cell2_6, Cell2_7, Cell2_8,
            Cell3_0, Cell3_1, Cell3_2, Cell3_3, Cell3_4, Cell3_5, Cell3_6, Cell3_7, Cell3_8,
            Cell4_0, Cell4_1, Cell4_2, Cell4_3, Cell4_4, Cell4_5, Cell4_6, Cell4_7, Cell4_8,
            Cell5_0, Cell5_1, Cell5_2, Cell5_3, Cell5_4, Cell5_5, Cell5_6, Cell5_7, Cell5_8,
            Cell6_0, Cell6_1, Cell6_2, Cell6_3, Cell6_4, Cell6_5, Cell6_6, Cell6_7, Cell6_8,
            Cell7_0, Cell7_1, Cell7_2, Cell7_3, Cell7_4, Cell7_5, Cell7_6, Cell7_7, Cell7_8,
            Cell8_0, Cell8_1, Cell8_2, Cell8_3, Cell8_4, Cell8_5, Cell8_6, Cell8_7, Cell8_8}

        For Each cell As RichTextBox In cells
            If (cell.Text <> "") Then
                counter += 1
            End If
        Next

        Return (counter = cells.Length)
    End Function

    ' Resets the game if the user selects yes on the end game menu 
    Private Sub ResetGame()
        ShowDiff()
        Mistake_Value.Text = 0
        Array.Clear(GlobalVariable.AnsBoard, 0, GlobalVariable.AnsBoard.Length)
        Array.Clear(GlobalVariable.GameBoard, 0, GlobalVariable.GameBoard.Length)
        Dim cells() As RichTextBox = New RichTextBox() {
            Cell0_0, Cell0_1, Cell0_2, Cell0_3, Cell0_4, Cell0_5, Cell0_6, Cell0_7, Cell0_8,
            Cell1_0, Cell1_1, Cell1_2, Cell1_3, Cell1_4, Cell1_5, Cell1_6, Cell1_7, Cell1_8,
            Cell2_0, Cell2_1, Cell2_2, Cell2_3, Cell2_4, Cell2_5, Cell2_6, Cell2_7, Cell2_8,
            Cell3_0, Cell3_1, Cell3_2, Cell3_3, Cell3_4, Cell3_5, Cell3_6, Cell3_7, Cell3_8,
            Cell4_0, Cell4_1, Cell4_2, Cell4_3, Cell4_4, Cell4_5, Cell4_6, Cell4_7, Cell4_8,
            Cell5_0, Cell5_1, Cell5_2, Cell5_3, Cell5_4, Cell5_5, Cell5_6, Cell5_7, Cell5_8,
            Cell6_0, Cell6_1, Cell6_2, Cell6_3, Cell6_4, Cell6_5, Cell6_6, Cell6_7, Cell6_8,
            Cell7_0, Cell7_1, Cell7_2, Cell7_3, Cell7_4, Cell7_5, Cell7_6, Cell7_7, Cell7_8,
            Cell8_0, Cell8_1, Cell8_2, Cell8_3, Cell8_4, Cell8_5, Cell8_6, Cell8_7, Cell8_8}
        For Each cell As RichTextBox In cells
            cell.Text = ""
            cell.ReadOnly = False
            cell.Cursor = Cursors.IBeam
            cell.ForeColor = Color.SeaGreen
        Next
    End Sub

End Class

' Class of global values for the answer key and the game state arrays 
Public Class GlobalVariable
    Public Shared AnsBoard(,) As Integer = New Integer(9, 9) {}
    Public Shared GameBoard(,) As Integer = New Integer(9, 9) {}
End Class
