Public Class $projectname$ : Inherits MedatechUK.ntService

#Region "Service Events"

    ''' <summary>
    ''' Overrides the service start event *unless* -debug mode.
    ''' In debug mode this function is called by the continue event.
    ''' This allows you to start the service, but still be able to 
    ''' debug the service start event.
    ''' </summary>
    ''' <param name="args">The command line parameters passed to the service startup</param>
    Public Overrides Sub svcStart(args As Dictionary(Of String, String))
        Try
            Log("Service Starting")

        Catch ex As Exception

        End Try

    End Sub

    ''' <summary>
    ''' Overrides the service continue event.
    ''' In debug mode the service start is called instead.
    ''' </summary>
    Public Overrides Sub svcContinue()
        Try
            Log("Service Continuing")

        Catch ex As Exception

        End Try

    End Sub

    ''' <summary>
    ''' Overrides the service pause event.
    ''' </summary>
    Public Overrides Sub svcPause()
        Try
            Log("Service Paused")

        Catch ex As Exception

        End Try

    End Sub

    ''' <summary>
    ''' Overrides the service stop event.
    ''' Add any required tear down here.
    ''' </summary>
    Public Overrides Sub svcStop()
        Try
            Log("Service Stopping")

        Catch ex As Exception

        End Try

    End Sub

#End Region

End Class
