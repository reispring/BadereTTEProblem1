Imports MySql.Data.MySqlClient

Public Class Form1


    Private conn As New MySqlConnection("server=localhost;userid=root;password=root;database=museum_db;")
    Private selectedId As Integer = -1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbCondition.Items.Clear()
        cmbCondition.Items.AddRange(New String() {"Excellent", "Good", "Fair", "Poor"})
        LoadRecords()
    End Sub

    Private Sub LoadRecords()
        Try
            Dim sql As String = "SELECT id, artifact_name, country, year_found, `condition` " &
                                "FROM artifacts_tbl WHERE is_deleted = 0"

            Dim da As New MySqlDataAdapter(sql, conn)
            Dim dt As New DataTable()
            da.Fill(dt)
            dgvArtifacts.DataSource = dt

        Catch ex As Exception
            MessageBox.Show("Error loading records: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ClearInputs()
        End Try
    End Sub

    Private Sub ClearInputs()
        txtArtifactName.Clear()
        txtOriginCountry.Clear()
        txtYearDiscovered.Clear()
        cmbCondition.SelectedIndex = -1
        selectedId = -1
    End Sub

    Private Function ValidateFields() As Boolean
        If String.IsNullOrWhiteSpace(txtArtifactName.Text) Then
            MessageBox.Show("Artifact name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Dim yearVal As Integer
        If Not Integer.TryParse(txtYearDiscovered.Text.Trim(), yearVal) Then
            MessageBox.Show("Year found must be numeric.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If cmbCondition.SelectedIndex = -1 Then
            MessageBox.Show("Please select condition.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Sub btnSaveArtifact_Click(sender As Object, e As EventArgs) Handles btnSaveArtifact.Click
        If Not ValidateFields() Then Exit Sub

        Dim yearVal As Integer
        Integer.TryParse(txtYearDiscovered.Text.Trim(), yearVal)
        Dim sql As String = "INSERT INTO artifacts_tbl " &
                        "(artifact_name, country, year_found, `condition`, is_deleted) " &
                        "VALUES (@name, @country, @year, @cond, 0);"

        Try
            conn.Open()

            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@name", txtArtifactName.Text.Trim())
                cmd.Parameters.AddWithValue("@country", txtOriginCountry.Text.Trim())
                cmd.Parameters.AddWithValue("@year", yearVal)
                cmd.Parameters.AddWithValue("@cond", cmbCondition.Text.Trim())

                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Artifact saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As MySqlException
            MessageBox.Show("MySQL Error: " & ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception
            MessageBox.Show("General Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            LoadRecords()
        End Try
    End Sub



    Private Sub dgvArtifacts_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvArtifacts.CellClick
        If e.RowIndex < 0 Then Exit Sub

        Try
            Dim row As DataGridViewRow = dgvArtifacts.Rows(e.RowIndex)
            selectedId = Convert.ToInt32(row.Cells("id").Value)
            txtArtifactName.Text = row.Cells("artifact_name").Value.ToString()
            txtOriginCountry.Text = row.Cells("country").Value.ToString()
            txtYearDiscovered.Text = row.Cells("year_found").Value.ToString()
            cmbCondition.Text = row.Cells("condition").Value.ToString()
        Catch ex As Exception
            MessageBox.Show("Error selecting row: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdateArtifact_Click(sender As Object, e As EventArgs) Handles btnUpdateArtifact.Click
        If selectedId = -1 Then
            MessageBox.Show("Select a record first.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not ValidateFields() Then Exit Sub

        Dim yearVal As Integer = Integer.Parse(txtYearDiscovered.Text.Trim())

        Dim sql As String = "UPDATE artifacts_tbl SET " &
                            "artifact_name = @name, country = @country, year_found = @year, `condition` = @cond " &
                            "WHERE id = @id;"

        Try
            conn.Open()
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@name", txtArtifactName.Text.Trim())
                cmd.Parameters.AddWithValue("@country", txtOriginCountry.Text.Trim())
                cmd.Parameters.AddWithValue("@year", yearVal)
                cmd.Parameters.AddWithValue("@cond", cmbCondition.Text.Trim())
                cmd.Parameters.AddWithValue("@id", selectedId)

                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Record updated.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error updating artifact: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            LoadRecords()
        End Try
    End Sub

    Private Sub btnDeleteArtifact_Click(sender As Object, e As EventArgs) Handles btnDeleteArtifact.Click
        If selectedId = -1 Then
            MessageBox.Show("Select a record first.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If MessageBox.Show("Are you sure you want to delete this artifact?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Dim sql As String = "UPDATE artifacts_tbl SET is_deleted = 1 WHERE id = @id"

        Try
            conn.Open()
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@id", selectedId)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Record deleted (soft).", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error deleting artifact: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
            LoadRecords()
        End Try
    End Sub

    Private Sub btnLoadArtifact_Click(sender As Object, e As EventArgs) Handles btnLoadArtifact.Click
        LoadRecords()
    End Sub

End Class
