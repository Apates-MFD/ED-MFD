using EDLibrary.Menu;

namespace EDLibrary.Output
{
    /// <summary>
    /// Single Keybind
    /// <para>Link between <see cref="Actions"/> and a sequence of <see cref="DirectXKeyStrokes"/></para>
    /// </summary>
    public class Keybinding
    {
        public string Action { get; set; }
        public DirectXKeyStrokes[] KeyStrokes { get; set; }
    }
}
