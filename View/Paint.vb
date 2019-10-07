Imports Enunciado3.PaintClass

Public Class Paint
    Shared XX, YY As Integer
    Shared Mybrush
    Shared grosorX = 10, grosorY = 10
    Shared mouseClickFlag = False
    Dim shape As String
    Shared colorFondo


    Private Sub Coordinates(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        Label1.Text = e.X & "," & e.Y
        XX = e.X
        YY = e.Y
    End Sub



    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        ToolStripButton4.Checked = False
        ToolStripButton1.Checked = False
        ToolStripButton2.Checked = False
        Circulo.Checked = False
        Linea.Checked = False
        Pie.Checked = False
        Rectangulo.Checked = False
        If ToolStripButton3.Checked = True Then
            ''  Me.Cursor = New Cursor("C:\Users\" & SystemInformation.UserName & "\Desktop\Paint-vb-master\eraser.ico")

        End If

    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        End
    End Sub

    Private Sub NuevoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem.Click
        Me.Invalidate()
        ToolStripButton1.Checked = False
        ToolStripButton3.Checked = False
        ToolStripButton4.Checked = False
        Circulo.Checked = False
        Rectangulo.Checked = False
        Linea.Checked = False
        Pie.Checked = False
        Label2.BackColor = Color.Transparent
        Me.Cursor = Cursors.Arrow
        Me.BackColor = Color.White
        Mybrush = Nothing

    End Sub

    Private Sub Drawing(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown

        If Circulo.Checked = True Then
            circle(XX, YY)


        ElseIf Rectangulo.Checked = True Then
            rectangle(XX, YY)

        ElseIf Linea.Checked Then
            Line(XX, YY)

        ElseIf Pie.Checked Then
            piee(XX, YY)

        End If

    End Sub

    Private Sub Filling(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown

        If Circulo.Checked = True And ToolStripButton2.Checked = True Then
            If Mybrush IsNot Nothing Then
                FilledCircle(XX, YY, Mybrush)

            Else
                MsgBox("Seleccione un color primero")
                ToolStripButton2.Checked = False
            End If

        ElseIf Rectangulo.Checked = True Then
            If Mybrush IsNot Nothing Then
                FillRectangle(XX, YY, Mybrush)

            Else
                MsgBox("Seleccione un color primero")
                ToolStripButton2.Checked = False
            End If

        ElseIf Linea.Checked Then
            If Mybrush IsNot Nothing Then
                ''  FilledLine(XX, YY, Mybrush)

            Else
                MsgBox("Seleccione un color primero")
                ToolStripButton2.Checked = False
            End If

        ElseIf Pie.Checked Then
            If Mybrush IsNot Nothing Then
                FilledPie(XX, YY, Mybrush)

            Else
                MsgBox("Seleccione un color primero")
                ToolStripButton2.Checked = False
            End If

        End If

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Mybrush = Brushes.Black
        Label2.BackColor = Color.Black
        colorFondo = Color.Black
        SetColor(0, 0, 0)
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        ToolStripButton3.Checked = False
        ToolStripButton1.Checked = False
        ToolStripButton2.Checked = False
        Circulo.Checked = False
        Linea.Checked = False
        Pie.Checked = False
        Rectangulo.Checked = False
    End Sub

    Private Sub Erasing(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If ToolStripButton3.Checked = True And mouseClickFlag = True Then
            ToolStripButton4.Checked = False
            ToolStripButton1.Checked = False
            Circulo.Checked = False
            Linea.Checked = False
            Pie.Checked = False
            Rectangulo.Checked = False
            Dim MyEreaser = Brushes.White
            CreateGraphics.FillEllipse(MyEreaser, XX, YY, grosorX, grosorY)
        End If
    End Sub

    Private Sub PxToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PxToolStripMenuItem.Click
        grosorX = 20
        grosorY = 20
    End Sub

    Private Sub PaintBrush(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If ToolStripButton4.Checked = True And mouseClickFlag = True Then

            If (Mybrush IsNot Nothing) Then

                CreateGraphics.FillEllipse(Mybrush, XX, YY, grosorX, grosorY)

            Else
                MsgBox("Seleccione un color primero")
                ToolStripButton4.Checked = False
            End If


        End If


    End Sub

    'PALETA DE COLORES
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Mybrush = Brushes.Red
        Label2.BackColor = Color.Red
        colorFondo = Color.Red
        SetColor(255, 0, 0)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Mybrush = Brushes.Lime
        Label2.BackColor = Color.Lime
        colorFondo = Color.Lime
        SetColor(0, 255, 0)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Mybrush = Brushes.Cyan
        Label2.BackColor = Color.Cyan
        colorFondo = Color.Cyan
        SetColor(0, 255, 255)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Mybrush = Brushes.Blue
        Label2.BackColor = Color.Blue
        colorFondo = Color.Blue
        SetColor(0, 0, 255)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        Mybrush = Brushes.Fuchsia
        Label2.BackColor = Color.Fuchsia
        SetColor(255, 0, 255)
        colorFondo = Color.Fuchsia
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        Mybrush = Brushes.Purple
        Label2.BackColor = Color.Purple
        colorFondo = Color.Purple
        SetColor(128, 0, 128)

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        Mybrush = Brushes.Orange
        Label2.BackColor = Color.Orange
        colorFondo = Color.Orange
        SetColor(255, 165, 0)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Mybrush = Brushes.White
        Label2.BackColor = Color.White
        colorFondo = Color.White
        SetColor(255, 255, 255)
    End Sub

    Private Sub PxToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PxToolStripMenuItem1.Click
        grosorX = 30
        grosorY = 30
    End Sub

    Private Sub PxToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles PxToolStripMenuItem2.Click
        grosorX = 60
        grosorY = 60
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Mybrush = Brushes.Yellow
        Label2.BackColor = Color.Yellow
        colorFondo = Color.Yellow
        SetColor(255, 255, 0)
    End Sub

    Public Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        Dim tmpImg As New Bitmap(Me.Width, Me.Height)
        Using g As Graphics = Graphics.FromImage(tmpImg)
            g.CopyFromScreen(PointToScreen(New Point(0, 0)), New Point(0, 0), New Size(Me.Width, Me.Height))
        End Using

        'lo guarda en  la ubicacion deseada
        Dim filename = "Captura-" & DateString
        tmpImg.Save("C:\Users\" & SystemInformation.UserName & "\Pictures\" & filename & ".png" & "", Imaging.ImageFormat.Png)


    End Sub

    Private Sub Circulo_CheckedChanged(sender As Object, e As EventArgs)
        ToolStripButton3.Checked = False
        ''  Me.Cursor = New Cursor("C:\Users\" & SystemInformation.UserName & "\Desktop\Paint-vb-master\circle.ico")
        ToolStripButton1.Checked = False
        ToolStripButton4.Checked = False

    End Sub

    Private Sub Rectangulo_CheckedChanged(sender As Object, e As EventArgs)
        ToolStripButton3.Checked = False
        '' Me.Cursor = New Cursor("C:\Users\" & SystemInformation.UserName & "\Desktop\Paint-vb-master\rectangle1.ico")
        ToolStripButton4.Checked = False
        ToolStripButton1.Checked = False
        Circulo.Checked = False
        Linea.Checked = False
        Pie.Checked = False
    End Sub


    Private Sub MousePresionado(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        mouseClickFlag = True
    End Sub

    Private Sub Pie_CheckedChanged(sender As Object, e As EventArgs)
        ToolStripButton3.Checked = False
        '' Me.Cursor = New Cursor("C:\Users\" & SystemInformation.UserName & "\Desktop\Paint-vb-master\pie.ico")
        ToolStripButton4.Checked = False
        ToolStripButton1.Checked = False
        Circulo.Checked = False
        Rectangulo.Checked = False
        Linea.Checked = False
    End Sub

    Private Sub Linea_CheckedChanged(sender As Object, e As EventArgs)
        ToolStripButton3.Checked = False
        '' Me.Cursor = New Cursor("C:\Users\" & SystemInformation.UserName & "\Desktop\Paint-vb-master\line.ico")
        ToolStripButton4.Checked = False
        ToolStripButton1.Checked = False
        Circulo.Checked = False
        Pie.Checked = False
        Rectangulo.Checked = False
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        ToolStripButton4.Checked = False
        ToolStripButton3.Checked = False
        ToolStripButton2.Checked = False
        Circulo.Checked = False
        Linea.Checked = False
        Pie.Checked = False
        Rectangulo.Checked = False
    End Sub


    Private Sub ChangeBackgroundColor(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
        If ToolStripButton1.Checked = True Then

            Select Case colorFondo
                Case Color.Black
                    Me.BackColor = colorFondo
                Case Color.White
                    Me.BackColor = colorFondo
                Case Color.Orange
                    Me.BackColor = colorFondo
                Case Color.Cyan
                    Me.BackColor = colorFondo
                Case Color.Lime
                    Me.BackColor = colorFondo
                Case Color.Fuchsia
                    Me.BackColor = colorFondo
                Case Color.Purple
                    Me.BackColor = colorFondo
                Case Color.Yellow
                    Me.BackColor = colorFondo
                Case Color.Red
                    Me.BackColor = colorFondo
                Case Color.Blue
                    Me.BackColor = colorFondo
                Case Else
                    MsgBox("Seleccione un color primero")
                    ToolStripButton1.Checked = False

            End Select
        End If

    End Sub

    Private Sub Circulo_CheckedChanged_1(sender As Object, e As EventArgs) Handles Circulo.CheckedChanged
        ToolStripButton1.Checked = False
        ToolStripButton3.Checked = False
        ToolStripButton4.Checked = False
    End Sub

    Private Sub Pie_CheckedChanged_1(sender As Object, e As EventArgs) Handles Pie.CheckedChanged
        ToolStripButton1.Checked = False
        ToolStripButton3.Checked = False
        ToolStripButton4.Checked = False
    End Sub

    Private Sub Rectangulo_CheckedChanged_1(sender As Object, e As EventArgs) Handles Rectangulo.CheckedChanged
        ToolStripButton1.Checked = False
        ToolStripButton3.Checked = False
        ToolStripButton4.Checked = False
    End Sub

    Private Sub Linea_CheckedChanged_1(sender As Object, e As EventArgs) Handles Linea.CheckedChanged
        ToolStripButton1.Checked = False
        ToolStripButton3.Checked = False
        ToolStripButton4.Checked = False
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        ToolStripButton1.Checked = False
        ToolStripButton3.Checked = False
        ToolStripButton4.Checked = False
    End Sub

    Private Sub ToolStripDropDownButton1_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton1.Click

    End Sub

    Private Sub MouseLiberado(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        mouseClickFlag = False
    End Sub

    Private Sub ToolStripButton1_Paint(sender As Object, e As PaintEventArgs) Handles ToolStripButton1.Paint
        ToolStripButton3.Checked = False
        ToolStripButton4.Checked = False
        ToolStripButton2.Checked = False
        Circulo.Checked = False
        Linea.Checked = False
        Pie.Checked = False
        Rectangulo.Checked = False
    End Sub
End Class
