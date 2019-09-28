Public Class PaintClass
    Shared grosor As Double
    Shared color As Brushes
    Shared y As SolidBrush

    Shared OurPen As Pen
    Shared red, green, blue

    Public Shared Sub SetColor(r, g, b)
        red = r
        green = g
        blue = b

    End Sub
    Public Shared Sub LineWidth(x, y, x1, y1)
        OurPen = New Pen(Drawing.Color.FromArgb(red, green, blue))
        Dim myGraphics As Graphics = Paint.CreateGraphics
        myGraphics.DrawLine(OurPen, x, y, x1, y1)

    End Sub

    Public Shared Sub circle(x, y)

        OurPen = New Pen(Drawing.Color.FromArgb(red, green, blue))

        Dim MyGraphic As Graphics = Paint.CreateGraphics
        Dim MyRectangle As New Rectangle

        MyRectangle.X = x
        MyRectangle.Y = y
        MyRectangle.Width = 200
        MyRectangle.Height = 200

        MyGraphic.DrawEllipse(OurPen, MyRectangle)

    End Sub



    Public Shared Sub rectangle(x, y)

        OurPen = New Pen(Drawing.Color.FromArgb(red, green, blue))

        Dim MyGraphic As Graphics = Paint.CreateGraphics
        Dim MyRectangle As New Rectangle

        MyRectangle.X = x
        MyRectangle.Y = y
        MyRectangle.Width = 200
        MyRectangle.Height = 100

        MyGraphic.DrawRectangle(OurPen, MyRectangle)



    End Sub
    Public Shared Sub piee(x, y)

        OurPen = New Pen(Drawing.Color.FromArgb(red, green, blue))

        Dim MyGraphic As Graphics = Paint.CreateGraphics
        Dim MyRectangle As New Rectangle

        MyRectangle.X = x
        MyRectangle.Y = y
        MyRectangle.Width = 200
        MyRectangle.Height = 200

        MyGraphic.DrawPie(OurPen, MyRectangle, 30.0F, 100.0F)
        MyGraphic.DrawPie(OurPen, MyRectangle, 130.0F, 140.0F)
        MyGraphic.DrawPie(OurPen, MyRectangle, 270.0F, 50.0F)
        MyGraphic.DrawPie(OurPen, MyRectangle, 320.0F, 70.0F)

    End Sub

End Class
