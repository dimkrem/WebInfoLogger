Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Net
Imports System.Management
Imports System.Text
Imports System.Net.NetworkInformation
Imports System.IO
Imports System.Net.Mail

'------- With this Code we can get information from System32 Class -------------
Module Module1

    Public Function GetInfo(stringIn As String) As String

        Dim sbOutput As New StringBuilder(String.Empty)
        Try
            Dim mcInfo As New ManagementClass(stringIn)
            Dim mcInfoCol As ManagementObjectCollection = _
                                                      mcInfo.GetInstances()
            Dim pdInfo As PropertyDataCollection = mcInfo.Properties
            For Each objMng As ManagementObject In mcInfoCol
                For Each prop As PropertyData In pdInfo
                    Try

                        sbOutput.AppendLine(prop.Name + ":  " + _
                           objMng.Properties(prop.Name).Value)
                    Catch
                    End Try
                Next
                sbOutput.AppendLine()
            Next

        Catch
        End Try

        Return sbOutput.ToString()

    End Function

End Module
'----------------------------------------------------------------

Partial Class _Default

    Inherits System.Web.UI.Page

    Dim MyHostName As String = ""
    Dim MyIPAddress As String = ""
    Dim IPOfTheRemoteClient As String = ""
    Dim DNSOfTheRemoteClient As String = ""
    Dim MyComputerOS As String = ""
    Dim MyPcsUserName As String = ""
    Dim MyRAM As String = ""
    Dim MyProccesorInfo As String
    Dim IPv6Address As String = ""
    Dim hostEntry As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())
    Dim theDate As DateTime = System.DateTime.Now
    Dim directoryPath As String = ""
  
 




    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
   
        Try
            Dim myIPs As String = My.Computer.Name
            Dim localIp As String

            For Each myIP As System.Net.IPAddress In System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName).AddressList
                If myIP.AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then
                    localIp = myIP.ToString()

                    For Each adapter As Net.NetworkInformation.NetworkInterface In Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
                        For Each unicastIPAddressInformation As Net.NetworkInformation.UnicastIPAddressInformation In adapter.GetIPProperties().UnicastAddresses
                            If unicastIPAddressInformation.Address.AddressFamily = Net.Sockets.AddressFamily.InterNetwork Then
                                If myIP.Equals(unicastIPAddressInformation.Address) Then
                                    'Subnet Mask
                                    Label16.Text = "Subnet Mask is = : " & unicastIPAddressInformation.IPv4Mask.ToString()

                                    Dim adapterProperties As Net.NetworkInformation.IPInterfaceProperties = adapter.GetIPProperties()
                                    For Each gateway As Net.NetworkInformation.GatewayIPAddressInformation In adapterProperties.GatewayAddresses
                                        'Default Gateway
                                        Label17.Text = "The Default Getaway is = : " & gateway.Address.ToString()
                                    Next

                                    'DNS1
                                    If adapterProperties.DnsAddresses.Count > 0 Then
                                        Label18.Text = "No1 Domain Server (DNS) is  = : " & adapterProperties.DnsAddresses(0).ToString()
                                    End If

                                    'DNS2
                                    If adapterProperties.DnsAddresses.Count > 1 Then
                                        Label19.Text = "No2 Domain Server (DNS) is = : " & adapterProperties.DnsAddresses(1).ToString()

                                    End If
                                End If
                            End If
                        Next

                    Next
                End If
            Next

            '----------ping IP in order to define if connection is ok--

            If My.Computer.Network.Ping(localIp) Then
                Label12.Text = "***** After Pinging the IP " & localIp & " the results is that the connection is OK *****"
            Else
                Label12.Text = "***** After Pinging the IP " & localIp & " the result is that the connection is not OK *****"
            End If
            '------------------

            '---about getting MAC address
            Dim networkInterface = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
            Dim firstNetwork = networkInterface.FirstOrDefault(Function(x As System.Net.NetworkInformation.NetworkInterface) _
                x.OperationalStatus = System.Net.NetworkInformation.OperationalStatus.Up)
            Dim firstMacAddressOfWorkingNetworkAdapter = firstNetwork.GetPhysicalAddress.ToString()
            '-------------------------------------------


            '-----------------------Get IPV6-------------------------------------------
            Try
                IPv6Address = hostEntry.AddressList().Where(Function(a) a.AddressFamily = Sockets.AddressFamily.InterNetworkV6).First().ToString()
            Catch
            End Try
            '--------------------------------------------------------------------




            MyHostName = "The name of the host is = " & myIPs
            MyIPAddress = "The IP address of host is = " & localIp
            IPOfTheRemoteClient = "The IP of the remote client is = " & Request.UserHostAddress()
            DNSOfTheRemoteClient = "The DNS name of the remote client is = " & Request.UserHostName()
            MyComputerOS = "The operating system is = : " & My.Computer.Info.OSFullName
            MyPcsUserName = "The User Name is = : " & Environment.UserName
            MyRAM = "RAM =  " & My.Computer.Info.TotalPhysicalMemory
            MyProccesorInfo = "Proccessor Info = : " & My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\SYSTEM\CentralProcessor\0", "ProcessorNameString", Nothing)
            directoryPath = "The directory path is = : " & Environment.SystemDirectory




            Label2.Text = MyHostName
            Label3.Text = MyPcsUserName
            Label4.Text = MyIPAddress
            Label5.Text = "IPv6 = :" & IPv6Address
            Label6.Text = "MAC Address = :" & firstMacAddressOfWorkingNetworkAdapter
            Label7.Text = MyComputerOS
            Label8.Text = MyRAM
            Label9.Text = MyProccesorInfo
            Label10.Text = DNSOfTheRemoteClient
            Label11.Text = IPOfTheRemoteClient
            Label13.Text = "Specific Info = :" & GetInfo("Win32_SystemBIOS")
            Label14.Text = "DATE/TIME : " & theDate.ToString()
            Label15.Text = directoryPath







        Catch ex As Exception
            Console.WriteLine("Something went wrong..")
        End Try
    End Sub

    Protected Sub ButtonText_Click(sender As Object, e As EventArgs) Handles ButtonText.Click
        Dim objWriter As New System.IO.StreamWriter("D:\ connextion_details.txt", False)

        Try
            objWriter.WriteLine(Label14.Text)
            objWriter.WriteLine("/***** Details about host *****/ ")
            objWriter.WriteLine(Label12.Text)
            objWriter.WriteLine(Label2.Text)
            objWriter.WriteLine(Label3.Text)

            objWriter.WriteLine(Label5.Text)
            objWriter.WriteLine(Label6.Text)
            objWriter.WriteLine(Label7.Text)
            objWriter.WriteLine(Label8.Text)
            objWriter.WriteLine(Label9.Text)
            objWriter.WriteLine(Label12.Text)
            objWriter.WriteLine(Label15.Text)
            objWriter.WriteLine(Label16.Text)
            objWriter.WriteLine(Label17.Text)
            objWriter.WriteLine(Label18.Text)
            objWriter.WriteLine(Label19.Text)

            objWriter.WriteLine(" /***** Details about client *****/ ")
            objWriter.WriteLine(Label10.Text)
            objWriter.WriteLine(Label11.Text)
            objWriter.Close()

            MesgBox()
        Catch ex As Exception
            MesgBox("Something went wrong. Please try again.")
        End Try
    End Sub


    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Response.Redirect("index.html")
    End Sub

    Private Sub MesgBox(Optional ByVal sMessage As String = Nothing)
        If (sMessage <> Nothing) Then
            Response.Write(sMessage)
        Else
            Dim msg As String
            msg = "file has been written sucessfully to C:\ !"
            Response.Write(msg)
        End If
    End Sub


    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("abcdrf@gmail.com", "---") ' 
            Smtp_Server.Port = 
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"


            Dim fileTXT As String = "C:\ connextion_details.txt"
            Dim data As Net.Mail.Attachment = New Net.Mail.Attachment(fileTXT)
            data.Name = "connextion_details.txt"
            e_mail = New MailMessage()
            e_mail.From = New MailAddress(TextBox1.Text)
            e_mail.To.Add(TextBox2.Text)
            e_mail.Subject = "Email Sending"
            e_mail.IsBodyHtml = False

            e_mail.Attachments.Add(data)
            Smtp_Server.Send(e_mail)
            MsgBox("Mail Sent")

        Catch error_t As Exception
            MsgBox(error_t.ToString)
        End Try
    End Sub

End Class