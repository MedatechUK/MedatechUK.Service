Imports MedatechUK.Logging

Public MustInherit Class ntService
    Inherits LogableService

#Region "Start argument variables"

    Private Enum eMode
        Switch
        Param
    End Enum

    Private _StartArg As New Dictionary(Of String, String)
    Public ReadOnly Property StartArg() As Dictionary(Of String, String)
        Get
            Return _StartArg
        End Get
    End Property

#End Region

#Region "Start"

    Public Overridable Sub svcStart(ByVal args As Dictionary(Of String, String))

    End Sub

    Protected Overrides Sub OnStart(ByVal args() As String)

        With _StartArg
            If args.Length > 0 Then

                Dim i As Integer = 0
                Dim m As eMode = eMode.Switch
                Dim thisSwitch As String = ""

                Do
                    Select Case args(i).Substring(0, 1)
                        Case "-", "/"
                            .Add(args(i).Substring(1), "")
                            thisSwitch = args(i).Substring(1)
                            m = eMode.Param
                        Case Else
                            Select Case m
                                Case eMode.Param
                                    .Item(thisSwitch) = args(i)
                                    thisSwitch = ""
                                    m = eMode.Switch

                                Case eMode.Switch
                                    .Add(args(i), "")

                            End Select

                    End Select
                    i += 1
                Loop Until i = args.Count

            End If

        End With

        If Not StartArg.Keys.Contains("debug") Then
            svcStart(StartArg)
        End If

    End Sub

#End Region

#Region "Pause"

    Public Overridable Sub svcPause()

    End Sub

    Protected Overrides Sub OnPause()
        svcPause()

    End Sub

#End Region

#Region "Continue"

    Public Overridable Sub svcContinue()

    End Sub

    Protected Overrides Sub OnContinue()
        If StartArg.Keys.Contains("debug") Then
            svcStart(StartArg)
        Else
            svcContinue()
        End If

    End Sub

#End Region

#Region "Stop"

    Public Overridable Sub svcStop()

    End Sub

    Protected Overrides Sub OnStop()
        svcStop()

    End Sub

#End Region

#Region "Logging"

    Public Sub Log(ByVal str As String, ByVal ParamArray arg() As String)
        Me.logHandler.Invoke(Me, New LogArgs(str, arg))

    End Sub

    Public Sub Log(ByVal str)
        Me.logHandler.Invoke(Me, New LogArgs(str, Nothing))

    End Sub

    Private Sub InitializeComponent()
        Me.CanPauseAndContinue = True

    End Sub

#End Region

End Class
