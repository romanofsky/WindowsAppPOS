<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmKWsales
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnCustomers = New System.Windows.Forms.Button()
        Me.btnManual = New System.Windows.Forms.Button()
        Me.btnOptions = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grpOrder = New System.Windows.Forms.GroupBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCheckOut = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnProducts = New System.Windows.Forms.Button()
        Me.btnMenu = New System.Windows.Forms.Button()
        Me.btnDeli = New System.Windows.Forms.Button()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblOrderID = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnSubmitOrder = New System.Windows.Forms.Button()
        Me.grpOrder.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCustomers
        '
        Me.btnCustomers.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.btnCustomers.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCustomers.Location = New System.Drawing.Point(433, 12)
        Me.btnCustomers.Name = "btnCustomers"
        Me.btnCustomers.Size = New System.Drawing.Size(109, 34)
        Me.btnCustomers.TabIndex = 0
        Me.btnCustomers.Text = "Customers"
        Me.btnCustomers.UseVisualStyleBackColor = False
        '
        'btnManual
        '
        Me.btnManual.BackColor = System.Drawing.Color.Green
        Me.btnManual.ForeColor = System.Drawing.Color.White
        Me.btnManual.Location = New System.Drawing.Point(570, 12)
        Me.btnManual.Name = "btnManual"
        Me.btnManual.Size = New System.Drawing.Size(87, 34)
        Me.btnManual.TabIndex = 1
        Me.btnManual.Text = "Manual"
        Me.btnManual.UseVisualStyleBackColor = False
        '
        'btnOptions
        '
        Me.btnOptions.BackColor = System.Drawing.Color.Blue
        Me.btnOptions.ForeColor = System.Drawing.Color.White
        Me.btnOptions.Location = New System.Drawing.Point(695, 12)
        Me.btnOptions.Name = "btnOptions"
        Me.btnOptions.Size = New System.Drawing.Size(82, 34)
        Me.btnOptions.TabIndex = 2
        Me.btnOptions.Text = "Options"
        Me.btnOptions.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1000, 634)
        Me.Panel1.TabIndex = 3
        '
        'grpOrder
        '
        Me.grpOrder.BackColor = System.Drawing.SystemColors.Highlight
        Me.grpOrder.Controls.Add(Me.ComboBox1)
        Me.grpOrder.Controls.Add(Me.Label1)
        Me.grpOrder.Controls.Add(Me.btnCheckOut)
        Me.grpOrder.Controls.Add(Me.Label2)
        Me.grpOrder.Controls.Add(Me.btnProducts)
        Me.grpOrder.Controls.Add(Me.btnMenu)
        Me.grpOrder.Controls.Add(Me.btnDeli)
        Me.grpOrder.Controls.Add(Me.lblDate)
        Me.grpOrder.Controls.Add(Me.lblOrderID)
        Me.grpOrder.Controls.Add(Me.btnOptions)
        Me.grpOrder.Controls.Add(Me.Label3)
        Me.grpOrder.Controls.Add(Me.btnManual)
        Me.grpOrder.Controls.Add(Me.btnCustomers)
        Me.grpOrder.Controls.Add(Me.btnExit)
        Me.grpOrder.Controls.Add(Me.btnSubmitOrder)
        Me.grpOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpOrder.Location = New System.Drawing.Point(12, 653)
        Me.grpOrder.Margin = New System.Windows.Forms.Padding(4)
        Me.grpOrder.Name = "grpOrder"
        Me.grpOrder.Padding = New System.Windows.Forms.Padding(4)
        Me.grpOrder.Size = New System.Drawing.Size(999, 102)
        Me.grpOrder.TabIndex = 21
        Me.grpOrder.TabStop = False
        Me.grpOrder.Text = "Main"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(298, 16)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(128, 28)
        Me.ComboBox1.TabIndex = 53
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(297, 28)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "My Point Of Sales Order:"
        '
        'btnCheckOut
        '
        Me.btnCheckOut.BackColor = System.Drawing.Color.Yellow
        Me.btnCheckOut.ForeColor = System.Drawing.Color.Red
        Me.btnCheckOut.Location = New System.Drawing.Point(802, 26)
        Me.btnCheckOut.Name = "btnCheckOut"
        Me.btnCheckOut.Size = New System.Drawing.Size(75, 55)
        Me.btnCheckOut.TabIndex = 10
        Me.btnCheckOut.Text = "Check Out"
        Me.btnCheckOut.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(187, 20)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Semiintegration.COM"
        '
        'btnProducts
        '
        Me.btnProducts.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnProducts.ForeColor = System.Drawing.Color.White
        Me.btnProducts.Location = New System.Drawing.Point(684, 60)
        Me.btnProducts.Name = "btnProducts"
        Me.btnProducts.Size = New System.Drawing.Size(93, 34)
        Me.btnProducts.TabIndex = 8
        Me.btnProducts.Text = "Products"
        Me.btnProducts.UseVisualStyleBackColor = False
        '
        'btnMenu
        '
        Me.btnMenu.BackColor = System.Drawing.Color.Blue
        Me.btnMenu.ForeColor = System.Drawing.Color.White
        Me.btnMenu.Location = New System.Drawing.Point(570, 60)
        Me.btnMenu.Name = "btnMenu"
        Me.btnMenu.Size = New System.Drawing.Size(82, 34)
        Me.btnMenu.TabIndex = 7
        Me.btnMenu.Text = "Menu"
        Me.btnMenu.UseVisualStyleBackColor = False
        '
        'btnDeli
        '
        Me.btnDeli.BackColor = System.Drawing.Color.Red
        Me.btnDeli.ForeColor = System.Drawing.Color.White
        Me.btnDeli.Location = New System.Drawing.Point(460, 61)
        Me.btnDeli.Name = "btnDeli"
        Me.btnDeli.Size = New System.Drawing.Size(82, 34)
        Me.btnDeli.TabIndex = 6
        Me.btnDeli.Text = "Deli"
        Me.btnDeli.UseVisualStyleBackColor = False
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.Location = New System.Drawing.Point(143, 62)
        Me.lblDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(0, 20)
        Me.lblDate.TabIndex = 5
        '
        'lblOrderID
        '
        Me.lblOrderID.AutoSize = True
        Me.lblOrderID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrderID.Location = New System.Drawing.Point(143, 26)
        Me.lblOrderID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOrderID.Name = "lblOrderID"
        Me.lblOrderID.Size = New System.Drawing.Size(0, 20)
        Me.lblOrderID.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 48)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(219, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Deli / Bodega Version"
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Red
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.White
        Me.btnExit.Location = New System.Drawing.Point(885, 7)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(93, 34)
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnSubmitOrder
        '
        Me.btnSubmitOrder.BackColor = System.Drawing.Color.Green
        Me.btnSubmitOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubmitOrder.ForeColor = System.Drawing.Color.White
        Me.btnSubmitOrder.Location = New System.Drawing.Point(884, 60)
        Me.btnSubmitOrder.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSubmitOrder.Name = "btnSubmitOrder"
        Me.btnSubmitOrder.Size = New System.Drawing.Size(93, 34)
        Me.btnSubmitOrder.TabIndex = 0
        Me.btnSubmitOrder.Text = "Submit"
        Me.btnSubmitOrder.UseVisualStyleBackColor = False
        '
        'frmKWsales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.Controls.Add(Me.grpOrder)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmKWsales"
        Me.Text = "MainForm"
        Me.grpOrder.ResumeLayout(False)
        Me.grpOrder.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnCustomers As Button
    Friend WithEvents btnManual As Button
    Friend WithEvents btnOptions As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents grpOrder As GroupBox
    Friend WithEvents lblDate As Label
    Friend WithEvents lblOrderID As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnExit As Button
    Friend WithEvents btnSubmitOrder As Button
    Friend WithEvents btnProducts As Button
    Friend WithEvents btnMenu As Button
    Friend WithEvents btnDeli As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents btnCheckOut As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ComboBox1 As ComboBox
End Class
