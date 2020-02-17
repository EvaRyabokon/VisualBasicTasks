Imports System.IO

Public Class DataWriter

    Private SaveButton As New Button()
    Private InputTextBox As New TextBox()
    Private TextLabel As New Label()
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InputTextBox.Location = New Point(20, 10)
        InputTextBox.Width = 500

        SaveButton.Text = "Сохранить"
        SaveButton.Location = New Point(25, 45)

        TextLabel.Location = New Point(20, 80)
        TextLabel.Width = 500

        Me.Height = 300
        Me.Width = 560

        Me.Controls.Add(SaveButton)
        Me.Controls.Add(InputTextBox)
        Me.Controls.Add(TextLabel)

        AddHandler SaveButton.Click, AddressOf UpdateButton_Click

    End Sub

    Private Sub UpdateButton_Click(sender As Object, e As EventArgs)
        
        Dim input AS String
        input = Me.InputTextBox.Text


        Dim filePath As String = "text_file.txt"
        Dim savedLastItem As String

        If File.Exists(filePath)
            savedLastItem = File.ReadAllLines(filePath).Last()
        End If

        Dim sw As StreamWriter

        Try
            sw = File.AppendText(filePath)
            sw.WriteLine( Environment.NewLine &
                          "Время записи: " &
                          DateTime.Now.ToString()&
                          Environment.NewLine &
                          input)
            sw.Close()

        Catch ex As Exception
            MsgBox("Error Creating File")
        End Try


        If Not String.Equals(input, savedLastItem)
            TextLabel.Text = "строка не найдена"
        Else 
            TextLabel.Text = input
        End If

    End Sub

End Class