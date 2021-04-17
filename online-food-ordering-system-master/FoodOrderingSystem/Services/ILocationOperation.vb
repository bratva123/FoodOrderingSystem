Public Interface ILocationOperation

    Function AddLocation(loc As Location) As Integer
    Function UpdateLocation(loc As Location) As Integer
    Function DeleteLocationById(id As Integer) As Integer
    Function GetLocationById(id As Integer) As Location

End Interface
