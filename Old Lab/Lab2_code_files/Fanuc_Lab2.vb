Option Explicit On
Imports System.Math

Public Class Test_NumReg2
    ' Sample VB.NET program to display R[1] and send a new value
    ' to/from any controller
    '
    ' Declarations
    '

    '   Public Class NumRegTest

    Private mobjRobot As FRRobot.FRCRobot
    Private WithEvents mobjRegs As FRRobot.FRCVars
    Dim Test1 As FRRobot.FRCVars



    ' Handle the Connect/Disconnect button click 
    Private Sub cmdConnect_Click(ByVal sender As Object, _
                                                             ByVal e As System.EventArgs) Handles cmdConnect.Click
        Try

            If cmdConnect.Text = "Connect" Then
                txtHostName.Text = "192.168.0.3"
                txtRegValue.Text = String.Format("Connecting to {0} Please wait.", txtHostName.Text)

                mobjRobot = New FRRobot.FRCRobot
                mobjRobot.Connect(txtHostName.Text) '%% you can write txtHostName.Text into the parantheses to define the ip address every time.
                mobjRegs = mobjRobot.RegNumerics

                ' modified DH angles in degrees
                Dim angleA(5), angleB(5), angleC(5), angleD(5) As Double

                angleA(1) = 
                angleA(2) = 
                angleA(3) = 
                angleA(4) = 
                angleA(5) = 

                angleB(1) = 
                angleB(2) = 
                angleB(3) = 
                angleB(4) = 
                angleB(5) = 

                angleC(1) = 
                angleC(2) = 
                angleC(3) = 
                angleC(4) = 
                angleC(5) = 

                angleD(1) = 
                angleD(2) = 
                angleD(3) = 
                angleD(4) = 
                angleD(5) = 
                '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                'MAIN LOOP'
                '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
               
              

                '' MOVE TO LINEAR COORDINATES
                'POINT A
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angleA)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                ''%%%%%%%%%%%%
                ''Open Gripper
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then
                    mobjRobot.RegNumerics(1).Value.RegLong = 5
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If
                ''%%%%%%%%%%%%

                'POINT B
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angleB)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If


                ''%%%%%%%%%%%%
                ''Close Gripper
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then
                    mobjRobot.RegNumerics(1).Value.RegLong = 6
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If
                ''%%%%%%%%%%%%

                'POINT A
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angleA)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                'POINT C
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angleC)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                'POINT D
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angleD)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                ''%%%%%%%%%%%%
                ''Open Gripper
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then
                    mobjRobot.RegNumerics(1).Value.RegLong = 5
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If
                ''%%%%%%%%%%%%

                'POINT C
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim th(5) As Double
                    th = ModifiedDH2Fanuc(angleC)

                    moveJnt(th(1), th(2), th(3), th(4), th(5), 20)

                    mobjRobot.RegNumerics(1).Value.RegLong = 4
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If


                '' move to Home
                If mobjRobot.RegNumerics(2).value.reglong = 1 Then

                    mobjRobot.RegNumerics(1).value.reglong = 1
                    mobjRobot.RegNumerics(2).value.reglong = 0

                    While mobjRobot.RegNumerics(2).value.reglong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If





                '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                ''End the motion by setting R(1) to 99
                mobjRobot.RegNumerics(1).Value.RegLong = 1
                mobjRobot.RegNumerics(2).Value.RegLong = 0



                System.Threading.Thread.Sleep(2000)

                ''Zero the Register Values before disconnecting!
                'zeroRegs()




            Else    ' must be the user wants to disconnect

                txtRegValue.Text = "Releasing the Robot objects"
                ReleaseObjects()
                txtRegValue.Text = "Not Connected"
            End If

        Catch ex As System.Runtime.InteropServices.COMException
            ' The only time an error is expected is during connect
            MsgBox(String.Format("{0} - {1}", ex.ErrorCode, ex.Message))
            ReleaseObjects()
        Catch ex As Exception
            MsgBox(ex.Message)
            ReleaseObjects()
        End Try

        If mobjRobot IsNot Nothing AndAlso mobjRobot.IsConnected Then
            cmdConnect.Text = "Disconnect"
        Else
            cmdConnect.Text = "Connect"
        End If

    End Sub

    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

    '' DH TO FANUC
    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

    Public Function ModifiedDH2Fanuc(ByVal DH() As Double)




        Dim outFanucAngles(5) As Double
        outFanucAngles(1) = DH(1)
        outFanucAngles(2) = DH(2) + 90
        outFanucAngles(3) = DH(3) - DH(2) - Math.Atan2(20, 290) * 180 / PI
        outFanucAngles(4) = DH(4) - 90 + Math.Atan2(20, 290) * 180 / PI
        outFanucAngles(5) = 90 - DH(5)

        Return outFanucAngles

    End Function

    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

    '' MOTION FUNCTIONS
    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

    '' LINEAR MOTION FUNCTION
    Private Sub moveLin(xLin As Double, yLin As Double, zLin As Double, wLin As Double, pLin As Double, rLin As Double, speedLin As Double)
        '' POINT1
        mobjRobot.RegNumerics(11).Value.RegLong = xLin     '' Point1 x-axis
        mobjRobot.RegNumerics(12).Value.RegLong = yLin     '' Point1 y-axis
        mobjRobot.RegNumerics(13).Value.RegLong = zLin     '' Point1 z-axis
        mobjRobot.RegNumerics(14).Value.RegLong = wLin     '' Point1 w-aangle
        mobjRobot.RegNumerics(15).Value.RegLong = pLin     '' Point1 p-angle
        mobjRobot.RegNumerics(16).Value.RegLong = rLin     '' Point1 r-angle
        '%%%%%%%%
        mobjRobot.RegNumerics(10).Value.RegLong = speedLin

    End Sub


    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    '' JOINT MOTION FUNCTION
    Private Sub moveJnt(theta1 As Double, theta2 As Double, theta3 As Double, theta4 As Double, theta5 As Double, speedJnt As Double)
        '' POINT1
        mobjRobot.RegNumerics(21).Value.RegLong = theta1     '' Point1 x-axis
        mobjRobot.RegNumerics(22).Value.RegLong = theta2     '' Point1 y-axis
        mobjRobot.RegNumerics(23).Value.RegLong = theta3     '' Point1 z-axis
        mobjRobot.RegNumerics(24).Value.RegLong = theta4     '' Point1 w-aangle
        mobjRobot.RegNumerics(25).Value.RegLong = theta5     '' Point1 p-angle
        '%%%%%%%%
        mobjRobot.RegNumerics(20).Value.RegLong = speedJnt

    End Sub


    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    '' Zero the Register Values
    Private Sub zeroRegs()
        Dim counterZR As Integer = 1
        For counterZR = 1 To 200
            mobjRobot.RegNumerics(counterZR).Value.RegLong = 0
        Next counterZR
    End Sub



    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%


    ' Fully releasing COM objects requires waiting for garbage collection
    Private Sub ReleaseObjects()
        mobjRegs = ReleaseObject("mobjRegs", mobjRegs)
        mobjRobot = ReleaseObject("mobjRobot", mobjRobot)
        System.GC.Collect()
    End Sub

    ' Wrap object release in Try-Catch for enhanced diagnostics
    Private Function ReleaseObject(ByVal identifier As String, ByRef item As Object) As Object
        Try
            item = Nothing
        Catch ex As Exception
            System.Diagnostics.Trace.WriteLine(String.Format("Error releasing {0}.{1}Error: {2}", identifier, Environment.NewLine, ex.Message))
        End Try

        Return Nothing
    End Function



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '
        mobjRobot.RegNumerics(1).Value.RegLong = txtRegValue.Text
    End Sub
End Class


