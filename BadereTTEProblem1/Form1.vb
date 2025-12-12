Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient

Public Class Form1
    Dim conn As MySqlConnection
    Dim COMMAND As MySqlCommand

    Private connStr As String = "server=localhost;userid=root;password=root;database=museum_db"
    Private selectedId As Integer = -1

    Private Sub FormArtifact_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbCondition.Items.Clear()
        cmbCondition.Items.AddRange(New String() {"Excellent", "Good", "Fair", "Poor"})
        LoadRecords()
    End Sub
    Private Sub LoadRecords()
        Using conn As New MySqlConnection(connStr)
            conn.Open()
            Dim sql As String = "SELECT id, artifact_name, country, year_found, condition FROM artifacts_tbl WHERE is_deleted = 0"
            Using cmd As New MySqlCommand(sql, conn)
                Using adapter As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)
                    dgvArtifacts.DataSource = dt
                End Using
            End Using
        End Using
        ClearInputs()
    End Sub

    Private Sub ClearInputs()
        txtArtifactName.Text = ""
        txtOriginCountry.Text = ""
        txtYearDiscovered.Text = ""
        cmbCondition.SelectedIndex = -1
        selectedId = -1
    End Sub

    Private Function ValidateInputs() As Boolean
        If String.IsNullOrWhiteSpace(txtArtifactName.Text) Then
            MessageBox.Show("Artifact name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Dim yearVal As Integer
        If Not Integer.TryParse(txtYearDiscovered.Text, yearVal) Then
            MessageBox.Show("Year found must be numeric.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If cmbCondition.SelectedIndex = -1 Then
            MessageBox.Show("Please select condition.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSaveArtifact.Click
        If Not ValidateInputs() Then Return
        Using conn As New MySqlConnection(connStr)
            conn.Open()
            Dim sql As String = "INSERT INTO artifact_tbl (artifact_name, country, year_found, condition) VALUES (@name, @country, @year, @cond)"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@name", txtArtifactName.Text.Trim())
                cmd.Parameters.AddWithValue("@country", txtOriginCountry.Text.Trim())
                cmd.Parameters.AddWithValue("@year", Integer.Parse(txtYearDiscovered.Text.Trim()))
                cmd.Parameters.AddWithValue("@cond", cmbCondition.SelectedItem.ToString())
                cmd.ExecuteNonQuery()
            End Using
        End Using
        MessageBox.Show("Artifact saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
        LoadRecords()
    End Sub

    Private Sub dgvArtifacts_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArtifacts.CellClick
        If e.RowIndex < 0 Then Return
        Dim row As DataGridViewRow = dgvArtifacts.Rows(e.RowIndex)
        selectedId = Convert.ToInt32(row.Cells("id").Value)
        txtArtifactName.Text = row.Cells("artifact_name").Value.ToString()
        txtOriginCountry.Text = row.Cells("country").Value.ToString()
        txtYearDiscovered.Text = row.Cells("year_found").Value.ToString()
        cmbCondition.SelectedItem = row.Cells("condition").Value.ToString()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdateArtifact.Click
        If selectedId = -1 Then
            MessageBox.Show("Select a record first.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If Not ValidateInputs() Then Return
        Using conn As New MySqlConnection(connStr)
            conn.Open()
            Dim sql As String = "UPDATE artifact_tbl SET artifact_name=@name, country=@country, year_found=@year, `condition`=@cond WHERE id=@id"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@name", txtArtifactName.Text.Trim())
                cmd.Parameters.AddWithValue("@country", txtOriginCountry.Text.Trim())
                cmd.Parameters.AddWithValue("@year", Integer.Parse(txtYearDiscovered.Text.Trim()))
                cmd.Parameters.AddWithValue("@cond", cmbCondition.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@id", selectedId)
                cmd.ExecuteNonQuery()
            End Using
        End Using
        MessageBox.Show("Record updated.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
        LoadRecords()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDeleteArtifact.Click
        If selectedId = -1 Then
            MessageBox.Show("Select a record first.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If MessageBox.Show("Are you sure you want to delete (soft)?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then
            Return
        End If
        Using conn As New MySqlConnection(connStr)
            conn.Open()
            Dim sql As String = "UPDATE artifact_tbl SET is_deleted = 1 WHERE id = @id"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@id", selectedId)
                cmd.ExecuteNonQuery()
            End Using
        End Using
        MessageBox.Show("Record deleted (soft).", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
        LoadRecords()
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoadArtifact.Click
        LoadRecords()
    End Sub
End Class




