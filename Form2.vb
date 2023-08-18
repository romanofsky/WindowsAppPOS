Imports System.Data
Imports System.Data.SqlClient

Public Class Form2
    Dim OrderNumber As Integer
    Dim KWSalesConnection As SqlConnection
    Dim OrdersCommand As SqlCommand
    Dim OrdersAdapter As SqlDataAdapter
    Dim OrdersTable As DataTable
    Dim CustomersCommand As SqlCommand
    Dim CustomersAdapter As SqlDataAdapter
    Dim CustomersTable As DataTable
    Dim CustomersManager As CurrencyManager
    'add another set of data objects that connect to Products table
    Dim ProductsCommand As SqlCommand
    Dim ProductsAdapter As SqlDataAdapter
    Dim ProductsTable As DataTable
    Dim PurchasesCommand As SqlCommand
    Dim PurchasesAdapter As SqlDataAdapter
    Dim PurchasesTable As DataTable
    Dim ProductsManager As CurrencyManager
    Dim CustomerID As Long
    Dim MyState As String, MyBookmark As Integer

    Private Sub FrmPublishers_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MyState = "Edit" Or MyState = "Add" Then
            MessageBox.Show("You must finish the current edit before stopping the application.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Cancel = True
        Else
            Try
                'save changes to database
                Dim ProductsAdapterCommands As New SqlCommandBuilder(ProductsAdapter)
                ProductsAdapter.Update(ProductsTable)
            Catch ex As Exception
                MessageBox.Show("Error saving database to file:" + ControlChars.CrLf + ex.Message, "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            'close the connection
            KWSalesConnection.Close()
            'dispose of the objects
            KWSalesConnection.Dispose()
            ProductsCommand.Dispose()
            ProductsAdapter.Dispose()
            ProductsTable.Dispose()
        End If
    End Sub
    Private Sub FrmKWSales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'connect to sales database
        KWSalesConnection = New SqlConnection("Data Source=.\SQLEXPRESS; AttachDbFilename=" + Application.StartupPath + "\SQLKWSalesDB.mdf; Integrated Security=True; Connect Timeout=30; User Instance=True")
            KWSalesConnection.Open()
            'establish command object
            ProductsCommand = New SqlCommand("Select * from Products ORDER BY ProductID", KWSalesConnection)
            'establish data adapter /data table
            ProductsAdapter = New SqlDataAdapter()
            ProductsAdapter.SelectCommand = ProductsCommand
            ProductsTable = New DataTable()
            ProductsAdapter.Fill(ProductsTable)
            'bind controls to data table
            txtProductID.DataBindings.Add("Text", ProductsTable, "ProductID")
            txtPrice.DataBindings.Add("Text", ProductsTable, "Price")
            txtDescription.DataBindings.Add("Text", ProductsTable, "Description")
            txtNumberSold.DataBindings.Add("Text", ProductsTable, "NumberSold")
            'bind combobox to data table
            cboProducts.DataSource = ProductsTable
            cboProducts.DisplayMember = "Description"
            cboProducts.ValueMember = "ProductID"
        'establish currency manager
        ProductsManager = DirectCast(Me.BindingContext(ProductsTable), CurrencyManager)
        Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error establishing Products table.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
        Me.Show()
        Call SetState("View")
    End Sub

    Private Sub BtnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.Click
        If ProductsManager.Position = 0 Then Console.Beep()
        ProductsManager.Position -= 1
    End Sub

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If ProductsManager.Position = ProductsManager.Count - 1 Then Console.Beep()
        ProductsManager.Position += 1
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not (ValidateData()) Then Exit Sub
        Dim SavedName As String = txtProductID.Text
        Dim SavedRow As Integer
        Try
            ProductsManager.EndCurrentEdit()
            ProductsTable.DefaultView.Sort = "ProductID"
            SavedRow = ProductsTable.DefaultView.Find(SavedName)
            ProductsManager.Position = SavedRow
            MessageBox.Show("Record saved.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call SetState("View")
        Catch ex As Exception
            MessageBox.Show("Error saving record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim Response As Windows.Forms.DialogResult
        Response = MessageBox.Show("Are you sure you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
        If Response = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        Try
            ProductsManager.RemoveAt(ProductsManager.Position)
        Catch ex As Exception
            MessageBox.Show("Error deleting record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SetState(ByVal AppState As String)
        MyState = AppState
        Select Case AppState
            Case "View"
                txtProductID.BackColor = Color.White
                txtProductID.ForeColor = Color.Black
                txtDescription.ReadOnly = True
                txtPrice.ReadOnly = True
                txtNumberSold.ReadOnly = True
                btnFirst.Enabled = True
                btnPrevious.Enabled = True
                btnNext.Enabled = True
                btnLast.Enabled = True
                BtnAddNew.Enabled = True
                btnSave.Enabled = False
                btnCancel.Enabled = False
                btnEdit.Enabled = True
                btnDelete.Enabled = True
                btnDone.Enabled = True
                txtDescription.Focus()
            Case "Add", "Edit"
                txtProductID.BackColor = Color.Red
                txtProductID.ForeColor = Color.White
                txtDescription.ReadOnly = False
                txtPrice.ReadOnly = False
                txtNumberSold.ReadOnly = False
                btnFirst.Enabled = False
                btnPrevious.Enabled = False
                btnNext.Enabled = False
                btnLast.Enabled = False
                BtnAddNew.Enabled = False
                btnSave.Enabled = True
                btnCancel.Enabled = True
                btnEdit.Enabled = False
                btnDelete.Enabled = False
                btnDone.Enabled = False
                txtPrice.Focus()
        End Select
    End Sub
    Private Sub BtnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddNew.Click
        Try
            MyBookmark = ProductsManager.Position
            ProductsManager.AddNew()
            Call SetState("Add")
        Catch ex As Exception
            MessageBox.Show("Error adding record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Call SetState("Edit")
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        ProductsManager.CancelCurrentEdit()
        If MyState = "Add" Then
            ProductsManager.Position = MyBookmark
        End If
        Call SetState("View")
    End Sub

    Private Function ValidateData() As Boolean
        Dim Message As String = ""
        Dim AllOK As Boolean = True
        'Check for name
        If txtDescription.Text.Trim = "" Then
            Message = "You must enter an Product Name." + ControlChars.CrLf
            txtDescription.Focus()
            AllOK = False
        End If
        If Not (AllOK) Then
            MessageBox.Show(Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Return (AllOK)
    End Function

    Private Sub TxtInput_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescription.KeyPress, txtProductID.KeyPress, txtPrice.KeyPress
        Dim WhichBox As TextBox = CType(sender, TextBox)
        If e.KeyChar = ControlChars.Cr Then
            Select Case WhichBox.Name
                Case "txtDescription"
                    txtProductID.Focus()
                Case "txtProductID"
                    txtPrice.Focus()
                Case "txtPrice"
                    txtDescription.Focus()
            End Select
        End If
    End Sub
    Private Sub BtnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        ProductsManager.Position = 0
    End Sub
    Private Sub BtnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        ProductsManager.Position = ProductsManager.Count - 1
    End Sub
    Private Sub BtnDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDone.Click
        Me.Close()
    End Sub

    Private Sub pbExit_Click(sender As Object, e As EventArgs) Handles pbExit.Click
        Me.Close()
    End Sub

    Private Sub BtnSearchBarCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearchBarCode.Click
        If txtProductID.Text = "" Then Exit Sub
        Dim SavedRow As Integer = ProductsManager.Position
        Dim FoundRows() As DataRow
        ProductsTable.DefaultView.Sort = "ProductID"
        FoundRows = ProductsTable.Select("ProductID LIKE '" + txtFind.Text + "*'")
        If FoundRows.Length = 0 Then
            ProductsManager.Position = SavedRow
        Else
            ProductsManager.Position = ProductsTable.DefaultView.Find(FoundRows(0).Item("ProductID"))
        End If
    End Sub


    'Button Add To Shopping Cart Procedure
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim UnitPrice As Single
        If cboProducts.SelectedIndex = -1 Then
            MessageBox.Show("You must select a product.", "Purchase Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        'Find unit price of selected product
        Dim NRec As Integer
        For NRec = 0 To ProductsTable.Rows.Count - 1
            If ProductsTable.Rows(NRec).Item("Description").ToString = cboProducts.Text.ToString Then
                UnitPrice = CSng(ProductsTable.Rows(NRec).Item("Price"))
                Exit For
            End If
        Next
        lstCart.Items.Add(Format(nudQuantity.Value, "##") + " " + cboProducts.SelectedValue.ToString + "-" + cboProducts.Text.ToString + " " + Format(UnitPrice, "$0.00"))
        'Adjust total price
        lblTotal.Text = Format(Val(lblTotal.Text) + nudQuantity.Value * UnitPrice, "0.00")
    End Sub

    Private Sub tbEntry_TextChanged(sender As Object, e As EventArgs) Handles tbEntry.TextChanged

    End Sub




    'Code finds the price and description of selected product
    'Code also adjusts the displayed total price
    Private Sub BtnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Dim Q As Integer, P As Single, I As Integer
        If lstCart.SelectedIndex <> -1 Then
            'Adjust total before removing
            'find Q (quantity) and P (price)
            I = InStr(lstCart.Text, " ")
            Q = CInt(Mid(lstCart.Text, 1, I - 1))
            I = InStr(lstCart.Text, "$")
            P = CSng(Mid(lstCart.Text, I + 1, Len(lstCart.Text) - I))
            lblTotal.Text = Format(Val(lblTotal.Text) - Q * P, "0.00")
            lstCart.Items.RemoveAt(lstCart.SelectedIndex)
        End If
    End Sub
End Class