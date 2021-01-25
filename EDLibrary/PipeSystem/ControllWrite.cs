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
        public override void Write(object data)
        {
            if (!data.GetType().Equals(typeof(string))) throw new ArgumentException("Argument needs to be a string");

            if (keybindings == null) keybindings = KeybindingParser.Parse(pathToKeybindins);
            Keybinding binding = keybindings.Find(e => e.Action.Equals(data));

            if (binding == null) throw new Exception("Action not bound to key");

            Keyboard.exec(binding.KeyStrokes);
        }
    }
}
