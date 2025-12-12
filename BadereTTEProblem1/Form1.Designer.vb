<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtArtifactName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtOriginCountry = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtYearDiscovered = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbCondition = New System.Windows.Forms.ComboBox()
        Me.btnSaveArtifact = New System.Windows.Forms.Button()
        Me.btnUpdateArtifact = New System.Windows.Forms.Button()
        Me.btnDeleteArtifact = New System.Windows.Forms.Button()
        Me.btnLoadArtifact = New System.Windows.Forms.Button()
        Me.dgvArtifacts = New System.Windows.Forms.DataGridView()
        CType(Me.dgvArtifacts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtArtifactName
        '
        Me.txtArtifactName.Location = New System.Drawing.Point(192, 69)
        Me.txtArtifactName.Name = "txtArtifactName"
        Me.txtArtifactName.Size = New System.Drawing.Size(120, 20)
        Me.txtArtifactName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(97, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Artifact Name:"
        '
        'txtOriginCountry
        '
        Me.txtOriginCountry.Location = New System.Drawing.Point(192, 112)
        Me.txtOriginCountry.Name = "txtOriginCountry"
        Me.txtOriginCountry.Size = New System.Drawing.Size(120, 20)
        Me.txtOriginCountry.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(97, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Origin Country:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(97, 163)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Year Discovered:"
        '
        'txtYearDiscovered
        '
        Me.txtYearDiscovered.Location = New System.Drawing.Point(192, 156)
        Me.txtYearDiscovered.Name = "txtYearDiscovered"
        Me.txtYearDiscovered.Size = New System.Drawing.Size(120, 20)
        Me.txtYearDiscovered.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(97, 207)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Condition:"
        '
        'cmbCondition
        '
        Me.cmbCondition.FormattingEnabled = True
        Me.cmbCondition.Items.AddRange(New Object() {"Excellent", "Good", "Fair", "Poor"})
        Me.cmbCondition.Location = New System.Drawing.Point(191, 199)
        Me.cmbCondition.Name = "cmbCondition"
        Me.cmbCondition.Size = New System.Drawing.Size(121, 21)
        Me.cmbCondition.TabIndex = 7
        '
        'btnSaveArtifact
        '
        Me.btnSaveArtifact.Location = New System.Drawing.Point(159, 246)
        Me.btnSaveArtifact.Name = "btnSaveArtifact"
        Me.btnSaveArtifact.Size = New System.Drawing.Size(109, 23)
        Me.btnSaveArtifact.TabIndex = 8
        Me.btnSaveArtifact.Text = "Save Artifact"
        Me.btnSaveArtifact.UseVisualStyleBackColor = True
        '
        'btnUpdateArtifact
        '
        Me.btnUpdateArtifact.Location = New System.Drawing.Point(159, 275)
        Me.btnUpdateArtifact.Name = "btnUpdateArtifact"
        Me.btnUpdateArtifact.Size = New System.Drawing.Size(109, 23)
        Me.btnUpdateArtifact.TabIndex = 9
        Me.btnUpdateArtifact.Text = "Update Artifact"
        Me.btnUpdateArtifact.UseVisualStyleBackColor = True
        '
        'btnDeleteArtifact
        '
        Me.btnDeleteArtifact.Location = New System.Drawing.Point(159, 304)
        Me.btnDeleteArtifact.Name = "btnDeleteArtifact"
        Me.btnDeleteArtifact.Size = New System.Drawing.Size(109, 23)
        Me.btnDeleteArtifact.TabIndex = 10
        Me.btnDeleteArtifact.Text = "Delete Artifact"
        Me.btnDeleteArtifact.UseVisualStyleBackColor = True
        '
        'btnLoadArtifact
        '
        Me.btnLoadArtifact.Location = New System.Drawing.Point(159, 333)
        Me.btnLoadArtifact.Name = "btnLoadArtifact"
        Me.btnLoadArtifact.Size = New System.Drawing.Size(109, 23)
        Me.btnLoadArtifact.TabIndex = 11
        Me.btnLoadArtifact.Text = "Load Artifact"
        Me.btnLoadArtifact.UseVisualStyleBackColor = True
        '
        'dgvArtifacts
        '
        Me.dgvArtifacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvArtifacts.Location = New System.Drawing.Point(28, 405)
        Me.dgvArtifacts.Name = "dgvArtifacts"
        Me.dgvArtifacts.Size = New System.Drawing.Size(372, 150)
        Me.dgvArtifacts.TabIndex = 12
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(426, 585)
        Me.Controls.Add(Me.dgvArtifacts)
        Me.Controls.Add(Me.btnLoadArtifact)
        Me.Controls.Add(Me.btnDeleteArtifact)
        Me.Controls.Add(Me.btnUpdateArtifact)
        Me.Controls.Add(Me.btnSaveArtifact)
        Me.Controls.Add(Me.cmbCondition)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtYearDiscovered)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtOriginCountry)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtArtifactName)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.dgvArtifacts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtArtifactName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtOriginCountry As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtYearDiscovered As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbCondition As ComboBox
    Friend WithEvents btnSaveArtifact As Button
    Friend WithEvents btnUpdateArtifact As Button
    Friend WithEvents btnDeleteArtifact As Button
    Friend WithEvents btnLoadArtifact As Button
    Friend WithEvents dgvArtifacts As DataGridView

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
