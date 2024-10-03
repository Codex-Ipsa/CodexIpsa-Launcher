using MCLauncher.controls;
using System.Windows.Forms;

namespace MCLauncher.forms
{
    public partial class NewInstance : Form
    {
        public NewInstance()
        {
            InitializeComponent();

            //disable resize
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            InstanceGui instanceGui = new InstanceGui(this, false);
            this.Controls.Add(instanceGui);

            //fill in default stuff
            instanceGui.playTime = 0;

            instanceGui.nameBox.Text = "New profile";
            instanceGui.ramMinBox.Value = 512;
            instanceGui.ramMaxBox.Value = 512;
            instanceGui.resXBox.Text = "854";
            instanceGui.resYBox.Text = "480";
            instanceGui.javaBox.Enabled = false;
            instanceGui.javaBtn.Enabled = false;
            instanceGui.jsonBox.Enabled = false;
            instanceGui.jsonBtn.Enabled = false;
            instanceGui.classBox.Enabled = false;
            instanceGui.assetIndexBox.Enabled = false;
            instanceGui.assetIndexBtn.Enabled = false;
            instanceGui.serverIPBox.Enabled = false;

            //set init to true so version list can be loaded
            instanceGui.initialized = true;

            //load lists
            instanceGui.loadJavaList();
            instanceGui.loadEduList();
            instanceGui.loadXboxList();

            //select in list
            instanceGui.selectInList(instanceGui.vanillaList, "b1.7.3");
        }
    }
}
