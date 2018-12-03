Public Class Board
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckNumber(sender As Object, e As EventArgs) Handles Cell1_1.TextChanged,
            Cell1_2.TextChanged, Cell1_3.TextChanged, Cell1_4.TextChanged, Cell1_5.TextChanged, Cell1_6.TextChanged, Cell1_7.TextChanged, Cell1_8.TextChanged, Cell1_9.TextChanged,
            Cell2_1.TextChanged, Cell2_2.TextChanged, Cell2_3.TextChanged, Cell2_4.TextChanged, Cell2_5.TextChanged, Cell2_6.TextChanged, Cell2_7.TextChanged, Cell2_8.TextChanged, Cell2_9.TextChanged,
            Cell3_1.TextChanged, Cell3_2.TextChanged, Cell3_3.TextChanged, Cell3_4.TextChanged, Cell3_5.TextChanged, Cell3_6.TextChanged, Cell3_7.TextChanged, Cell3_8.TextChanged, Cell3_9.TextChanged,
            Cell4_1.TextChanged, Cell4_2.TextChanged, Cell4_3.TextChanged, Cell4_4.TextChanged, Cell4_5.TextChanged, Cell4_6.TextChanged, Cell4_7.TextChanged, Cell4_8.TextChanged, Cell4_9.TextChanged,
            Cell5_1.TextChanged, Cell5_2.TextChanged, Cell5_3.TextChanged, Cell5_4.TextChanged, Cell5_5.TextChanged, Cell5_6.TextChanged, Cell5_7.TextChanged, Cell5_8.TextChanged, Cell5_9.TextChanged,
            Cell6_1.TextChanged, Cell6_2.TextChanged, Cell6_3.TextChanged, Cell6_4.TextChanged, Cell6_5.TextChanged, Cell6_6.TextChanged, Cell6_7.TextChanged, Cell6_8.TextChanged, Cell6_9.TextChanged,
            Cell7_1.TextChanged, Cell7_2.TextChanged, Cell7_3.TextChanged, Cell7_4.TextChanged, Cell7_5.TextChanged, Cell7_6.TextChanged, Cell7_7.TextChanged, Cell7_8.TextChanged, Cell7_9.TextChanged,
            Cell8_1.TextChanged, Cell8_2.TextChanged, Cell8_3.TextChanged, Cell8_4.TextChanged, Cell8_5.TextChanged, Cell8_6.TextChanged, Cell8_7.TextChanged, Cell8_8.TextChanged, Cell8_9.TextChanged,
            Cell9_1.TextChanged, Cell9_2.TextChanged, Cell9_3.TextChanged, Cell9_4.TextChanged, Cell9_5.TextChanged, Cell9_6.TextChanged, Cell9_7.TextChanged, Cell9_8.TextChanged, Cell9_9.TextChanged


    End Sub

    ''Private Sub LoadBoard(ByVal board As Array, ByVal fileName As String)

    Private Sub ChooseDifficulty(sender As Object, e As EventArgs) Handles DiffChoose.Click
        Select Case True
            Case EasyDiff.Checked
                TextBox1.Visible = True
                HideDiff()
            Case MedDiff.Checked
                TextBox2.Visible = True
                HideDiff()
            Case HardDiff.Checked
                TextBox3.Visible = True
                HideDiff()
            Case Else
                TextBox4.Visible = True
        End Select
    End Sub

    Private Sub HideDiff()
        Label1.Visible = False
        EasyDiff.Visible = False
        MedDiff.Visible = False
        HardDiff.Visible = False
        DiffChoose.Visible = False
        Cell1_1.Text = 1
    End Sub

End Class

Public Class GlobalVariable
    Public Shared AnsBoard(,) As Integer = New Integer(9, 9) {}
End Class
