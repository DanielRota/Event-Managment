using System.Windows.Forms;

namespace EventsManagment
{
    public partial class Form1 : Form
    {
        public Form1()
        {

        }

        // Refers to the new EventHandler: ChangeNameEventArgs, not EventArgs anymore
        private static void AlertChange(object sender, ChangeNameEventArgs e)
        {
            MessageBox.Show("Event unleashed!\n" + $"OldName: {e.OldName} - NewName: {e.NewName}");
        }

        // When Name gets changed
        private void ChangeName(object sender, System.EventArgs e)
        {
            // Instance Example Class
            var example = new Example("Daniel");

            // Assign things to ChangeName Event
            example.ChangeName += AlertChange;

            // Unleash associated Event (AlertChange) and 
            example.Name = RTXTName.Text;
        }
    }
}