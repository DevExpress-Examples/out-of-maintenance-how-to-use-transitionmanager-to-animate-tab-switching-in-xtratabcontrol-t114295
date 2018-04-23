Imports DevExpress.Utils.Animation
Imports DevExpress.XtraEditors

Public Class Form1

    Dim animatedControl As Control

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        animatedControl = XtraTabControl1

        ' Populate the ImageComboBox with available transition types.
        ImageComboBoxEdit1.Properties.Items.AddEnum(GetType(DevExpress.Utils.Animation.Transitions))
        AddHandler ImageComboBoxEdit1.SelectedIndexChanged, AddressOf ImageComboBoxEdit1_SelectedIndexChanged
        ImageComboBoxEdit1.SelectedIndex = 0
    End Sub

    Private Sub ImageComboBoxEdit1_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim imComboBox As ImageComboBoxEdit = TryCast(sender, ImageComboBoxEdit)

        If TransitionManager1.Transitions(animatedControl) Is Nothing Then
            ' Add a transition, associated with the xtraTabControl1, to the TransitionManager.
            Dim transition1 As New Transition()
            transition1.Control = animatedControl
            TransitionManager1.Transitions.Add(transition1)
        End If
        ' Specify the transition type.
        Dim trType As DevExpress.Utils.Animation.Transitions = DirectCast(imComboBox.EditValue, DevExpress.Utils.Animation.Transitions)
        TransitionManager1.Transitions(animatedControl).TransitionType = CreateTransitionInstance(trType)
    End Sub

    Private Function CreateTransitionInstance(transitionType As Transitions) As BaseTransition
        Select Case transitionType
            Case Transitions.Dissolve
                Return New DissolveTransition()
            Case Transitions.Fade
                Return New FadeTransition()
            Case Transitions.Shape
                Return New ShapeTransition()
            Case Transitions.Clock
                Return New ClockTransition()
            Case Transitions.SlideFade
                Return New SlideFadeTransition()
            Case Transitions.Cover
                Return New CoverTransition()
            Case Transitions.Comb
                Return New CombTransition()
            Case Else
                Return New PushTransition()
        End Select
    End Function

    Private Sub XtraTabControl1_SelectedPageChanging(sender As Object, e As DevExpress.XtraTab.TabPageChangingEventArgs) Handles XtraTabControl1.SelectedPageChanging
        ' Start the state transition when a page is about to be switched.
        If animatedControl Is Nothing Then
            Return
        End If
        TransitionManager1.StartTransition(animatedControl)
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        ' Finish the transition after a page has been selected.
        TransitionManager1.EndTransition()
    End Sub

    ' A custom easing function.
    Dim myEasingFunc As DevExpress.Data.Utils.IEasingFunction = New DevExpress.Data.Utils.BackEase()

    Private Sub TransitionManager1_CustomTransition(transition As DevExpress.Utils.Animation.ITransition, e As DevExpress.Utils.Animation.CustomTransitionEventArgs) Handles TransitionManager1.CustomTransition
        ' Set a clip region for the state transition.
        e.Regions = New Rectangle() {XtraTabPage1.Bounds}
        ' Specify a custom easing function.
        e.EasingFunction = myEasingFunc
    End Sub


End Class
