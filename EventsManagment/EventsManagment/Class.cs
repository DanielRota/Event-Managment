using System;

namespace EventsManagment
{
    public class Example
    {
        public Example(string name)
        {
            this._Name = name;
        }

        // Property that is being changed
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                // Once Name is changed 
                OnNameChange(_Name, value);
                _Name = value;
            }
        }

        // Create new EventHandler Event of <Class that contains both new and old datas>
        public event EventHandler<ChangeNameEventArgs> ChangeName;

        // Method called once there's a change in Example's Name Property
        public void OnNameChange(string oldname, string newname)
        {
            // Contains both OldName and NewName
            var data = new ChangeNameEventArgs(oldname, newname);

            // Executes the specified method on the Thread of the referred instance
            // If the instance'Thread is the same of the one we're on, don't use
            ChangeName?.Invoke(this, data);
        }
    }
    public class ChangeNameEventArgs : EventArgs
    {
        // Class which refers to Data changes
        public ChangeNameEventArgs(string oldname, string newname)
        {
            this.OldName = oldname;
            this.NewName = newname;
        }
        public string OldName { get; set; }
        public string NewName { get; set; }
    }
}