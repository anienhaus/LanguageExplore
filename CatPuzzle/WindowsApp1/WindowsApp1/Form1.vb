Public Class Form1
    Private Sub load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Start game with a shuffled puzzle
        shuffle()
    End Sub

    Private Sub checkForWin()
        Dim hasWon As Boolean
        Dim pieces() As PictureBox
        pieces = New PictureBox() {PB1, PB2, PB3, PB4, PB5, PB6, PB7, PB8, PB9, PB10, PB11, PB12, PB14, PB15, PB13, blankBox}
        hasWon = True

        'If all the pieces are in the correct spot, then user won!
        For Each piece As PictureBox In pieces
            Select Case piece.Name
                Case "PB1"
                    If piece.Location.X <> 363 Or piece.Location.Y <> 27 Then
                        hasWon = False
                    End If
                Case "PB2"
                    If piece.Location.X <> 466 Or piece.Location.Y <> 27 Then
                        hasWon = False
                    End If
                Case "PB3"
                    If piece.Location.X <> 569 Or piece.Location.Y <> 27 Then
                        hasWon = False
                    End If
                Case "PB4"
                    If piece.Location.X <> 672 Or piece.Location.Y <> 27 Then
                        hasWon = False
                    End If
                Case "PB5"
                    If piece.Location.X <> 363 Or piece.Location.Y <> 180 Then
                        hasWon = False
                    End If
                Case "PB6"
                    If piece.Location.X <> 466 Or piece.Location.Y <> 180 Then
                        hasWon = False
                    End If
                Case "PB7"
                    If piece.Location.X <> 569 Or piece.Location.Y <> 180 Then
                        hasWon = False
                    End If
                Case "PB8"
                    If piece.Location.X <> 672 Or piece.Location.Y <> 180 Then
                        hasWon = False
                    End If
                Case "PB9"
                    If piece.Location.X <> 363 Or piece.Location.Y <> 333 Then
                        hasWon = False
                    End If
                Case "PB10"
                    If piece.Location.X <> 466 Or piece.Location.Y <> 333 Then
                        hasWon = False
                    End If
                Case "PB11"
                    If piece.Location.X <> 569 Or piece.Location.Y <> 333 Then
                        hasWon = False
                    End If
                Case "PB12"
                    If piece.Location.X <> 672 Or piece.Location.Y <> 333 Then
                        hasWon = False
                    End If
                Case "PB13"
                    If piece.Location.X <> 363 Or piece.Location.Y <> 486 Then
                        hasWon = False
                    End If
                Case "PB14"
                    If piece.Location.X <> 466 Or piece.Location.Y <> 486 Then
                        hasWon = False
                    End If
                Case "PB15"
                    If piece.Location.X <> 569 Or piece.Location.Y <> 486 Then
                        hasWon = False
                    End If
            End Select
        Next

        'If the user won, show the congrats message
        If hasWon Then
            congrats.Visible = True
            tip.Visible = True
        End If
    End Sub

    Private Sub shuffle()
        Dim pieces() As PictureBox
        Dim x, y, pieceHeight, pieceWidth As Integer
        pieceHeight = 153
        pieceWidth = 103
        Dim taken(), newPoint As Point
        Dim pointIsTaken As Boolean
        pointIsTaken = True
        congrats.Visible = False
        tip.Visible = False
        taken = New Point() {} 'keeps track of which spots have already been chosen by other pieces
        pieces = New PictureBox() {PB1, PB2, PB3, PB4, PB5, PB6, PB7, PB8, PB9, PB10, PB11, PB12, PB14, PB15, PB13, blankBox}

        Randomize() 'initializes RNG

        For Each piece As PictureBox In pieces
            While pointIsTaken
                'Picks a random spot, and checks to see if it's taken
                x = 363 + (Int((4 * Rnd())) * pieceWidth)
                y = 27 + (Int((4 * Rnd())) * pieceHeight)
                newPoint = New Point(x, y)
                pointIsTaken = False
                For Each point As Point In taken
                    'If it's taken, must choose a new point
                    If point.X = newPoint.X And point.Y = newPoint.Y Then
                        pointIsTaken = True
                        Exit For
                    End If
                Next
            End While

            pointIsTaken = True

            'Put piece into its new spot
            piece.Location = newPoint

            'Add element to taken array
            Array.Resize(taken, taken.Length + 1)
            taken(taken.Length - 1) = newPoint
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles ResetButton.Click
        'Reshuffle puzzle when game is reset
        shuffle()
    End Sub

    Private Sub Puzzle_Click(sender As Object, e As EventArgs) Handles PB1.Click, PB2.Click, PB3.Click, PB4.Click, PB5.Click, PB6.Click, PB7.Click, PB8.Click, PB9.Click,
            PB10.Click, PB11.Click, PB12.Click, PB14.Click, PB15.Click, PB13.Click
        Dim pieceHeight, pieceWidth As Integer
        pieceHeight = 153
        pieceWidth = 103
        Dim clickedPiece As PictureBox
        clickedPiece = CType(sender, PictureBox)

        'Check the clicked piece's location against the blankBox's location and see if it can be moved
        'If the piece can be moved, swap the location of the piece and blankBox
        If clickedPiece.Location.Y + pieceHeight = blankBox.Location.Y And clickedPiece.Location.X = blankBox.Location.X Then
            Dim oldSpot As Point
            oldSpot = clickedPiece.Location
            clickedPiece.Location = New Point(clickedPiece.Location.X, clickedPiece.Location.Y + pieceHeight)
            blankBox.Location = oldSpot
            checkForWin()

        ElseIf clickedPiece.Location.Y = blankBox.Location.Y + pieceHeight And clickedPiece.Location.X = blankBox.Location.X Then
            Dim oldSpot As Point
            oldSpot = clickedPiece.Location
            clickedPiece.Location = New Point(clickedPiece.Location.X, clickedPiece.Location.Y - pieceHeight)
            blankBox.Location = oldSpot
            checkForWin()

        ElseIf clickedPiece.Location.X = blankBox.Location.X + pieceWidth And clickedPiece.Location.Y = blankBox.Location.Y Then
            Dim oldSpot As Point
            oldSpot = clickedPiece.Location
            clickedPiece.Location = New Point(clickedPiece.Location.X - pieceWidth, clickedPiece.Location.Y)
            blankBox.Location = oldSpot
            checkForWin()

        ElseIf clickedPiece.Location.X + pieceWidth = blankBox.Location.X And clickedPiece.Location.Y = blankBox.Location.Y Then
            Dim oldSpot As Point
            oldSpot = clickedPiece.Location
            clickedPiece.Location = New Point(clickedPiece.Location.X + pieceWidth, clickedPiece.Location.Y)
            blankBox.Location = oldSpot
            checkForWin()

        End If
    End Sub
End Class
