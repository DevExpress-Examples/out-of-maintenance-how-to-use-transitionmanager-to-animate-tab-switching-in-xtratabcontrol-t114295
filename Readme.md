<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/TransitionManagerSample/Form1.cs) (VB: [Form1.vb](./VB/TransitionManagerSample/Form1.vb))
<!-- default file list end -->
# How to: Use TransitionManager to animate tab switching in XtraTabControl


This example contains an XtraTabControl with two tabs. The <a href="https://docs.devexpress.com/WindowsForms/DevExpress.Utils.Animation.TransitionManager">TransitionManager component</a> is used to animate switching between these tabs, using a certain animation effect (specified by the Transition Type combobox). Animated tab switching is initiated in the XtraTabControl.SelectedPageChanging event handler and is finished in the XtraTabControl.SelectedPageChanged event handler.<br /><br />Before the transition starts, it is created in the SelectedIndexChanged event of the combobox control. <br /><br />By default, the entire area occupied by the control is animated by the TransitionManager. In the example, the CustomTransition event is handled to exclude the tab region from animation.

<br/>


