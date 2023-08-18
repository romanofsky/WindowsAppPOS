Imports System.Data
Imports System.Data.SqlClient

Public Class Customers

    Dim OrderNumber As Integer
    Dim KWSalesConnection As SqlConnection
    Dim OrdersCommand As SqlCommand
    Dim OrdersAdapter As SqlDataAdapter
    Dim OrdersTable As DataTable
    Dim CustomersCommand As SqlCommand
    Dim CustomersAdapter As SqlDataAdapter
    Dim CustomersTable As DataTable
    Dim CustomersManager As CurrencyManager
    Dim ProductsCommand As SqlCommand
    Dim ProductsAdapter As SqlDataAdapter
    Dim ProductsTable As DataTable
    Dim ProductsManager As CurrencyManager
    Dim PurchasesCommand As SqlCommand
    Dim PurchasesAdapter As SqlDataAdapter
    Dim PurchasesTable As DataTable
    Dim CustomerID As Long
    Dim MyState As String, MyBookmark As Integer


    Dim NewCustomer As Boolean = False, SavedIndex As Integer



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'connect to sales database
        KWSalesConnection = New SqlConnection("Data Source=.\SQLEXPRESS; AttachDbFilename=" + Application.StartupPath + "\SQLKWSalesDB.mdf; Integrated Security=True; Connect Timeout=30; User Instance=True")
            KWSalesConnection.Open()
            'establish Orders command object
            OrdersCommand = New SqlCommand("SELECT * FROM Orders ORDER BY OrderID", KWSalesConnection)
            'establish Orders data adapter/data table
            OrdersAdapter = New SqlDataAdapter()
            OrdersAdapter.SelectCommand = OrdersCommand
            OrdersTable = New DataTable()
            OrdersAdapter.Fill(OrdersTable)
            'establish Customers command object
            CustomersCommand = New SqlCommand("SELECT * FROM Customers", KWSalesConnection)
            'establish Customers data adapter/data table
            CustomersAdapter = New SqlDataAdapter()
            CustomersAdapter.SelectCommand = CustomersCommand
            CustomersTable = New DataTable()
            CustomersAdapter.Fill(CustomersTable)
            'bind controls to data table
            txtFirstName.DataBindings.Add("Text", CustomersTable, "FirstName")
            txtLastName.DataBindings.Add("Text", CustomersTable, "LastName")
            txtAddress.DataBindings.Add("Text", CustomersTable, "Address")
            txtCity.DataBindings.Add("Text", CustomersTable, "City")
            txtState.DataBindings.Add("Text", CustomersTable, "State")
            txtZip.DataBindings.Add("Text", CustomersTable, "Zip")
            txtPhone.DataBindings.Add("Text", CustomersTable, "Phone")

            'establish currency manager
            CustomersManager = DirectCast(Me.BindingContext(CustomersTable), CurrencyManager)
            'establish Products command object
            ProductsCommand = New SqlCommand("SELECT * FROM Products ORDER BY Description", KWSalesConnection)
            'establish Products data adapter/data table
            ProductsAdapter = New SqlDataAdapter()
            ProductsAdapter.SelectCommand = ProductsCommand
            ProductsTable = New DataTable()
        ProductsAdapter.Fill(ProductsTable)
        'bind controls to data table
        txtProductID.DataBindings.Add("Text", ProductsTable, "ProductID")
        txtPrice.DataBindings.Add("Text", ProductsTable, "Price")
        txtDescription.DataBindings.Add("Text", ProductsTable, "Description")
        'bind combobox to data table
        cboProducts.DataSource = ProductsTable
            cboProducts.DisplayMember = "Description"
            cboProducts.ValueMember = "ProductID"
            'establish Purchases command object
            PurchasesCommand = New SqlCommand("SELECT * FROM Purchases ORDER BY OrderID", KWSalesConnection)
            'establish Purchases data adapter/data table
            PurchasesAdapter = New SqlDataAdapter()
            PurchasesAdapter.SelectCommand = PurchasesCommand
            PurchasesTable = New DataTable()
            PurchasesAdapter.Fill(PurchasesTable)
            'Fill customers combo box
            Call FillCustomers()
            OrderNumber = 0
            Call NewOrder()
        ProductsManager = DirectCast(Me.BindingContext(ProductsTable), CurrencyManager)
        Try
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error establishing Products table.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Exit Sub
        End Try
        Me.Show()
        Call SetStateP("View")
    End Sub
    Private Sub SetStateP(ByVal AppState As String)
        MyState = AppState
        Select Case AppState
            Case "View"
                txtProductID.BackColor = Color.White
                txtProductID.ForeColor = Color.Black
                txtDescription.ReadOnly = True
                txtPrice.ReadOnly = True
                btnFirstP.Enabled = True
                btnPreviousP.Enabled = True
                btnNextP.Enabled = True
                BtnLastP.Enabled = True
                txtDescription.Focus()

        End Select
    End Sub

    Private Sub FillCustomers()
        Dim NRec As Integer
        cboCustomers.Items.Clear()
        If CustomersTable.Rows.Count <> 0 Then
            For NRec = 0 To CustomersTable.Rows.Count - 1
                cboCustomers.Items.Add(CustomerListing(CustomersTable.Rows(NRec).Item("LastName").ToString, CustomersTable.Rows(NRec).Item("FirstName").ToString, CustomersTable.Rows(NRec).Item("CustomerID").ToString))
            Next NRec
        End If
    End Sub

    Private Function CustomerListing(ByVal LastName As String, ByVal FirstName As String, ByVal ID As String) As String
        Return (LastName + ", " + FirstName + " (" + ID + ")")
    End Function


    'procedure to save the remaining data tables and dispose of the newly added objects
    Private Sub FrmKWSales_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If NewCustomer Then
            MessageBox.Show("You must finish the current edit before stopping.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            e.Cancel = True
        Else
            Try
                'save the tables to the database file
                Dim OrdersAdapterCommands As New SqlCommandBuilder(OrdersAdapter)
                OrdersAdapter.Update(OrdersTable)
                Dim CustomersAdapterCommands As New SqlCommandBuilder(CustomersAdapter)
                CustomersAdapter.Update(CustomersTable)
                Dim ProductsAdapterCommands As New SqlCommandBuilder(ProductsAdapter)
                ProductsAdapter.Update(ProductsTable)
                Dim PurchasesAdapterCommands As New SqlCommandBuilder(PurchasesAdapter)
                PurchasesAdapter.Update(PurchasesTable)
            Catch ex As Exception
                MessageBox.Show("Error saving database", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            'close the connection
            KWSalesConnection.Close()
            'dispose of the objects
            OrdersCommand.Dispose()
            OrdersAdapter.Dispose()
            OrdersTable.Dispose()
            CustomersCommand.Dispose()
            CustomersAdapter.Dispose()
            CustomersTable.Dispose()
            ProductsCommand.Dispose()
            ProductsAdapter.Dispose()
            ProductsTable.Dispose()
            PurchasesCommand.Dispose()
            PurchasesAdapter.Dispose()
            PurchasesTable.Dispose()
        End If
    End Sub


    Private Sub NewOrder()
        Dim IDString As String
        Dim ThisDay As Date = Now
        lblDate.Text = Format(ThisDay, "d")
        'Build order ID as string
        OrderNumber += 1
        IDString = Mid(ThisDay.Year.ToString, 3, 2)
        IDString += Format(ThisDay.Month, "00")
        IDString += Format(ThisDay.Day, "00")
        IDString += Format(OrderNumber, "000")
        lblOrderID.Text = IDString
        If cboCustomers.Items.Count <> 0 Then
            cboCustomers.SelectedIndex = 0
        End If
        'Clear purchase information
        cboProducts.SelectedIndex = -1
        nudQuantity.Value = 1
        lblTotal.Text = "0.00"
        lstCart.Items.Clear()
    End Sub

    Private Sub CboCustomers_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomers.SelectedIndexChanged
        If NewCustomer Then Exit Sub
        Dim ID As String, PL As Integer
        Try
            PL = InStr(cboCustomers.SelectedItem.ToString, "(")
            If PL = 0 Then Exit Sub
            'extract ID from selected item
            ID = Mid(cboCustomers.SelectedItem.ToString, PL + 1, Len(cboCustomers.SelectedItem.ToString) - PL - 1)
            CustomersTable.DefaultView.Sort = "CustomerID"
            CustomersManager.Position = CustomersTable.DefaultView.Find(ID)
            CustomerID = CLng(ID)
        Catch ex As Exception
            MessageBox.Show("Could not find customer", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub


    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        'enable text boxes for editing and add row
        NewCustomer = True
        txtFirstName.ReadOnly = False
        txtLastName.ReadOnly = False
        txtAddress.ReadOnly = False
        txtCity.ReadOnly = False
        txtState.ReadOnly = False
        txtZip.ReadOnly = False
        txtPhone.ReadOnly = False
        btnNew.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True
        SavedIndex = cboCustomers.SelectedIndex
        cboCustomers.SelectedIndex = -1
        cboCustomers.Enabled = False
        CustomersManager.AddNew()
        txtFirstName.Focus()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'return to previous customer
        NewCustomer = False
        txtFirstName.ReadOnly = True
        txtLastName.ReadOnly = True
        txtAddress.ReadOnly = True
        txtCity.ReadOnly = True
        txtState.ReadOnly = True
        txtZip.ReadOnly = True
        txtPhone.ReadOnly = True
        btnNew.Enabled = True
        btnSave.Enabled = False
        btnCancel.Enabled = False
        CustomersManager.CancelCurrentEdit()
        cboCustomers.Enabled = True
        cboCustomers.SelectedIndex = SavedIndex
    End Sub


    Private Sub TxtFirstName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFirstName.KeyPress
        If e.KeyChar = ControlChars.Cr Then txtLastName.Focus()
    End Sub

    Private Sub TxtLastName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLastName.KeyPress
        If e.KeyChar = ControlChars.Cr Then txtAddress.Focus()
    End Sub

    Private Sub TxtAddress_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress.KeyPress
        If e.KeyChar = ControlChars.Cr Then txtCity.Focus()
    End Sub

    Private Sub TxtCity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCity.KeyPress
        If e.KeyChar = ControlChars.Cr Then txtState.Focus()
    End Sub

    Private Sub TxtState_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtState.KeyPress
        If e.KeyChar = ControlChars.Cr Then txtZip.Focus()
    End Sub

    Private Sub TxtZip_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtZip.KeyPress
        If e.KeyChar = ControlChars.Cr Then btnSave.Focus()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim AllOK As Boolean = True
        'make sure there are entries
        If txtFirstName.Text = "" Then AllOK = False
        If txtLastName.Text = "" Then AllOK = False
        If txtAddress.Text = "" Then AllOK = False
        If txtCity.Text = "" Then AllOK = False
        If txtState.Text = "" Then AllOK = False
        If txtZip.Text = "" Then AllOK = False
        If Not (AllOK) Then
            MessageBox.Show("All text boxes require an entry.", "Information Missing", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtFirstName.Focus()
            Exit Sub
        End If
        CustomersManager.EndCurrentEdit()
        'save to database then reopen to retrieve assigned CustomerID
        Dim SavedFirstName As String = txtFirstName.Text
        Dim SavedLastName As String = txtLastName.Text
        Dim CustomersAdapterCommands As New SqlCommandBuilder(CustomersAdapter)
        CustomersAdapter.Update(CustomersTable)
        KWSalesConnection.Close()
        'reconnect to sales database
        KWSalesConnection = New SqlConnection("Data Source=.\SQLEXPRESS; AttachDbFilename=" + Application.StartupPath + "\SQLKWSalesDB.mdf; Integrated Security=True; Connect Timeout=30; User Instance=True")
        KWSalesConnection.Open()
        CustomersCommand = New SqlCommand("SELECT * FROM Customers", KWSalesConnection)
        CustomersAdapter = New SqlDataAdapter()
        CustomersAdapter.SelectCommand = CustomersCommand
        CustomersTable = New DataTable()
        CustomersAdapter.Fill(CustomersTable)

        'rebind controls to data table
        txtFirstName.DataBindings.Clear()
        txtLastName.DataBindings.Clear()
        txtLastName.DataBindings.Clear()
        txtAddress.DataBindings.Clear()
        txtCity.DataBindings.Clear()
        txtState.DataBindings.Clear()
        txtZip.DataBindings.Clear()
        txtPhone.DataBindings.Clear()
        txtFirstName.DataBindings.Add("Text", CustomersTable, "FirstName")
        txtLastName.DataBindings.Add("Text", CustomersTable, "LastName")
        txtAddress.DataBindings.Add("Text", CustomersTable, "Address")
        txtCity.DataBindings.Add("Text", CustomersTable, "City")
        txtState.DataBindings.Add("Text", CustomersTable, "State")
        txtZip.DataBindings.Add("Text", CustomersTable, "Zip")
        txtPhone.DataBindings.Add("Text", CustomersTable, "Phone")
        CustomersManager = DirectCast(Me.BindingContext(CustomersTable), CurrencyManager)
        'find added customer
        Dim I As Integer, ID As String = ""
        For I = 0 To CustomersTable.Rows.Count - 1
            If CustomersTable.Rows(I).Item("FirstName").ToString = SavedFirstName And CustomersTable.Rows(I).Item("LastName").ToString = SavedLastName Then
                ID = CustomersTable.Rows(I).Item("CustomerID").ToString
                Exit For
            End If
        Next
        cboCustomers.Enabled = True
        'refill table
        Call FillCustomers()
        'display new customer
        NewCustomer = False
        txtFirstName.ReadOnly = True
        txtLastName.ReadOnly = True
        txtAddress.ReadOnly = True
        txtCity.ReadOnly = True
        txtState.ReadOnly = True
        txtZip.ReadOnly = True
        txtPhone.ReadOnly = True
        btnNew.Enabled = True
        btnSave.Enabled = False
        btnCancel.Enabled = False
        cboCustomers.SelectedItem = CustomerListing(SavedLastName, SavedFirstName, ID)
    End Sub
    Private Sub BtnDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDone.Click
        Me.Close()
    End Sub

    'Button Add To Shopping Cart Procedure
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
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

    Private Sub pbExit_Click(sender As Object, e As EventArgs) Handles pbExit.Click
        Me.Close()
    End Sub

    Private Sub BtnSubmitOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmitOrder.Click
        Dim I As Integer, J As Integer
        Dim Q As Integer, ID As String
        'Make sure there is customer information
        If cboCustomers.SelectedIndex = -1 Then
            MessageBox.Show("You need to select a customer.", "Submit Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If lstCart.Items.Count = 0 Then
            MessageBox.Show("You need to select some items.", "Submit Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        'Submit purchases to database
        Dim NewRow As DataRow
        NewRow = OrdersTable.NewRow
        NewRow.Item("OrderID") = lblOrderID.Text
        NewRow.Item("CustomerID") = CustomerID
        NewRow.Item("OrderDate") = lblDate.Text
        OrdersTable.Rows.Add(NewRow)
        For I = 0 To lstCart.Items.Count - 1
            NewRow = PurchasesTable.NewRow
            J = InStr(lstCart.Items.Item(I).ToString, " ")
            Q = CInt(Mid(lstCart.Items.Item(I).ToString, 1, J - 1))
            ID = Mid(lstCart.Items.Item(I).ToString, J + 1, 6)
            NewRow.Item("OrderID") = lblOrderID.Text
            NewRow.Item("ProductID") = ID
            NewRow.Item("Quantity") = Q
            PurchasesTable.Rows.Add(NewRow)
            'Update number sold
            'find row with correct productid
            Dim PR As Integer
            For PR = 0 To ProductsTable.Rows.Count - 1
                If ProductsTable.Rows(PR).Item("ProductID").ToString = ID Then
                    Exit For
                End If
            Next
            ProductsTable.Rows(PR).Item("NumberSold") = CInt(ProductsTable.Rows(PR).Item("NumberSold")) + Q
        Next I
        If MessageBox.Show("Do you want a printed invoice?", "Print Inquiry", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            'Call PrintInvoice()
        End If
        Call NewOrder()
    End Sub

    Private Sub BtnSearchBarCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearchBarCode.Click
        If txtFind.Text = "" Then Exit Sub
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

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub TxtInput_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescription.KeyPress, txtFind.KeyPress, txtPrice.KeyPress
        Dim WhichBox As TextBox = CType(sender, TextBox)
        If e.KeyChar = ControlChars.Cr Then
            Select Case WhichBox.Name
                Case "txtDescription"
                    txtFind.Focus()
                Case "txtProductID"
                    txtPrice.Focus()
                Case "txtPrice"
                    txtDescription.Focus()
            End Select
        End If
    End Sub
    Private Sub BtnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirstP.Click
        ProductsManager.Position = 0
    End Sub
    Private Sub BtnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLastP.Click
        ProductsManager.Position = ProductsManager.Count - 1
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub

    Private Sub BtnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviousP.Click
        If ProductsManager.Position = 0 Then Console.Beep()
        ProductsManager.Position -= 1
    End Sub

    Private Sub BtnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextP.Click
        If ProductsManager.Position = ProductsManager.Count - 1 Then Console.Beep()
        ProductsManager.Position += 1
    End Sub
End Class