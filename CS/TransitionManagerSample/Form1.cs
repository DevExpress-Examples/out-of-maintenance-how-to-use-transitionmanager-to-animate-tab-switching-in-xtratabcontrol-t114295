using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.Utils.Animation;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace TransitionManagerSample {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            // Populate the ImageComboBox with available transition types.
            imageComboBoxEdit1.Properties.Items.AddEnum(typeof(DevExpress.Utils.Animation.Transitions));
            imageComboBoxEdit1.SelectedIndexChanged += imageComboBoxEdit1_SelectedIndexChanged;
            imageComboBoxEdit1.SelectedIndex = 0;

            xtraTabControl1.Transition.AllowTransition = DevExpress.Utils.DefaultBoolean.True;
            xtraTabControl1.Transition.EasingMode = DevExpress.Data.Utils.EasingMode.EaseInOut;
        }

        BaseTransition CreateTransitionInstance(Transitions transitionType) {
            switch(transitionType) {
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
            var edit = sender as ImageComboBoxEdit;
            var trType = (Transitions)edit.EditValue;
            xtraTabControl1.Transition.TransitionType = CreateTransitionInstance(trType);
        }
        void XtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e) {
            Thread.Sleep(500);
        }

    }
}
