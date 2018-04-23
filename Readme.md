# How to: Use TransitionManager to animate tab switching in XtraTabControl


This example contains an XtraTabControl with two tabs. The TransitionManager component is used to animate switching between these tabs, using a certain animation effect (specified by the Transition Type combobox). Animated tab switching is initiated in the XtraTabControl.SelectedPageChanging event handler and is finished in the XtraTabControl.SelectedPageChanged event handler.<br /><br />Before the transition starts, it is created in the SelectedIndexChanged event of the combobox control. <br /><br />By default, the entire area occupied by the control is animated by the TransitionManager. In the example, the CustomTransition event is handled to exclude the tab region from animation.

<br/>


