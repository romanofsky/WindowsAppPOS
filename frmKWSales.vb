


Public Class frmKWsales





    Private Sub btnCustomers_Click(sender As Object, e As EventArgs) Handles btnCustomers.Click
        Panel1.Controls.Clear()
        Customers.TopLevel = False
        Panel1.Controls.Add(Customers)
        Customers.Show()
    End Sub

    Private Sub btnManual_Click(sender As Object, e As EventArgs) Handles btnManual.Click
        Panel1.Controls.Clear()
        Form2.TopLevel = False
        Panel1.Controls.Add(Form2)
        Form2.Show()
    End Sub

    Private Sub btnOptions_Click(sender As Object, e As EventArgs) Handles btnOptions.Click
        Panel1.Controls.Clear()
        Form3.TopLevel = False
        Panel1.Controls.Add(Form3)
        Form3.Show()
    End Sub
    Private Sub btnDeli_Click(sender As Object, e As EventArgs) Handles btnDeli.Click
        Panel1.Controls.Clear()
        Form4.TopLevel = False
        Panel1.Controls.Add(Form4)
        Form4.Show()
    End Sub

    Private Sub btnMenu_Click(sender As Object, e As EventArgs) Handles btnMenu.Click
        Panel1.Controls.Clear()
        Form5.TopLevel = False
        Panel1.Controls.Add(Form5)
        Form5.Show()
    End Sub

    Private Sub btnProducts_Click(sender As Object, e As EventArgs) Handles btnProducts.Click
        Panel1.Controls.Clear()
        Form6.TopLevel = False
        Panel1.Controls.Add(Form6)
        Form6.Show()
    End Sub

    Private Sub btnCheckOut_Click(sender As Object, e As EventArgs) Handles btnCheckOut.Click
        Panel1.Controls.Clear()
        Form7.TopLevel = False
        Panel1.Controls.Add(Form7)
        Form7.Show()
    End Sub

End Class
