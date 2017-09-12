Imports System.Data.OleDb

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'dichiaro la variabile del nome utente
        Dim nomeutente As String = TextBox1.Text
        'dichiaro la variabile della password
        Dim password As String = TextBox2.Text
        'controllo che la variabile nome utente sia valorizzata
        If String.IsNullOrEmpty(nomeutente) Or String.IsNullOrWhiteSpace(nomeutente) Then
            'se non è valorizzata restituisce un messaggio di errore
            MsgBox("Attenzione! Nome utente non valido")
        Else
            'se il nome utente è valorizzato, controllo che la password sia valorizzata
            If String.IsNullOrEmpty(password) Or String.IsNullOrWhiteSpace(password) Then
                'se la password non è valorizzata, restituisce un messaggio di errore
                MsgBox("Attenzione! Password non valida")
            Else
                'se anche la password è valorizzata, si connette al database e verifica l'esistenza dell'account
                'dichiaro la stringa di connessione
                Dim cs As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='C:\Users\Alessandro Fiori\Desktop\Analisi\Progetto Votazione SourceForge\Database.accdb'")
                'apro la connessione
                cs.Open()
                'dichiaro la query da eseguire
                Dim command As New OleDbCommand("SELECT Login.[Nome utente], Login.Password FROM Login WHERE ((((([Login].[Nome utente]=" & Chr(34) & nomeutente & Chr(34) & "))) And ([Login].[Password]=" & Chr(34) & password & Chr(34) & ")));", cs)
                'dichiaro il data reader ed eseguo la query
                Dim dr As OleDbDataReader = command.ExecuteReader
                'controllo che il nome utente o la password siano errati
                If dr.Read = False Then
                    'se errati, restituisce un messaggio di errore
                    MsgBox("Attenzione! Nome utente o password errata")
                Else
                    'se esatti, esegue un ultimo controllo di tipo case sensitive
                    Dim nomeutenterestituito As String = dr(0)
                    Dim passwordrestituita As String = dr(1)
                    If nomeutente <> nomeutenterestituito Then
                        'se il controllo case sensitive è errato, restituisce un messaggio di errore
                        MsgBox("Attenzione! Nome utente o password errata")
                    Else
                        'esegue la stessa operazione per la password
                        If password <> passwordrestituita Then
                            'se il controllo case sensitive è errato, restituisce un messaggio di errore
                            MsgBox("Attenzione! Nome utente o password errata")
                        Else
                            Dim command1 As New OleDbCommand("SELECT Votanti.[Nome Utente] FROM Votanti WHERE ((([Votanti].[Nome Utente]=" & Chr(34) & nomeutente & Chr(34) & ")));", cs)
                            Dim dr1 As OleDbDataReader = command1.ExecuteReader
                            If dr1.Read = False Then
                                'se tutti i dati di accesso sono ok, salva nelle impostazioni il nome utente (che servirà a generare il token) ed entra nel programma
                                My.Settings("Utente") = nomeutente
                                Form2.Activate()
                                Form2.Show()
                                Me.Close()
                            Else
                                MsgBox("Attenzione! Ci risulta tu abbia già espresso il voto. Non è possibile continuare")
                                Me.Close()
                            End If
                        End If
                    End If
                End If
                'chiude la connessione una volta terminata l'operazione
                cs.Close()
            End If
        End If
    End Sub
End Class
