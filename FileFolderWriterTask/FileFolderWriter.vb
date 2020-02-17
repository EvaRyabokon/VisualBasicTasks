Imports System.IO

Module FileFolderWriter
    Sub Main(args As String())

        Dim inputPath As String = Console.ReadLine() '��������� ���� � �������
        Dim folders() As String
        Dim folderPaths As String

        Try
            folders = IO.Directory.GetDirectories(inputPath, "*", IO.SearchOption.TopDirectoryOnly) '�������� �������� �������� �����, ����������� � ������� ����� �� ��������� ����

        Catch ex As Exception
            Console.WriteLine("Error Geting File Directory")
        End Try

        If (folders IsNot Nothing AndAlso folders.Count > 0)
            For Each item In folders
                folderPaths += item
                folderPaths += Environment.NewLine
            Next
        End If


        Dim strFile As String = "log_file.txt"
        Dim sw As StreamWriter

        Try
            If File.Exists(strFile)
                IO.File.WriteAllText(strFile, "")
            End If
            
            sw = File.AppendText(strFile)
            
            sw.WriteLine("���������� ����� � ������� �����: " & '���������� ������ ���������� � ����
                         folders.Count.ToString &
                         Environment.NewLine &
                         "����� �������: " & DateTime.Now  &
                         Environment.NewLine &
                         "���� � ������:" &
                         Environment.NewLine &
                         folderPaths)
            sw.Close()

        Catch ex As Exception
            Console.WriteLine("Error Creating File")
        End Try

    End Sub
End Module