Imports MedatechUK.ntService

Public Class Class1 : Inherits MedatechUK.ntService

    Public Overrides Sub svcStart(args As Dictionary(Of String, String))
        MyBase.svcStart(args)
        Log()
    End Sub

End Class
