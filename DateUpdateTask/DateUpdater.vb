Imports System.IO
 
Public Class DateUpdater
 
    Private ClearButton As New Button()
    Private UpdateButton As New Button()
    Private DateTextBox As New TextBox()
 
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
 
        DateTextBox.Location = New Point(10, 10)
 
        ClearButton.Text = "Очистить"
        ClearButton.Location = New Point(25, 45)
 
        UpdateButton.Text = "Обновить"
        UpdateButton.Location = New Point(ClearButton.Left, ClearButton.Height + ClearButton.Top + 10)
 
        Me.Height = 300
        Me.Width = 560
 
        Me.Controls.Add(ClearButton)
        Me.Controls.Add(UpdateButton)
        Me.Controls.Add(DateTextBox)
 
        AddHandler UpdateButton.Click, AddressOf UpdateButton_Click
        AddHandler ClearButton.Click, AddressOf ClearButton_Click
    End Sub
 
    Private Sub UpdateButton_Click(sender As Object, e As EventArgs)
 
        Dim dateFourDaysAgo = DateTime.Now.AddDays(-4).ToString("dd.MM.yyyy")
        DateTextBox.Text = dateFourDaysAgo
 
        Dim filePath As String = "text_file.txt"
 
        Dim sw As StreamWriter

        Try
            sw = File.AppendText(filePath)
            sw.WriteLine(dateFourDaysAgo)
            sw.Close()

        Catch ex As Exception
            MsgBox("Error Creating File")
        End Try

    End Sub
 
    Private Sub ClearButton_Click(sender As Object, e As EventArgs)
 
        DateTextBox.Text = ""
 
    End Sub
 
End Class