using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils.Animation;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace TransitionManagerSample {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        Control animatedControl;

        private void xtraTabControl1_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e) {
            // Start the state transition when a page is about to be switched.
            if (animatedControl == null) return;
            transitionManager1.StartTransition(animatedControl);
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e) {
            // Finish the transition after a page has been selected.
            transitionManager1.EndTransition();
        }

        private void Form1_Load(object sender, EventArgs e) {
            animatedControl = xtraTabControl1;

            // Populate the ImageComboBox with available transition types.
            imageComboBoxEdit1.Properties.Items.AddEnum(typeof(DevExpress.Utils.Animation.Transitions));
            imageComboBoxEdit1.SelectedIndexChanged += imageComboBoxEdit1_SelectedIndexChanged;
            imageComboBoxEdit1.SelectedIndex = 0;
        }

        BaseTransition CreateTransitionInstance(Transitions transitionType) {
            switch (transitionType) {
                case Transitions.Dissolve: return new DissolveTransition();
                case Transitions.Fade: return new FadeTransition();
                case Transitions.Shape: return new ShapeTransition();
                case Transitions.Clock: return new ClockTransition();
                case Transitions.SlideFade: return new SlideFadeTransition();
                case Transitions.Cover: return new CoverTransition();
                case Transitions.Comb: return new CombTransition();
                default: return new PushTransition();
            }
        }

        void imageComboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e) {
            ImageComboBoxEdit imComboBox = sender as ImageComboBoxEdit;

            if (transitionManager1.Transitions[animatedControl] == null) {
                // Add a transition, associated with the xtraTabControl1, to the TransitionManager.
                Transition transition1 = new Transition();
                transition1.Control = animatedControl;
                transitionManager1.Transitions.Add(transition1);
            }
            // Specify the transition type.
            DevExpress.Utils.Animation.Transitions trType = (DevExpress.Utils.Animation.Transitions)imComboBox.EditValue;
            transitionManager1.Transitions[animatedControl].TransitionType = CreateTransitionInstance(trType);
        }

        // A custom easing function.
        DevExpress.Data.Utils.IEasingFunction myEasingFunc = new DevExpress.Data.Utils.BackEase();

        private void transitionManager1_CustomTransition(DevExpress.Utils.Animation.ITransition transition, DevExpress.Utils.Animation.CustomTransitionEventArgs e) {
            // Set a clip region for the state transition.
            e.Regions = new Rectangle[] { xtraTabPage1.Bounds };
            // Specify a custom easing function.
            e.EasingFunction = myEasingFunc;
        }

        
    }
}
