Imports Enunciado3.PaintClass

Public Class Paint
    Shared XX, YY As Integer
    Shared Mybrush
    Shared grosorX = 10, grosorY = 10
    Shared mouseClickFlag = False
    Dim shape As String


    Private Sub Coordinates(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        Label1.Text = e.X & "," & e.Y
        XX = e.X
        YY = e.Y

    End Sub



    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        ToolStripButton4.Checked = False
        Circulo.Checked = False
        Linea.Checked = False
        Pie.Checked = False
        Rectangulo.Checked = False
        If ToolStripButton3.Checked = True Then
            Me.Cursor = New Cursor("C:\Users\" & SystemInformation.UserName & "\Desktop\Paint-vb-master\eraser.ico")

        End If

    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        End
    End Sub

    Private Sub NuevoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoToolStripMenuItem.Click
        Me.Invalidate()
        ToolStripButton1.Checked = False
        ''ToolStripDropDownButton1.Selected = False
        ToolStripButton3.Checked = False
        ToolStripButton4.Checked = False
        Circulo.Checked = False
        Rectangulo.Checked = False
        Linea.Checked = False
        Pie.Checked = False
        Label2.BackColor = Color.Transparent
        Me.Cursor = Cursors.Arrow
        Mybrush = Nothing

    End Sub

    Private Sub Drawing(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown

        If Circulo.Checked = True Then
            circle(XX, YY)


        ElseIf Rectangulo.Checked = True Then
            rectangle(XX, YY)

        ElseIf Linea.Checked Then
            LineWidth(XX, YY, XX, YY)

        ElseIf Pie.Checked Then
            piee(XX, YY)

        End If

    End Sub





    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SetColor(0, 0, 0)
        Mybrush = Brushes.Black
        Label2.BackColor = Color.Black
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        ToolStripButton3.Checked = False
        Circulo.Checked = False
        Linea.Checked = False
        Pie.Checked = False
        Rectangulo.Checked = False
        If ToolStripButton4.Checked = True Then
            Me.Cursor = New Cursor("C:\Users\" & SystemInformation.UserName & "\Desktop\Paint-vb-master\pencil.ico")
        End If

    End Sub

    Private Sub Erasing(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If ToolStripButton3.Checked = True And mouseClickFlag = True Then

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
        SetColor(0, 0, 0)
        Mybrush = Brushes.Red
        Label2.BackColor = Color.Red
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SetColor(0, 0, 0)
        Mybrush = Brushes.Lime
        Label2.BackColor = Color.Lime
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        SetColor(0, 0, 0)
        Mybrush = Brushes.Cyan
        Label2.BackColor = Color.Cyan
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        SetColor(0, 0, 0)
        Mybrush = Brushes.Blue
        Label2.BackColor = Color.Blue
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        SetColor(0, 0, 0)
        Mybrush = Brushes.Fuchsia
        Label2.BackColor = Color.Fuchsia
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        SetColor(0, 0, 0)
        Mybrush = Brushes.Purple
        Label2.BackColor = Color.Purple
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        SetColor(0, 0, 0)
        Mybrush = Brushes.Orange
        Label2.BackColor = Color.Orange
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SetColor(0, 0, 0)
        Mybrush = Brushes.White
        Label2.BackColor = Color.White
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
        SetColor(0, 0, 0)
        Mybrush = Brushes.Yellow
        Label2.BackColor = Color.Yellow
    End Sub

    Public Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        ' creando nuevo bitmap

        Using bm As New Bitmap(Me.Width, Me.Height)



            'uusando el metodo , se hace una copia en un picturebox
            Me.DrawToBitmap(bm, New Rectangle(0, 0, Me.Width, Me.Height))



            ' lo guarda en  la ubicacion deseada
            Dim filename = InputBox("Nombre del archivo")
            bm.Save("C:\Users\" & SystemInformation.UserName & "\Pictures\" & filename & ".png" & "", Imaging.ImageFormat.Png)



        End Using

    End Sub

    Private Sub Circulo_CheckedChanged(sender As Object, e As EventArgs) Handles Circulo.CheckedChanged
        ToolStripButton3.Checked = False
        Me.Cursor = New Cursor("C:\Users\" & SystemInformation.UserName & "\Desktop\Paint-vb-master\circle.ico")
        ToolStripButton4.Checked = False
    End Sub

    Private Sub Rectangulo_CheckedChanged(sender As Object, e As EventArgs) Handles Rectangulo.CheckedChanged
        ToolStripButton3.Checked = False
        Me.Cursor = New Cursor("C:\Users\" & SystemInformation.UserName & "\Desktop\Paint-vb-master\rectangle1.ico")
        ToolStripButton4.Checked = False
        Circulo.Checked = False
    End Sub


    Private Sub MousePresionado(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown

        mouseClickFlag = True
    End Sub

    Private Sub Pie_CheckedChanged(sender As Object, e As EventArgs) Handles Pie.CheckedChanged
        ToolStripButton3.Checked = False
        Me.Cursor = New Cursor("C:\Users\" & SystemInformation.UserName & "\Desktop\Paint-vb-master\pie.ico")
        ToolStripButton4.Checked = False
        Circulo.Checked = False
        Rectangulo.Checked = False
    End Sub

    Private Sub Linea_CheckedChanged(sender As Object, e As EventArgs) Handles Linea.CheckedChanged
        ToolStripButton3.Checked = False
        Me.Cursor = New Cursor("C:\Users\" & SystemInformation.UserName & "\Desktop\Paint-vb-master\line.ico")
        ToolStripButton4.Checked = False
        Circulo.Checked = False
        Rectangulo.Checked = False
    End Sub

    Private Sub MouseLiberado(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        mouseClickFlag = False
    End Sub

    Private Sub ToolStripButton1_Paint(sender As Object, e As PaintEventArgs) Handles ToolStripButton1.Paint

    End Sub
End Class
