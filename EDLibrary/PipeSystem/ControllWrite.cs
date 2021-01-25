using EDLibrary.Menu;
using EDLibrary.Output;
using System;
using System.Collections.Generic;

namespace EDLibrary.PipeSystem
{
    /// <summary>
    /// Converts given action into keystrokes
    /// </summary>
    class ControllWrite : PipeWrite
    {
        private static List<Keybinding> keybindings = null;
        private string pathToKeybindins;

        /// <summary>
        /// Sets path to keybindings
        /// </summary>
        /// <param name="PathToKeybindins"></param>
        public ControllWrite(string PathToKeybindins)
        {
            pathToKeybindins = PathToKeybindins;
        }
        /// <summary>
        /// <seealso cref="ControllWrite"/>
        /// </summary>
        /// <param name="data"></param>
        /// 
        public override void Write(object input)
        {
            object[] data = (object[])input;
            if (!data[0].GetType().Equals(typeof(string))) throw new ArgumentException("Argument needs to be a string");
            if (!data[1].GetType().Equals(typeof(bool))) throw new ArgumentException("Argument needs to be a bool");

            if (keybindings == null) keybindings = KeybindingParser.Parse(pathToKeybindins);
            Keybinding binding = keybindings.Find(e => e.Action.Equals(data[0]));

            if (binding == null) throw new Exception("Action not bound to key");

            if ((bool)data[1])
            {
                Keyboard.press(binding.KeyStrokes);
            }
            else
            {
                Keyboard.release(binding.KeyStrokes);
            }         
        }
    }
}
