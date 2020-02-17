Imports System.IO

Module FileFolderWriter
    Sub Main(args As String())

        Dim inputPath As String = Console.ReadLine() 'считываем путь с консоли
        Dim folders() As String
        Dim folderPaths As String

        Try
            folders = IO.Directory.GetDirectories(inputPath, "*", IO.SearchOption.TopDirectoryOnly) 'пытаемся получить перечень папок, находящихся в текущей папке по введеному пути

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
            
            sw.WriteLine("Количество папок в текущей папке: " & 'записываем нужную информацию в файл
                         folders.Count.ToString &
                         Environment.NewLine &
                         "Время запуска: " & DateTime.Now  &
                         Environment.NewLine &
                         "Пути к папкам:" &
                         Environment.NewLine &
                         folderPaths)
            sw.Close()

        Catch ex As Exception
            Console.WriteLine("Error Creating File")
        End Try

    End Sub
End Module
