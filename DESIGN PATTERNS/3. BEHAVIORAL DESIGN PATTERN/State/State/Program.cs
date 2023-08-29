using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    internal class Program
    {
        interface IEditingMode
        {
            void Edit();
            void Save();
            void Close();
        }

        class EditMode : IEditingMode
        {
            public void Edit()
            {
                Console.WriteLine("In edit mode. Editing document...");
            }

            public void Save()
            {
                Console.WriteLine("Saving document in edit mode.");
            }

            public void Close()
            {
                Console.WriteLine("Closing document in edit mode.");
            }
        }

        class ViewMode : IEditingMode
        {
            public void Edit()
            {
                Console.WriteLine("Switching to edit mode.");
            }

            public void Save()
            {
                Console.WriteLine("Cannot save in view mode.");
            }

            public void Close()
            {
                Console.WriteLine("Closing document in view mode.");
            }
        }

        class DocumentEditor
        {
            private IEditingMode currentMode;

            public DocumentEditor()
            {
                currentMode = new ViewMode();
            }

            public void SetMode(IEditingMode mode)
            {
                currentMode = mode;
            }

            public void Edit()
            {
                currentMode.Edit();
                if (currentMode is ViewMode)
                    SetMode(new EditMode());
            }

            public void Save()
            {
                currentMode.Save();
            }

            public void Close()
            {
                currentMode.Close();
            }
        }


        static void Main(string[] args)
        {
            DocumentEditor editor = new DocumentEditor();

            editor.Edit();
            editor.Save();
            editor.Close();

            Console.WriteLine();

            editor.SetMode(new EditMode());
            editor.Save();
            editor.Edit();
            editor.Close();
        }
    }

}

