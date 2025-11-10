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




                '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                'MAIN LOOP'
                '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

                '' MOVE TO LINEAR COORDINATES
                'POINT 1
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim FKxyz(3) As Double
                    FKxyz = forwKin()
                    '' x, y, z, W, P, R, speed (mm/sec)
                    moveLin(FKxyz(1), FKxyz(2), FKxyz(3), -90, 0, -90, 200)

                    mobjRobot.RegNumerics(1).Value.RegLong = 3
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                '' MOVE TO LINEAR COORDINATES
                'POINT 2
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim FKxyz(3) As Double
                    FKxyz = forwKin()
                    '' x, y, z, W, P, R, speed (mm/sec)
                    moveLin(FKxyz(1), FKxyz(2), FKxyz(3), -90, 0, -90, 200)
                    mobjRobot.RegNumerics(1).Value.RegLong = 3
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                '' MOVE TO LINEAR COORDINATES
                'POINT 3
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim FKxyz(3) As Double
                    FKxyz = forwKin()
                    '' x, y, z, W, P, R, speed (mm/sec)
                    moveLin(FKxyz(1), FKxyz(2), FKxyz(3), -90, 0, -90, 200)
                    mobjRobot.RegNumerics(1).Value.RegLong = 3
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                '' MOVE TO LINEAR COORDINATES

                'POINT 4
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim FKxyz(3) As Double
                    FKxyz = forwKin()
                    '' x, y, z, W, P, R, speed (mm/sec)
                    moveLin(FKxyz(1), FKxyz(2), FKxyz(3), -90, 0, -90, 200)
                    mobjRobot.RegNumerics(1).Value.RegLong = 3
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                '' MOVE TO LINEAR COORDINATES
                'POINT 5
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim FKxyz(3) As Double
                    FKxyz = forwKin()
                    '' x, y, z, W, P, R, speed (mm/sec)
                    moveLin(FKxyz(1), FKxyz(2), FKxyz(3), -90, 0, -90, 200)
                    mobjRobot.RegNumerics(1).Value.RegLong = 3
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                '' MOVE TO LINEAR COORDINATES
                'POINT 6
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim FKxyz(3) As Double
                    FKxyz = forwKin()
                    '' x, y, z, W, P, R, speed (mm/sec)
                    moveLin(FKxyz(1), FKxyz(2), FKxyz(3), -90, 0, -90, 200)
                    mobjRobot.RegNumerics(1).Value.RegLong = 3
                    mobjRobot.RegNumerics(2).Value.RegLong = 0
                    While mobjRobot.RegNumerics(2).Value.RegLong = 0
                        System.Threading.Thread.Sleep(200)
                    End While
                End If

                '' MOVE TO LINEAR COORDINATES
                'POINT 1
                If mobjRobot.RegNumerics(2).Value.RegLong = 1 Then

                    Dim FKxyz(3) As Double
                    FKxyz = forwKin()
                    '' x, y, z, W, P, R, speed (mm/sec)
                    moveLin(FKxyz(1), FKxyz(2), FKxyz(3), -90, 0, -90, 200)
                    mobjRobot.RegNumerics(1).Value.RegLong = 3
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
                mobjRobot.RegNumerics(1).Value.RegLong = 99
                mobjRobot.RegNumerics(2).Value.RegLong = 0
                System.Threading.Thread.Sleep(2000)

                ''Zero the Register Values before disconnecting!
                zeroRegs()




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

    '' FORWARD KINEMATICS
    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%



    Public Function forwKin(ByVal th1 As Double, ByVal th2 As Double, ByVal th3 As Double, ByVal th4 As Double, ByVal th5 As Double)

        '' Define pi:
        Dim pi As Double
        pi = 22 / 7




        Dim c1, c2, c3, c4, c5, s1, s2, s3, s4, s5 As Double
        c1 = Math.Cos(th1 * pi / 180)
        c2 = Math.Cos(th2 * pi / 180)
        c3 = Math.Cos(th3 * pi / 180)
        c4 = Math.Cos(th4 * pi / 180)
        c5 = Math.Cos(th5 * pi / 180)
        s1 = Math.Sin(th1 * pi / 180)
        s2 = Math.Sin(th2 * pi / 180)
        s3 = Math.Sin(th3 * pi / 180)
        s4 = Math.Sin(th4 * pi / 180)
        s5 = Math.Sin(th5 * pi / 180)


        '' Define x, y, z:
        Dim x, y, z As Double

        x = 260 * c1 * c2 + 78 * c4 * (c1 * c2 * s3 - c1 * c3 * s2) + 78 * s4 * (c1 * c2 * c3 + c1 * s2 * s3) + (2907 * c1 * c2 * c3) / 10 + (2907 * c1 * s2 * s3) / 10
        y = 260 * c2 * s1 + 78 * c4 * (c2 * s1 * s3 - c3 * s1 * s2) + 78 * s4 * (s1 * s2 * s3 + c2 * c3 * s1) + (2907 * s1 * s2 * s3) / 10 + (2907 * c2 * c3 * s1) / 10
        z = (2907 * c2 * s3) / 10 - 260 * s2 - (2907 * c3 * s2) / 10 - 78 * c4 * (c2 * c3 + s2 * s3) + 78 * s4 * (c2 * s3 - c3 * s2)

        Dim outFK(3) As Double
        outFK(1) = x
        outFK(2) = y
        outFK(3) = z

        Return outFK

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
    '' Grip Open FUNCTION
    Private Sub gripOpen()

        mobjRobot.RegNumerics(51).Value.RegLong = 1
        mobjRobot.RegNumerics(52).Value.RegLong = 0

    End Sub


    '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    '' Grip Close FUNCTION
    Private Sub gripClose()

        mobjRobot.RegNumerics(51).Value.RegLong = 0
        mobjRobot.RegNumerics(52).Value.RegLong = 1

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


